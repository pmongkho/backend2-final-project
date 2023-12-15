Thank you for the additional information. I'll update the README file to reflect the specific folder structure of your project, with the ASP.NET Core backend in the "Server" folder and the Angular frontend in the "Client" folder.

---

# Cooler Heater

Cooler Heater is a dynamic project designed to provide functionalities related to drone operations and user management. The application offers an intuitive interface for managing drones and users, making it ideal for scenarios involving drone-based services.

## Getting Started

These instructions will guide you through setting up the Cooler Heater project on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) - Required for the .NET Core 8 backend.
- [MongoDB](https://www.mongodb.com/try/download/community) - Used as the NoSQL database for the project.
- [Node.js](https://nodejs.org/en/) - Needed for running the Angular frontend.
- [Angular CLI](https://cli.angular.io/) - Utilized for Angular development.
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) - Recommended IDEs for development.

### Installing

#### Backend Setup (.NET Core 8 with MongoDB) - Server Folder

1. Ensure MongoDB is operational on your local machine.
2. Navigate to the `Server` folder in the project directory.
3. Restore the .NET dependencies:

   ```bash
   dotnet restore
   ```

4. Start the backend server:

   ```bash
   dotnet run
   ```

   Alternatively, open the solution in Visual Studio and run the project from there.

#### Frontend Setup (Angular) - Client Folder

1. Navigate to the `Client` folder in the project directory.
2. Install required npm packages:

   ```bash
   npm install
   ```

3. Launch the Angular development server:

   ```bash
   ng serve
   ```

   The frontend will typically be accessible at `http://localhost:4200`.

### Application Routes

The Cooler Heater application currently supports the following functional routes:

- `/get-drone`: A route dedicated to retrieving drone information.
- `/users`: Handles various user-related operations including creation, retrieval, and management of user data.

### Running the Tests

(Instructions for running any automated tests for this system, if available.)

### Deployment

(Additional notes about deploying this application on a live system.)

---

**Note**: Ensure MongoDB is properly configured and the connection string is accurately specified in the .NET backend application settings. Adjust the project paths or commands based on the specific structure of the Cooler Heater project. This README provides a foundational outline and should be tailored to fit the specific details of the project.

---

This README now reflects the structure of your project with the backend in the "Server" folder and the frontend in the "Client" folder. You can modify or add more details to this README as needed for your project.