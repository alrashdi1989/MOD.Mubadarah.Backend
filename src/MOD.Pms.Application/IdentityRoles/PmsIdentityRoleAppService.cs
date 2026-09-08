using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace MOD.Pms.IdentityUsers
{
    [Authorize]
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IPmsIdentityRoleAppService), typeof(IdentityRoleAppService), typeof(PmsIdentityRoleAppService))]
    public class PmsIdentityRoleAppService : IdentityRoleAppService, IPmsIdentityRoleAppService, ITransientDependency
    {
        private readonly IRepository<IdentityRole, Guid> _identityRoleRepository;
        private readonly IIdentityUserRepository _identityUserRepository;



        public PmsIdentityRoleAppService(IdentityRoleManager roleManager, IIdentityRoleRepository roleRepository, IIdentityUserRepository identityUserRepository,  IIdentityClaimTypeRepository identityClaimTypeRepository, IIdentityUserRepository userRepository, IdentityUserManager userManager, IRepository<IdentityRole, Guid> identityRoleRepository) : base(roleManager, roleRepository, identityClaimTypeRepository, userRepository, userManager)
        {
         _identityRoleRepository = identityRoleRepository;
            _identityUserRepository = identityUserRepository;

        }


        
        [AllowAnonymous]
        public override async Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
        {
            var  roles = (await _identityRoleRepository.GetQueryableAsync()).Where(c => c.Name != "Admin");
            List<IdentityRoleDto> result = ObjectMapper.Map<List<Volo.Abp.Identity.IdentityRole>, List<IdentityRoleDto>>(roles.ToList());
            return new ListResultDto<IdentityRoleDto>(result);
        }

        [AllowAnonymous]
        public async Task<List<IdentityUser>> GetAllMubaadaraUsersAsync()
        {
            var role = await RoleManager.FindByNameAsync("خطة العمل السنوية - خلية إدارة المنظومة");
            List<Guid> userIdList = await UserRepository.GetUserIdListByRoleIdAsync(role.Id).ConfigureAwait(continueOnCapturedContext: false);
            var userDtoList = await _identityUserRepository.GetListByIdsAsync(userIdList).ConfigureAwait(continueOnCapturedContext: false);
            return userDtoList;
        }






    }
}
