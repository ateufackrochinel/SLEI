using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SLEI.Domain;
using SLEI.Domain.Repository;
using SLEI.Insfrastructure.Data;
using SLEI.Insfrastructure.Services;
using SLEI_Backend.Security;

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

// permet de preciser que SelfieContext sera utilisee pour l'authentification
builder.Services.AddIdentity<IdentityUser, IdentityRole>(    // On remplace AddDefaultIdentity par AddIdentity pour permettre de gerer aussi des roles 
    options =>
    {
        options.SignIn.RequireConfirmedEmail = true;
    }).AddEntityFrameworkStores<SLEIContext>()
    .AddDefaultTokenProviders();




//Ajouter le service pour la securite en passant la configuration en parametre 
builder.Services.AddCustumAuthentication(builder.Configuration);

// 2. Ajouter l’autorisation
builder.Services.AddAuthorization();

var app = builder.Build();

// Ajouter les rôles à la base de données
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await AjouterRole.InitializeAsync(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// pour gerer l'authentification
app.UseAuthentication();
app.UseAuthorization();





app.MapControllers();

app.Run();
