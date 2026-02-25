# 📚 Library Management MVC

**Library Management MVC** is an ASP.NET Core MVC web application that demonstrates a clean and structured approach to building web applications using **Layered Architecture**, **Service Layer**, and **Repository Pattern**.

The system allows managing **Books**, **Authors**, and **Categories** while maintaining relationships between entities and separating business logic from data access logic.

---

## 🚀 Features

* 📖 Book management
* ✍️ Author management
* 🏷 Category management
* ✅ Full CRUD operations
* 🔗 Book–Author–Category relationships
* ✔ Server-side validation
* ⚙ Dependency Injection
* 🗄 Entity Framework Core integration
* 🧱 Clean MVC architecture

---

## 🏗 Architecture

The project follows **ASP.NET Core MVC** combined with a layered architecture:

```
Controller
    ↓
Service Layer (Business Logic)
    ↓
Repository Layer (Data Access)
    ↓
Entity Framework Core
    ↓
SQL Server Database
```

### Layer Responsibilities

**Controllers**

* Handle HTTP requests and responses
* Communicate only with services
* Do not access the database directly

**Services**

* Contain business logic
* Validate data
* Coordinate repositories

**Repositories**

* Perform CRUD operations
* Work with a single entity
* Isolate database access

**Data Layer**

* `LibraryDbContext` manages EF Core database interaction

---

## 🧰 Technologies

* ASP.NET Core MVC
* C#
* Entity Framework Core
* SQL Server
* Razor Views
* LINQ
* Dependency Injection

---

## 📂 Project Structure

```
LibrarySystem
│
├── Controllers/
│   ├── BooksController.cs
│   ├── AuthorsController.cs
│   ├── CategoriesController.cs
│   └── HomeController.cs
│
├── Models/
│   ├── Book.cs
│   ├── Author.cs
│   ├── Category.cs
│   └── ErrorViewModel.cs
│
├── Services/
│   ├── Interfaces/
│   │   ├── IBookService.cs
│   │   ├── IAuthorService.cs
│   │   └── ICategoryService.cs
│   │
│   ├── BookService.cs
│   ├── AuthorService.cs
│   └── CategoryService.cs
│
├── Repositories/
│   ├── Interfaces/
│   │   ├── IBookRepository.cs
│   │   ├── IAuthorRepository.cs
│   │   └── ICategoryRepository.cs
│   │
│   ├── BookRepository.cs
│   ├── AuthorRepository.cs
│   └── CategoryRepository.cs
│
├── Data/
│   └── LibraryDbContext.cs
│
├── Migrations/
├── Views/
├── wwwroot/
└── Program.cs
```

---

## ⚙️ Dependency Injection

Repositories and services are registered in `Program.cs`.

Example:

```csharp
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
```

ASP.NET Core automatically resolves dependencies using the built-in DI container.

---

## 🗄 Database Configuration

Database connection string is located in:

```
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "LibraryConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LibraryDb;Trusted_Connection=True;"
}
```

---

## ▶️ Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/DmytroHron/library-management-mvc.git
cd library-management-mvc
```

---

### 2. Apply database migrations

```bash
dotnet ef database update
```

---

### 3. Run the application

```bash
dotnet run
```

After launching, the application URL will appear in the console output, for example:

```
Now listening on: https://localhost:xxxx
```

The browser may open automatically depending on local launch settings.

---

## 🔄 Application Flow

```
User Request
      ↓
Controller
      ↓
Service (Business Logic & Validation)
      ↓
Repository
      ↓
Database
      ↓
View Response
```

---

## 🧠 Design Principles

* MVC Pattern
* Separation of Concerns
* Dependency Injection
* Repository Pattern
* Service Layer Pattern
* Clean Code Practices

---

## 📈 Possible Improvements

* Authentication & Authorization
* REST API layer
* DTOs & AutoMapper
* Pagination & Search
* Unit Testing
* Logging
* Docker support

---

## 📄 License

This project is created for educational purposes.

---

## 👨‍💻 Author

Developed by **Dmytro Hron** as an ASP.NET Core MVC architecture practice project.
