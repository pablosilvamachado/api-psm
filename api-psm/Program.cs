using api_psm.Authorization;
using api_psm.domain.Interface.Repository;
using api_psm.domain.Interface.Services;
using api_psm.infra;
using api_psm.infra.data.Factory;
using api_psm.infra.data.Repository;
using api_psm.infra.Interface;
using api_psm.Services;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();    
}
 

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom basic auth middleware
    app.UseMiddleware<BasicAuthMiddleware>();

    app.MapControllers();
}

app.Run("http://localhost:4000");

//app.MapGet("/", () => "Hello World!");

//app.Run();
