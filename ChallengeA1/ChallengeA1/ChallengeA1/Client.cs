using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ChallengeA1
{
    static internal class Client
    {
        static public HttpClient GetHttpClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");

            var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNDMiLCJuYmYiOjE2Mzg0Mzc3MTAsImV4cCI6MTYzODUyNDExMCwiaWF0IjoxNjM4NDM3NzEwfQ.1Ff9R4Lxs_rICrURoE_It0PBpyfI-0Bvwyt9uyuBV9U_237mbjEY-Kej1RnZf7oC3UQoG6N5VN-ixSb1O4PA0Q";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //var startUrl = "api/path/1/easy/Start";
            //var startResponse = await client.GetAsync(startUrl);

            return client;
        } 
    }
}
