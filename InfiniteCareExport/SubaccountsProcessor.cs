using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CreateSubAccount
{
    public class SubAccountsProcessor
    {
        public static async Task<Boolean> ShareCourses(int coursenumber, int subAccountNumber = 0, Boolean bProdChecked = false)
        {
            string url = "";
            Boolean isUpdated = new Boolean();
            isUpdated = false;
            var logger = NLog.LogManager.GetCurrentClassLogger();
            //SubAccountInputModel sam = new SubAccountInputModel { item_id = coursenumber.ToString(), item_type = "CourseTemplate", domain_id = subAccountNumber.ToString() };
            SubAccountInputModel_1 sam = new SubAccountInputModel_1 { item_id = coursenumber.ToString(), item_type = "CourseTemplate", domain_id = subAccountNumber.ToString() };
            if (subAccountNumber > 0)
            {
                if(bProdChecked == true)
                {
                    url = ConfigurationManager.AppSettings["subaccountsURLProduction"];
                }
                else
                {
                    url = ConfigurationManager.AppSettings["subaccountsURLSandbox"];
                }
                
            }
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, sam))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        isUpdated = true;
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                isUpdated = false;
                return false;
            }

            return isUpdated;
        }

        public static async Task<string> LoadDomain(int subAccountNumber = 0)
        {
            string url = "";
            string subdomainid = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if (subAccountNumber > 0)
            {
                url = ConfigurationManager.AppSettings["getDomainURL"] + subAccountNumber.ToString();
            }
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

                        var des = (RootObjectSubaccount)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(RootObjectSubaccount));

                        //Check how many enrollments there are...
                        if (des.sub_accounts.Length == 0)
                        {
                            Console.WriteLine("This subaccount: " + subAccountNumber.ToString() + " has no groups, writing to ok to expire file");


                        }
                        else
                        {
                            if (des.sub_accounts.Length > 0) //More than one learner
                            {
                                Console.WriteLine("This course: " + subAccountNumber.ToString() + " has multiple groups");

                                foreach (Sub_Accounts sa in des.sub_accounts)
                                {
                                    //groupid = "";

                                    if (!string.IsNullOrEmpty(sa.subdomain))
                                    {
                                        subdomainid = sa.subdomain.ToString();
                                        return subdomainid;
                                    }
                                }
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

            return subdomainid;
        }
    }


}

