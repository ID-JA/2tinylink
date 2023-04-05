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
- [x] Standard Link Shortening
  - Anonymous users can shorten links without registration
  - Shortened links redirect to the original URL
- [ ] Pro Link Shortening (for registered users only )
  - Registered users can access this feature to shorten their links with additional features, such as :
    - [x] The expiration date feature allows registered users to set an expiration date for their pro shortening link. This means that after a certain period of time, the link will expire and no longer be accessible. 
- [x] Get Corresponding URL for alias
  - Users can retrieve the original URL for a given alias
- [x] User Registration
  - User can sign up with their first name, last name, username, email and password
  - User receives an email confirmation link to activate their account
- [x] Email Confirmation
  - Users receive an email confirmation link to verify their email address
- [x] User Login
  - Registered users can log in with their email/username and password
- [x] Trial User Login (for testing purposes only) - Superuser has full access to all app features
  - To make it easier for users to test the application, we have added a trial user `Superuser` login feature. Here are the credentials for the trial account:
  ```text
   UserName: john.doe
   Password: Pa$$w0rd
  ```
- [x] Admin User Login (for testing purposes only)
  - To make it easier for users to test the application as an admin, we have added an `Admin` user login feature. Here are the credentials for the admin account:
  ```text
   UserName: admin.user
   Password: Pa$$w0rd
  ```
