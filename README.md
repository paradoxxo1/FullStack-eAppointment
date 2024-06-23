```markdown
# eAppointment Application

This project is an eAppointment application developed using Angular 17 and .NET 8. The project utilizes advanced concepts and technologies such as Clean Architecture principles, CQRS (Command Query Responsibility Segregation), Result pattern, Automapper, Entity Framework Core, SmartEnum, and JWT (JSON Web Tokens).

## Features

- **CQRS (Command Query Responsibility Segregation)**
- **Clean Architecture Principles**
- **Result Pattern Implementation**
- **ORM Operations with Entity Framework Core**
- **Object Mapping with Automapper**
- **SmartEnum Usage**
- **Secure Authentication and Authorization with JWT**

## Libraries and Technologies Used

### Backend

- **.NET 8**
- **MediatR**
- **JWT**
- **Ardalis**
- **Scrutor**
- **AutoMapper**
- **Entity Framework Core**
- **SmartEnum**

### Frontend

- **Angular 17**
- **form-validate-angular**
- **Visual Studio Code**

## Installation

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js and npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [Visual Studio Code](https://code.visualstudio.com/)

### Steps

1. **Clone the Project Repositories:**

   ```bash
   git clone https://github.com/your_username/eAppointment.git
   cd eAppointment
   ```

2. **Set Up the Backend:**

   ```bash
   cd Backend
   dotnet restore
   dotnet build
   dotnet run
   ```

3. **Set Up the Frontend:**

   ```bash
   cd ../Frontend
   npm install
   ng serve
   ```

4. **Open the Application in Your Browser:**

   The application will run at `http://localhost:4200`.

## Usage

### Backend

- API endpoints start with `/api`.
- The API documentation is available at `http://localhost:5000/swagger` using Swagger UI.

### Frontend

- The user interface is developed with Angular 17.
- Form validations are handled using the `form-validate-angular` library.

## Contributing

To contribute, please create a `fork`, create a new `branch` (`feature-name`), make your changes, and then submit a `pull request`.

## License

This project is licensed under the MIT License. For more information, see the [LICENSE](LICENSE) file.

---

If you found this project useful, please give it a star! ⭐
```
