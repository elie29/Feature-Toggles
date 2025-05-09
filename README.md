# 🏢 HR Sample Application with Feature Toggles

This is a simple HR web application that demonstrates the use of feature toggles in a real-world scenario. The application includes a new performance review system that can be toggled on/off using feature flags.

## ✨ Features

- 👥 Employee management
- 📊 Performance review system (feature toggled)
- 🔌 RESTful API endpoints
- 📚 Swagger documentation
- 🎛️ Multiple feature toggle methods (Environment Variables & Headers)

## 🛠️ Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or VS Code

## 🚀 Getting Started

1. Clone the repository
1. Navigate to the project directory:

```bash
cd src/HrWebApp.Api
```

1. Run the application:

```bash
dotnet run
```

The API will be available at `http://localhost:5000`

## 📡 API Endpoints

### 👥 Employee Management

- GET `/api/employees` - Get all employees
- GET `/api/employees/{id}` - Get employee by ID

### 📊 Performance Review System (Feature Toggled)

- GET `/api/employees/{id}/performance-review` - Get performance review for an employee
- POST `/api/employees/{id}/performance-review` - Create a new performance review

## ⚙️ Feature Toggle Configuration

The performance review system can be enabled using either environment variables or HTTP headers.

### 🔧 Using Environment Variables

Set the environment variable before running the application:

```bash
# Windows
set FeatureManagement__NewPerformanceReviewSystem=true

# Linux/macOS
export FeatureManagement__NewPerformanceReviewSystem=true
```

### 🎯 Using HTTP Headers

Send requests with the `X-Feature-Flag` header:

```bash
# Enable the feature
curl -H "X-Feature-Flag: NewPerformanceReviewSystem=true" http://localhost:5000/api/employees/1/performance-review

# Disable the feature
curl -H "X-Feature-Flag: NewPerformanceReviewSystem=false" http://localhost:5000/api/employees/1/performance-review
```

## ⚠️ Error Handling

When the performance review system is disabled, attempting to access performance review endpoints will return a 400 Bad Request with the message "The new performance review system is not enabled."

## 📄 License

This project is licensed under the MIT License.
