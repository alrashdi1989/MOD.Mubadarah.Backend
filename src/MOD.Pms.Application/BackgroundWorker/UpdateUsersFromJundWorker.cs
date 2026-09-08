using Hangfire;
using Microsoft.Extensions.Logging;
using MOD.Pms.ExternalApiEntites.Jund;
using MOD.Pms.Repositories;
using MOD.Pms.UserReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account;
using Volo.Abp.BackgroundWorkers.Hangfire;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using Volo.Abp.SettingManagement;
using Volo.Abp.BlobStoring;
using Volo.Abp.Application.Services;
using MOD.Pms.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MOD.Pms.BackgroundWorker
{
    public interface IUpdateUsersFromJundWorker : IHangfireBackgroundWorker
    {

    }
    [ExposeServices(typeof(IUpdateUsersFromJundWorker))]
    public class UpdateUsersFromJundWorker : HangfireBackgroundWorkerBase, IUpdateUsersFromJundWorker
    {

        private readonly IPmsIdentityUserRepository _pmsIdentityUserRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IdentityUserManager _identityUserManager;
        private readonly IDataFilter _dataFilter;
        private readonly UnitOfWorkManager _unitOfWorkManager;
        private readonly IJundClient _jundClient;
        private readonly ISettingManager _settingManager;
        private readonly IDbContextProvider<PmsDbContext> _dbContextProvider;
        protected IBlobContainer<AccountProfilePictureContainer> _accountProfilePictureContainer { get; }
        private readonly ICurrentTenant _currentTenant;

        public UpdateUsersFromJundWorker(IIdentityUserRepository identityUserRepository, IDataFilter dataFilter, UnitOfWorkManager unitOfWorkManager, IJundClient jundClient, ISettingManager settingManager, IBlobContainer<AccountProfilePictureContainer> accountProfilePictureContainer, IDbContextProvider<PmsDbContext> dbContextProvider, IdentityUserManager identityUserManager, IPmsIdentityUserRepository pmsIdentityUserRepository, ICurrentTenant currentTenant)
        {
            CronExpression = Cron.Daily(20, 0);
            RecurringJobId = nameof(UpdateUsersFromJundWorker);


            _identityUserRepository = identityUserRepository;

            _dataFilter = dataFilter;
            _unitOfWorkManager = unitOfWorkManager;
            _jundClient = jundClient;
            _settingManager = settingManager;
            _accountProfilePictureContainer = accountProfilePictureContainer;
            _dbContextProvider = dbContextProvider;
            _identityUserManager = identityUserManager;
            _pmsIdentityUserRepository = pmsIdentityUserRepository;
            _currentTenant = currentTenant;
        }

        [UnitOfWork]
        public override async Task DoWorkAsync(CancellationToken cancellationToken = default)
        {


            using (_dataFilter.Disable<IMultiTenant>())
            {
                var users = (await _identityUserRepository.GetListAsync()).Where(x => x.UserName != "admin");

                foreach (var user in users)
                {
                    using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: false))
                    {
                        try
                        {

                            var employee = await _jundClient.GetEmployeeAsync(user.UserName);
                            user.SetProperty("ServiceNumber", employee.ServiceNumber.ToString() ?? null );
                        user.SetProperty("RankOrder", employee.RankOrder.ToString() ?? null)       ;
                        user.SetProperty("RankEnglish", employee.RankEnlgish.ToString() == null ? "not set" : employee.RankEnlgish);
                        user.SetProperty("RankArabic", employee.RankArabic.ToString() == null ? "غير محدد" : employee.RankArabic);
                        user.SetProperty("ArabicName", employee.EmpNameAr.ToString() ?? null);
                        user.SetProperty("EnglishName", employee.EmpNameEn.ToString() ?? null);
                        user.SetProperty("MainUnitArabic", employee.MainUnitAr == null? "غير محدد" :  employee.MainUnitAr);
                        user.SetProperty("MainUnitEnglish", employee.MainUnitEn == null ? "not set" : employee.MainUnitEn);
                        user.SetProperty("PositionUnitId", employee.PositionUnitId == null ? null : employee.PositionUnitId.ToString());
                            user.SetProperty("PositionEnglish", employee.PositionEn == null ? "no position" : employee.PositionEn);
                            user.SetProperty("PositionArabic", employee.PositionAr == null ? "لا يوجد منصب" : employee.PositionAr);



                            user.Surname = employee.LastNameAr;
                            user.Name = employee.FirstNameAr;
                            user.SetPhoneNumber(employee.Mobile ?? null, true);
                            //update user image
                            var tenentid = employee.TenantId;


                      
                            await _identityUserRepository.UpdateAsync(user, true);



                            if (user.TenantId != employee.TenantId)
                            {
                                await _pmsIdentityUserRepository.DeleteUserRolesProcedure(user.Id);

                                await _pmsIdentityUserRepository.UpdateUserTenantProcedure(user.Id, employee.TenantId.Value);


                            }


                            using (_currentTenant.Change(employee.TenantId))
                            {

                                byte[] imageByteArray = employee.Photo;

                                await _settingManager.SetForUserAsync(user.Id, AccountSettingNames.ProfilePictureSource, Enum.GetName(typeof(ProfilePictureType), ProfilePictureType.Image));

                                string userIdText = user.Id.ToString();
                                await _accountProfilePictureContainer.SaveAsync(userIdText, imageByteArray, true);


                            }

                        }
                        catch (Exception ex) { 
                        Console.WriteLine(user);
                        }
          


                      

                        await uow.SaveChangesAsync();
                        await uow.CompleteAsync();


                    }
                }
            }
        }



    }
}
