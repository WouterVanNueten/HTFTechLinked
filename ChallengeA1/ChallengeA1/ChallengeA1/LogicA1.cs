using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeA1
{
    static internal class LogicA1
    {
        static public async Task Logic()
        {
            HttpClient client = Client.GetHttpClient();

            var startUrl = "api/path/1/easy/Start";
            var startResponse = await client.GetAsync(startUrl);

            Console.WriteLine(startResponse);
        }
    }
}
