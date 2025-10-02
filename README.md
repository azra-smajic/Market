# Market

A full-stack web application template for managing an online marketplace.  
Includes a **.NET 8 Web API** backend and a **React + TypeScript** frontend.

---

## 🏗️ Project Structure

- **Market API** — Backend (ASP.NET Core Web API, Entity Framework Core, SQL Server)  
- **Market Web** — Frontend (React + TypeScript, Material UI)  

---

## ⚙️ Tech Stack

**Backend (Market API):**
- C# / ASP.NET Core 8.0  
- Dapper (ORM)  
- PostgreSQL (database)  
- JWT Authentication  
- xUnit (for testing)  

**Frontend (Market Web):**
- Next.js  
- Material-UI (MUI)  
- Fetch (HTTP client)  
- MobX (state management)  

---

## 🚀 Installation & Setup

### Backend (API)

```bash
cd "Market API"
dotnet restore
dotnet build
# configure appsettings.json (ConnectionStrings, JWT Key, etc.)
dotnet ef database update
dotnet run
