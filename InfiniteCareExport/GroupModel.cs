using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSubAccount
{
    public class GroupRootObject
    {
        public GroupMeta meta { get; set; }
        public Group[] groups { get; set; }
    }

    public class GroupMeta
    {
    }

    public class Group
    {
        public string id { get; set; }
        public string parent_id { get; set; }
        public string domain_id { get; set; }
        public string external_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int users_count { get; set; }
        public object archived_at { get; set; }
        public object registered_count { get; set; }
        public int? messageable_count { get; set; }
        public bool new_smart_group { get; set; }
        public GroupLinks links { get; set; }
    }

    public class GroupLinks
    {
    }
}
