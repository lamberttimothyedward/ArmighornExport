using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteCareExport
{

    public class EnrollmentRootobject
    {
        public EnrollmentMeta meta { get; set; }
        public EnrollmentLinked linked { get; set; }
        public Enrollment[] enrollments { get; set; }
    }

    public class EnrollmentMeta
    {
    }

    public class EnrollmentLinked
    {
        public Course_Templates[] course_templates { get; set; }
        public Learner[] learners { get; set; }
    }

    public class Course_Templates
    {
        public string id { get; set; }
    }

    public class Learner
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        //public string avatar_url { get; set; }
        public bool deleted { get; set; }
    }

    public class Enrollment
    {
        public string id { get; set; }
        public string course_template { get; set; }
        public string end_at { get; set; }
        public string progress { get; set; }
        public string can_be_removed { get; set; }
        public string can_be_made_optional { get; set; }
        public string completed_at { get; set; }
        public string score { get; set; }
        public string state { get; set; }
        public string expires_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public bool active { get; set; }
        public bool required { get; set; }
        public bool is_permanently_failed { get; set; }
        public string is_archived { get; set; }
        public string allow_re_enroll { get; set; }
        public Links links { get; set; }
    }

    public class Links
    {
        public Learner1 learner { get; set; }
    }

    public class Learner1
    {
        public string type { get; set; }
        public string id { get; set; }
    }

}
