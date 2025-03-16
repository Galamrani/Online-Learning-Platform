# Online Learning Platform

## Overview

This project is an Online Learning Platform that allows users to access various courses and learning materials. It provides features such as user registration, course enrollment, and progress tracking.

## Features

- User Registration and Authentication
- Course Catalog
- Course Enrollment
- Progress Tracking
- Interactive Quizzes

## Code Structure

The project is structured as follows:

### Backend (API)

- **Controllers**: Handles HTTP requests and responses.
- **Data**: Contains database context, repositories, and seed data.
- **Migrations**: Manages database schema changes.
- **Middleware**: Custom middleware for handling requests and responses.
- **Models**: Defines the data models and mapping profiles.
- **Program.cs**: Configures and runs the application.

### Frontend (Client)

- **Components**: Contains Angular components for different parts of the application.
- **Services**: Handles business logic and API interactions.
- **Interceptors**: Manages HTTP request and response interception.
- **Models**: Defines the data models used in the frontend.
- **Stores**: Manages application state using services.
- **Routes**: Configures application routes.
- **Utils**: Contains utility functions.

## Code Base

### Backend

- **Program.cs**: Configures services, middleware, and the HTTP request pipeline.
- **MappingProfiles.cs**: Configures AutoMapper profiles for mapping between models and DTOs.
- **LessonController.cs**: Manages lesson-related endpoints.
- **CourseController.cs**: Manages course-related endpoints.
- **LearningPlatformDbContext.cs**: Configures the database context and relationships.
- **Repositories**: Contains repository classes for accessing data.
- **SeedData.cs**: Provides initial data for the database.
- **UnauthorizedActionFilter.cs**: Handles unauthorized access attempts globally.

### Frontend

- **main.ts**: Bootstraps the Angular application.
- **app.config.ts**: Configures application-wide providers and settings.
- **app.routes.ts**: Defines the routes for the application.
- **error-utils.ts**: Utility functions for error handling.
- **user.service.ts**: Manages user-related operations.
- **course-manager.service.ts**: Manages course-related operations.
- **lesson-api.service.ts**: Handles API interactions for lessons.
- **course-api.service.ts**: Handles API interactions for courses.
- **register.component.ts**: Manages user registration.
- **login.component.ts**: Manages user login.
- **server-error.component.ts**: Displays server error messages.
- **edit-lesson.component.ts**: Manages lesson editing.
- **edit-course.component.ts**: Manages course editing.
- **add-lesson.component.ts**: Manages adding new lessons.
- **add-course.component.ts**: Manages adding new courses.
- **course-details.component.ts**: Displays course details.
- **course-catalog.component.ts**: Displays the course catalog.
- **course-card.component.ts**: Displays individual course cards.
- **lesson-card.component.ts**: Displays individual lesson cards.
- **menu.component.ts**: Manages the application menu.

## Design Patterns

- **Repository Pattern**: Used to abstract the data access layer, making it easier to manage and test.
- **Unit of Work Pattern**: Ensures that multiple repository operations are treated as a single transaction.
- **Dependency Injection**: Promotes loose coupling by injecting dependencies into classes rather than hardcoding them.
- **Middleware Pattern**: Used to handle cross-cutting concerns such as logging and authentication in the request pipeline.
- **DTO (Data Transfer Object) Pattern**: Used to transfer data between layers, ensuring that only necessary data is exposed.
- **Observer Pattern**: Used to create a subscription mechanism to allow multiple objects to listen to and react to events or changes in state, ensuring real-time updates and state consistency.
