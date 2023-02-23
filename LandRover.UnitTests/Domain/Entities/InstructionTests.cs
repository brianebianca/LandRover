using FluentAssertions;
using LandRover.Domain.Entities;
using LandRover.Domain.Enums;

namespace LandRover.UnitTests.Domain.Entities
{
    public class InstructionTests
    {
        [Theory]
        [InlineData('L',InstructionType.spin)]
        [InlineData('M', InstructionType.move)]
        [InlineData('R', InstructionType.spin)]
        public void InstructionTests_ShouldSetInstructionTypeOnCreation(char instruction, InstructionType expectedType)
        {
            var createdInstruction = new Instruction(instruction);
            createdInstruction.instruction.Should().Be(instruction);
            createdInstruction.instructionType.Should().Be(expectedType);
        }
    }
}