using Microsoft.EntityFrameworkCore;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Core.Services;
using UESAN_INTRANET.CORE.Infrastructure.Data;
using UESAN_INTRANET.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get Connection String
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
// Add dbcontext
builder.Services.AddDbContext<VdiIntranet2Context>(options => options.UseSqlServer(connectionString));

//TODO: Add interfaces
builder.Services.AddScoped<IAccesosRepository, AccesosRepository>();
builder.Services.AddScoped<IAccesosService, AccesosService>();

builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolService, RolService>();

builder.Services.AddScoped<INotificacionesRepository, NotificacionesRepository>();
builder.Services.AddScoped<INotificacionesService, NotificacionesService>();

builder.Services.AddScoped<IAsignacionesRepository, AsignacionesRepository>();
builder.Services.AddScoped<IAsignacionesService, AsignacionesService>();

builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();

builder.Services.AddScoped<IListasCerradasRepository, ListasCerradasRepository>();
builder.Services.AddScoped<IListasCerradasService, ListasCerradasService>();

builder.Services.AddScoped<IListasCerradasGuardadasRepository, ListasCerradasGuardadasRepository>();
builder.Services.AddScoped<IListasCerradasGuardadasService, ListasCerradasGuardadasService>();

builder.Services.AddScoped<IIssnConsultaRepository, IssnConsultaRepository>();
builder.Services.AddScoped<IIssnConsultaService, IssnConsultaService>();

builder.Services.AddScoped<IAccesosFormularioProfesoresRepository, AccesosFormularioProfesoresRepository>();
builder.Services.AddScoped<IAccesosFormularioProfesoresService, AccesosFormularioProfesoresService>();

// --------------------- CORS CONFIG ---------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost9000",
        policy => policy
            .WithOrigins("http://localhost:9000")
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});
// -------------------------------------------------------

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// --------------------- CORS MIDDLEWARE -----------------
app.UseCors("AllowLocalhost9000");
// -------------------------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();