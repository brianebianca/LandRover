using LandRover.Core.Utils;
using LandRover.Domain.Entities;
using LandRover.Domain.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LandRover.UnitTests")]
namespace LandRover.Infra.Repository.Repositories
{
    public class LandingPlanRepository
    {
        public LandingPlans GetLandingPlans(string path)
        {
            var lines = FileReader.ReadFile(path);
            return LoadLandingPlans(lines);
        }

        internal LandingPlans LoadLandingPlans(string[] lines)
        {
            try
            {
                var landingPlans = new LandingPlans();
                landingPlans.plateau = LoadPlateau(lines[0].Split(' '));

                for (int i = 1; i < lines.Length; i = i + 2)
                {
                    var landingPlan = new LandingPlan();
                    landingPlan.Rover = LoadRover(lines[i].Split(" "));
                    landingPlan.instructions = LoadInstructions(lines[i + 1]);
                    landingPlans.landingPlans.Add(landingPlan);
                }

                return landingPlans;
            }
            catch (Exception)
            {
                throw new Exception($"Error loading {nameof(LandingPlans)}");
            }
        }

        internal Plateau LoadPlateau(string[] strings)
        {
            try
            {
                var plateau = new Plateau();
                var coordinates = new Coordinate();
                coordinates.x = Convert.ToInt32(strings[0]);
                coordinates.y = Convert.ToInt32(strings[1]);
                plateau.UpperRightLimit = coordinates;
                return plateau;
            }
            catch(Exception)
            {
                throw new Exception($"Error loading {nameof(Plateau)}");
            }
        }

        internal Rover LoadRover(string[] strings)
        {
            try
            {
                var rover = new Rover();
                var coordinates = new Coordinate();
                coordinates.x = Convert.ToInt32(strings[0]);
                coordinates.y = Convert.ToInt32(strings[1]);
                rover.coordinate = coordinates;
                Enum.TryParse(strings[2], out CardinalPoint cardinalPoint);
                rover.cardinalPoint = cardinalPoint;
                return rover;

            }
            catch (Exception)
            {
                throw new Exception($"Error loading {nameof(Rover)}");
            }
        }

        internal List<Instruction> LoadInstructions(string str)
        {
            try
            {
                var instructionList = new List<Instruction>();
                foreach (char c in str)
                {
                    instructionList.Add(new Instruction(c));
                }
                return instructionList;
            }
            catch (Exception)
            {
                throw new Exception($"Error loading {nameof(Rover)}");
            }
        }
    }
}