Certainly! Below is a simple **README.md** file that provides documentation for a Web API project built using **C# .NET Framework**. It also covers testing the API with **Postman** and using **Swagger** for API documentation, with an example for an **Employee** table.

---

# Web API in C# .NET Framework - Employee Management

This is a simple Web API built using **C# .NET Framework** to manage an **Employee** table. The API allows for CRUD (Create, Read, Update, Delete) operations on employee data, and it's documented with **Swagger**. Additionally, the API can be tested using **Postman**.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Project Setup](#project-setup)
3. [API Endpoints](#api-endpoints)
4. [Testing with Postman](#testing-with-postman)
5. [Swagger Documentation](#swagger-documentation)

## Prerequisites

To run this project, you'll need:

- **Visual Studio** (or any IDE with .NET Framework support)
- **.NET Framework** version 4.7.2 or higher
- **SQL Server** (for database management)
- **Postman** (for testing API endpoints)
- **Swagger** (API documentation and testing)

## Project Setup

### 1. Clone the Repository
To get started, clone the project repository to your local machine:

```bash
git clone https://github.com/yourusername/Web_Api.git
```

### 2. Set up Database
Ensure you have a SQL Server instance running and create a database for the Employee table. You can use the following SQL script to create the **Employee** table:

```sql
CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    DepartmentVARCHAR(100)
);
```

### 3. Update Database Connection String
In the `Web.config` file, update the connection string to point to your SQL Server database.

```xml
<connectionStrings>
    <add name="EmployeeDB" connectionString="Server=YOUR_SERVER;Database=EmployeeDB;Integrated Security=True;" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

# 4. Build and Run the Project
- Open the solution in **Visual Studio** and build the project.
- Press `F5` to run the Web API.

Your API should now be accessible at `http://localhost:port/api/`.

## API Endpoints

Below are the available API endpoints for the **Employee Management** API:
# 1. Create a New Employee
- **Endpoint:** `POST /api/employees`
- **Request Body (JSON):**
  ```json
  {
    "FirstName": "John",
    "LastName": "Doe",
    "Email": "john.doe@example.com",
    "DateOfBirth": "1985-06-15"
  }
  ```
- **Response (200 OK):
  ```json
  {
    "EmployeeId": 1,
    "Name": "John",
    "Email": "john.doe@example.com",
    "Department": "cs"
  }
  ```

## 2. Get All Employees
- **Endpoint:** `GET /api/employees`
- **Response (200 OK):**
  ```json
  [
    {
    "EmployeeId": 1,
    "Name": "John",
    "Email": "john.doe@example.com",
    "Department": "cs"
  }
  ]
  ```

### 3. Get Employee by ID
- **Endpoint:** `GET /api/employees/{id}`
- **Response (200 OK):**
  ```json
  {
    "EmployeeId": 1,
    "Name": "John",
    "Email": "john.doe@example.com",
    "Department": "cs"
  }
  ```

### 4. Update an Employee
- **Endpoint:** `PUT /api/employees/{id}`
- **Request Body (JSON):**
  ```json
  {
    "EmployeeId": 1,
    "Name": "John",
    "Email": "john.doe@example.com",
    "Department": "cs"
  }
  ```
- **Response (200 OK):**
  ```json
  {
    "EmployeeId": 1,
    "Name": "John",
    "Email": "john.doe@example.com",
    "Department": "cs"
  }
  ```

### 5. Delete an Employee
- **Endpoint:** `DELETE /api/employees/{id}`
- **Response (200 OK):**
  ```json
  {
    "message": "Employee deleted successfully"
  }
  ```

## Testing with Postman

You can test all of the above endpoints using **Postman**. Here's how to do it:

1. **Open Postman** and create a new request for each of the API endpoints.
2. Set the request method (GET, POST, PUT, DELETE) and the corresponding URL (`http://localhost:port/api/employees`).
3. For POST and PUT requests, set the request body to the JSON data as shown above.
4. Click **Send** to execute the request and check the response.

## Swagger Documentation

Once your API is running, you can access the **Swagger** UI to test and explore the API documentation.

1. Navigate to the following URL in your browser:
   ```
   http://localhost:port/swagger
   ```
2. The Swagger UI will show all the API endpoints, their methods, and request/response formats.
3. You can also interact with the API directly from Swagger (send requests and view responses).

---

### Example Swagger UI Output

- **POST /api/employees**
    - Send JSON data to create a new employee.
    - Example input and output will be shown interactively.

- **GET /api/employees**
    - Fetch a list of all employees.

- **GET /api/employees/{id}**
    - Fetch employee details by their ID.

- **PUT /api/employees/{id}**
    - Update employee details by their ID.

- **DELETE /api/employees/{id}**
    - Delete an employee by their ID.

## Conclusion

This Web API allows you to perform CRUD operations on an Employee database. It is documented using Swagger and can be tested using Postman for easy interaction with the API endpoints.
