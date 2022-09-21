using System.Configuration;

namespace Anbima.Infra.Data.Files.Util
{  
        public static class ConfigurationsPath
        {
            public static string appSettingsValue(string key)
            {
                return ConfigurationSettings.AppSettings[key];
            }
        }
   
}
