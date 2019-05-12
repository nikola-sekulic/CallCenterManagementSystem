# CallCenterManagementSystem
 
 ![Capture](https://user-images.githubusercontent.com/48560426/57133504-3fdc2680-6da3-11e9-83ce-d88f75abdecc.JPG)
 
Call center management  web application to support requirement which is that buyer buy device and get registered, after that, they call an agent if they have problem with that device. By default the reclamation gets a pending status because it needs to be reviewed, if warranty is valid. After that, the supervisor is going to work out the reclamation type and specialist who will repair device.

# Frameworks - Libraries
1. ASP.NET MVC (version 5)
2. Entity Framework
3. Automapper
4. Bootstrap
5. Bootbox
6. Toastr
7. Typeahead
8. Pikaday

# Running Project
- Open the project with Visual Studio.

- If you get csc.exe error, in package manager console, run the following command:
```
  - Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
  - update-database
```
- If you get error: "Cannot attach the file as database" in package manager console, run the following command:
```
  - sqllocaldb stop MSSQLLocalDB
  - sqllocaldb delete MSSQLLocalDB
```

- Run the project. Go to http://localhost:xxxx/Account/Register to add user.

- Or login with this account: admin@webshop.com password: admin1
