using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBridgeCourses
{
    public class CourseRootObject
    {
        public CourseMeta meta { get; set; }
        public Course2_templates[] course_templates { get; set; }
    }

    public class CourseMeta
    {
        public CoursePermission[] permissions { get; set; }
    }

    public class CoursePermission
    {
        public string type { get; set; }
        public string id { get; set; }
        public object[] actions { get; set; }
    }

    public class Course2_templates
    {
        public string id { get; set; }
        public int? estimated_time { get; set; }
        public int? passing_threshold { get; set; }
        public object max_quiz_attempts { get; set; }
        public object continuing_education_credits { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool? is_published { get; set; }
        public bool? has_been_unpublished { get; set; }
        public bool? has_unpublished_changes { get; set; }
        public bool? retain { get; set; }
        public int? quizzes_count { get; set; }
        public string external_status { get; set; }
        public object external_status_message { get; set; }
        public string course_type { get; set; }
        public int? enrollments_count { get; set; }
        public int? attachments_count { get; set; }
        public object third_party_course_id { get; set; }
        public Course2Meta1 meta { get; set; }
        public bool? show_correct_response { get; set; }
        public CourseBranding_Override branding_override { get; set; }
        public bool? is_archived { get; set; }
        public object archived_at { get; set; }
        public bool? unarchive_locked { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public int incomplete_enrollments_count { get; set; }
        public bool? within_subaccount_scope { get; set; }
        public bool? maintain_branding_in_sub_account { get; set; }
        public bool? has_cover_slide { get; set; }
        public CourseSub_Account sub_account { get; set; }
        public CourseEnrollment_Counts enrollment_counts { get; set; }
        public object[] tags { get; set; }
        public object[] matching_tags { get; set; }
        public object[] categories { get; set; }
        public bool? expires { get; set; }
        public int? default_days_until_expiration { get; set; }
        public bool auto_re_enroll { get; set; }
        public int? re_enrollment_period { get; set; }
        public bool? open_book { get; set; }
        public bool? has_certificate { get; set; }
        public string external_course_id { get; set; }
        public string due_date_type { get; set; }
        public object default_due_on_date { get; set; }
        public int? default_days_until_due { get; set; }
        public bool? open_enrollment { get; set; }
        public string uuid { get; set; }
        public string enroll_url { get; set; }
        public CourseLinks links { get; set; }
        public CourseAuthor author { get; set; }
        public bool? direct_messaging_enabled { get; set; }
    }

    public class Course2Meta1
    {
        public string domain_id { get; set; }
        public string sub_account_id { get; set; }
        public string r2b_jwt { get; set; }
    }

    public class CourseBranding_Override
    {
        public bool? color_enabled { get; set; }
        public string primary_color { get; set; }
        public string navigation_color { get; set; }
        public string primary_logo_url { get; set; }
        public object reverse_logo_url { get; set; }
        public DateTime? updated_at { get; set; }
        public int? primary_logo_width { get; set; }
        public int primary_logo_height { get; set; }
        public object reverse_logo_width { get; set; }
        public object reverse_logo_height { get; set; }
        public object font { get; set; }
        public CourseSignin signin { get; set; }
        public CourseHeader header { get; set; }
        public bool? maintain_branding_in_sub_account { get; set; }
    }

    public class CourseSignin
    {
        public object brand_logo { get; set; }
        public string brand_photo_url { get; set; }
        public int? brand_photo_opacity { get; set; }
        public string brand_photo_style { get; set; }
    }

    public class CourseHeader
    {
        public object brand_logo { get; set; }
        public object custom_text { get; set; }
        public string brand_photo_url { get; set; }
        public int? brand_photo_opacity { get; set; }
        public string brand_photo_style { get; set; }
        public string title_contrast { get; set; }
    }

    public class CourseSub_Account
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool? is_root { get; set; }
        public bool? sub_accounts_exist { get; set; }
        public bool? not_current { get; set; }
        public string tac_type { get; set; }
        public object tac_custom_body_markup { get; set; }
        public DateTime? tac_updated_at { get; set; }
    }

    public class CourseEnrollment_Counts
    {
        public int? all { get; set; }
        public int? required { get; set; }
        public int? optional { get; set; }
        public int? finished { get; set; }
        public int? not_started { get; set; }
        public int? overdue { get; set; }
        public int? in_progress { get; set; }
        public int? incomplete { get; set; }
        public int? incomplete_or_finished { get; set; }
    }

    public class CourseLinks
    {
        public string author { get; set; }
    }

    public class CourseAuthor
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public object email { get; set; }
        public object avatar_url { get; set; }
    }

}
