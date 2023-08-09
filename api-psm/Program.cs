using api_psm.domain.Interface.Services;
using api_psm.infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
