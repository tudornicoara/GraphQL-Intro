using Microsoft.EntityFrameworkCore;
using RealEstateManager.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RealEstateContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:RealEstateDb"]));

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
