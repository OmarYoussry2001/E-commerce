# 🕒 Watch Store Web App

A full-stack **.NET Core MVC** web application for selling watches, built using **N-Layer Architecture** with clean separation of concerns. The application supports dynamic product listings, admin features, and structured logging.

---

## 🔧 Tech Stack

- ASP.NET Core MVC  
- Entity Framework Core  
- N-Layer Architecture  
- Serilog Logging  
- AutoMapper  
- SQL Server

---

## 🧠 Architecture

This project follows a multi-layered (N-Layer) design:

- **UI Layer**: MVC Views and Controllers  
- **Business Layer**: Business logic and service interfaces  
- **Data Access Layer (DAL)**: EF Core + Generic Repository + Unit of Work  
- **Domain Layer**: Entities and Views  
- **Resources**: (for localization and globalization)

---

## 💡 Features

- 🛍️ Dynamic Product Listing (by Type, price, etc.)  
- 🔐 Admin Panel for product and category management  
- 📦 CRUD operations using Generic Repository + Unit of Work  
- 🧩 Clean Mapping using AutoMapper  
- 📝 Structured Logging using Serilog  
- 🧼 Clean code structure following SOLID principles

---

