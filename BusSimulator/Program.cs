
using BusSimulator.Models;

class Program
{
    static void Main(string[] args)
    {
        var bus = new Bus(30);
        var stops = new List<BusStop>
        {
            new BusStop("Parada Resinto UCNE"),
            new BusStop("Parada Resinto UASD"),
            new BusStop("Parada Parque Duarte")
        };
        var simulation = new BusSimulation(bus, stops);

        Console.WriteLine("Simulación de Autobús");
        Console.WriteLine("Presione 'Enter' para iniciar la simulación, 'S' para detenerla y 'Q' para salir.");

        var input = Console.ReadKey(true);
        while (input.Key != ConsoleKey.Q)
        {
            if (input.Key == ConsoleKey.Enter)
            {
                simulation.StartSimulation();
                Console.WriteLine("Simulación iniciada. Presione 'S' para detenerla.");
            }
            else if (input.Key == ConsoleKey.S)
            {
                simulation.StopSimulation();
                var stats = simulation.GetStatistics();
                stats.PrintStatistics();
                Console.WriteLine("Presione 'Enter' para iniciar nuevamente o 'Q' para salir.");
            }

            input = Console.ReadKey(true);
        }
    }
}