using ControlTecnicos.BLL.Servicios;
using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.TDOs;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
});*/

builder.Services.AddDbContext<DbtecnicosV20Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddScoped<IGenericRepository<TecnicoDTO>, TecnicoRepository>();
builder.Services.AddScoped<IGenericRepository<ElementosDTO>, ElementoRepository>();
builder.Services.AddScoped<IGenericRepository<SucursalDTO>, SucursalRepositorty>();
builder.Services.AddScoped<IElementosTecnico,  ElementosTecnicoRepository>();

builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddScoped<IElementoService, ElementoService>();
builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<IElementosTecnicoService, ElementosTecnicosService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
