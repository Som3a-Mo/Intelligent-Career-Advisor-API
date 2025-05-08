**# Intelligent Career Advisor API**

A robust ASP.NET Core Web API that provides user authentication, profile management, and job application tracking features. It leverages JWT for secure authentication, ASP.NET Identity for user management, FileHelpers for file uploads, and FluentValidation for request validation.

---

## Table of Contents

* [Features](#features)
* [Prerequisites](#prerequisites)
* [Getting Started](#getting-started)

  * [Clone Repository](#clone-repository)
  * [Configuration](#configuration)
  * [Database Migration](#database-migration)
  * [Run the Application](#run-the-application)
* [API Endpoints](#api-endpoints)

  * [Authentication](#authentication)
  * [Account Management](#account-management)
  * [Job Applications](#job-applications)
* [Project Structure](#project-structure)
* [Contributing](#contributing)
* [License](#license)

---

## Features

* **User Registration & Login** using ASP.NET Identity and JWT tokens
* **Email Confirmation** and **Password Reset** via tokenized email links
* **Profile Management**: Create, view, update user profiles with profile picture & resume uploads
* **Job Application Tracking**: CRUD operations for user-specific job applications with file attachments
* **Validation**: FluentValidation for robust request validation
* **File Storage**: FileHelpers utility for saving and deleting uploads
* **Swagger / OpenAPI** documentation

---

## Prerequisites

* [.NET SDK 7.0 or later](https://dotnet.microsoft.com/download)
* [SQL Server](https://www.microsoft.com/sql-server)
* SMTP server credentials (for sending emails)

---

## Getting Started

### Clone Repository

```bash
git clone https://github.com/Som3a-Mo/intelligent-career-advisor.git
cd intelligent-career-advisor
```

### Configuration

Copy `appsettings.json.example` to `appsettings.json` and update the following sections:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=CareerAdvisorDb;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "YourSecureKeyHere",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience",
    "ExpiryDays": 7
  },
  "MailSettings": {
    "Host": "smtp.example.com",
    "Port": 587,
    "Mail": "no-reply@example.com",
    "Password": "YourEmailPassword"
  }
}
```

Ensure `WebRootPath` folder exists for file uploads (e.g. `wwwroot/images`, `wwwroot/files`).

### Database Migration

Use EF Core tools to create and apply migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Run the Application

```bash
dotnet run
```

The API will be available at `https://localhost:5001` (or as configured).

---

## API Endpoints

### Authentication

| Method | Route                             | Description                                |
| ------ | --------------------------------- | ------------------------------------------ |
| POST   | `/auth/register`                  | Register a new user                        |
| POST   | `/auth/confirm-email`             | Confirm user email with token              |
| POST   | `/auth/resend-confirmation-email` | Resend email confirmation token            |
| POST   | `/auth/login`                     | Login user and receive JWT + refresh token |
| POST   | `/auth/refresh`                   | Refresh JWT using a valid refresh token    |
| POST   | `/auth/revoke-refresh-token`      | Revoke a refresh token                     |
| POST   | `/auth/forget-password`           | Send password reset token to email         |
| POST   | `/auth/reset-password`            | Reset password using token                 |

### Account Management

> **Authenticated endpoints** — include `Authorization: Bearer <token>` header.

| Method | Route                  | Description                           |
| ------ | ---------------------- | ------------------------------------- |
| GET    | `/me`                  | Get current user's profile            |
| POST   | `/me/add-profile-data` | Create initial profile data + uploads |
| PUT    | `/me/info`             | Update profile details + uploads      |
| PUT    | `/me/change-password`  | Change user password                  |

### Job Applications

> **Authenticated endpoints** — include `Authorization: Bearer <token>` header.

| Method | Route                  | Description                          |
| ------ | ---------------------- | ------------------------------------ |
| GET    | `/JobApplication`      | List all job applications for user   |
| GET    | `/JobApplication/{id}` | Get a specific job application by ID |
| POST   | `/JobApplication`      | Create a new job application         |
| PUT    | `/JobApplication/{id}` | Update existing job application      |
| DELETE | `/JobApplication/{id}` | Delete a job application             |

---

## Project Structure

```
/Controllers       # API controllers
/Contracts         # DTOs & Validators
/Helpers           # Utility classes (FileHelpers, JwtProvider)
/Models            # EF Core entities & Identity user
/Services          # Business logic services
/DependencyInjection.cs  # DI registration & configuration
/appsettings.json  # Configuration file
/Program.cs        # Main entry point
```

---

## Contributing

Contributions are welcome! Please open issues or submit pull requests for enhancements or bug fixes.

---

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
