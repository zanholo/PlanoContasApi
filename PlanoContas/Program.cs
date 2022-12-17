using PlanoContas.Application.Serviços;
using PlanoContas.Domain.IServicos;
using PlanoContas.Infraestructure;
using PlanoContas.Infraestructure.Ioc;
using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.IRepositorios;
using PlanoContas.Infraestructure.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeção
builder.Services.AddScoped<IServicoLancamento, ServicoLancamentos>();
builder.Services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();


builder.Services.AddScoped<IServicoTipo, ServicoTipo>();
builder.Services.AddScoped<ITipoRepositorio, TipoRepositorio>();



///Conexão com banco
builder.Services.AddDbContext<LancamentoContexto>(opt => opt.UseInMemoryDatabase("Lancamentos"));
builder.Services.AddDbContext<TipoContexto>(opt => opt.UseInMemoryDatabase("Tipo"));

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
