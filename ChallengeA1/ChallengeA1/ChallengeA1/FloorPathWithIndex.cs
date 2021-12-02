using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class FloorPathWithIndex
    {
        public int ListNumber { get; set; }
        public List<int> FloorPathList { get; set; }

        public FloorPathWithIndex(int listNumber)
        {
            FloorPathList = new List<int>();
            ListNumber = listNumber;
        }

        public void addFloorToPath(int floor)
        {
            FloorPathList.Add(floor);
        }

        //public removeFloorFromPath(int floor)
        //{
        //    FloorPathList.Add(floor);
        //}
    }
}
