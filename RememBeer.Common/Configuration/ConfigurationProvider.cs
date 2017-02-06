using System;
using System.Configuration;

using RememBeer.Common.Exceptions;

namespace RememBeer.Common.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public bool UserNamesAllowOnlyAlphanumeric
        {
            get
            {
                try
                {
                    return bool.Parse(ConfigurationManager.AppSettings["UserNamesAllowOnlyAlphanumeric"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("UserNamesAllowOnlyAlphanumeric");
                }
            }
        }

        public bool RequireUniqueEmail
        {
            get
            {
                try
                {
                    return bool.Parse(ConfigurationManager.AppSettings["RequireUniqueEmail"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("RequireUniqueEmail");
                }
            }
        }

        public int PasswordMinLength
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["PasswordMinLength"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("PasswordMinLength");
                }
            }
        }

        public bool PasswordRequireNonLetterOrDigit
        {
            get
            {
                try
                {
                    return bool.Parse(ConfigurationManager.AppSettings["PasswordRequireNonLetterOrDigit"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("PasswordRequireNonLetterOrDigit");
                }
            }
        }

        public bool PasswordRequireDigit
        {
            get
            {
                try
                {
                    return bool.Parse(ConfigurationManager.AppSettings["PasswordRequireDigit"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("PasswordRequireDigit");
                }
            }
        }

        public bool PasswordRequireLowercase
        {
            get
            {
                try
                {
                    return bool.Parse(ConfigurationManager.AppSettings["PasswordRequireLowercase"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("PasswordRequireLowercase");
                }
            }
        }

        public bool PasswordRequireUppercase
        {
            get
            {
                try
                {
                    return bool.Parse(ConfigurationManager.AppSettings["PasswordRequireUppercase"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("PasswordRequireUppercase");
                }
            }
        }

        public bool UserLockoutEnabledByDefault
        {
            get
            {
                try
                {
                    return bool.Parse(ConfigurationManager.AppSettings["UserLockoutEnabledByDefault"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("UserLockoutEnabledByDefault");
                }
            }
        }

        public int DefaultAccountLockoutTimeSpan
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["DefaultAccountLockoutTimeSpan"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("DefaultAccountLockoutTimeSpan");
                }
            }
        }

        public int MaxFailedAccessAttemptsBeforeLockout
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["MaxFailedAccessAttemptsBeforeLockout"]);
                }
                catch (FormatException)
                {
                    throw new InvalidConfigurationOptionException("MaxFailedAccessAttemptsBeforeLockout");
                }
            }
        }
    }
}
