namespace LandRover.Domain.Entities
{
    public class LandingPlans
    {
        public LandingPlans() 
        {
            landingPlans = new List<LandingPlan>();
        }
        public Plateau plateau { get; set; }
        public List<LandingPlan> landingPlans { get; set; }
    }
}