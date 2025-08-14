# DND Battler

A console game allowing users to run battle simulations between various characters. To see the full constraints and rules refer to the following brief: 
## Specification
- Each player will create a team of 3 characters. The options are:
  - Fighter
  - Wizard
  - Cleric

The team can be any combination of these characters, but each team must have exactly 3 characters.

The battle will then be simulated in a turn-based manner, where each character in a team takes turns to attack a member of the opposing team randomly. The battle will be played out until all three members of one team have no health and are defeated.

### Classes
Each class has a `Health` property, an `Attack` property. When a class is created the health and attack is given a separate random value between 1 and 10. The classes also have the following properties:
- **Warrior:** The Warrior gets a bonus of 5 to their health regardless of the random value.
- **Wizard:** The Wizard's attack is doubled regardless of the random value but looses 1 health point when they attack.
- **Cleric:** The Cleric can heal themselves for 1 health point whenever they attack.

### Battle Simulation
- Each player will take turns deciding on their 3 players to create a team. They will then give the team a name
- Once this is done, the system will simulate the battle by alternating turns between the two teams and reporting on the battle using a logger or console window.
- During the battle, the system should report on the current health of the remaining characters in each team after each turn.
- The battle continues until one team has no remaining characters.

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

### Assumptions/Changes From Brief

- I have asked users for a team name before creating characters as it flowed better than the opposite in my opinion.



