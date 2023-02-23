namespace LandRover.Domain.Entities
{
    public class LandingPlan
    {
        public LandingPlan() 
        { 
            instructions = new List<Instruction>();
        }

        public Rover Rover { get; set; }
        public List<Instruction> instructions { get; set; }
    }
}