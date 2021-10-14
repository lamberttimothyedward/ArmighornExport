using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CreateSubAccount
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void IninitializeClient()
        {

            ApiClient = new HttpClient();
        
            ApiHelper.ApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["enrollmentURLProduction"]);
         

            ApiClient.DefaultRequestHeaders.Accept.Clear();

             ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["tokenProduction"]);


            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
}
