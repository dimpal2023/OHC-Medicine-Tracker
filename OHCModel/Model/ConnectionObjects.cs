using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCModel.Model
{
    public abstract class ConnectionObjects
    {
        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["OHC"].ConnectionString;
            }
        }
        public static string masterConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["masterdb"].ConnectionString;
            }
        }
        public static string WorkersConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["workerdb"].ConnectionString;
            }
        }
    }
}
