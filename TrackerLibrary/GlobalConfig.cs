using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections = new List<IDataConnection>();

        public static void InitializeConnections(bool useSql, bool useTextFile)
        {
            if (useSql)
            {
                SqlConnection sql = new SqlConnection();
                Connections.Add(sql);
            }

            if (useTextFile)
            {
                FileConnection file = new FileConnection();
                Connections.Add(file);
            }
        }
    }
}
