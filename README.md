# 🏞️ NZWalks API  

![.NET](https://img.shields.io/badge/.NET-8.0-blue)  
![Azure](https://img.shields.io/badge/Deployed%20on-Azure-blue)  

A backend learning project built to explore modern **ASP.NET Core Web API** development practices.  
This API provides CRUD operations for managing walking trails in New Zealand while implementing real-world concepts like authentication, authorization, filtering, and deployment.  

---

## 🚀 Features  

- ✅ **Async/Await** for efficient asynchronous programming  
- ✅ **Filtering, Sorting & Pagination** for flexible data queries  
- ✅ **Authentication & Authorization** with JWT  
- ✅ **Image Upload Functionality** to store and serve images  
- ✅ **Azure Deployment** for cloud hosting  
- ✅ **API Versioning** to support evolving endpoints  
- ✅ **MVC Architecture** for clean separation of concerns  
- ✅ **AutoMapper** for mapping between DTOs and models  
- ✅ **Model Validation** using Data Annotations  
- ✅ **Centralized Logging** for monitoring API activities  
- ✅ **Repository Pattern** for data access abstraction  
- ✅ **Dependency Injection** for clean, testable code  
- ✅ **Entity Framework Core (EF Core)** as ORM  
- ✅ **SQL Server** as database  
- ✅ **Global Exception Handling** for consistent error responses  

---

## 🛠️ Tech Stack  

- **.NET 8 / ASP.NET Core Web API**  
- **Entity Framework Core**  
- **SQL Server**  
- **AutoMapper**  
- **JWT Authentication**  
- **Azure App Service**  

---

## 📂 Project Structure  
NZWalks.API
- │── Controllers/ # API Controllers (Versioned)
- │── Models/ # Domain Models & DTOs
- │── Data/ # DbContext & EF Core Migrations
- │── Repositories/ # Repository Pattern Implementations
- │── Services/ # Business Logic Layer
- │── Middleware/ # Global Exception Handling
- │── Mappings/ # AutoMapper Profiles
- │── wwwroot/ # Image Uploads


---

## 🔑 Getting Started  

### Prerequisites  
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- [SQL Server](https://www.microsoft.com/en-us/sql-server)  
- [Postman](https://www.postman.com/) or similar API client  

### Setup  
1. Clone the repository  
   ```bash
   git clone https://github.com/Hizbucodes/NZWalks.API.git
   cd NZWalks.API

2. Update appsettings.json with your SQL Server connection string.

3. Run migrations to create the database:

4. ```bash
   dotnet ef database update
   
5. Run the API:
6. ```bash
   dotnet run

## 🔒 Authentication & Authorization
JWT-based authentication

Roles supported:
Reader → Can only view walks
Writer → Can add, update, delete walks

## 🌐 Deployment
Deployed on Azure App Service for testing and real-world hosting experience.

## 📸 API Documentation
Swagger UI is enabled for exploring and testing endpoints

## 📖 Lessons Learned
Through this project, I strengthened my backend skills by practicing:

Writing clean, maintainable APIs using best practices.

Applying Repository Pattern & Dependency Injection.

Securing APIs with JWT Authentication.

Handling images, versioning, and logging.

Deploying a .NET API to Azure Cloud.
