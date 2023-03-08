### How to run the web API app ?
- To run the web API app, follow these steps:
1. Make sure you have the [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  installed on your computer.
2. Open your terminal or command prompt and navigate to the server folder of the project.
3. Run the following command to build and run the project:
```bash
dotnet run --project .\src\WebUI\
```
4. If the app is running successfully, you will see output in the terminal similar to this:
```csharp
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5132
```
5. Open a web browser and navigate to `http://localhost:5132` to access the web API.

### API Documentation
- For detailed documentation of the API endpoints, please refer to the Postman collection located [here](2tinylink.postman_collection.json). The collection contains all available endpoints, along with their input parameters and expected responses.

### Implemented Features
- [x] Link Shortening for Anonymous Users
  - Anonymous users can shorten links without registration
  - Shortened links redirect to the original URL
- [x] Get Corresponding URL for address
  - Users can retrieve the original URL for a given address
- [x] User Registration
  - User can sign up with their first name, last name, username, email and password
  - User receives an email confirmation link to activate their account
- [x] User Login
  - Registered users can log in with their email/username and password
- [x] Email Confirmation
  - Users receive an email confirmation link to verify their email address
