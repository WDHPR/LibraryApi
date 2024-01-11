using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using LibraryApi.Models;
using System.Diagnostics;
using LibraryApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Json serialization ignores looping references in Team/Players
// Alternative to do later: solve with DTOs
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Set SqLite Database for testing
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("Sqlite");
    opt.UseSqlite(connectionString);

    opt.LogTo(m => Debug.WriteLine(m)).EnableSensitiveDataLogging(true);
});

// Set Azure SQL Database
/*
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("AzureDb");
    var connBuilder = new SqlConnectionStringBuilder(connectionString)
    {
        Password = builder.Configuration["AzureDbPassword"]
    };
    connectionString = connBuilder.ConnectionString;
    opt.UseSqlServer(connectionString);
});
*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//ensure empty DB for development
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
