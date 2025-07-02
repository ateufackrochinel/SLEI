using Microsoft.EntityFrameworkCore;
using SLEI.Domain.Repository;
using SLEI.Insfrastructure.Data;
using SLEI.Insfrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<LogementRepository, LogementService>();
builder.Services.AddScoped<VilleRepository, VilleService>();
builder.Services.AddScoped<AppartementRepository, AppartementService>();
builder.Services.AddScoped<StudioRepository, StudioService>();


//Ajouter le contexte de bases de donnees 
builder.Services.AddDbContext<SLEIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
