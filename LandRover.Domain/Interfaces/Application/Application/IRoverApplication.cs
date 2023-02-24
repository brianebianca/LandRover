using LandRover.Domain.Entities;

namespace LandRover.Domain.Interfaces.Application.Application
{
    public interface IRoverApplication
    {
        List<Rover> NavigateAllRovers(string path);
    }
}