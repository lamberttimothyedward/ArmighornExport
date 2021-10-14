using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteCareExport
{

    public class ILRootobject
    {
        public ILMeta meta { get; set; }
        public ILReport[] reports { get; set; }
    }

    public class ILMeta
    {
        public string next { get; set; }
    }

    public class ILReport
    {
        public string title { get; set; }
        public string report_type { get; set; }
        public ILDatum[] data { get; set; }
        public ILData_Types data_types { get; set; }
    }

    public class ILData_Types
    {
        public string name { get; set; }
        public string uid { get; set; }
        public string email { get; set; }
        public string course_id { get; set; }
        public string course_external_id { get; set; }
        public string course { get; set; }
        public string course_description { get; set; }
        public string score { get; set; }
        public string due_date { get; set; }
        public string completion_date { get; set; }
        public string state { get; set; }
        public string continuing_education_credits { get; set; }
        public string required { get; set; }
        public string total_time { get; set; }
        public string programs { get; set; }
        public string groups { get; set; }
        public string created_at { get; set; }
        public string archived_at { get; set; }
        public string custom_field_employeenumber { get; set; }
        public string custom_field_location { get; set; }
        public string custom_field_position { get; set; }
        public string user_id { get; set; }
    }

    public class ILDatum
    {
        public string course_template_external_id { get; set; }
        public string course_template_title { get; set; }
        public int course_template_course_type { get; set; }
        public string course_template_description { get; set; }
        public int continuing_education_credits { get; set; }
        public int id { get; set; }
        public string user_id { get; set; }
        public string state { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string completed_at { get; set; }
        public string score { get; set; }
        public string end_at { get; set; }
        public int course_template_id { get; set; }
        public int attempts_count { get; set; }
        public bool required { get; set; }
        public object external_id { get; set; }
        public object deleted_at { get; set; }
        public int sources_count { get; set; }
        public string config { get; set; }
        public object expires_at { get; set; }
        public object inactive { get; set; }
        public object renew_by { get; set; }
        public object archived_at { get; set; }
        public string uuid { get; set; }
        public string display_name { get; set; }
        public string uid { get; set; }
        public string email { get; set; }
        public string source_program_titles { get; set; }
        public string source_group_names { get; set; }
        public int total_time { get; set; }
        public string name { get; set; }
        public string course_id { get; set; }
        public string course_external_id { get; set; }
        public string course { get; set; }
        public string course_description { get; set; }
        public string due_date { get; set; }
        public object completion_date { get; set; }
        public string programs { get; set; }
        public string groups { get; set; }
        public string custom_field_location { get; set; }
        public string custom_field_position { get; set; }
        public string custom_field_employeenumber { get; set; }
    }

}
