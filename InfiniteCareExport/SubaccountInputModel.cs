using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSubAccount
{

    public class SAIMRootobject
    {
        public Sub_Account sub_account { get; set; }
    }

    public class Sub_Account
    {
        public string locale { get; set; }
        public string subdomain { get; set; }
        public string name { get; set; }
        public string contact_name { get; set; }
        public string contact_phone { get; set; }
        public string contact_email { get; set; }
        public string time_zone { get; set; }
    }

}
