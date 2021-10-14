using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FileExportHarness
{

    public class CLRootobject
    {
        public CLMeta meta { get; set; }
        public CLReport[] reports { get; set; }
    }

    public class CLMeta
    {
        public string next { get; set; }
    }

    public class CLReport
    {
        public string title { get; set; }
        public string report_type { get; set; }
        public CLDatum[] data { get; set; }
        public CLData_Types data_types { get; set; }
    }

    //public class CLData_Types
    //{
    //    public string name { get; set; }
    //    public string uid { get; set; }
    //    public string email { get; set; }
    //    public string course_id { get; set; }
    //    public string course_external_id { get; set; }
    //    public string course { get; set; }
    //    public string course_description { get; set; }
    //    public string score { get; set; }
    //    public string due_date { get; set; }
    //    public string completion_date { get; set; }
    //    public string state { get; set; }
    //    public string continuing_education_credits { get; set; }
    //    public string required { get; set; }
    //    public string total_time { get; set; }
    //    public string programs { get; set; }
    //    public string groups { get; set; }
    //    public string created_at { get; set; }
    //    public string archived_at { get; set; }
    //    public string available { get; set; }
    //    public string certificate_url { get; set; }
    //    public string custom_field_employmentstatus { get; set; }
    //    public string custom_field_firstn_ame { get; set; }
    //    public string custom_field_holidayzone { get; set; }
    //    public string custom_field_paylocation { get; set; }
    //    public string custom_field_positionnumber { get; set; }
    //    public string custom_field_preferredname { get; set; }
    //    public string custom_field_staffmember { get; set; }
    //    public string user_id { get; set; }
    //}

    //public class CLDatum
    //{
    //    public string course_template_external_id { get; set; }
    //    public string course_template_title { get; set; }
    //    public int course_template_course_type { get; set; }
    //    public string course_template_description { get; set; }
    //    public int continuing_education_credits { get; set; }
    //    public int id { get; set; }
    //    public string user_id { get; set; }
    //    public string state { get; set; }
    //    public DateTime created_at { get; set; }
    //    public string updated_at { get; set; }
    //    public string completed_at { get; set; }
    //    public string score { get; set; }
    //    public string end_at { get; set; }
    //    public int course_template_id { get; set; }
    //    public int attempts_count { get; set; }
    //    public bool required { get; set; }
    //    public string external_id { get; set; }
    //    public string deleted_at { get; set; }
    //    public int sources_count { get; set; }
    //    public string config { get; set; }
    //    public string expires_at { get; set; }
    //    public string inactive { get; set; }
    //    public string renew_by { get; set; }
    //    public string archived_at { get; set; }
    //    public string uuid { get; set; }
    //    public string display_name { get; set; }
    //    public string uid { get; set; }
    //    public string email { get; set; }
    //    public string available { get; set; }
    //    public bool owned { get; set; }
    //    public string source_program_titles { get; set; }
    //    public int total_time { get; set; }
    //    public string name { get; set; }
    //    public string course_id { get; set; }
    //    public string course_external_id { get; set; }
    //    public string course { get; set; }
    //    public string course_description { get; set; }
    //    public DateTime? due_date { get; set; }
    //    public DateTime completion_date { get; set; }
    //    public string programs { get; set; }
    //    public string groups { get; set; }
    //    [JsonProperty("custom_field_location code")]
    //    public string custom_field_location_code { get; set; }
    //    public string custom_field_mgrname { get; set; }
    //    public string custom_field_mrgemail { get; set; }
    //    [JsonProperty("custom_field_position 1")]
    //    public string custom_field_position_1 { get; set; }
    //    public string custom_field_mgr1email { get; set; }
    //}


    public class Rootobject
    {
        public Meta meta { get; set; }
        public Report[] reports { get; set; }
    }

    public class Meta
    {
        public string next { get; set; }
    }

    public class Report
    {
        public string title { get; set; }
        public string report_type { get; set; }
        public CLDatum[] data { get; set; }
        public CLData_Types data_types { get; set; }
    }

    public class CLData_Types
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
        public string available { get; set; }
        public string certificate_url { get; set; }
        public string custom_field_careassistantrole { get; set; }
        public string custom_field_employeenumber { get; set; }
        public string custom_field_group { get; set; }
        public string custom_field_location { get; set; }
        public string custom_field_manager { get; set; }
        public string custom_field_manageruid { get; set; }
        public string custom_field_position { get; set; }
        public string user_id { get; set; }
    }

    public class CLDatum
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
        public string expires_at { get; set; }
        public bool? inactive { get; set; }
        public string renew_by { get; set; }
        public object archived_at { get; set; }
        public string uuid { get; set; }
        public string display_name { get; set; }
        public string uid { get; set; }
        public string email { get; set; }
        public string available { get; set; }
        public bool owned { get; set; }
        public object source_program_titles { get; set; }
        public int total_time { get; set; }
        public string name { get; set; }
        public string course_id { get; set; }
        public string course_external_id { get; set; }
        public string course { get; set; }
        public string course_description { get; set; }
        public string due_date { get; set; }
        public string completion_date { get; set; }
        public object programs { get; set; }
        public string groups { get; set; }
        public string custom_field_careassistantrole { get; set; }
        public string custom_field_manageruid { get; set; }
        public string custom_field_location { get; set; }
        public string custom_field_manager { get; set; }
        public string custom_field_position { get; set; }
        public string custom_field_group { get; set; }
        [JsonProperty("custom_field_employee number")]
        public string custom_field_employeenumber { get; set; }
        public string certificate_url { get; set; }
        public string source_group_names { get; set; }
    }


}
