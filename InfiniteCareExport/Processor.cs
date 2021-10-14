using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using CreateSubAccount;
using ProgramExpiryWizard;
using FileExportHarness;
using InfiniteCareExport;
namespace CreateBridgeCourses
{
    public class Processor
    {
        public static async Task<Sub_Accounts> connectToDomain(string domainURL = "")
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();

             url = domainURL + ConfigurationManager.AppSettings["getDomainURL"];


            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string basestring = response.Content.ReadAsStringAsync().Result;
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (SubAccountRoot)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(SubAccountRoot));

                        if (des.sub_accounts.Length == 0)
                        {
                            Console.WriteLine("This subaccount: " + domainURL.ToString() + " has no information");


                        }
                        else
                        {
                            if (des.sub_accounts.Length > 0)
                            {
                                Console.WriteLine("This domain: " + domainURL.ToString() + " is cool...");

                                foreach (Sub_Accounts sa in des.sub_accounts)
                                {

                                    if (!string.IsNullOrEmpty(sa.id))
                                    {

                                        return sa;
                                    }
                                }
                                return null;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }

            return null;
        }

        public static async Task<Enrollment[]> getEnrollments(string domainURL = "", string range1 = "", string range2 = "", string courseNumber = "")
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            
            url = domainURL + ConfigurationManager.AppSettings["courseEnrollments"] + courseNumber + "/enrollments";

            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string basestring = response.Content.ReadAsStringAsync().Result;

                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (EnrollmentRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(EnrollmentRootobject));

                        if (des.enrollments == null)
                        {
                            Console.WriteLine("This subaccount: has no information");

                            return null;
                        }
                        else
                        {
                            if (des.enrollments.Length > 0)
                            {
                                Console.WriteLine("This domain: is cool...");

                                return des.enrollments;
                            }
                            return null;
                        }
                    }
                 }
                return null;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public static async Task<CLDatum[]> getCompletedLearning(string domainURL = "", string range1 = "", string range2 = "", string reportType = "")
        {

            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
 
             url = domainURL + ConfigurationManager.AppSettings["completedLearning"] + "?end_date=" + range1 + "&start_date=" + range2 + "&limit=2000";
  
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
               {
                    if (response.IsSuccessStatusCode)
                    {
                        string basestring = response.Content.ReadAsStringAsync().Result;
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (CLRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(CLRootobject));

                        if (des.reports.Length == 0)
                        {
                            Console.WriteLine("This subaccount: has no information");

                            return null;
                        }
                        else
                        {
                            if (des.reports.Length > 0)
                            {
                                Console.WriteLine("This domain: is cool...");

                                return des.reports[0].data;
                            }
                            return null;
                        }

                    }
                    return null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public static async Task<InfiniteCareExport2.Course_Templates[]> getCourses(string domainurl = "")
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if (domainurl != "https://")
            {
                url = domainurl + ConfigurationManager.AppSettings["courseenrollmentsURL"];
            }
            else
            {
                url += domainurl + "acc.bridgeapp.com" + ConfigurationManager.AppSettings["courseenrollmentsURL"] + "?filters[]=published&subaccounts[]=1";
            }

            var loop = true;
            string result = "";

            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });
                        //here
                        do
                        {
                            try
                            {
                                var des = (InfiniteCareExport2.CourseRootobject2)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(InfiniteCareExport2.CourseRootobject2));
                                loop = true;
                                if (des.course_templates.Length == 0)
                                {
                                    Console.WriteLine("This subaccount: " + domainurl.ToString() + " has no information");

                                    return null;
                                }
                                else
                                {
                                    if (des.course_templates.Length > 0)
                                    {
                                        return des.course_templates;
                                    }
                                }
                            }
                            catch (JsonReaderException ex)
                            {
                                var position = ex.LinePosition;
                                var invalidChar = result.Substring(position - 2, 2);
                                invalidChar = invalidChar.Replace("\"", "'");
                                result = $"{result.Substring(0, position - 1)}{result.Substring(position)}";
                            }


                        } while (loop);
                        //here
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }

            return null;


        }

        public static async Task<OLDatum[]> getOverdueLearning(string domainURL = "", string range1 = "", string range2 = "")
        {

            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
 
            url = domainURL + ConfigurationManager.AppSettings["OverdueLearning"] + "?end_date=" + range1 + "&start_date=" + range2 + "&limit=2000";


            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string basestring = response.Content.ReadAsStringAsync().Result;
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (OLRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(OLRootobject));

                        if (des.reports.Length == 0)
                        {
                            Console.WriteLine("This subaccount: has no information");

                            return null;
                        }
                        else
                        {
                            if (des.reports.Length > 0)
                            {
                                Console.WriteLine("This domain: is cool...");

                                return des.reports[0].data;
                            }
                            return null;
                        }

                    }
                    return null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }


        public static async Task<ILDatum[]> getInCompleLearning(string domainURL = "", string range1 = "", string range2 = "", string reportType = "")
        {

            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
 
            url = domainURL + ConfigurationManager.AppSettings["IncompleteLearning"] + "?end_date=" + range1 + "&start_date=" + range2 + "&limit=2000";


            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string basestring = response.Content.ReadAsStringAsync().Result;
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (ILRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(ILRootobject));

                        if (des.reports.Length == 0)
                        {
                            Console.WriteLine("This subaccount: has no information");

                            return null;
                        }
                        else
                        {
                            if (des.reports.Length > 0)
                            {
                                Console.WriteLine("This domain: is cool...");

                                return des.reports[0].data;
                            }
                            return null;
                        }

                    }
                    return null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public static async Task<User> getUser(string domainURL = "", string userid = "")
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
 
                url = domainURL + ConfigurationManager.AppSettings["userURL"] + userid;
 



            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (UsersRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(UsersRootobject));

                        if (des.users.Length == 0)
                        {
                            Console.WriteLine("This subaccount: " + domainURL.ToString() + " has no information");

                            return null;
                        }
                        else
                        {
                            if (des.users.Length > 0)
                            {
                                return des.users[0];
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }

            return null;
        }

        public static async Task<CustomFieldsRootobject> getUserCustomFields(string domainURL = "", string userid = "")
        {
            string url = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();

            url = domainURL + ConfigurationManager.AppSettings["userURL"] + userid + "?includes[]=custom_fields";




            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //Strip String of any extra characters
                        string result = response.Content.ReadAsStringAsync()
                            .Result
                            .Replace("\\", "")
                            .Trim(new char[1] { '"' });

                        var des = (CustomFieldsRootobject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(CustomFieldsRootobject));

                        if (des.users.Length == 0)
                        {
                            Console.WriteLine("This subaccount: " + domainURL.ToString() + " has no information");

                            return null;
                        }
                        else
                        {
                            if (des.users.Length > 0)
                            {
                                return des;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }

            return null;
        }
    }
}
