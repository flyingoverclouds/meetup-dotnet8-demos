var builder = WebApplication.CreateBuilder(args);

//01

var app = builder.Build();

app.MapGet("/", () => "Hello World!"); // inutile, mais c'est pour la démo :)

//02

app.Run();
