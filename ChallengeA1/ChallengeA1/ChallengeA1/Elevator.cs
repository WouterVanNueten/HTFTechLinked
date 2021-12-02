using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class Elevator
    {
        public int Start { get; set; }
        public int Destination { get; set; }

        public Elevator(int start, int destination)
        {
            this.Start = start;
            this.Destination = destination;
        }

        public override string ToString()
        {
            return "Start: " + this.Start.ToString() + ", Destination: " + this.Destination.ToString();
        }
    }
}
