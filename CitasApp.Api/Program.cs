using CitasApp.Application.Services;
using CitasApp.Interfaces;
using CitasApp.Repositories;
using CitasApp.Observers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorios
builder.Services.AddScoped<IPacienteRepository>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();

    var repo = RepositoryFactory.CrearPacienteRepository(
        builder.Environment.EnvironmentName, env);

    return new LoggingPacienteRepository(repo);
});

builder.Services.AddScoped<IMedicoRepository>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();

    return RepositoryFactory.CrearMedicoRepository(
        builder.Environment.EnvironmentName, env);
});

builder.Services.AddScoped<ICitaRepository>(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();

    return RepositoryFactory.CrearCitaRepository(
        builder.Environment.EnvironmentName, env);
});

// Observers de notificaciones
builder.Services.AddScoped<ICitaObserver, SmsObserver>();
builder.Services.AddScoped<ICitaObserver, EmailObserver>();

// Servicios de aplicación
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<CitaService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "CitasApp.Api funcionando. Usa /api/Pacientes, /api/Medicos o /api/Citas.");


app.Run();
