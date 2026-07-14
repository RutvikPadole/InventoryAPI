# 🛒 Inventory Management API (Product REST API)

## 📌 Project Overview
This project is a RESTful Backend API developed using ASP.NET Core Web API (.NET 10).  
It provides complete CRUD operations for Products along with secure authentication using JWT and Refresh Token strategy.

The application follows a clean and scalable architecture, making it easy to maintain and extend.

---

## 🚀 Features

- ✅ Product CRUD Operations (Create, Read, Update, Delete)
- 🔐 JWT Authentication & Authorization
- 🔁 Refresh Token Implementation
- 👥 Role-Based Access Control (Admin/User)
- 📦 Clean Architecture (API, Application, Domain, Infrastructure)
- 📘 Swagger API Documentation
- ✔️ Data Validation using FluentValidation


## 🛠 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- JWT Authentication

## 📁 Project Structure

InventoryManagementAPI/
│
├── src/
│ ├── API/
│ │ ├── Controllers/
│ │ ├── Middleware/
│ │
│ ├── Application/
│ │ ├── Services/
│ │ ├── Validators/
│ │
│ ├── Infrastructure/
│ │ ├── Data/
│ │ ├── Repositories/
│
├── Program.cs
├── appsettings.json
├── README.md


## ▶️ How to Run Project

### 🔹 Step 1: Clone Repository

```bash
git clone https://github.com/your-username/inventory-api.git
cd inventory-api

🔹 Step 2: Run Project

dotnet run

🔹 Step 3: Open Swagger

https://localhost:5118

🔐 Authentication

Login API

POST /api/auth/login

Request Body
{
  "username": "admin",
  "password": "123"
}


Response
{
  "token": "your-jwt-token"
}
