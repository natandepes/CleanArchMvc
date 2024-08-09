# Clean Architecture Project

## Overview

This project is built using the principles of Clean Architecture, as proposed by Uncle Bob (Robert C. Martin). Clean Architecture aims to create systems that are easy to maintain, test, and extend by adhering to key principles like separation of concerns, dependency inversion, and modularity.

The project is divided into the following layers:

- **Application**: Contains the application's use cases and business logic.
- **Domain**: Contains the core domain entities, interfaces, and domain services.
- **Infra.Data**: Handles data persistence and access, such as repositories and database contexts.
- **Infra.IoC**: Handles Dependency Injection (IoC) for the entire application.
- **WebUI**: Represents the presentation layer, including controllers, views, and APIs.

## Project Structure

### 1. Application

The `Application` layer holds the use cases and business logic of the application. This layer is responsible for coordinating the workflow and executing the business rules.

**Why?**  
- This layer ensures that business logic is isolated from other layers, promoting reusability and testability.

### 2. Domain

The `Domain` layer represents the core of the application, containing the essential business entities, domain services, and interfaces. The domain layer is independent of any external frameworks or technology.

**Why?**  
- This independence allows the domain to be easily testable and not influenced by external changes, making the core logic of the application stable and adaptable.

### 3. Infra.Data

The `Infra.Data` layer is responsible for handling data access and persistence. This layer contains the implementation of repositories, database contexts, and data-related services. The key principle here is that this layer depends on the domain layer interfaces but not vice versa.

**Why?**  
- By adhering to the Dependency Inversion Principle (DIP), the application remains flexible and can switch to different data storage solutions without affecting the domain or application layers.

### 4. Infra.IoC

The `Infra.IoC` layer handles dependency injection and manages the lifetimes of the dependencies throughout the application. It wires up the necessary services, repositories, and other dependencies that the application needs.

**Why?**  
- Centralizing dependency injection improves maintainability and ensures that the dependencies across different layers are managed consistently.

### 5. WebUI

The `WebUI` layer represents the user interface, including controllers, views, and APIs. This layer interacts with the `Application` layer to handle user requests, execute use cases, and render responses.

**Why?**  
- Keeping the user interface layer separate from the business logic ensures that changes to the UI don't affect the core functionality of the application, leading to a more maintainable and scalable system.

## Clean Architecture Benefits

1. **Separation of Concerns**: Each layer has a distinct responsibility, making the system easier to understand, develop, and maintain.
2. **Testability**: By isolating the domain and application logic from external frameworks, the core business logic can be tested independently.
3. **Flexibility**: The architecture allows you to swap out technologies (e.g., UI frameworks, databases) without impacting the core logic.
4. **Maintainability**: A clear separation of concerns leads to cleaner, more organized code, making it easier to locate and fix issues.
5. **Scalability**: The modular nature of Clean Architecture enables easy extension and modification of the system over time.
