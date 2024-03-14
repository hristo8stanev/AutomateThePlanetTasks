# PostmanAPITesting Project

- This repository contains the PostmanAPITesting  project, which is a demonstration API for a media store. Follow the instructions below to set up and run the project.

## Prerequisites

- Visual Studio
- .NET SDK
- Postman

1. Open the solution file (`MediaStore.Demo.API.sln`) in Visual Studio. You can run the project from the command line with `dotnet run` in the project directory.

## Running Requests in Postman

### Manual Execution

1. Open Postman.
2. Import the provided collection (`MediaStore.postman_collection.json`) and environment (`MediaStore.postman_environment.json`) files into Postman.
3. Ensure that the environment variables are set correctly according to your API configuration.
4. Manually run each request in the collection against the running API to test various endpoints and scenarios.

### Batch File Execution

1. Ensure that the API project is running.
2. Open the provided batch file `runPostmanProject.bat`.
3. Double-click the batch file to execute it.
4. Postman will automatically open with the imported collection and environment. 
5. The requests will be automatically executed against the running API.
6. You can find the Report in `newman` folder.

## Notes

- Ensure that the API is running before executing requests in Postman.
- Customize the environment variables in the Postman environment file to match your API configuration.
- Make sure to review and understand the requests before running them, especially if the API has authentication or authorization requirements.
- The batch file execution assumes Postman is installed and configured on your system.