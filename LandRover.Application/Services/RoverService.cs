using LandRover.Domain.Entities;
using LandRover.Domain.Enums;
using LandRover.Domain.Interfaces.Application.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LandRover.UnitTests")]
namespace LandRover.Application.Services
{
    public class RoverService : IRoverService
    {
        public Rover Navigate(Rover rover, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                rover = NavigateByInstruction(rover, instruction);
            }

            return rover;
        }

        internal Rover NavigateByInstruction(Rover rover, Instruction instruction) 
        { 
            if(instruction.instructionType == InstructionType.spin)
            {
                rover = Spin(rover, instruction);
            }
            else
            {
                rover = MoveFoward(rover, instruction);
            }
            return rover;
        }

        internal Rover MoveFoward(Rover rover, Instruction instruction)
        {
            if(rover.cardinalPoint == CardinalPoint.W || rover.cardinalPoint == CardinalPoint.E)
            {
                rover.coordinate.MoveXAsis(rover.cardinalPoint);
            }
            else if (rover.cardinalPoint == CardinalPoint.N || rover.cardinalPoint == CardinalPoint.S)
            {
                rover.coordinate.MoveYAsis(rover.cardinalPoint);
            }
            return rover;
        }

        internal Rover Spin(Rover rover, Instruction instruction)
        {
            if (instruction.instruction == SpinDirection.L.ToString())
            {
                rover.SpinAntiClockwise();
            }
            else if (instruction.instruction == SpinDirection.R.ToString())
            {
                rover.SpinClockwise();
            }
            return rover;
        }
    }
}