////// See https://aka.ms/new-console-template for more information
////Console.WriteLine("Hello, World!");

//using LandRover.Core.Utils;

//Console.WriteLine($"Hi");
////string name = Environment.GetCommandLineArgs()[0];
//string file = Console.ReadLine();
//Console.WriteLine($"Reading file {file}!");

//var commands = FileReader.ReadFile( file );
//foreach (string line in commands)
//    Console.WriteLine(line);


using LandRover.Application.Services;
using LandRover.Domain.Interfaces.Application.Services;
using LandRover.Domain.Interfaces.Infra.Repository;
using LandRover.Infra.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LandRover.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddScoped<ILandingPlanRepository, LandingPlanRepository>()
                .AddScoped<IRoverService, RoverService>()
                .BuildServiceProvider();

            var roverService = serviceProvider.GetRequiredService<IRoverService>();

            var plans = roverService.GetLandingPlans("C:\\Users\\JessicaAbreu\\Downloads\\teste.txt");
            var plan = plans.landingPlans.First();
            var result = roverService.Navigate(plan.Rover, plan.instructions);
            Console.WriteLine(result.ToString());

            var plan2 = plans.landingPlans.Last();
            var result2 = roverService.Navigate(plan2.Rover, plan2.instructions);
            Console.WriteLine(result2.ToString());
        }
    }
}
