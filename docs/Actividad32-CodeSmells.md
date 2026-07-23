# Actividad 32 — Identificación y refactorización de code smells

## Estado inicial

Antes de modificar el código se revisó la estructura de CitasApp, incluyendo la aplicación Web MVC, la API REST y las capas Application, Domain e Infrastructure.

El proyecto compila correctamente antes de iniciar la refactorización.

## Code smell 1: Tight Coupling

### Ubicación

`CitasApp.Api/Controllers/CitasController.cs`

### Evidencia

El controlador depende directamente de las clases concretas:

- `CitaService`
- `PacienteService`
- `MedicoService`

Además, `PacienteService` y `MedicoService` se reciben en el constructor, pero no se utilizan en ninguna acción del controlador.

Esto provoca acoplamiento porque el controlador conoce implementaciones concretas en lugar de depender de una abstracción.

### Técnica de refactorización

Se aplicará Dependency Injection mediante la interfaz `ICitaService`.

El controlador dependerá de `ICitaService` y la implementación concreta `CitaService` será configurada en `Program.cs`.

## Code smell 2: posible God Class

### Ubicación

`Controllers/CitaController.cs`

### Evidencia

El controlador realiza diferentes responsabilidades:

- Consulta citas
- Consulta pacientes
- Consulta médicos
- Prepara los datos de las vistas
- Construye una cita predeterminada
- Valida el formulario
- Guarda la cita

Aunque actualmente no es una clase demasiado grande, concentra responsabilidades que pueden hacerla crecer y convertirse en una God Class.

### Técnica de refactorización

Se aplicará Extract Class para mover la preparación del formulario a una clase independiente.

## Comportamiento que debe conservarse

La refactorización no debe modificar:

- Las rutas existentes
- Los códigos de estado HTTP
- Los mensajes de respuesta
- Los modelos del dominio
- Los repositorios
- Las notificaciones mediante Observer
- La forma en que se almacenan las citas

## Resultado de la refactorización

Se creó la interfaz ICitaService y se modificó CitaService para implementar dicha abstracción.

CitasController dejó de depender directamente de CitaService, PacienteService y MedicoService. Ahora recibe únicamente ICitaService mediante inyección de dependencias.

La configuración se realizó en CitasApp.Api/Program.cs mediante el registro:

builder.Services.AddScoped<ICitaService, CitaService>();

Después de la refactorización, la solución continuó compilando correctamente y tanto la aplicación Web MVC como la API conservaron su comportamiento.

No se modificaron las rutas, los modelos, los códigos HTTP, las vistas ni el almacenamiento de datos.
