# Emergent Solutions Code Challeng for Scott Snyder

## Backend
The backend is a Azure Function application located in the `server` directory of the repo. It was written with VS 2019 using .NET Core 3.1 (.NET Core 5 does not yet support DI within Azure functions as outlined [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection#prerequisites)). To run locally, open the solution in VS and run.

## UI
The UI is located in the `client` directory of the repo. It is a React app written in VS Code. To run locally, perform the standard npm commands (`npm i` and `npm start`) from the `client` directory.

## Azure
Both applications are running in Azure and can be accessed [here](https://sasemergent.z19.web.core.windows.net/). Both were deployed directly from their respective IDE's. The backend is a standard Function App. The UI was deployed as a Static Website in Blob Storage.
