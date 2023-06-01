# AdaBattleships - README

## Challenge Outline

### Summary and Review
Ada Battleships is a .NET console adaptation of the classic paper-based game Battleships. The objective of the game is to strategically place your ships on a grid and take turns attacking the opponent's grid to sink their ships. The game incorporates object-oriented design principles and follows an agile development approach.

### UML Style Diagram
![AdaShip UML Diagram](https://cloud.solarsentinels.co.uk/DuBO8/QEbuhoBA17.png/raw)

The UML diagram illustrates the initial overall solution for Ada Battleships. It showcases the main classes and their relationships, such as the `Game`,`Menu`, `Player`, `Board`, and `Ship` classes.

### Initial Working Plan and Approach
To develop Ada Battleships, I followed an iterative and agile development approach. The plan included the following key components:
- Defining and implement the basic game structure, including the `Menu` and `Game` class and their core functionality.
- Designing the `Player` class to manage each player's board and ships.
- Creating the `Board` class to represent the game grid and handle ship placement and attacks.
- Implementing the `Ship` class to represent individual ships with their properties and status.
- Incorporating testing and quality assurance practices to ensure a robust and bug-free game.

### Analysis and Decomposition
The overall problem of Ada Battleships is decomposed into several key epic-style tasks:
1. User interface and input handling: Develop a user-friendly console interface to interact with the game and handle user input effectively.
2. Game logic implementation: Implement the core game logic, including ship placement, attacking, and checking for game-ending conditions.
3. Error handling and validation: Ensure the game handles invalid inputs and provides appropriate error messages to users.
4. AI opponent: Creating an AI computer opponent to provide a single-player mode for the game.
5. Testing and quality assurance: Thoroughly test the game to identify and fix any bugs or issues, ensuring a reliable and enjoyable user experience.

### Initial Object-Oriented Design
The object-oriented design of Ada Battleships revolves around the following key principles:

- Encapsulation: Each class encapsulates its data and provides well-defined methods for accessing and modifying it.
- Inheritance: The `RealPlayer` and `AIPlayer` classes inherit from a base `PlayerBase` class, allowing for code reuse and customization.
- Polymorphism: The `Game` class utilizes polymorphism to support different types of players, such as a human player and an AI opponent.

## Development

### Adoption of Good Standards
Throughout the development process, I have adhered to good coding standards and best practices. This included:
- Writing clean and readable code with meaningful variable and method names.
- Following proper code indentation and formatting conventions.
- Utilizing appropriate design patterns and principles to ensure maintainability and extensibility of the codebase.

### Phase 1 Development
During the initial development phase, I focused on the following tasks:
1. Created folder structure for project.
2. Created Interfaces such as `IMenu,` and `IPlayer`.
3. Laid the ground work for the menu system.
4. Templated the Grid.
5. Implemented a JSON configuration system for the game with basic draft settings.

### Phase 2 Development
1. Implementing the basic game structure and the menu (console-based menu) from the interfaces created previously.
2. Creating the `Player` class and its associated functionality for managing the board and ships.
3. Developing the `Board` class to handle ship placement and attacks.
4. Implemented the `Ship` class to represent individual ships with their properties and status.
5. Created the `PrintBoard` method to handle the display of the board in the console UI whilst incorporating the different ways that the board is expected to be printed aka different colours, letters and numbers used for the ships, hits, misses and coordinates.
6. Working on other features such as `Player vs Player` and `Player vs Computer` functionality.
7. Added automatic ship placement functionality.

### Phase 3 Development
1. Refactoring and optimizing code for improved performance and maintainability.
2. Added Manual ship placement functionality.
3. Added Utilities Class with methods included in this class such as `IntToLetter`, `LetterToInt` and `GetShipInPosition`, these are helpful functions which are used in the game functionality.
4. Conducting tests to verify the correctness of the implemented features. 
5. Conducting code reviews to ensure code quality and adherence to best practices.

### Ensuring Quality through Testing and Bug Resolution
To ensure high quality and reliability, Ada Battleships undergoes rigorous testing and quality assurance. This included:
- Unit tests: Writing unit tests to validate the behavior of individual components and functionalities.
- Integration tests: Conducting integration tests to verify the interaction between different modules.
- System tests: Performing system tests to validate the overall behavior and functionality of the game.
- Bug resolution: Identifying and resolve any bugs or issues encountered during testing to ensure a smooth and error-free gameplay experience.

## Evaluation

### Analysis of Key Code Refactoring, Reuse, and Smells
During the development of Ada Battleships, I actively took opportunities for code refactoring and reuse. This included:
- Identifying and eliminating code smells, such as duplicated code or overly complex methods.
- Refactoring code to improve readability, maintainability, and adherence to coding standards.
- Reusing existing code modules or components to minimize redundancy and improve efficiency.

### Implementation of Advanced Programming Principles
Ada Battleships has advanced programming principles to enhance its functionality and design. This included:
- Utilization of inheritance and polymorphism to facilitate code reuse and flexibility.
- Application of solid principles to ensure modularity, extensibility, and testability of the codebase.

### Features Showcase and Embedded Innovations
Ada Battleships offers various features and innovations to enhance the gameplay experience. These include:
- Multiplayer mode: Players can compete against each other or against an AI opponent
- Customizable game settings: The grid size, ship configurations, and game rules can all be configured using the config.json file.