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
    public class GroupSharingProcessor
    {
        public static async Task<Boolean> SetRelavance(int groupid, int coursenumber, string subdomain = "", Boolean bProdChecked = false)
        {
            string url = "";
            Boolean isUpdated = new Boolean();
            isUpdated = false;
            var logger = NLog.LogManager.GetCurrentClassLogger();
            //ShareGroupsModel sgm = new ShareGroupsModel { learnable_type = "CourseTemplate", learnable_id = coursenumber.ToString(), group_id = groupid.ToString(), relevance = "in_library" };
            ShareGroupsModel sgm = new ShareGroupsModel { learnable_type = "CourseTemplate", learnable_id = coursenumber.ToString(), group_id = groupid.ToString(), relevance = "in_library" };

            if(bProdChecked == true)
            {
                url = "https://" + subdomain + ConfigurationManager.AppSettings["setRelevanceURLProduction"];
            }
            else
            {
                url = "https://" + subdomain + ConfigurationManager.AppSettings["setRelevanceURLSandbox"];
            }

            

            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, sgm))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        isUpdated = true;

                    }
                }

            }
            catch (Exception ex)
            {
                isUpdated = false;
                logger.Error(ex.Message);
                return false;
            }

            return isUpdated;
        }
    }
}
