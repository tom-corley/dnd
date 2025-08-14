# DND Battler

A console game allowing users to run battle simulations between various characters.

###  Use Guide
To download the game onto your local machine:
1. Run `git clone https://github.com/tom-corley/dnd`

To run the game:
1. Navigate inside the `dndbattler` directory
2. Run `dotnet run`

To run tests:
1. Run `dotnet test` from the root directory of the project

### Implementation

- The character types are implemented as subclasses of an abstract class Character, which override methods where necessary this allows dependency injection on other code using the characters.
- The character types are also stored as an enum, which allows a new character type to be added to the game by adding one line to the enum, and adding another line on the switch statement in the factory.
- A Factory pattern is used to create characters, which is passed a random number generator (C# `Random`) upon construction, which is then used to generate (pseudo)random stats for generated characters.
- Magic numbers have been avoided by keeping constants in a class `GameConstants.cs`, they are initialised to the values prescribed in the brief but things like team size and the possible range of health and damage can easily be edited.
- A Builder pattern is used to construct a Team, this allows characters to be added one at a time, and ensures the team size is correct before allowing building. The builder is passed a character factory to use.
- A Singleton pattern is used for the Logger, this was mapped almost 1-1 from the exercise last week, as it seemed to transfer well to this task.
- The battle loop works by looping over each of the characters with modular arithmetic, randomly selecting a target from the opposing team and skipping any characters that are already dead. The `AttackCharacter` function has responsiblility for producing a string detailing what happened, which is then logged by the logger, along with the health of the characters, and a round change notification.

### Testing

There are five test files (Achieving well above 90% coverage)
1. CharacterTests.cs
    - Basic Unit tests checking behaviour of each of the classes, such as making sure Clerics do not heal above their maximum health, and making sure Wizards can kill themselves through recoil. This also checks the corresponding Factory class works correctly.
2. TeamAndTeamBuilder.cs
    - Unit tests on the Team and TeamBuilder class, checking team size is correct, and that teams can be named correctly
3. LoggerTests.cs
    - Simple unit tests checking the logger works correctly
4. BattleEngineTests.cs
    - A simple unit test checking that the game runs to completion and correctly deals with dead players.
5. InputAndProgramTests.cs
    - Unit tests checking that user input is processed correctly and that the whole application runs to completion when given suitable input.



