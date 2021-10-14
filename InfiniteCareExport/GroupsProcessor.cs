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
    public class GroupsProcessor
    {
        public static async Task<string> LoadGroups(string subdomain = "", Boolean bProdChecked = false)
        {
            string url = "";
            string groupid = "";
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if(bProdChecked == true)
            {
                url = "https://" + subdomain + ConfigurationManager.AppSettings["groupURLProduction"];
            }
            else
            {
                url = "https://" + subdomain + ConfigurationManager.AppSettings["groupURLSandbox"];
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

                        var des = (GroupRootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(GroupRootObject));

                        //Check how many enrollments there are...
                        if (des.groups.Length == 0)
                        {
                            Console.WriteLine("This subaccount: " + subdomain.ToString() + " has no groups, writing to ok to expire file");


                        }
                        else
                        {
                            if (des.groups.Length > 0) //More than one learner
                            {
                                Console.WriteLine("This course: " + subdomain.ToString() + " has multiple groups");

                                foreach (Group gr in des.groups)
                                {
                                    //groupid = "";

                                    if (gr.name.ToString() == "All Learners")
                                    {
                                        groupid = gr.id.ToString();
                                        return groupid;
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

            return groupid;
        }


    }
}
