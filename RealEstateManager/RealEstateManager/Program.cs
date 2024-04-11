using GraphQL;
using Microsoft.EntityFrameworkCore;
using RealEstateManager.Data;
using RealEstateManager.Repositories;
using RealEstateManager.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPropertyRepository, PropertyRepository>();
builder.Services.AddDbContext<RealEstateContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:RealEstateDb"]));
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

try
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<RealEstateContext>();
    dbContext?.EnsureSeedData();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();
