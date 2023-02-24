# LandRover
## _Welcome to LandRover Project_

# Run App
LandRover requires [Dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/) to run.

1. Open project path and navigate to LandRover.UI
```
cd LandRover.UI
dotnet build
dotnet run -- C:\\YourFileName.txt
```
2. To run the unit tests, open  navigate to LandRover.UnitTests
```
cd LandRover.UnitTests
dotnet test
```


## Tools

LandRover is currently using the following tools:

| Tool | Version |
| ------ | ------ |
| xUnit | [2.4.2](https://www.nuget.org/packages/xunit) |
| AutoFixture | [4.18.0](https://www.nuget.org/packages/AutoFixture) |
| FluentAssertions |[6.10.0](https://github.com/FluentAssertions/FluentAssertions/releases/tag/6.10.0) |
| moq | [2.4.2](https://github.com/moq/moq) |
| DependencyInjection | [7.0.0](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection)

# Architecture

The chosen architecture was Onion Archtecture.

## Explaining each layer and its components
The application is divided into 6 layers, which are: Application, Service, Core, Domain, Infra, UI.

- *Domain Layer* is responsible for storing all the entities used by the rest of the project, as well as their behaviors. There are the enumerators, interfaces and business entities.

- *Service Layer* is responsible for storing the business logic of domain objects.

- *Application Layer* is responsible for orchestrating user requests and calling the necessary business logic to fulfill these requests.

- *Infrastructure Layer* is responsible for communicating with external domains to feed the service layer.

- *Core Layer* is there to meet needs that will be common to several other layers of the project.

## How it works:

First, we open the text file using *File Reader* class (which is in the Core layer), then the *LandingPlanRepository* class is responsible for reading the text and transforming it into a navigation plan.
*RoverService* is the class responsible for executing all the movements of a rover according to the instructions received in the navigation plan.
A Rover has coordinates and a heading.
Coordinates can move both in the X axis and in the Y axis, in the positive or negative direction. Which represents the *"M" instruction* of the rover. Its responsible method is called "Move Forward".
In addition, a rover can perform the *Spin movement*, which can be clockwise (*"R" instruction*) or anticlockwise (*"L" instruction*).
Its responsible method is called "Spin".
The *Navigate* method, of the *RoverService* class, receives a Rover as a parameter and a set of instructions and returns the rover in the position resulting from the execution of the instructions.
The *NavigateAllRovers* method of the *RoverApplication* class is responsible for receiving the rovers navigation plan and executing the instructions for each rover and returning to their respective positions after executing the given instructions.

![image](https://user-images.githubusercontent.com/9805258/221267027-9d5c67db-33d5-4537-a71f-b676066b6f81.png)

