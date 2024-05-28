using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BusSimulator.Models
{

    class BusStatistics
    {
        public int TotalTransported { get; }
        public int RemainingInBus { get; }
        public Dictionary<string, int> TotalByStop { get; }
        public int LeftWaiting { get; }

        public BusStatistics(int totalTransported, int remainingInBus, Dictionary<string, int> totalByStop, int leftWaiting)
        {
            TotalTransported = totalTransported;
            RemainingInBus = remainingInBus;
            TotalByStop = totalByStop;
            LeftWaiting = leftWaiting;
        }

        public void PrintStatistics()
        {
            Console.WriteLine("Estadísticas Finales:");
            Console.WriteLine($"Total de personas transportadas: {TotalTransported}");
            Console.WriteLine($"Personas que quedaron en el bus: {RemainingInBus}");
            foreach (var stop in TotalByStop)
            {
                Console.WriteLine($"Total de personas transportadas desde {stop.Key}: {stop.Value}");
            }
            Console.WriteLine($"Total de personas que quedaron esperando: {LeftWaiting}");
        }
    }
}
