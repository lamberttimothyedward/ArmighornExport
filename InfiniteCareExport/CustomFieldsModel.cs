using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteCareExport
{

    public class CustomFieldsRootobject
    {
        public CFMeta meta { get; set; }
        public CFLinked linked { get; set; }
        public CFUser[] users { get; set; }
    }

    public class CFMeta
    {
    }

    public class CFLinked
    {
        public Custom_Fields[] custom_fields { get; set; }
        public Custom_Field_Values[] custom_field_values { get; set; }
    }

    public class Custom_Fields
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Custom_Field_Values
    {
        public string id { get; set; }
        public string value { get; set; }
        public CFLinks links { get; set; }
    }

    public class CFLinks
    {
        public Custom_Field custom_field { get; set; }
    }

    public class Custom_Field
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class CFUser
    {
        public string id { get; set; }
        public string uid { get; set; }
        public object hris_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string sortable_name { get; set; }
        public string email { get; set; }
        public string locale { get; set; }
        public string[] roles { get; set; }
        public string name { get; set; }
        public object avatar_url { get; set; }
        public DateTime updated_at { get; set; }
        public object deleted_at { get; set; }
        public object unsubscribed { get; set; }
        public string welcomedAt { get; set; }
        public string loggedInAt { get; set; }
        public bool passwordIsSet { get; set; }
        public object hire_date { get; set; }
        public bool is_manager { get; set; }
        public string job_title { get; set; }
        public object bio { get; set; }
        public object department { get; set; }
        public object anonymized { get; set; }
        public int domain_id { get; set; }
        public object birth_month { get; set; }
        public object birth_day_of_month { get; set; }
        public object location { get; set; }
        public object preferred_phone { get; set; }
        public string welcomeUrl { get; set; }
        public string passwordUrl { get; set; }
        public Links1 links { get; set; }
        public Meta1 meta { get; set; }
    }

    public class Links1
    {
        public string[] custom_field_values { get; set; }
    }

    public class Meta1
    {
        public bool can_masquerade { get; set; }
    }

}
