using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSubAccount
{
    public class RootObjectSubaccount
    {
        public MetaSubaccount meta { get; set; }
        public Sub_Accounts[] sub_accounts { get; set; }
    }

    public class MetaSubaccount
    {
    }

    public class Sub_Accounts
    {
        public string id { get; set; }
        public string administrators { get; set; }
        public bool branding_enabled { get; set; }
        public string contact_email { get; set; }
        public string contact_name { get; set; }
        public object contact_phone { get; set; }
        public bool limited_authoring { get; set; }
        public bool bridge_retain { get; set; }
        public string locale { get; set; }
        public string name { get; set; }
        public string subdomain { get; set; }
        public string time_zone { get; set; }
        public bool notifications { get; set; }
        public bool chat_notifications { get; set; }
        public string from_label { get; set; }
        public string reply_to { get; set; }
        public string support_level { get; set; }
        public string sub_account_support_level { get; set; }
        public bool show_custom_support_info { get; set; }
        public string support_name { get; set; }
        public string support_phone { get; set; }
        public object support_email { get; set; }
        public object customer_provided_support_help_articles_url { get; set; }
        public object customer_provided_support_chat_url { get; set; }
        public bool use_custom_support { get; set; }
        public string custom_support_chat_url { get; set; }
        public string custom_support_ticket_url { get; set; }
        public string custom_support_phone_number { get; set; }
        public string custom_support_help_articles_url { get; set; }
        public ProductSubaccount[] products { get; set; }
        public DateTime? created_at { get; set; }
        public bool is_active { get; set; }
        public int? course_count { get; set; }
        public int? user_count { get; set; }
        public bool import_passwords { get; set; }
        public string tac_type { get; set; }
        public object tac_custom_body { get; set; }
        public object lynda_org_id { get; set; }
        public bool auto_csv { get; set; }
        public bool password_reset_allowed { get; set; }
        public object password_minimum_length { get; set; }
        public bool password_requires_numbers { get; set; }
        public bool password_requires_symbols { get; set; }
        public bool password_requires_uppercase { get; set; }
        public Import_ProfileSubaccount import_profile { get; set; }
        public AuthSubaccount auth { get; set; }
        public bool create_user_from_auth_hash { get; set; }
        public bool scim { get; set; }
    }

    public class Import_ProfileSubaccount
    {
        public bool[] csv_days { get; set; }
        public object csv_time { get; set; }
        public object csv_url { get; set; }
        public object csv_user { get; set; }
        public object csv_public_key { get; set; }
        public object try_key_based_auth { get; set; }
    }

    public class AuthSubaccount
    {
        public string provider { get; set; }
        public string subprovider { get; set; }
    }

    public class ProductSubaccount
    {
        public string product_name { get; set; }
        public string subscription_type { get; set; }
    }
}
