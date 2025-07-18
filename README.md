# Alibaba Clone Backend 🚀

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](https://github.com/AminGh05/Alibaba-Clone-Backend)
[![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![License](https://img.shields.io/badge/license-Apache-green)](LICENSE)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-orange)](https://www.microsoft.com/en-us/sql-server)

A comprehensive backend API for an Alibaba.ir clone built with **ASP.NET Core** following **Clean Architecture** principles. This project demonstrates modern software development practices including Domain-Driven Design (DDD), and robust API design for an e-commerce platform.

<div align="center">
    <img src="https://www.milanjovanovic.tech/blogs/mnw_017/clean_architecture.png" alt="Clean Architecture">
</div>

## Table of Contents

- [Features](#features)
- [Architecture Overview](#architecture-overview)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [Roadmap](#roadmap)
- [Support](#support)
- [Acknowledgments](#acknowledgments)
- [License](#license)
- [Order of the Phoenix](#order-of-the-phoenix)

## Features

### Core Functionalities

- 🛍️ **Product Management**: Complete CRUD operations for transportations, users, companies, etc.
- 👥 **User Management**: Authentication, authorization, and user profile management
- 📦 **Order Processing**: Order creation, tracking, and fulfillment workflows
- 🔍 **Advanced Search**: Search with filtering
- 📊 **Analytics & Reporting**: Business intelligence and performance metrics
- 🔐 **Security**: JWT authentication, role-based authorization, and data protection
- 📱 **RESTful APIs**: Clean, documented APIs following REST principles

### Technical Features

- ✅ **Clean Architecture**: Separation of concerns with well-defined layers
- 🎯 **Domain-Driven Design**: Rich domain models and business logic encapsulation
- 📚 **API Documentation**: Swagger specification
- 🔧 **Dependency Injection**: Built-in DI container with service registration

## Architecture Overview

This project follows **Clean Architecture** principles, ensuring maintainability, testability, and scalability:

```bash
┌─────────────────────────────────────────────────────────────┐
│ Presentation Layer                                          │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐  │
│  │   Controllers   │  │    Properties   │  │     Auth    │  │
│  └─────────────────┘  └─────────────────┘  └─────────────┘  │
└─────────────────────────────────────────────────────────────┘
┌─────────────────────────────────────────────────────────────┐
│ Application Layer                                           │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐  │
│  │    Services     │  │      Common     │  │     DTOs    │  │
│  └─────────────────┘  └─────────────────┘  └─────────────┘  │
└─────────────────────────────────────────────────────────────┘
┌─────────────────────────────────────────────────────────────┐
│ Domain Layer                                                │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐  │
│  │    Framework    │  │    Aggregates   │  │    Enums    │  │
│  └─────────────────┘  └─────────────────┘  └─────────────┘  │
└─────────────────────────────────────────────────────────────┘
┌─────────────────────────────────────────────────────────────┐
│ Infrastructure Layer                                        │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────┐  │
│  │   Repositories  │  │   Data Access   │  │  Configurs  │  │
│  └─────────────────┘  └─────────────────┘  └─────────────┘  │
└─────────────────────────────────────────────────────────────┘
```

### Layer Responsibilities

- **Presentation Layer**: Handles HTTP requests, responses, and authentication
- **Application Layer**: Contains business logic, command/query handlers, and application services
- **Domain Layer**: Core business entities, aggregates, and domain services
- **Infrastructure Layer**: Data persistence, external services, and infrastructure concerns

## Prerequisites

Before running this project, ensure you have the following installed:

- **[.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** or later
- **[SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)** (LocalDB, Express, or Full)
- **[Visual Studio 2022](https://visualstudio.microsoft.com/vs/)** or **[Visual Studio Code](https://code.visualstudio.com/)**
- **[Git](https://git-scm.com/)**

### Optional Tools

- **[SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)**
- **[Postman](https://www.postman.com/)** for API testing

## Installation

### 1. Clone the Repository

```bash
git clone https://github.com/AminGh05/Alibaba-Clone-Backend.git
cd Alibaba-Clone-Backend
```

### 2. Configure Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB; Database=Alibaba; Trusted_Connection=true; MultipleActiveResultSets=true"
  }
}
```

### 3. Install Dependencies

```bash
dotnet restore
```

### 4. Run Database Migrations

```bash
dotnet ef database update
```

### 5. Seed Initial Data (Optional)

```bash
dotnet run --seeddata
```

### 6. Start the Application

```bash
dotnet run
```

The API will be available at:

- **HTTPS**: `https://localhost:7131`
- **Swagger UI**: `https://localhost:7131/swagger`

## Usage

### Authentication

Most endpoints require authentication. First, register a user or login:

```bash
# Register a new user
curl -X POST "https://localhost:7131/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "phone": 09000000000
    "email": "user@example.com",
    "password": "Password123!",
    "confirmPassword" : "Password123!"
  }'

# Login
curl -X POST "https://localhost:7131/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{
    "phone": "user@example.com",
    "password": "Password123!"
  }'
```

### Example API Calls

#### Login

```bash
curl -X GET "https://localhost:7131/api/transportations/search" \
  -H "Authorization: Bearer YOUR_JWT_TOKEN"
```

## API Documentation

### Swagger Documentation

Access the interactive API documentation at: `https://localhost:7131/swagger`

### Key Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Authenticate user |
| GET | `/api/transportation/search` | Search for transport |
| GET | `/api/transportation/{id}/seats` | Get product by ID |
| POST | `/api/account/person` | Create a new person by user |
| PUT | `/api/account/email` | Upsert a new email |
| POST | `/api/ticketorder/create-order` | Create a new order |

### Response Format

All API responses follow a consistent format:

```json
{
  "data": {
    // Response data
  },
  "message": "Operation completed successfully"
}
```

## Project Structure

```bash
Alibaba-Clone-Backend/
├── src/
│   ├── AlibabaCone.WebAPI/                # Presentation Layer
│   │   ├── Controllers/                   # API Controllers
│   │   ├── Properties/                    # Custom Middlewares
│   │   ├── Authentication/                # Authentication
│   │   └── Program.cs                     # Application Entry Point
│   │
│   ├── AlibabaCli.Application/            # Application Layer
│   │   ├── Services/                      # Application Services
│   │   ├── DTOs/                          # Data Transfer
│   │   ├── Common/                        # Utils and Profiles
│   │   ├── Result/                        # Presentation layer
│   │   └── Interfaces/                    # Service Interfaces
│   │
│   ├── AlibabaCli.Domain/                 # Domain Layer
│   │   ├── Enums/                         # Domain Enums
│   │   ├── Aggregates/                    # Domain Aggregates
│   │   ├── Framework/                     # Domain Services
│   │       ├── Repositories/              # Repository Interfaces
│   │
│   └── AlibabaCli.Infrastructure/         # Infrastructure Layer
│       ├── Migrations/                    # EF Core Migrations
│       ├── Services/                      # Repository Implementations
│       ├── Framework/                     # Base Classes
│       └── Configurations/                # EF Configurations
```

## Technologies Used

### Backend Framework

- **ASP.NET Core 8.0** - Web framework
- **Entity Framework Core** - Object-Relational Mapping
- **SQL Server** - Primary database
- **AutoMapper** - Object-to-object mapping

### Security & Authentication

- **JWT Bearer Authentication** - Token-based authentication
- **ASP.NET Core Identity** - User management
- **BCrypt.NET** - Password hashing

### Documentation & Validation

- **Swagger** - API documentation
- **Data Annotations** - Input validation

### Development Tools

- **Visual Studio 2022** - IDE
- **Git** - Version control

## Contributing

We welcome contributions! Please follow these guidelines:

### Development Setup

1. Fork the repository
2. Create a feature branch:

   ```bash
   git checkout -b feature/amazing-feature
   ```

3. Make your changes and add tests
4. Ensure all tests pass:

   ```bash
   dotnet test
   ```

5. Commit your changes:

   ```bash
   git commit -m "Add amazing feature"
   ```

6. Push to your branch:

   ```bash
   git push origin feature/amazing-feature
   ```

7. Open a Pull Request

### Code Style

- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use meaningful variable and method names
- Write comprehensive unit tests
- Document public APIs

### Pull Request Process

1. Update the README.md with details of changes if needed
2. Ensure all tests pass and code coverage is maintained
3. Request review from maintainers
4. Address any feedback from code review

## Roadmap

### Phase 1: Core Features ✅

- [ ] Learn basic software development with ASP.NET Core MVC
- [ ] Choose a big project to create a clone of it
- [ ] Design Database and entities
- [ ] Implement it with ASP.NET Core features and C#

### Phase 2: Enhanced Features 🚧

- [ ] Design business logic and complete the flow for each endpoint, from repositories through services in application and finally, API
- [ ] Seed data to test each endpoint
- [ ] Test it with Postman
- [ ] Debug each flow and sync it with Frontend

## Support

If you encounter any issues or have questions:

### Documentation

- Check the code, it's self-documented and understandable
- Contact with info on [MyProfile](https://www.github.com/AminGh05)
- Review [API Documentation](https://localhost:7131/swagger) for endpoint details

### Getting Help

- 📧 **Email**: <mo.ghoorchian@gmail.com>
- 🐛 **Bug Reports**: [GitHub Issues](https://github.com/AminGh05/Alibaba-Clone-Backend/issues)
- 💡 **Feature Requests**: [GitHub Discussions](https://github.com/AminGh05/Alibaba-Clone-Backend/discussions)

### Common Issues

- **Database Connection**: Ensure SQL Server is running and connection string is correct
- **Migration Issues**: Try `dotnet ef database drop` and `dotnet ef database update`
- **Authentication**: Check JWT token expiration and format

## Acknowledgments

Special thanks to:

- 🎯 **Clean Architecture** concepts by Robert C. Martin
- 🏗️ **Domain-Driven Design** principles by Eric Evans
- 📚 **ASP.NET Core Documentation** and community

### Third-Party Libraries

- [AutoMapper](https://automapper.org/) - Object-to-object mapping
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) - API documentation

### Inspiration

- **Alibaba.ir** - Original platform inspiration
- **Clean Architecture Community** - Architecture patterns
- **Microsoft Documentation** - Best practices and examples

## License

This project is licensed under the Apache License - see the [LICENSE](LICENSE) file for details.

## Order of the Phoenix

All this idea and project is come from a group of friends. Team work, movement and learning as motivation and persistance could lead us to start a project which was a fascinating experience.

I should specially thank:

- [Mehrdad Shirvani](https://github.com/MehrdadShirvani/)
- [Ali Taherzadeh](https://github.com/AliThz)

For their guidance, help and accompaniment

---

<div align="center">
  <strong>Built with ❤️ by AminGh05</strong>
  <br>
  <sub>⭐ Star this repository if you find it helpful!</sub>
</div>
