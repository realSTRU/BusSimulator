using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSimulator.Models
{
    class Bus
    {
        public int Capacity { get; set; }
        public List<Person> Passengers { get; set; }

        public Bus(int capacity)
        {
            Capacity = capacity;
            Passengers = new List<Person>();
        }
    }
}
