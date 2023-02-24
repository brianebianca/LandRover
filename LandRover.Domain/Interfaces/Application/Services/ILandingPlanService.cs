using LandRover.Domain.Entities;

namespace LandRover.Domain.Interfaces.Application.Services
{
    public interface ILandingPlanService
    {
        LandingPlans GetLandingPlans(string path);
    }
}