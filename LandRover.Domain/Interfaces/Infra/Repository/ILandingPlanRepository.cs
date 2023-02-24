using LandRover.Domain.Entities;

namespace LandRover.Domain.Interfaces.Infra.Repository
{
    public interface ILandingPlanRepository
    {
        LandingPlans GetLandingPlans(string path);
    }
}