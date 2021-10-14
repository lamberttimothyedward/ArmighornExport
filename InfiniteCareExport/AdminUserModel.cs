using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSubAccount
{

    public class AdminUserRootObject
    {
        public AdminUserMeta meta { get; set; }
        public Admin_Users[] admin_users { get; set; }
    }

    public class AdminUserMeta
    {
    }

    public class Admin_Users
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
