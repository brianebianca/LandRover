using LandRover.Domain.Entities;
using LandRover.Domain.Interfaces.Application.Application;
using LandRover.Domain.Interfaces.Application.Services;

namespace LandRover.Application.Application
{
    public class RoverApplication : IRoverApplication
    {
        private readonly ILandingPlanService _landingPlanService;
        private readonly IRoverService _roverService;

        public RoverApplication(ILandingPlanService landingPlanService, IRoverService roverService)
        {
            _landingPlanService = landingPlanService;
            _roverService = roverService;
        }

        public List<Rover> NavigateAllRovers(string path)
        {
            var landingPlans = _landingPlanService.GetLandingPlans(path);
            var rovers = new List<Rover>();

            foreach(var plan in landingPlans.landingPlans)
            {
                rovers.Add(_roverService.Navigate(plan.Rover, plan.instructions));
            }
            return rovers;
        }
    }
}