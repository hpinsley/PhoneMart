using System;
using System.Configuration;
using Angular.Nag.Common.Interfaces;

namespace Angular.Nag.Common.Implementations {
    public class Settings : ISettings {
        public bool InitializeDatabase {
            get {
                string init = GetMandatoryStringSetting("InitDb");
                return init.ToLower() == "yes";
            }
        }

        public string ConnectionString { 
            get { return GetMandatoryConnectionString("phones"); }
        }

        private string GetMandatoryStringSetting(string key) {
            string val = ConfigurationManager.AppSettings[key];
            if (val == null)
                throw new Exception(string.Format("Missing mandatory string settings '{0}'", key));
            return val;
        }

        private string GetMandatoryConnectionString(string key) {
            var connection = ConfigurationManager.ConnectionStrings[key];
            if (connection != null) {
                return connection.ConnectionString;
            }
            throw new Exception(string.Format("Unable to location connection string '{0}'", key));
        }
    }
}