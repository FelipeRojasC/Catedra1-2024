using catedra1_api.Src.Data;
using catedra1_api.Src.Data.Migrations;
using catedra1_api.Src.Repositories.Implements;
using catedra1_api.Src.Repositories.Interfaces;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddScoped<IGeneroRepository,GeneroRepository>();


string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "Data Source = app.db";

builder.Services.AddDbContext<ApplicationDbContext>(opt =>opt.UseSqlite(connectionString));
var app = builder.Build();

using (var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    //Aplica cualquier migracion pendiente en la base de datos.
    context.Database.Migrate();
    //Ingresa los dataseeders
    DataSeeders.Iniialize(services);
}
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
