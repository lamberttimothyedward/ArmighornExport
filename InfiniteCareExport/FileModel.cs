using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace GetUserInfo
{
    [DelimitedRecord(",")]
    public class FileCourses
    {
        public string SubAccountID;
        public string SubAccount;
        public string URL;
    }
    [DelimitedRecord(",")]
    public class FileOutput
    {
        [Description("user_id")]
        public string user_id { get; set; }

        [Description("uid")]
        public string uid { get; set; }

        [Description("learnable_id")]
        public string learnable_id { get; set; }

        [Description("enrolled")]
        public string enrolled { get; set; }

        [Description("due")]
        public string due { get; set; }

        [Description("started")]
        public string started { get; set; }

        [Description("completed")]
        public string completed { get; set; }

        [Description("expiry")]
        public string expiry { get; set; }

        [Description("score")]
        public string score { get; set; }

        [Description("learnable_group")]
        public string learnable_group { get; set; }







        [Description("Status")]
        public string status { get; set; }

        [Description("Location")]
        public string Location { get; set; }

        [Description("Position")]
        public string Position { get; set; }

        [Description("EmployeeId")]
        public string EmployeeId { get; set; }
    }
    [DelimitedRecord(",")]
    public class ErrorFileOutput
    {
        public string domainName;
        public string errormessage;
    }

    [DelimitedRecord(",")]
    public class SubaccountFileOutput
    {
        public string id;
        public string name;
        public string subdomain;
        public string user_count;
        public string time_zone;
        public string contact_email;
        public string contact_name;
        public string contact_phone;
    }

    [DelimitedRecord(",")]
    public class FileMatrixOutput
    {
        public string uid { get; set; }
        public string learner { get; set; }
        public string Mandatory1 { get; set; }
        public string Mandatory2 { get; set; }
        public string Mandatory3 { get; set; }
        public string Mandatory4 { get; set; }
        public string Mandatory5 { get; set; }
        public string Mandatory6 { get; set; }
        public string Mandatory7 { get; set; }
        public string Mandatory8 { get; set; }
        public string Mandatory9 { get; set; }
        public string Mandatory10 { get; set; }
        public string Mandatory11 { get; set; }
        public string Mandatory12 { get; set; }
        public string LocationCode { get; set; }
        public string Manager { get; set; }
        public string Position { get; set; }
    }

    [DelimitedRecord(",")]
    public class FileExistingCourses
    {
        public string courseid { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string title { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string description { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public int default_days_until_due { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public bool autoReenroll { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public int reenrollPeriod { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string relevance { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string tags { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string groups { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public int default_days_until_expiration { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string has_certificate { get; set; }

    }
}
