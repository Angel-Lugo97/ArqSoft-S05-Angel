using CitasApp.Interfaces;
using CitasApp.Repositories;
using CitasApp.Observers;

var builder = WebApplication.CreateBuilder(args);

var dataFolder = Path.Combine(builder.Environment.WebRootPath, "data");
Directory.CreateDirectory(dataFolder);

var csvPacientes = Path.Combine(dataFolder, "pacientes.csv");
var csvMedicos = Path.Combine(dataFolder, "medicos.csv");
var csvCitas = Path.Combine(dataFolder, "citas.csv");

var sqlitePath = Path.Combine(dataFolder, "citasapp.db");

builder.Services.AddControllersWithViews();

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

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
