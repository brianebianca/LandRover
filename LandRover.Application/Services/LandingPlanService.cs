using LandRover.Domain.Entities;
using LandRover.Domain.Interfaces.Application.Services;
using LandRover.Domain.Interfaces.Infra.Repository;

namespace LandRover.Application.Services
{
    public class LandingPlanService : ILandingPlanService
    {
        private readonly ILandingPlanRepository _landingPlanRepository;

        public LandingPlanService(ILandingPlanRepository landingPlanRepository)
        {
            _landingPlanRepository = landingPlanRepository;
        }

        public LandingPlans GetLandingPlans(string path)
        {
            return _landingPlanRepository.GetLandingPlans(path);
        }
    }
}