# 👥 Employee Management System

> *A robust, full-featured administrative dashboard built to manage departments, employees, users, and roles with complete CRUD capabilities.*

## 🌐 Live Demo & Repository
* **🌍 Live App:** [Employee Management System on MonsterASP](http://employee-management-system01.runasp.net/)

## 📝 Project Overview
This project is a comprehensive Employee Management System designed with a focus on clean code, maintainability, and security. It provides a responsive administrative dashboard for managing company resources efficiently, featuring secure role-based access control and robust data validation.

## 🏗️ Architecture & Design Patterns
To ensure high maintainability and a strict separation of concerns, the solution is architected using:
* **3-Tier Architecture:** * **Presentation Layer (PL):** ASP.NET Core MVC, ViewModels, and Bootstrap for a responsive UI.
  * **Business Logic Layer (BLL):** Encapsulates core business rules and services.
  * **Data Access Layer (DAL):** Manages database connections and schema.
* **Repository Pattern:** Implemented to optimize database operations and decouple data access logic from the rest of the application.

## ✨ Key Features
* **🛡️ Identity & Security:** Integrated **ASP.NET Core Identity** for secure user authentication, authorization, and dynamic Role-Based Access Control (RBAC).
* **⚙️ Complete CRUD Operations:** Full administrative management capabilities for Departments, Employees, Users, and Roles.
* **🔍 Search & Validation:** Implemented efficient search functionalities across the dashboard and robust data validation mechanisms.
* **📱 Responsive UI:** Designed a clean, interactive, and mobile-friendly user interface utilizing **Bootstrap**.

## 🛠️ Technologies & Tools
* **Backend:** ASP.NET Core MVC (.NET)
* **ORM:** Entity Framework (EF) Core
* **Security:** ASP.NET Core Identity
* **Frontend:** HTML5, CSS3, Bootstrap, Razor Views
* **Design Patterns:** 3-Tier Architecture, Repository Pattern
* **Deployment & Hosting:** Deployed and hosted live on **MonsterASP (RunASP)**.
