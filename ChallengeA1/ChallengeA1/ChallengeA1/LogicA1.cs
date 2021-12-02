using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace ChallengeA1
{
    static internal class LogicA1
    {
        static public async Task Logic()
        {
            HttpClient client = Client.GetHttpClient();

            //var startUrl = "api/path/1/easy/Start";
            //var startResponse = await client.GetAsync(startUrl);

            //Console.WriteLine(startResponse);

            var sampleUrl = "api/path/1/easy/Puzzle";
            var sampleResponse = await client.GetFromJsonAsync<List<int>>(sampleUrl);

            var sampleAnswer = GetAnswer(sampleResponse);

            var samplePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, sampleAnswer);
            var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();

            Console.WriteLine(samplePostResponseValue);
        }

        static private int GetAnswer(List<int> list)
        {
            int numberSumResult = 0;

            foreach(var number in list)
            {
                numberSumResult += number;
            }

            Console.WriteLine("Sum of all numbers: " + numberSumResult);

            int digitSumResult;

            do
            {
                List<int> splittedNumber = new List<int>();
                while (numberSumResult > 0)
                {
                    splittedNumber.Add(numberSumResult % 10);
                    numberSumResult /= 10;
                }
                splittedNumber.Reverse();

                Console.WriteLine("Seperated digits:");

                digitSumResult = 0;

                foreach (var digit in splittedNumber)
                {      
                    Console.Write(digit + " ");
                    digitSumResult += digit;
                }

                Console.WriteLine();
                Console.WriteLine("Result of sum of digits: " + digitSumResult);
                numberSumResult = digitSumResult;
            }
            while (digitSumResult > 9);

            Console.WriteLine("One digit left");

            return digitSumResult;
        }
    }
}
