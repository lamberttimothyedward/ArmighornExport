using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSubAccount
{

    public class ConfigRootObject
    {
        public Config config { get; set; }
    }

    public class Config
    {
        public bool auto_csv { get; set; }
        public Branding branding { get; set; }
        public bool bridge_retain { get; set; }
        public bool can_change_password { get; set; }
        public string contact_email { get; set; }
        public string contact_name { get; set; }
        public string contact_phone { get; set; }
        public object custom_back_to_my_learning_href { get; set; }
        public object custom_back_to_my_learning_label { get; set; }
        public string custom_favicon { get; set; }
        public string custom_support_chat_url { get; set; }
        public string custom_support_help_articles_url { get; set; }
        public string custom_support_phone_number { get; set; }
        public string custom_support_ticket_url { get; set; }
        public string custom_window_title { get; set; }
        public object customer_provided_support_chat_url { get; set; }
        public object customer_provided_support_help_articles_url { get; set; }
        public object draft_branding { get; set; }
        public bool hide_login_bridge_logo { get; set; }
        public bool import_passwords { get; set; }
        public bool limited_authoring { get; set; }
        public string locale { get; set; }
        public object lynda_org_id { get; set; }
        public object password_minimum_length { get; set; }
        public bool password_requires_numbers { get; set; }
        public bool password_requires_symbols { get; set; }
        public bool password_requires_uppercase { get; set; }
        public bool password_reset_allowed { get; set; }
        public Product[] products { get; set; }
        public bool scorm_sftp { get; set; }
        public bool show_custom_support_info { get; set; }
        public Slack slack { get; set; }
        public string sub_account_support_level { get; set; }
        public object support_email { get; set; }
        public string support_level { get; set; }
        public string support_name { get; set; }
        public string support_phone { get; set; }
        public string time_zone { get; set; }
        public bool use_custom_support { get; set; }
    }

    public class Branding
    {
        public bool color_enabled { get; set; }
        public string primary_color { get; set; }
        public string navigation_color { get; set; }
        public object primary_logo_url { get; set; }
        public object reverse_logo_url { get; set; }
        public object updated_at { get; set; }
        public object primary_logo_width { get; set; }
        public object primary_logo_height { get; set; }
        public object reverse_logo_width { get; set; }
        public object reverse_logo_height { get; set; }
        public object font { get; set; }
        public Signin signin { get; set; }
        public Header header { get; set; }
        public bool maintain_branding_in_sub_account { get; set; }
    }

    public class Signin
    {
        public object brand_logo { get; set; }
        public object brand_photo_url { get; set; }
        public object brand_photo_opacity { get; set; }
        public object brand_photo_style { get; set; }
    }

    public class Header
    {
        public object brand_logo { get; set; }
        public object custom_text { get; set; }
        public object brand_photo_url { get; set; }
        public object brand_photo_opacity { get; set; }
        public object brand_photo_style { get; set; }
        public object title_contrast { get; set; }
    }

    public class Slack
    {
        public bool enabled { get; set; }
        public object team_id { get; set; }
        public object team_name { get; set; }
        public object bot_user_id { get; set; }
        public object error { get; set; }
    }

    public class Product
    {
        public string product_name { get; set; }
        public string subscription_type { get; set; }
    }

}
