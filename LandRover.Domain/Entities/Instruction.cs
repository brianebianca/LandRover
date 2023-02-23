using LandRover.Domain.Enums;

namespace LandRover.Domain.Entities
{
    public class Instruction
    {
        public InstructionType instructionType { get; set; }
        public char instruction { get; set; }
    }
}