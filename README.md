Inventory Management API (Product REST API)

A scalable and maintainable RESTful Backend API built using .NET 10 and ASP.NET Core Web API. 
This project is designed following clean architecture principles and industry best practices.

Project Overview :-

This API provides complete CRUD operations for Product and Item entities, along with authentication, validation, and structured architecture.
The goal of this project is to demonstrate:
1. Clean code practices
2. Scalable architecture
3. Real-world backend development skills


Features :-

1. Product CRUD Operations (Create, Read, Update, Delete)
2. JWT Authentication & Authorization
3. Refresh Token Implementation
4. Role-Based Access Control (Admin/User)
5. Clean Architecture (API, Application, Domain, Infrastructure)
6. Swagger API Documentation
7. Data Validation using FluentValidation
8. Global Exception Handling Middleware
9. Async/Await for better performance


Tech Stack :-

1. Framework: .NET 10
2. API: ASP.NET Core Web API
3. Database: SQL Server + Entity Framework Core
4. Authentication: JWT (Access Token + Refresh Token)
5. Validation: FluentValidation
6. Testing: xUnit
7. Documentation: Swagger 
8. Logging: Built-in logging 


Project Structure :-

Solution/
├── API/            → Controllers, Middleware, Config
├── Application/    → Services, DTOs, Interfaces, Validators
├── Domain/         → Entities, Enums, Exceptions
├── Infrastructure/ → DbContext, Repositories, Identity
├── Tests/          → Unit & Integration Tests


Authentication Flow :-

1. User logs in → receives JWT Access Token
2. Access Token used for API requests
3. Refresh Token used to generate new Access Token
4. Role-based authorization applied to secure endpoints


 How to Run Project :-

Step 1: Clone Repository


git clone https://github.com/RutvikPadole/InventoryAPI.git

cd InventoryAPI


Step 2: Run Project

dotnet run

Step 3: Open Swagger

https://localhost:5118

