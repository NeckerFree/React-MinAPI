# React-MinAPI (Track training App)

## Description

> The purpuse of this project is to implement .NET Minimal Api using SQLite with Code First Model.	
> In addition it is implemented a ReactJS project to consume paginated data in client side.

### Projects 

## reactminapi.dataAccess
1. Create DB Models: 
- User 
- Training 
2. Create local SQLite database RunningDB.db 
3. Create RunningContext and inherit from `DbContext` 
-  add the connection string: `optionsBuilder.UseSqlite(@"DataSource=C:\Temp\RunningDB.db");`
-  reference `DbSet<User>` and `DbSet<Training>`
4. In the Package Manager Console of this project:
- Create initial migration using: `add-migration initial`
- Update database model with: `update-database` to reflect Model First in database
After this the DB and tables should be created. 
5. Create CRUD Repositories: TrainingRepository and UserRepository

## reactminapi.back (.NET Minimal Api Backend)
1. Create project: https://www.c-sharpcorner.com/article/two-ways-to-create-minimal-apis-in-net-6/
2. Add reference to dataAccess project 
3. Modify Program.cs to expose Get an Post Web methods.
4. Test this minimal API

## reactminapi.front
1. Create React project: https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-react?view=vs-2022
2. Reference API project
2. Implement pagination in App.js

### Built With
- SQLite (Code First)
- C#.NET Minimal API
- ReactJS.Net 

### Project Set up

Clone Repository using

`git clone https://github.com/NeckerFree/React-MinAPI`

Move into project directory

`cd React-MinAPI`

Open the app Visual Studio 2022

### Set the statup project

1. In Solution Explorer, right-click the solution name and select Set Startup Project. Change the startup project from Single startup project to Multiple startup projects. Select Start for each project’s action.

2. Next, select the backend project and move it above the frontend, so that it starts up first.

### Start the project
1. Before you start the project, make sure that the port numbers match. Go to the launchSettings.json file in your ASP.NET Core project (in the Properties folder). Get the port number from the applicationUrl property.

If there are multiple applicationUrl properties, look for one using an https endpoint. It should look similar to https://localhost:7049.

2. Then, go to the setupProxy.js file for your React project (look in the src folder). Update the target property to match the applicationUrl property in launchSettings.json. When you update it, that value should look similar to this:

target: 'https://localhost:7049',
To start the project, press F5 or select the Start button at the top of the window. You will see two command prompts appear:

The ASP.NET Core API project running
npm running the react-scripts start command

You should see a React app appear, that is populated via the API.

## Author:

👤 **Elio Cortés**

- GitHub: [@NeckerFree](https://github.com/NeckerFree)
- Twitter: [@ElioCortesM](https://twitter.com/ElioCortesM)
- LinkedIn: [elionelsoncortes](https://www.linkedin.com/in/elionelsoncortes/)

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

Feel free to check the [Issues page](https://github.com/NeckerFree/React-MinAPI/issues).

## Show your support

Give a ⭐️ if you like this project!

## 📝 License

This project is [MIT](./LICENSE) licensed.
Give a ⭐️ if you like this project!

## 📝 License

This project is [MIT](./LICENSE) licensed.
