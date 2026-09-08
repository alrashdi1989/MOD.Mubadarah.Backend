using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Emailing;
using Volo.Abp.Settings;

namespace MOD.Pms.Settings
{
    public class SettingService : ApplicationService
    {
        private readonly ISettingEncryptionService _encryptionService;
        private readonly ISettingDefinitionManager _definitionManager;

        public SettingService(ISettingEncryptionService encryptionService, ISettingDefinitionManager definitionManager)
        {
            _encryptionService = encryptionService;
            _definitionManager = definitionManager;
        }
        public async Task<string> EncryptMailingSmtpPassword(string password)
        {
            var setting =await _definitionManager.GetAsync(EmailSettingNames.Smtp.Password);
 
             var encryptPassword=_encryptionService.Encrypt(setting, password);

            return encryptPassword;
        }

    }
}
