using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSubAccount
{

    public class CourseTitlesRootObject
    {
        public CourseTitlesMeta meta { get; set; }
        public CTCourse_Templates[] course_templates { get; set; }
    }

    public class CourseTitlesMeta
    {
        public string next { get; set; }
    }

    public class CTCourse_Templates
    {
        public string id { get; set; }
        public string title { get; set; }
        public bool is_archived { get; set; }
    }

}
