using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using ChallengeA1;
using System.Text.Json;

namespace Challenges
{
    static public class LogicA2
    {
        static public async Task Logic()
        {
            HttpClient client = Client.GetHttpClient();

            //var startUrl = "api/path/1/medium/Start";
            //var startResponse = await client.GetAsync(startUrl);

            //Console.WriteLine(startResponse);

            var sampleUrl = "api/path/1/medium/Sample";
            JsonElement sampleResponse = await client.GetFromJsonAsync<JsonElement>(sampleUrl);

            if(sampleResponse.TryGetProperty("destination", out JsonElement value))
            {
                int destination = value.GetInt32();
                Console.WriteLine(destination);

                var sampleAnswer = GetAnswer(destination);
                Console.WriteLine(sampleAnswer);
            }

            //var samplePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, sampleAnswer);
            //var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();

            //Console.WriteLine(samplePostResponseValue);
        }

        static private List<int> GetAnswer(int destination)
        {
            int currentFloor = 0;
            int elevatorFloorSkips = 1;
            List<int> floors = new List<int>();
            int minusindex = 1;
            int floorDown = 0;
            bool firstFloor = true;

            while(currentFloor != destination)
            {
                int floorcount = 0;

                if((currentFloor + elevatorFloorSkips) < destination)
                {
                    if(currentFloor == floorDown && !firstFloor)
                    {
                        currentFloor -= elevatorFloorSkips;
                    }
                    else
                    {
                        currentFloor += elevatorFloorSkips;
                    }
                    firstFloor = false;
                    floorcount++;
                    floors.Add(currentFloor);
                    Console.WriteLine(currentFloor);
                }
                else
                {

                    for(int floor = 0; floor < floors.Count; floor++)
                    {
                        if(floor == minusindex)
                        {
                            floorDown = floor;
                        }
                    }
                    foreach (int floor in floors)
                    {
                        Console.Write(floor);
                    }
                    Console.WriteLine();
                    minusindex++;
                    floors.Clear();
                    elevatorFloorSkips = 0;
                    firstFloor = true;
                    currentFloor = 0;
                }

                elevatorFloorSkips++;
            }


            return floors;
        }

        //    int currentFloor = 0;
        //    int elevatorFloorSkips = 1;
        //    int currentFloorPathNumber = 0;
        //    var answer = new List<int>();
        //    List<FloorPathWithIndex> floorPathList = new List<FloorPathWithIndex>();

        //    FloorPathWithIndex floorPathWithIndexBase = new FloorPathWithIndex(currentFloorPathNumber);
        //    floorPathList.Add(floorPathWithIndexBase);

        //    while (currentFloor != destination)
        //    {   
        //        foreach(FloorPathWithIndex floorPath in floorPathList)
        //        {

        //            bool revertFloorPath = false;

        //            if(floorPath.ListNumber == currentFloorPathNumber)
        //            {
        //                Console.WriteLine(currentFloor);
        //                if ((currentFloor + elevatorFloorSkips) < destination)
        //                {
        //                    currentFloor += elevatorFloorSkips;
        //                    floorPath.FloorPathList.Add(currentFloor);
        //                }
        //                else
        //                {
        //                    if(elevatorFloorSkips > destination)
        //                    {
        //                        revertFloorPath = true;
        //                    }

        //                    if (!revertFloorPath)
        //                    {
        //                        currentFloorPathNumber++;
        //                        FloorPathWithIndex floorPathWithIndex = new FloorPathWithIndex(currentFloorPathNumber); 
        //                        currentFloor -= elevatorFloorSkips;
        //                        floorPathWithIndex.FloorPathList.Add(currentFloor);
        //                    }
                            
        //                }
        //                elevatorFloorSkips++;
        //            }
        //        }
        //    }

        //    return answer;
            
        //}
    }
}
