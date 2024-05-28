using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSimulator.Models
{
    class BusSimulation
    {
        private readonly Bus bus;
        private readonly List<BusStop> stops;
        private bool isRunning;
        private readonly Random random = new Random();

        public BusSimulation(Bus bus, List<BusStop> stops)
        {
            this.bus = bus;
            this.stops = stops;
        }

        public void StartSimulation()
        {
            isRunning = true;
            Task.Run(() => Simulate());
        }

        public void StopSimulation()
        {
            isRunning = false;
        }

        private async Task Simulate()
        {
            while (isRunning)
            {
                foreach (var stop in stops)
                {
                    if (!isRunning) break;

                    Console.Clear();
                    Console.WriteLine($"Llegando a {stop.Name}...");

                    // Simular llegada de personas a la parada
                    int newPeopleCount = random.Next(1, 5);
                    var newPeople = Enumerable.Range(0, newPeopleCount).Select(id => new Person { Id = random.Next() }).ToList();
                    stop.WaitingPeople.AddRange(newPeople);

                    Console.WriteLine($"{newPeople.Count} personas llegaron a {stop.Name}.");
                    Console.WriteLine($"Personas en espera en {stop.Name}: {stop.WaitingPeople.Count}");

                    // Simular salida y entrada del autobús
                    var leavingPeople = bus.Passengers.Where(p => random.Next(2) == 0).ToList();
                    bus.Passengers.RemoveAll(p => leavingPeople.Contains(p));
                    stop.ArrivedPeople.AddRange(leavingPeople);

                    var boardingPeople = stop.WaitingPeople.Take(bus.Capacity - bus.Passengers.Count).ToList();
                    bus.Passengers.AddRange(boardingPeople);
                    stop.WaitingPeople = stop.WaitingPeople.Skip(boardingPeople.Count).ToList();

                    Console.WriteLine($"{leavingPeople.Count} personas se bajaron del bus.");
                    Console.WriteLine($"{boardingPeople.Count} personas se subieron al bus.");
                    Console.WriteLine($"Personas en el bus: {bus.Passengers.Count}");

                    Console.WriteLine($"Salida de {stop.Name}...");

                    // Esperar antes de moverse a la siguiente parada
                    await Task.Delay(3000);
                }
            }

            Console.WriteLine("Simulación detenida.");
        }

        public BusStatistics GetStatistics()
        {
            var totalTransported = stops.Sum(stop => stop.ArrivedPeople.Count);
            var remainingInBus = bus.Passengers.Count;
            var totalByStop = stops.ToDictionary(stop => stop.Name, stop => stop.ArrivedPeople.Count);
            var leftWaiting = stops.Sum(stop => stop.WaitingPeople.Count);

            return new BusStatistics(totalTransported, remainingInBus, totalByStop, leftWaiting);
        }
    }

}