# ASP.NET + Angular Application

This project is a template-based application created using Visual Studio. It includes an ASP.NET Core backend and an Angular frontend. The project follows the N-Layer/Onion architecture and incorporates several modern development patterns and tools such as AutoMapper, FluentValidation, CQRS Pattern, and Entity Framework.

## Prerequisites

Ensure you have the following installed on your machine:

- **.NET SDK**: Version 8.0
- **Node.js**: Version 18.13.0
- **Angular CLI**: Version 17.3.8

## Technologies Used

- **Backend**: ASP.NET Core
- **Frontend**: Angular
- **Styling**: Bootstrap
- **Architecture**: N-Layer/Onion
- **Patterns**: CQRS
- **Mapping**: AutoMapper
- **Validation**: FluentValidation
- **ORM**: Entity Framework

## Getting Started

### Build and Run the Application

1. **Navigate to the Server Project Directory**:
    ```bash
    cd path/to/Exam.Server
    ```

2. **Restore Dependencies**:
    ```bash
    dotnet restore
    ```

3. **Build the Project**:
    ```bash
    dotnet build
    ```

4. **Run the Application**:
    ```bash
    dotnet run
    ```

5. **Open Your Browser** and navigate to `http://localhost:5000` or the URL provided in the console output.

### Testing the Application

#### Backend Tests

1. **Navigate to the Backend Test Project**:
    ```bash
    cd path/to/Exam.Application.UnitTest
    ```

2. **Run the Tests**:
    ```bash
    dotnet test
    ```

#### Frontend Tests

1. **Navigate to the Frontend Directory**:
    ```bash
    cd path/to/exam.client
    ```

2. **Run the Tests**:
    ```bash
    ng test
    ```

### Folder Structure

```plaintext
.
├── Backend
│   ├── Exam.Application
│   ├── Exam.Domain
│   ├── Exam.Infrastructure
│   ├── Exam.Server
│   └── Exam.Application.UnitTest
└── Frontend
    └── exam.client
