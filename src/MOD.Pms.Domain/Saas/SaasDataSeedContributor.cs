using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;

namespace MOD.Pms.Saas;

public class SaasDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IEditionDataSeeder _editionDataSeeder;
    private readonly ITenantManager _tenantManager;
    private readonly IEditionRepository _editionRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    private readonly ICurrentTenant _currentTenant;
    protected IDataSeeder DataSeeder { get; }

    public SaasDataSeedContributor(IEditionDataSeeder editionDataSeeder,
     ITenantManager tenantManager,
     IEditionRepository editionRepository,
     ITenantRepository tenantRepository,
     IDataSeeder dataSeeder,
     IUnitOfWorkManager unitOfWorkManager,
     ICurrentTenant currentTenant)
    {
        _editionDataSeeder = editionDataSeeder;
        _tenantManager = tenantManager;
        _editionRepository = editionRepository;
        _tenantRepository = tenantRepository;
        DataSeeder = dataSeeder;
        _unitOfWorkManager = unitOfWorkManager;
        _currentTenant = currentTenant;
    }

    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        if (context.TenantId != null)
        {
            return;

        }

        await _editionDataSeeder.CreateStandardEditionsAsync();

        await _unitOfWorkManager.Current.SaveChangesAsync();


        var standardEdition = (await _editionRepository.GetListAsync()).FirstOrDefault(ed => ed.DisplayName == "Standard");

        if (standardEdition != null)
        {

            var mod = await _tenantRepository.FindByNameAsync("MOD", false);

            if (mod == null)
            {
                mod = await _tenantManager.CreateAsync("MOD", standardEdition.Id);
                mod.SetProperty("EnglishName", "Ministery For Defence");
                mod.SetProperty("ArabicName", "وزارة الدفاع");

                await _tenantRepository.InsertAsync(mod, true);

                using (_currentTenant.Change(mod.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(mod.Id)
                            .WithProperty("AdminEmail", "odpmda.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }




            var cossafTenant = await _tenantRepository.FindByNameAsync("COSSAF", false);

            if (cossafTenant == null)
            {
                cossafTenant = await _tenantManager.CreateAsync("COSSAF", standardEdition.Id);
                cossafTenant.SetProperty("EnglishName", "Chief of Staff of the Armed Forces");
                cossafTenant.SetProperty("ArabicName", "رئاسة قوات السلطان المسلحة");

                cossafTenant = await _tenantRepository.InsertAsync(cossafTenant, true);

                using (_currentTenant.Change(cossafTenant.Id))
                {
                    await DataSeeder.SeedAsync(new DataSeedContext(cossafTenant.Id)
                        .WithProperty("AdminEmail", "cossaf.jund@mod.saf")
                        .WithProperty("AdminPassword", "1q2w3E*"));
                }
            }


            var raoTenant = await _tenantRepository.FindByNameAsync("RAO", false);

            if (raoTenant == null)
            {
                raoTenant = await _tenantManager.CreateAsync("RAO", standardEdition.Id);
                raoTenant.SetProperty("EnglishName", "Royal Army of Oman");
                raoTenant.SetProperty("ArabicName", "الجيش السلطاني العماني");

                await _tenantRepository.InsertAsync(raoTenant, true);

                using (_currentTenant.Change(raoTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(raoTenant.Id)
                            .WithProperty("AdminEmail", "rao.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }


            var rafoTenant = await _tenantRepository.FindByNameAsync("RAFO", false);

            if (rafoTenant == null)
            {
                rafoTenant = await _tenantManager.CreateAsync("RAFO", standardEdition.Id);
                rafoTenant.SetProperty("EnglishName", "Royal Air Forec of Oman");
                rafoTenant.SetProperty("ArabicName", "سلاح الجو السلطاني العماني");

                await _tenantRepository.InsertAsync(rafoTenant, true);

                using (_currentTenant.Change(rafoTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(rafoTenant.Id)
                            .WithProperty("AdminEmail", "rafo.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }

            var rnoTenant = await _tenantRepository.FindByNameAsync("RNO", false);

            if (rnoTenant == null)
            {
                rnoTenant = await _tenantManager.CreateAsync("RNO", standardEdition.Id);
                rnoTenant.SetProperty("EnglishName", "Royal Navy Of Oman");
                rnoTenant.SetProperty("ArabicName", "البحرية السلطانية العمانية");

                await _tenantRepository.InsertAsync(rnoTenant, true);

                using (_currentTenant.Change(rnoTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(rnoTenant.Id)
                            .WithProperty("AdminEmail", "rno.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }


            var ndcTenant = await _tenantRepository.FindByNameAsync("NDC", false);

            if (ndcTenant == null)
            {
                ndcTenant = await _tenantManager.CreateAsync("NDC", standardEdition.Id);
                ndcTenant.SetProperty("EnglishName", "National Defence College");
                ndcTenant.SetProperty("ArabicName", "كلية الدفاع الوطني");

                await _tenantRepository.InsertAsync(ndcTenant, true);

                using (_currentTenant.Change(ndcTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(ndcTenant.Id)
                            .WithProperty("AdminEmail", "ndc.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }

            var modesTenant = await _tenantRepository.FindByNameAsync("MODES", false);

            if (modesTenant == null)
            {
                modesTenant = await _tenantManager.CreateAsync("MODES", standardEdition.Id);
                modesTenant.SetProperty("EnglishName", "MINISTRY OF DEFENCE ENGINEERING SERVICES");
                modesTenant.SetProperty("ArabicName", "الخدمات الهندسية بوزارة الدفاع");

                await _tenantRepository.InsertAsync(modesTenant, true);

                using (_currentTenant.Change(modesTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(modesTenant.Id)
                            .WithProperty("AdminEmail", "modes.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }


            var nsaTenant = await _tenantRepository.FindByNameAsync("NSA", false);

            if (nsaTenant == null)
            {
                nsaTenant = await _tenantManager.CreateAsync("NSA", standardEdition.Id);
                nsaTenant.SetProperty("EnglishName", "National Survey Authority");
                nsaTenant.SetProperty("ArabicName", "الهيئة الوطنية للمساحة");

                await _tenantRepository.InsertAsync(nsaTenant, true);

                using (_currentTenant.Change(nsaTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(nsaTenant.Id)
                            .WithProperty("AdminEmail", "nsa.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }


            var mtcTenant = await _tenantRepository.FindByNameAsync("MTC", false);

            if (mtcTenant == null)
            {
                mtcTenant = await _tenantManager.CreateAsync("MTC", standardEdition.Id);
                mtcTenant.SetProperty("EnglishName", "Military Technical College");
                mtcTenant.SetProperty("ArabicName", "الكلية التقنية العسكرية");

                await _tenantRepository.InsertAsync(mtcTenant, true);

                using (_currentTenant.Change(mtcTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(mtcTenant.Id)
                            .WithProperty("AdminEmail", "mtc.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }


            // ADCS

            var ASDSTenant = await _tenantRepository.FindByNameAsync("ASDS", false);

            if (ASDSTenant == null)
            {
                ASDSTenant = await _tenantManager.CreateAsync("ASDS", standardEdition.Id);
                ASDSTenant.SetProperty("EnglishName", "Strategic and Defence Studies Academy");
                ASDSTenant.SetProperty("ArabicName", "أكاديمية الدراسات الإستراتيجبة والدفاعية");

                await _tenantRepository.InsertAsync(ASDSTenant, true);

                using (_currentTenant.Change(ASDSTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(ASDSTenant.Id)
                            .WithProperty("AdminEmail", "asds.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }

            // MSC


            var MSCTenant = await _tenantRepository.FindByNameAsync("MSC", false);

            if (MSCTenant == null)
            {
                MSCTenant = await _tenantManager.CreateAsync("MSC", standardEdition.Id);
                MSCTenant.SetProperty("EnglishName", "Maritime Security Center");
                MSCTenant.SetProperty("ArabicName", "مركز الأمن البحري");

                await _tenantRepository.InsertAsync(MSCTenant, true);

                using (_currentTenant.Change(MSCTenant.Id))
                {
                    await DataSeeder.SeedAsync(
                        new DataSeedContext(MSCTenant.Id)
                            .WithProperty("AdminEmail", "msc.jund@mod.saf")
                            .WithProperty("AdminPassword", "1q2w3E*")
                    );
                }
            }

        }
    }

}
