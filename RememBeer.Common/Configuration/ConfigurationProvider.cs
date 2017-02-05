using System.Configuration;

namespace RememBeer.Common.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public bool UserNamesAllowOnlyAlphanumeric => bool.Parse(ConfigurationManager.AppSettings["UserNamesAllowOnlyAlphanumeric"]);

        public bool RequireUniqueEmail => bool.Parse(ConfigurationManager.AppSettings["RequireUniqueEmail"]);

        public int PasswordMinLength => int.Parse(ConfigurationManager.AppSettings["PasswordMinLength"]);

        public bool PasswordRequireNonLetterOrDigit => bool.Parse(ConfigurationManager.AppSettings["PasswordRequireNonLetterOrDigit"]);

        public bool PasswordRequireDigit => bool.Parse(ConfigurationManager.AppSettings["PasswordRequireDigit"]);

        public bool PasswordRequireLowercase => bool.Parse(ConfigurationManager.AppSettings["PasswordRequireLowercase"]);

        public bool PasswordRequireUppercase => bool.Parse(ConfigurationManager.AppSettings["PasswordRequireUppercase"]);

        public bool UserLockoutEnabledByDefault => bool.Parse(ConfigurationManager.AppSettings["UserLockoutEnabledByDefault"]);

        public int DefaultAccountLockoutTimeSpan => int.Parse(ConfigurationManager.AppSettings["DefaultAccountLockoutTimeSpan"]);

        public int MaxFailedAccessAttemptsBeforeLockout => int.Parse(ConfigurationManager.AppSettings["MaxFailedAccessAttemptsBeforeLockout"]);
    }
}
