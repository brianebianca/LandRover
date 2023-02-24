using LandRover.Domain.Entities;

namespace LandRover.Domain.Interfaces.Application.Services
{
    public interface IRoverService
    {
        Rover Navigate(Rover rover, List<Instruction> instructions);

        LandingPlans GetLandingPlans(string path);
    }
}