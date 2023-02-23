using LandRover.Domain.Enums;

namespace LandRover.Domain.Entities
{
    public class Instruction
    {
        public Instruction(char instruction) 
        {
            this.instruction = instruction;
            if(instruction == 'M')
            {
                instructionType = InstructionType.move;
            }
        }

        public InstructionType instructionType { get; set; } = InstructionType.spin;
        public char instruction { get; set; }
    }
}