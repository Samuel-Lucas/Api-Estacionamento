using Estacionamento.Application.UseCases;
using Estacionamento.Domain.Interfaces;
using Estacionamento.Infrastructure.Data.Context;
using Estacionamento.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreSql"]));

builder.Services.AddScoped<IPessoaUseCases, PessoaUseCases>();
builder.Services.AddScoped<IVeiculoUseCases, VeiculoUseCases>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();