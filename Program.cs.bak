using CitasApp.Interfaces;
using CitasApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Carpeta donde se guardan los archivos CSV.
var dataFolder = Path.Combine(builder.Environment.WebRootPath, "data");
Directory.CreateDirectory(dataFolder);

var csvPacientes = Path.Combine(dataFolder, "pacientes.csv");
var csvMedicos = Path.Combine(dataFolder, "medicos.csv");
var csvCitas = Path.Combine(dataFolder, "citas.csv");

var sqlitePath = Path.Combine(dataFolder, "citasapp.db");

builder.Services.AddControllersWithViews();

// JSON
// builder.Services.AddScoped<IPacienteRepository, JsonPacienteRepository>();
// builder.Services.AddScoped<IMedicoRepository, JsonMedicoRepository>();
// builder.Services.AddScoped<ICitaRepository, JsonCitaRepository>();

// CSV
builder.Services.AddSingleton<IPacienteRepository>(_ => new CsvPacienteRepository(csvPacientes));
builder.Services.AddSingleton<IMedicoRepository>(_ => new CsvMedicoRepository(csvMedicos));
builder.Services.AddSingleton<ICitaRepository>(_ => new CsvCitaRepository(csvCitas));

// SQLite
// builder.Services.AddSingleton<IPacienteRepository>(_ => new SqlitePacienteRepository(sqlitePath));
// builder.Services.AddSingleton<IMedicoRepository>(_ => new SqliteMedicoRepository(sqlitePath));
// builder.Services.AddSingleton<ICitaRepository>(_ => new SqliteCitaRepository(sqlitePath));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
