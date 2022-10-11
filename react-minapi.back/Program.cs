using Asp.Versioning;
using Asp.Versioning.Conventions;
using LiteDB;
using Microsoft.EntityFrameworkCore;
using react_minapi.dataAccess.Models;
using react_minapi.dataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<ILiteDatabase, LiteDatabase>(
   x => new LiteDatabase(connectionString));

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new HeaderApiVersionReader("api-version");
});

var app = builder.Build();


var versionSet = app.NewApiVersionSet()
                    .HasApiVersion(1.0)
                    .HasApiVersion(2.0)
                    .ReportApiVersions()
                    .Build();
app.MapGet("/GetMessage", () => "This is an example of a minimal API").WithApiVersionSet(versionSet).HasApiVersion(new ApiVersion(2, 0));
app.MapGet("/GetString", () => "This is my string of a minimal API").WithApiVersionSet(versionSet).HasApiVersion(new ApiVersion(1, 0));
app.MapGet("/GetText", () => "This is another example of a minimal API").WithApiVersionSet(versionSet).IsApiVersionNeutral();
app.MapGet("/{chunck}", (string chunck, ILiteDatabase db) =>
    db.GetCollection<ShortUrl>().FindOne(x => x.Chunck == chunck)
    is ShortUrl url
    ? Results.Redirect(url.Url)
    : Results.NotFound());

app.MapPost("/urls", (ShortUrl shortUrl, HttpContext ctx, ILiteDatabase db) =>
{
    //check if is a valid url
    if (Uri.TryCreate(shortUrl.Url, UriKind.RelativeOrAbsolute
       , out Uri? parsedUri))
    {
        //generates a random value
        shortUrl.Chunck = Nanoid.Nanoid.Generate(size: 9);

        //inserts new record in the database
        db.GetCollection<ShortUrl>(BsonAutoId.Guid).Insert(shortUrl);

        var rawShortUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}/{shortUrl.Chunck}";

        return Results.Ok(new { ShortUrl = rawShortUrl });
    }
    return Results.BadRequest(new { ErrorMessage = "Invalid Url" });
});
app.MapGet("/users", () =>
{
    UserRepository userRepository = new UserRepository(new RunningContext());
    var users = userRepository.Get();
    return Results.Ok(users);
});
app.MapPost("/users", (User user) =>
{
    UserRepository userRepository = new UserRepository(new RunningContext());
    User newUser= userRepository.Create(user);
    
    return Results.Created($"/users/{newUser.Id}", newUser);
});

app.Run();
