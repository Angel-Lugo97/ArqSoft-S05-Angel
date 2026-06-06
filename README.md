# CitasApp - Sistema de Gestión de Citas Médicas

Este proyecto es una aplicación web desarrollada con **C#, ASP.NET Core MVC y .NET 10**. La aplicación permite registrar pacientes, registrar médicos, crear citas médicas, consultar la agenda general y ver las citas asociadas a cada paciente.

La intención principal del proyecto fue construir una aplicación funcional usando el patrón **MVC**, almacenamiento local en archivos **JSON** y vistas Razor para mostrar la información de manera sencilla dentro del navegador.

---

## 👤 Datos del Estudiante

| Campo | Información |
| :--- | :--- |
| **Nombre** | Angel Abraham Lugo Saenz |
| **Matrícula** | SW2409052 |
| **Universidad** | Tecnológico de Software |
| **Profesor** | Jorge Javier Pedroza Romero |
| **Materia** | Arquitectura de Software |
| **Tarea** | Sistema de citas médicas en ASP.NET Core MVC |

---

## 📝 Descripción General

La aplicación consiste en una agenda médica web donde se pueden administrar tres partes principales: pacientes, médicos y citas. El sistema permite consultar los registros guardados, agregar nuevos datos y relacionar una cita con un paciente y un médico.

Las restricciones principales del proyecto son:

* Las citas deben estar relacionadas con un paciente registrado.
* Las citas deben estar relacionadas con un médico registrado.
* Los pacientes se guardan dentro del archivo `Pacientes.json`.
* Los médicos se guardan dentro del archivo `Medicos.json`.
* Las citas se guardan dentro del archivo `Citas.json`.
* La información se conserva usando archivos JSON locales, sin utilizar una base de datos externa.
* La agenda muestra los nombres de pacientes y médicos tomando como referencia sus identificadores.

---

## 🚀 Tecnologías Utilizadas

* **Lenguaje:** C#
* **Framework:** ASP.NET Core MVC
* **Versión de .NET:** .NET 10
* **Patrón:** MVC
* **Vistas:** Razor Views
* **Estilos:** HTML, CSS y Bootstrap
* **Persistencia:** Archivos JSON
* **IDE recomendado:** JetBrains Rider
* **Sistema compatible:** Arch Linux
* **Herramientas:** .NET SDK, Git y GitHub

---

## 🧱 Retos del Proyecto

Durante el desarrollo se presentaron varios retos importantes:

* Organizar el proyecto usando el patrón MVC.
* Separar correctamente los modelos, controladores, vistas y datos.
* Crear una forma sencilla de guardar información sin usar base de datos.
* Leer y escribir archivos JSON desde la carpeta `Data`.
* Relacionar las citas con pacientes y médicos mediante sus identificadores.
* Mostrar en la agenda el nombre del paciente y del médico, en lugar de solo mostrar sus IDs.
* Crear formularios para agregar pacientes, médicos y citas.
* Agregar navegación entre las secciones principales del sistema.
* Crear una sección para consultar las citas de un paciente específico.
* Mantener el proyecto funcionando en .NET 10 y compatible con JetBrains Rider en Arch Linux.
* Agregar imágenes de evidencia dentro de la carpeta `assets`.

---

## 📂 Estructura del Proyecto

```text
ArqSoft-S05-Angel/
├── CitasApp.slnx
├── CitasApp.csproj
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── Controllers/
│   ├── CitaController.cs
│   ├── HomeController.cs
│   ├── MedicoController.cs
│   └── PacienteController.cs
├── Models/
│   ├── Cita.cs
│   ├── ErrorViewModel.cs
│   ├── Medico.cs
│   └── Paciente.cs
├── Data/
│   ├── Citas.json
│   ├── DatosJson.cs
│   ├── Medicos.json
│   └── Pacientes.json
├── Views/
│   ├── Cita/
│   │   ├── Create.cshtml
│   │   ├── Index.cshtml
│   │   └── PorPaciente.cshtml
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── Medico/
│   │   ├── Create.cshtml
│   │   ├── Detalle.cshtml
│   │   └── Index.cshtml
│   ├── Paciente/
│   │   ├── Create.cshtml
│   │   ├── Detalle.cshtml
│   │   └── Index.cshtml
│   ├── Shared/
│   │   ├── Error.cshtml
│   │   ├── _Layout.cshtml
│   │   ├── _Layout.cshtml.css
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   ├── lib/
│   │   ├── bootstrap/
│   │   ├── jquery/
│   │   ├── jquery-validation/
│   │   └── jquery-validation-unobtrusive/
│   └── favicon.ico
├── assets/
│   ├── 1.png
│   ├── 2.png
│   └── 3.png
└── README.md
```
---
⚙️ Funcionalidades

Gestión de pacientes: permite visualizar pacientes registrados, agregar nuevos pacientes y consultar el detalle de cada uno.

Gestión de médicos: permite visualizar médicos disponibles, agregar nuevos médicos y consultar el detalle de cada uno.

Gestión de citas: permite consultar la agenda general de citas médicas.

Agregar cita: permite crear una nueva cita seleccionando paciente, médico, fecha, hora, motivo y estado.

Citas por paciente: permite ver las citas relacionadas con un paciente específico.

Persistencia en JSON: los pacientes, médicos y citas se guardan en archivos JSON locales dentro de la carpeta Data.

Navegación principal: el menú superior permite entrar a Home, Citas, Medico y Paciente.

❓ ¿De qué trata?

El proyecto trata de una aplicación web para administrar citas médicas de manera sencilla. La idea es que el sistema pueda registrar pacientes y médicos, y después crear citas relacionadas con ellos.

La aplicación funciona como una agenda básica donde se puede ver la fecha, hora, paciente, médico, motivo y estado de cada cita. Para guardar la información no se usa una base de datos tradicional, sino archivos JSON, lo cual hace que el proyecto sea más simple y fácil de revisar para una práctica escolar.

🧩 ¿Qué hicimos?

Se creó una aplicación MVC para organizar una agenda de citas médicas. Entre las partes realizadas se encuentran:
```
- Se crearon los modelos Paciente, Medico y Cita.
- Se creó la clase DatosJson para leer y guardar información en archivos JSON.
- Se agregaron archivos JSON para pacientes, médicos y citas.
- Se creó el controlador PacienteController para listar, agregar y ver detalles de pacientes.
- Se creó el controlador MedicoController para listar, agregar y ver detalles de médicos.
- Se creó el controlador CitaController para listar citas, agregar citas y ver citas por paciente.
- Se crearon vistas Razor para mostrar tablas y formularios.
- Se agregó un menú superior en _Layout.cshtml para navegar entre las secciones principales.
- Se relacionaron las citas con pacientes y médicos usando PacienteId y MedicoId.
- Se agregó la carpeta assets para colocar capturas de evidencia del proyecto.
- Se configuró el proyecto para ejecutarse como aplicación web ASP.NET Core MVC.
```
▶️ ¿Cómo funciona?
```
1- La aplicación inicia en la página principal Home.
2- Desde el menú superior se puede entrar a la sección de Citas, Medico o Paciente.
3- En la sección de pacientes se pueden ver los pacientes registrados.
4- También se pueden agregar nuevos pacientes desde el formulario correspondiente.
5- En la sección de médicos se pueden ver los médicos disponibles.
6- También se pueden agregar nuevos médicos desde su formulario.
7- En la sección de citas se muestra la agenda general.
8- Para crear una cita se selecciona un paciente y un médico registrados.
9- Después se captura la fecha, hora, motivo y estado de la cita.
10- Al guardar, la información se escribe en el archivo JSON correspondiente.
11- Desde el detalle de un paciente se pueden consultar sus citas.

```
🛠️ Comandos de Uso
Desarrollo con .NET
```
# Restaurar dependencias
dotnet restore

# Compilar proyecto
dotnet build

# Ejecutar el proyecto web
dotnet run --project CitasApp.csproj
```
También se puede ejecutar desde la carpeta del proyecto:
```
cd ArqSoft-S05-Angel
dotnet run
```
Gestión con Git
```
# Inicializar repositorio
git init

# Agregar archivos
git add .

# Crear commit
git commit -m "CitasApp con pacientes, medicos, citas y persistencia JSON"

# Conectar con GitHub
git remote add origin URL_DEL_REPOSITORIO

# Subir cambios
git push -u origin main
```
🖥️ Uso en JetBrains Rider
```
1 Abre JetBrains Rider.
2 Selecciona Open.
3 Abre el archivo CitasApp.slnx o la carpeta del proyecto.
4 Espera a que Rider restaure y sincronice el proyecto.
5 Selecciona como configuración de ejecución el proyecto CitasApp.
6 Presiona Run.
7 Abre la ruta del navegador que indique Rider.
```
En mi caso, el proyecto se ejecutó en una ruta local como esta:
```
http://localhost:5018
```
Para abrir directamente la agenda de citas se puede usar:
```
http://localhost:5018/Cita
```
Y para abrir el formulario de agregar cita:
```
http://localhost:5018/Cita/Create
```
📸 Evidencias de Ejecución

En esta sección se muestran capturas del proyecto funcionando correctamente en el navegador. Las imágenes evidencian la pantalla principal, la agenda de citas y el formulario para agregar una nueva cita médica.

✅ Página principal

En esta captura se observa la pantalla inicial de la aplicación CitasApp. También se muestra la barra de navegación superior con las opciones principales del sistema: Home, Citas, Medico y Paciente.

📅 Agenda de citas

En esta imagen se muestra la sección de agenda de citas. La tabla presenta las citas médicas registradas con su fecha, hora, paciente, médico, motivo, estado y un enlace para ver más detalles.

➕ Formulario para agregar cita

En esta captura se observa el formulario para agregar una nueva cita médica. El sistema permite seleccionar un paciente, elegir un médico, capturar la fecha, hora, motivo y estado de la cita antes de guardarla.

🐧 Requisitos en Arch Linux

Instala el SDK de .NET compatible con el proyecto:
```
sudo pacman -S dotnet-sdk
```
Verifica la instalación:
```
dotnet --list-sdks
dotnet --list-runtimes
```
El proyecto está configurado para:
```
<TargetFramework>net10.0</TargetFramework>
```
Por lo tanto, el sistema debe tener instalado el SDK y runtime de ASP.NET Core correspondientes a .NET 10.
🖌️ Personalización y Diseño

El proyecto utiliza vistas Razor con HTML y Bootstrap. La estructura visual se controla principalmente desde _Layout.cshtml y los estilos del proyecto se encuentran en wwwroot/css/site.css.

Elementos visuales del proyecto:
```
- Barra de navegación superior.
- Tablas para mostrar pacientes, médicos y citas.
- Formularios para registrar información nueva.
- Enlaces para ver detalles.
- Estructura básica generada por ASP.NET Core MVC.
- Uso de Bootstrap para mantener una presentación ordenada.
```
💻 Códigos Importantes
Ruta inicial del proyecto

En Program.cs se configuró la ruta principal del sistema:
```
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
```
Lectura de archivos JSON

En DatosJson.cs se creó el método para leer información desde la carpeta Data:
```
public static List<T> Leer<T>(string archivo)
{
    var ruta = Path.Combine(Directory.GetCurrentDirectory(), "Data", archivo);

    if (!File.Exists(ruta))
    {
        File.WriteAllText(ruta, "[]");
    }

    var json = File.ReadAllText(ruta);

    if (string.IsNullOrWhiteSpace(json))
    {
        return new List<T>();
    }

    return JsonSerializer.Deserialize<List<T>>(json, opciones) ?? new List<T>();
}
```
Guardado de archivos JSON

El método Guardar permite escribir la información actualizada en el archivo JSON correspondiente:
```
public static void Guardar<T>(string archivo, List<T> datos)
{
    var ruta = Path.Combine(Directory.GetCurrentDirectory(), "Data", archivo);

    var json = JsonSerializer.Serialize(datos, opciones);

    File.WriteAllText(ruta, json);
}
```
Agregar una cita

En CitaController se crea un nuevo ID, se agrega la cita a la lista y se guarda en Citas.json:
```
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Cita cita)
{
    var citas = Citas();

    cita.Id = citas.Any() ? citas.Max(c => c.Id) + 1 : 1;

    citas.Add(cita);

    DatosJson.Guardar("Citas.json", citas);

    return RedirectToAction(nameof(Index));
}
```
Mostrar nombres en lugar de IDs

En la vista Views/Cita/Index.cshtml, la cita usa los IDs para buscar el paciente y el médico correspondiente:
```
var paciente = pacientes?.FirstOrDefault(p => p.Id == c.PacienteId);
var medico = medicos?.FirstOrDefault(m => m.Id == c.MedicoId);
```
De esa manera, la tabla puede mostrar el nombre completo del paciente y del médico.

Menú principal

En _Layout.cshtml se agregaron enlaces para navegar entre las secciones principales del sistema:
```
<a class="nav-link text-dark" asp-controller="Home" asp-action="Index">Home</a>
<a class="nav-link text-dark" asp-controller="Cita" asp-action="Index">Citas</a>
<a class="nav-link text-dark" asp-controller="Medico" asp-action="Index">Medico</a>
<a class="nav-link text-dark" asp-controller="Paciente" asp-action="Index">Paciente</a>
```
✅ Validación de Entrada

El proyecto tiene formularios para capturar información de pacientes, médicos y citas. Actualmente se usa el envío normal de formularios MVC con protección antifalsificación mediante:
```
[ValidateAntiForgeryToken]
```
La información que se captura es:
```
Paciente: nombre, apellido, email y teléfono.
Médico: nombre, apellido, especialidad y número de licencia.
Cita: paciente, médico, fecha, hora, motivo y estado.
```
Como mejora futura, se pueden agregar validaciones más estrictas con anotaciones como [Required], [EmailAddress] y mensajes personalizados para evitar registros incompletos.

📈 Mejoras Futuras
```
[ ] Agregar validaciones con Data Annotations en los modelos.

[ ] Evitar guardar registros vacíos en los archivos JSON.

[ ] Agregar edición de pacientes.

[ ] Agregar eliminación de pacientes.

[ ] Agregar edición de médicos.

[ ] Agregar eliminación de médicos.

[ ] Agregar edición de citas.

[ ] Agregar eliminación de citas.

[ ] Crear una vista de detalle individual para cada cita.

[ ] Mejorar el diseño visual de las tablas y formularios.

[ ] Migrar la persistencia de JSON a una base de datos como SQLite o SQL Server.

[ ] Unificar los namespaces del proyecto para mantener una estructura más limpia.
```
🏁 Conclusión

Este proyecto permitió aplicar conceptos de arquitectura de software en una aplicación web real usando ASP.NET Core MVC. Se trabajó con modelos, controladores, vistas y persistencia local mediante archivos JSON.

Además, el proyecto ayudó a entender cómo se relacionan distintas entidades dentro de una aplicación, ya que una cita necesita estar conectada con un paciente y un médico. Aunque todavía se pueden agregar mejoras como validaciones, edición y eliminación de registros, la base principal del sistema ya permite administrar una agenda médica sencilla y funcional.

Cláusula de IA
```
Yo Angel Abraham Lugo Saenz declaro que utilicé IA,
para realizar mi README, apoyarme en la redacción del documento y explicar de forma más clara la estructura y funcionamiento de mi proyecto de citas médicas.
```
