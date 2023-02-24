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


using LandRover.Application.Application;
using LandRover.Application.Services;
using LandRover.Domain.Interfaces.Application.Application;
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
                .AddScoped<ILandingPlanService, LandingPlanService>()
                .AddScoped<IRoverApplication, RoverApplication>()
                .BuildServiceProvider();

            var _roverApplication = serviceProvider.GetRequiredService<IRoverApplication>();

            string path = Path.GetFullPath(args[0]);
            Console.WriteLine("trying path: " + path);

            var rovers = _roverApplication.NavigateAllRovers(path);
            foreach (var rover in rovers)
            {
                Console.WriteLine(rover.ToString());
            }
        }
    }
}
