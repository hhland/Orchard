using DbLinq.Data.Linq;
using DbLinq.MySql;
using DbLinq.PostgreSql;
using DbLinq.SqlServer;
using MySql.Data.MySqlClient;
using Orchard.Environment.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Data.Linq
{
    public class DataContextFactory
    {

        public static ShellSettings settings { get; set; }


        

        public static DataContext createDataContext(string name) {
            DataContext dc = null;
            string constr = settings.DataConnectionString;
            switch (settings.DataProvider) {
               case "sqlserver": { dc = new SqlServerDataContext(constr);break; }
                case "mysql": { dc = new MySqlDataContext(new MySqlConnection(constr)); break; }
                // case "post": { dc = new PgsqlDataContext(constr); break; }
                default: break;
            };
            
            return dc;
        }

        public static DataContext createDefaultDataContext() {
            return createDataContext("default");
        }

    }
}
