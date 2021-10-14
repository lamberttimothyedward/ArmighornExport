using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramExpiryWizard
{

    public class ProgramRootobject
    {
        public ProgramMeta meta { get; set; }
        public LearnerProgram[] programs { get; set; }
    }

    public class ProgramMeta
    {
        public Permission[] permissions { get; set; }
    }

    public class Permission
    {
        public string type { get; set; }
        public string id { get; set; }
        public object[] actions { get; set; }
    }

    public class LearnerProgram
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string description { get; set; }
        public int course_count { get; set; }
        public int item_count { get; set; }
        public bool is_published { get; set; }
        public bool publishable { get; set; }
        public bool has_unpublished_changes { get; set; }
        public bool step_notifications { get; set; }
        public bool has_certificate { get; set; }
        public object external_id { get; set; }
        public bool direct_messaging_enabled { get; set; }
        public int unfinished_learners_count { get; set; }
        public object[] tags { get; set; }
        public object[] matching_tags { get; set; }
        public object[] categories { get; set; }
        public Enrollment_Counts enrollment_counts { get; set; }
        public Sub_Account sub_account { get; set; }
        public Item[] items { get; set; }
        public Course_Templates[] course_templates { get; set; }
        public Graphic graphic { get; set; }
        public bool is_non_linear { get; set; }
        public int estimated_time { get; set; }
        public bool open_enrollment { get; set; }
        public string uuid { get; set; }
        public string enroll_url { get; set; }
        public bool has_shared_content { get; set; }
        public bool is_shared { get; set; }
        public string due_date_type { get; set; }
        public object default_due_on_date { get; set; }
        public object default_days_until_due { get; set; }
        public bool expires { get; set; }
        public object default_days_until_expiration { get; set; }
        public bool auto_re_enroll { get; set; }
        public int re_enrollment_period { get; set; }
    }

    public class Enrollment_Counts
    {
        public int all { get; set; }
        public int overdue { get; set; }
        public int not_finished { get; set; }
        public int finished { get; set; }
    }

    public class Sub_Account
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool is_root { get; set; }
        public bool sub_accounts_exist { get; set; }
        public bool not_current { get; set; }
        public string tac_type { get; set; }
        public object tac_custom_body_markup { get; set; }
        public DateTime tac_updated_at { get; set; }
    }

    public class Graphic
    {
        public int gradient { get; set; }
        public string image { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string item_type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public object default_days_until_due { get; set; }
        public object default_due_on_date { get; set; }
        public bool editable { get; set; }
        public int estimated_time { get; set; }
        public bool is_published { get; set; }
        public int passing_threshold { get; set; }
        public int sessions_count { get; set; }
        public object max_quiz_attempts { get; set; }
        public object continuing_education_credits { get; set; }
        public object default_approver { get; set; }
        public bool requires_approval { get; set; }
        public bool requires_evidence { get; set; }
        public bool blocks_progress { get; set; }
        public object icon { get; set; }
        public bool is_archived { get; set; }
    }

    public class Course_Templates
    {
        public string id { get; set; }
        public int estimated_time { get; set; }
        public int passing_threshold { get; set; }
        public object max_quiz_attempts { get; set; }
        public object continuing_education_credits { get; set; }
        public object default_days_until_due { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool is_published { get; set; }
        public DateTime published_at { get; set; }
        public bool has_certificate { get; set; }
        public string course_type { get; set; }
        public object external_id { get; set; }
        public bool is_archived { get; set; }
        public bool maintain_branding_in_sub_account { get; set; }
    }

}
