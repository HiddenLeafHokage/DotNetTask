Dot NET E-commerce Demo (Onion Slice Architecture)
A modern e-commerce demo app built with:

Backend: .NET 8 (C#), Onion Slice architecture, EF Core with SQL Server Express
Frontend: React (Vite), TypeScript, Tailwind CSS, react-icons

Features

Product catalog (8 Apple products, real images)
Shopping cart (add, update, remove)
User authentication (demo credentials)
Modern, responsive UI


Demo Credentials

Email: chukwukasolomon28@gmail.com
Password: DotNetTask


Project Structure
Ecommerce/
├── backend/                # .NET 8 API (C#)
│   ├── ECommerce.API/      # Main API project
│   ├── ECommerce.Domain/   # Domain models
│   ├── ECommerce.Infrastructure/ # Data, seeding
│   └── ECommerce.Application/    # Application logic
├── frontend/               # React + Vite + Tailwind frontend
└── README.md               # This file


Getting Started
Prerequisites

.NET 8.0 SDK
Node.js and npm for frontend
SQL Server Express installed and running as .\SQLEXPRESS

1. Start the Backend API
Open a terminal in the project root and run:
cd backend/ECommerce.API
dotnet restore
dotnet run


The API now uses SQL Server Express with Windows Authentication.
Database: ECommerceDb (automatically created via migrations).
Swagger UI available at: http://localhost:5234/swagger
Ensure SQL Server Express is running and accessible as .\SQLEXPRESS.

2. Start the Frontend
Open a new terminal in the project root and run:
cd frontend
npm install
npm run dev





Usage

Go to http://localhost:5173
Log in with the demo credentials above
Browse products, add to cart, and checkout


Migration and Seeding

Migration to SQL Server Express: The project was migrated from an in-memory database to SQL Server Express. The connection string is configured in backend/ECommerce.API/appsettings.json using Windows Authentication.
Seeding: Applied migration 20250727191357_SeedInitialProducts to seed 8 Apple products into the Products table. Verify data in SSMS with SELECT * FROM Products.
API Endpoint: Products are accessible at /api/products.

Troubleshooting

Port in use:
Backend: Ensure nothing else is running on port 5234.
Frontend: Ensure nothing else is running on port 5173 (adjust if needed).


SQL Server Connection Issues:
Verify SQL Server Express is running and .\SQLEXPRESS is accessible.
Check appsettings.json for the correct connection string.


Frontend can't connect to backend:
Ensure both servers are running.
Check CORS errors (allowed by default).


Images not loading:
Product images use external URLs; ensure an internet connection.


Migration Issues:
Run dotnet ef database update --startup-project ../ECommerce.API from ECommerce.Infrastructure to reapply migrations.




Tech Stack

Backend: .NET 8, ASP.NET Core, EF Core (SQL Server), Onion Slice
Frontend: React, Vite, Tailwind CSS, react-icons

