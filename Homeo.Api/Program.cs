using AutoMapper;
using Homeo.IoC;
using Homeo.Utils;

var builder = WebApplication.CreateBuilder(args);

// Define the environment variables
string path = Environment.CurrentDirectory + "\\dotenv.env";
LoadEnvironmentVariables.Load(path);

builder.AddServices();
builder.AddApplicationContexts();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
