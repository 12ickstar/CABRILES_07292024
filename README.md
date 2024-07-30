# CABRILES_07292024


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

### Backend Setup

1. **Navigate to the Backend Directory**:
    ```bash
    cd path/to/backend
    ```

2. **Restore Dependencies**:
    ```bash
    dotnet restore
    ```

3. **Build the Backend**:
    ```bash
    dotnet build
    ```

4. **Run the Backend**:
    ```bash
    dotnet run
    ```

### Frontend Setup

1. **Navigate to the Frontend Directory**:
    ```bash
    cd path/to/frontend
    ```

2. **Install Dependencies**:
    ```bash
    npm install
    ```

3. **Build the Frontend**:
    ```bash
    ng build
    ```

4. **Run the Frontend**:
    ```bash
    ng serve
    ```

### Running the Full Application

1. **Ensure the Backend is Running**:
    ```bash
    cd path/to/backend
    dotnet run
    ```

2. **Ensure the Frontend is Running**:
    ```bash
    cd path/to/frontend
    ng serve
    ```

3. **Open Your Browser** and navigate to `http://localhost:4200`.

### Testing the Application

#### Backend Tests

1. **Navigate to the Backend Test Project**:
    ```bash
    cd path/to/backend/tests
    ```

2. **Run the Tests**:
    ```bash
    dotnet test
    ```

#### Frontend Tests

1. **Navigate to the Frontend Directory**:
    ```bash
    cd path/to/frontend
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
