using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBridgeCourses
{
    public class course_templates
    {

        public string course_type { get; set; }

    }

    public class course_template
    {

        public string title { get; set; }

    }

    public class CoursePublishInputModel
    {

        public string notify_filter { get; set; }
        public string notify_message { get; set; }
        public bool re_enroll { get; set; }

    }
}
