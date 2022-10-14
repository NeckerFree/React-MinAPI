using Asp.Versioning;
using Asp.Versioning.Conventions;
//using LiteDB;
using Microsoft.EntityFrameworkCore;
using reactminapi.dataAccess.Models;
using reactminapi.dataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build();

app.MapGet("/Users", () =>
{
    UserRepository UserRepository = new UserRepository(new RunningContext());
    var Users = UserRepository.Get();
    return Results.Ok(Users);
});
app.MapPost("/Users", (User User) =>
{
    UserRepository UserRepository = new UserRepository(new RunningContext());
    User newUser= UserRepository.Create(User);
    
    return Results.Created($"/Users/{newUser.Id}", newUser);
});

app.MapGet("/Trainings", () =>
{
    TrainingRepository TrainingRepository = new TrainingRepository(new RunningContext());
    var trainings = TrainingRepository.Get();
    return Results.Ok(trainings);
});

app.MapGet("/AllTrainingsByUser", (int userId) =>
{
    TrainingRepository TrainingRepository = new TrainingRepository(new RunningContext());
    var trainings = TrainingRepository.GetByUser(userId);
    return Results.Ok(trainings);
});

app.MapPost("/Trainings", (Training Training) =>
{
    TrainingRepository TrainingRepository = new TrainingRepository(new RunningContext());
    Training newTraining = TrainingRepository.Create(Training);

    return Results.Created($"/Trainings/{newTraining.Id}", newTraining);
});

app.Run();
