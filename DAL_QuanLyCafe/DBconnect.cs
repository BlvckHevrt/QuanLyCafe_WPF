using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL_QuanLyCafe
{
    public class DBconnect
    {
        protected string _conn = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
    }
}
