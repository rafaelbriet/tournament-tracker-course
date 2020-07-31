using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection;

        public static void InitializeConnections(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.Sql:
                    Connection = new SqlConnection();
                    break;
                case ConnectionType.TextFile:
                    Connection = new TextConnection();
                    break;
                default:
                    break;
            }
        }

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
