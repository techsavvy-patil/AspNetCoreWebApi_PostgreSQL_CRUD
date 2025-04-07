# AspNetCoreWebApi_PostgreSQL_CRUD

## 📌 Project Overview

This project demonstrates a **Registration Form API** built using **ASP.NET Core 8 Web API** with **PostgreSQL** for data storage. It follows a **Three-Tier Architecture** and uses **Stored Procedures** instead of Entity Framework for database interaction.

---

## 📁 Project Structure
---

## 🛠️ Tech Stack

- ASP.NET Core 8 Web API
- PostgreSQL (with Npgsql)
- Swagger for API Testing
- SHA256 for Password Hashing
- No Entity Framework

---

## 🎯 Features

- ✅ Create new user registrations
- ✅ Retrieve all users
- ✅ Get user by ID
- ✅ Update user details
- ✅ Delete a user
- ✅ Passwords are securely hashed using SHA256
- ✅ API documented via Swagger UI

---

## 🧠 Architecture: Three-Tier

1. **Presentation Layer:** API Controllers handle HTTP requests/responses.
2. **Business Layer:** Contains business logic and validations.
3. **Data Access Layer:** Interacts with PostgreSQL using Npgsql and stored procedures.

---

## 📝 Registration Fields

| Field      | Type      | Description                        |
|------------|-----------|------------------------------------|
| Id         | Integer   | Primary Key, Auto Increment        |
| FullName   | Varchar   | User's full name                   |
| Email      | Varchar   | Must be unique                     |
| Phone      | Varchar   | Contact number                     |
| Password   | Varchar   | Stored as hashed (SHA256)          |
| CreatedAt  | Timestamp | Automatically set on creation      |

---

## 🔐 Security

- Passwords are hashed using SHA256 before storing in the database.
- No plain-text password storage.
- SQL injection prevention through parameterized queries.

---

## 🧾 Stored Procedures

Stored procedures/functions are used for all CRUD operations:
- `create_user`
- `get_all_users`
- `get_user_by_id`
- `update_user`
- `delete_user`

All procedures include:
- Input validation
- Error handling using `BEGIN...EXCEPTION...END`

> 📄 See `StoredProcedures.sql` for full definitions.

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or VS Code

---

### 🛠️ Setup Instructions

1. **Clone the repo**
   ```bash
   git clone https://github.com/techsavvy-patil/AspNetCoreWebApi_PostgreSQL_CRUD.git
   cd AspNetCoreWebApi_PostgreSQL_CRUD
