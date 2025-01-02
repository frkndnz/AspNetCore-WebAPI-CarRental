# CarRental-WebAPI
A RESTful Web API developed using ASP.NET Core for managing car rentals, including car inventory, rental records, and customer data.
## Project Overview

CarRentalAPI is a Web API developed with ASP.NET Core that allows businesses to manage their car rental operations. The API supports the creation, retrieval, updating, and deletion of car, customer, and rental records. It integrates with a SQL Server database to persist data and provides Swagger documentation for easy testing and interaction with the API.
## Features:
- CRUD operations for cars, customers, rentals, and categories
- AutoMapper for object-to-object mapping
- FluentValidation for input validation
- SQL Server database integration
- Swagger API documentation for easy testing and interaction
- Data validation and error handling
## API Usage

Once the app is running, you can test the endpoints using Swagger UI at `http://localhost:5000/swagger`.

### Example API Requests:

- **GET /api/cars**  
  Retrieve all cars in the inventory:
  ```bash
  GET /api/cars
- **POST /api/cars**  
  Add a new car to the inventory:
  ```bash
  POST /api/cars
  Content-Type: application/json
  Body: 
  {
    "brand": "Toyota",
    "model": "Camry",
    "categoryId": 1,
    "price": 45,
    "status": true
  }
- **GET /api/rentals/{id}**  
  Retrieve details of a specific rental by ID:
  ```bash
  GET /api/rentals/1
- **GET /api/rentals/{id}/pdf**  
  Retrieve a PDF document of a specific rental by ID:
  ```bash
  GET /api/rentals/1/pdf
Example output (PDF document):

<img src="https://github.com/frkndnz/AspNetCore-WebAPI-CarRental/blob/main/Images/pdf-example.png" alt="Rental PDF Example" width="500" />
## Swagger UI

You can test the API directly using Swagger UI. To access Swagger UI, run the application and navigate to:

[http://localhost:5000/swagger](http://localhost:5000/swagger)

Example Swagger UI screen:

![Swagger UI Example](https://github.com/frkndnz/AspNetCore-WebAPI-CarRental/blob/main/Images/swaggerExample.png)

