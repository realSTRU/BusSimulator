using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSimulator.Models
{
    class BusStop
    {
        public string Name { get; set; }
        public List<Person> WaitingPeople { get; set; }
        public List<Person> ArrivedPeople { get; set; }

        public BusStop(string name)
        {
            Name = name;
            WaitingPeople = new List<Person>();
            ArrivedPeople = new List<Person>();
        }
    }
}
