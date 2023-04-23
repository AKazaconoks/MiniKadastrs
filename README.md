# Mini Kadastrs

A web application for managing property transactions and displaying related statistics.

## Features

- Upload and process property transaction data in CSV format
- Display property transactions in a table
- Filter and sort property transactions by region
- Display charts for average price and number of transactions per year
- Responsive design and mobile-friendly layout

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- JavaScript, jQuery, and AJAX
- Chart.js for data visualization
- Bootstrap for responsive design and styling

## Getting Started

### Prerequisites

- .NET Core SDK (version 5.0 or later)
- SQL Server (local or remote instance)

### Installation and Setup

1. Clone the repository:

git clone https://github.com/your-repository-url.git

2. Navigate to the project directory:

cd path/to/your/project

3. Update the connection string in `appsettings.json` to point to your SQL Server instance.

4. Run the following commands to create the database and apply migrations:

dotnet ef database update

5. Run the application:

dotnet run


## Usage

1. Upload a CSV file with property transaction data by clicking on the "Upload CSV" button on the main page.
2. View the property transactions in a table format.
3. Navigate to the "Statistics" page to view charts for average price and number of transactions per year.
4. Use the dropdown menu on the "Statistics" page to filter data by region.

## API

This application also exposes a REST API for managing property transactions.

### Endpoints

- `GET /api/PropertyTransaction`: Retrieve all property transactions
- `GET /api/PropertyTransaction/{id}`: Retrieve a specific property transaction by ID
- `POST /api/PropertyTransaction`: Create a new property transaction
- `PUT /api/PropertyTransaction`: Update an existing property transaction
- `DELETE /api/PropertyTransaction/{id}`: Delete a property transaction

### Usage

You can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to interact with the API.

#### Example: Retrieve all property transactions

curl -X GET https://localhost:44311/api/PropertyTransaction

#### Example: Create a new property transaction
curl -X POST https://localhost:44311/api/PropertyTransaction
-H "Content-Type: application/json"
-d '{"year": "2023-1", "avgPriceRegion1": 1500, "transactionCountRegion1": 50, "avgPriceRegion2": 1000, "transactionCountRegion2": 200, "avgPriceRegion3": 2500, "transactionCountRegion3": 150}'


