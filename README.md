# React-MinAPI (track training)

## Description

> The purpuse of this project is to implement .NET Minimal Api using SQLite with Code First Model.	
> In addition it is implemented a ReactJS project to consume paginated data.

### Backend followed process (.NET Minimal Api):
1. Create DB Models: 
- User, 
- Training 

2. Reference these DB entities in the class RunningContext of dataAccess project, and in Package manager console of this project:

- Create initial migration using: `add-migration relation-user-training`
- Update database model with: `update-database` to reflect Model First in database

## Built With

- React JS 
- C#.NET 
- .NET Minimal API
- SQLite
- HTML 
- CSS

## Project Set up

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