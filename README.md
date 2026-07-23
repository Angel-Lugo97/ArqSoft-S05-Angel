# CitasApp — Pruebas unitarias e Integración Continua

Este repositorio contiene una aplicación para la gestión de citas médicas desarrollada con **C#, ASP.NET Core MVC, ASP.NET Core Web API y .NET 10**.

La rama **`CI/CD`** está enfocada en incorporar pruebas unitarias con **xUnit** y un flujo de **Integración Continua con GitHub Actions**, de modo que cada cambio enviado al repositorio sea restaurado, compilado y probado automáticamente.

---

## Datos del estudiante

| Campo | Información |
| :--- | :--- |
| **Nombre** | Angel Abraham Lugo Saenz |
| **Matrícula** | SW2409052 |
| **Universidad** | Tecnológico de Software |
| **Profesor** | Jorge Javier Pedroza Romero |
| **Materia** | Arquitectura de Software |
| **Actividad** | Pruebas unitarias e Integración Continua |
| **Rama de trabajo** | `CI/CD` |

---

# Objetivo de la rama `CI/CD`

El objetivo de esta rama es comprobar automáticamente que los cambios realizados en CitasApp no rompan el comportamiento esperado del sistema.

En esta rama se implementó:

- Una primera prueba unitaria con xUnit
- La estructura Arrange, Act y Assert
- La clase `CitaFactory`
- El proyecto `CitasApp.Domain.Tests`
- Un workflow de GitHub Actions
- Ejecución automática en cada `push` y Pull Request

El flujo general es:

```text
git push o Pull Request
        ↓
GitHub Actions detecta el cambio
        ↓
Configura .NET 10
        ↓
Restaura dependencias
        ↓
Compila CitasApp.sln
        ↓
Ejecuta las pruebas xUnit
        ↓
Check verde o check rojo
```

---

# Prueba unitaria con xUnit

Una prueba unitaria comprueba una parte pequeña y específica del código.

En esta rama, la prueba representa la siguiente promesa:

```text
Si CitaFactory recibe datos válidos,
debe crear una Cita con estado Pendiente
y conservar correctamente el PacienteId.
```

La prueba se encuentra en:

```text
tests/CitasApp.Domain.Tests/CitaFactoryTests.cs
```

Código implementado:

```csharp
using CitasApp.Factories;

namespace CitasApp.Domain.Tests;

public class CitaFactoryTests
{
    [Fact]
    public void Construir_ConDatosValidos_CreaCitaConEstadoPendiente()
    {
        // Arrange
        var factory = new CitaFactory();

        // Act
        var cita = factory.Construir(
            pacienteId: 1,
            medicoId: 2,
            fecha: new DateOnly(2026, 7, 20),
            hora: new TimeOnly(10, 0),
            motivo: "Consulta"
        );

        // Assert
        Assert.Equal("Pendiente", cita.Estado);
        Assert.Equal(1, cita.PacienteId);
    }
}
```

Resultado obtenido:

```text
Test summary: total: 1, failed: 0, succeeded: 1, skipped: 0
```

---

# Arrange, Act y Assert

| Etapa | Qué hace | Aplicación en la prueba |
| :--- | :--- | :--- |
| **Arrange** | Prepara los objetos y datos necesarios | Crear `CitaFactory` |
| **Act** | Ejecuta el comportamiento que se quiere probar | Llamar a `Construir(...)` |
| **Assert** | Comprueba que el resultado sea el esperado | Verificar `Estado` y `PacienteId` |

## Arrange

```csharp
var factory = new CitaFactory();
```

## Act

```csharp
var cita = factory.Construir(
    pacienteId: 1,
    medicoId: 2,
    fecha: new DateOnly(2026, 7, 20),
    hora: new TimeOnly(10, 0),
    motivo: "Consulta"
);
```

## Assert

```csharp
Assert.Equal("Pendiente", cita.Estado);
Assert.Equal(1, cita.PacienteId);
```

Si un cambio futuro modifica el comportamiento de `CitaFactory`, la prueba fallará antes de que el problema llegue al usuario.

---

# CitaFactory

La clase se encuentra en:

```text
src/CitasApp.Domain/Factories/CitaFactory.cs
```

Su responsabilidad es construir una entidad `Cita` y asignar el estado inicial `Pendiente`.

```csharp
using CitasApp.Models;

namespace CitasApp.Factories;

public class CitaFactory
{
    public Cita Construir(
        int pacienteId,
        int medicoId,
        DateOnly fecha,
        TimeOnly hora,
        string motivo)
    {
        return new Cita
        {
            PacienteId = pacienteId,
            MedicoId = medicoId,
            Fecha = fecha,
            Hora = hora,
            Motivo = motivo,
            Estado = "Pendiente"
        };
    }
}
```

---

# Proyecto de pruebas

Se creó el proyecto:

```text
tests/CitasApp.Domain.Tests/
```

La dependencia principal es:

```text
CitasApp.Domain.Tests
        ↓
CitasApp.Domain
```

Comando utilizado para agregar la referencia:

```bash
dotnet add   tests/CitasApp.Domain.Tests/CitasApp.Domain.Tests.csproj   reference src/CitasApp.Domain/CitasApp.Domain.csproj
```

Comando para agregar el proyecto a la solución:

```bash
dotnet sln CitasApp.sln add   tests/CitasApp.Domain.Tests/CitasApp.Domain.Tests.csproj
```

---

# Integración Continua

La Integración Continua, conocida como **CI**, permite verificar automáticamente cada cambio que se envía al repositorio.

En este proyecto, CI responde la pregunta:

```text
¿Mi cambio rompió algo?
```

GitHub Actions ejecuta:

```text
1. Restaurar dependencias
2. Compilar la solución
3. Ejecutar las pruebas
```

Si todo funciona, GitHub muestra un check verde. Si algo falla, muestra un check rojo con el registro del error.

---

# Diferencia entre CI y CD

| Concepto | Descripción | Pregunta que responde |
| :--- | :--- | :--- |
| **CI** | Compila y ejecuta pruebas automáticamente | ¿Mi cambio rompió algo? |
| **CD** | Entrega o despliega automáticamente el sistema | ¿Mi cambio ya está publicado? |

La automatización implementada en esta rama se concentra en **CI**. El despliegue automático queda como mejora futura.

---

# GitHub Actions

El workflow se encuentra en:

```text
.github/workflows/ci.yml
```

Contenido:

```yaml
name: CI

on:
  push:
  pull_request:

permissions:
  contents: read

jobs:
  test:
    name: Compilar y ejecutar pruebas
    runs-on: ubuntu-latest

    steps:
      - name: Descargar repositorio
        uses: actions/checkout@v4

      - name: Configurar .NET 10
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '10.0.x'

      - name: Restaurar dependencias
        run: dotnet restore CitasApp.sln

      - name: Compilar solución
        run: dotnet build CitasApp.sln --configuration Release --no-restore

      - name: Ejecutar pruebas xUnit
        run: dotnet test tests/CitasApp.Domain.Tests/CitasApp.Domain.Tests.csproj --configuration Release --no-build --verbosity normal
```

El workflow usa .NET 10 porque la solución está configurada con:

```xml
<TargetFramework>net10.0</TargetFramework>
```

---

# Eventos que activan el workflow

```yaml
on:
  push:
  pull_request:
```

Esto hace que GitHub Actions se ejecute cuando:

- Se realiza un `push`
- Se crea un Pull Request
- Se agregan commits a un Pull Request existente

---

# Arquitectura del proyecto

```text
CitasApp.Web
    ↓
CitasApp.Application
    ↓
CitasApp.Domain
    ↑
CitasApp.Infrastructure

CitasApp.Api
    ↓
CitasApp.Application
    ↓
CitasApp.Domain
    ↑
CitasApp.Infrastructure

CitasApp.Domain.Tests
    ↓
CitasApp.Domain
```

| Capa | Responsabilidad |
| :--- | :--- |
| **CitasApp.Web** | Interfaz MVC, vistas Razor y controladores |
| **CitasApp.Api** | Endpoints REST y Swagger |
| **CitasApp.Application** | Servicios y casos de uso |
| **CitasApp.Domain** | Modelos, interfaces y `CitaFactory` |
| **CitasApp.Infrastructure** | Repositorios, PostgreSQL, SQLite y observers |
| **CitasApp.Domain.Tests** | Pruebas unitarias del dominio |
| **GitHub Actions** | Compilación y pruebas automáticas |

## Diagrama UML por capas

La documentación UML existente se conserva en:

```text
docs/doc-UML/README.md
```

[Ver documentación UML de CitasApp](docs/doc-UML/README.md)

![Diagrama UML de CitasApp](docs/doc-UML/assets/capturas/Diagrama-UML.png)

---

# Estructura principal

```text
ArqSoft-S05-Angel/
│
├── .github/
│   └── workflows/
│       └── ci.yml
│
├── tests/
│   └── CitasApp.Domain.Tests/
│       ├── CitaFactoryTests.cs
│       └── CitasApp.Domain.Tests.csproj
│
├── src/
│   ├── CitasApp.Domain/
│   │   ├── Factories/
│   │   │   └── CitaFactory.cs
│   │   ├── Models/
│   │   └── Interfaces/
│   │
│   ├── CitasApp.Application/
│   └── CitasApp.Infrastructure/
│
├── CitasApp.Api/
├── Controllers/
├── Views/
├── wwwroot/
├── database/
├── docs/
├── assets/
├── CitasApp.Web.csproj
├── CitasApp.sln
└── README.md
```

---

# Exclusión de la carpeta de pruebas

Como `CitasApp.Web.csproj` se encuentra en la raíz, podía intentar compilar archivos `.cs` dentro de `tests/`.

Para separar correctamente ambos proyectos se agregó:

```xml
<ItemGroup>
  <Compile Remove="tests/**/*.cs" />
  <Content Remove="tests/**" />
  <None Remove="tests/**" />
  <EmbeddedResource Remove="tests/**" />
</ItemGroup>
```

Esto evita errores como:

```text
Duplicate AssemblyAttribute
Duplicate TargetFrameworkAttribute
The type or namespace name 'Xunit' could not be found
```

---

# Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** ASP.NET Core
- **Versión:** .NET 10
- **Aplicación Web:** ASP.NET Core MVC
- **API:** ASP.NET Core Web API
- **Pruebas:** xUnit
- **Estructura de pruebas:** Arrange, Act, Assert
- **Automatización:** GitHub Actions
- **Runner:** Ubuntu Latest
- **Control de versiones:** Git y GitHub
- **IDE:** JetBrains Rider
- **Sistema operativo local:** Arch Linux
- **Arquitectura:** Separación por capas
- **Base de datos:** PostgreSQL
- **Proveedor:** Npgsql

---

# Comandos principales

## Verificar la rama

```bash
git branch --show-current
```

Resultado esperado:

```text
CI/CD
```

## Restaurar dependencias

```bash
dotnet restore CitasApp.sln
```

## Limpiar la solución

```bash
dotnet clean CitasApp.sln
```

## Compilar

```bash
dotnet build CitasApp.sln --no-restore
```

Resultado esperado:

```text
Build succeeded
```

## Ejecutar todas las pruebas

```bash
dotnet test CitasApp.sln
```

## Ejecutar únicamente las pruebas de dominio

```bash
dotnet test   tests/CitasApp.Domain.Tests/CitasApp.Domain.Tests.csproj   --verbosity normal
```

## Ejecutar los mismos pasos del CI

```bash
dotnet restore CitasApp.sln
```

```bash
dotnet build   CitasApp.sln   --configuration Release   --no-restore
```

```bash
dotnet test   tests/CitasApp.Domain.Tests/CitasApp.Domain.Tests.csproj   --configuration Release   --no-build   --verbosity normal
```

Resultado esperado:

```text
Test summary: total: 1, failed: 0, succeeded: 1, skipped: 0
```

---

# Ejecutar la aplicación

## Web MVC

```bash
dotnet run   --project CitasApp.Web.csproj   --launch-profile http
```

Abrir:

```text
http://localhost:5018
```

## API REST

```bash
dotnet run   --project CitasApp.Api/CitasApp.Api.csproj   --launch-profile http
```

Abrir:

```text
http://localhost:5057
http://localhost:5057/swagger
```

---

# Subir cambios a GitHub

```bash
git status
git add .
git status
git commit -m "docs: actualizar README para la rama CI/CD"
git push -u origin "$(git branch --show-current)"
```

Después del `push`, GitHub Actions debe ejecutar el workflow automáticamente.

---

# Permisos del token

Para crear o modificar archivos dentro de:

```text
.github/workflows/
```

el Personal Access Token clásico necesita:

```text
repo
workflow
```

No necesita:

```text
write:packages
delete:packages
admin:org
delete_repo
```

Si aparece:

```text
refusing to allow a Personal Access Token to create or update workflow
without workflow scope
```

se debe activar:

```text
workflow — Update GitHub Action workflows
```

Después:

```bash
printf "protocol=https
host=github.com

" | git credential reject
```

Y repetir:

```bash
git push -u origin "$(git branch --show-current)"
```

---

# Comprobar GitHub Actions

```text
1. Abrir el repositorio en GitHub
2. Entrar a la pestaña Actions
3. Seleccionar el workflow CI
4. Abrir la ejecución más reciente
5. Revisar Compilar y ejecutar pruebas
6. Confirmar que todos los pasos estén en verde
```

Pasos esperados:

```text
✓ Descargar repositorio
✓ Configurar .NET 10
✓ Restaurar dependencias
✓ Compilar solución
✓ Ejecutar pruebas xUnit
```

---

# Advertencia de SQLite

Durante la compilación puede aparecer:

```text
warning NU1903:
Package 'SQLitePCLRaw.lib.e_sqlite3' 2.1.11
has a known high severity vulnerability
```

Esta advertencia no impide actualmente la compilación ni la ejecución de las pruebas, pero el paquete debe actualizarse o sustituirse después de comprobar su compatibilidad.

---

# Solución de problemas

## La prueba no aparece

```bash
dotnet test   tests/CitasApp.Domain.Tests/CitasApp.Domain.Tests.csproj   --list-tests
```

Debe mostrarse:

```text
CitasApp.Domain.Tests.CitaFactoryTests.Construir_ConDatosValidos_CreaCitaConEstadoPendiente
```

## La prueba falla

```bash
dotnet test   tests/CitasApp.Domain.Tests/CitasApp.Domain.Tests.csproj   --verbosity detailed
```

Revisar:

```text
Expected
Actual
Stack Trace
```

## GitHub no ejecuta el workflow

```bash
ls -la .github/workflows
cat .github/workflows/ci.yml
git ls-files .github/workflows/ci.yml
```

## El proyecto Web vuelve a incluir `tests`

Verificar que `CitasApp.Web.csproj` tenga la exclusión de `tests/**`, después ejecutar:

```bash
find . -type d \( -name bin -o -name obj \) -prune -exec rm -rf {} +
dotnet restore CitasApp.sln
dotnet build CitasApp.sln --no-restore
```

---

# Evidencias de ejecución

Las imágenes existentes se conservan dentro de `assets/`.

## Página principal y panel de endpoints

![Página principal de CitasApp](assets/1.png)

## Comprobación por terminal

![Comprobación por terminal del proyecto](assets/2.png)

## Interfaz Web de CitasApp

![Visualización de CitasApp en la página Web](assets/3.png)

## Evidencias recomendadas para `CI/CD`

- Rama `CI/CD` activa
- Archivo `CitaFactoryTests.cs`
- Resultado local con una prueba exitosa
- Archivo `.github/workflows/ci.yml`
- Pestaña Actions de GitHub
- Workflow con check verde
- Job `Compilar y ejecutar pruebas`
- Resultado de `dotnet build`
- Resultado de `dotnet test`
- Pull Request con CI aprobado

---

# Beneficios obtenidos

- Detección temprana de errores
- Comprobación automática en cada `push`
- Menor dependencia de pruebas manuales
- Documentación del comportamiento esperado
- Mayor seguridad al modificar `CitaFactory`
- Mejor revisión de Pull Requests
- Base para agregar más pruebas
- Preparación para un futuro despliegue continuo

---

# Mejoras futuras

```text
[ ] Agregar pruebas para datos inválidos

[ ] Validar PacienteId y MedicoId

[ ] Validar que Motivo no esté vacío

[ ] Agregar pruebas para CitaService

[ ] Agregar pruebas para confirmar citas

[ ] Probar SmsObserver y EmailObserver

[ ] Agregar mocks para repositorios

[ ] Agregar pruebas de integración para la API

[ ] Agregar pruebas con PostgreSQL

[ ] Generar reportes de cobertura

[ ] Proteger ramas contra merges con CI fallido

[ ] Actualizar el paquete SQLite señalado por NU1903

[ ] Implementar una etapa de despliegue continuo
```

---

# Gestión de commits

Secuencia recomendada:

```text
test: crear CitaFactory
test: agregar proyecto xUnit y primera prueba
chore: excluir tests del proyecto web
ci: agregar workflow de GitHub Actions
docs: actualizar README de la rama CI/CD
```

Consultar historial:

```bash
git --no-pager log --oneline --decorate -10
```

---

# Conclusión

La rama `CI/CD` incorporó una primera prueba automatizada a CitasApp y estableció un proceso de Integración Continua con GitHub Actions.

La prueba `Construir_ConDatosValidos_CreaCitaConEstadoPendiente` verifica que `CitaFactory` cree correctamente una cita con estado `Pendiente` y conserve el identificador del paciente.

También se creó el proyecto `CitasApp.Domain.Tests`, se conectó con la capa de dominio y se corrigió la configuración de `CitasApp.Web.csproj` para evitar que el proyecto Web compilara los archivos de la carpeta `tests`.

Finalmente, `.github/workflows/ci.yml` automatiza la restauración, compilación y ejecución de pruebas en cada `push` y Pull Request, lo cual permite detectar fallos antes de integrar cambios y prepara el repositorio para futuras pruebas y despliegues.

---

## Cláusula de IA

```text
Yo, Angel Abraham Lugo Saenz, declaro que utilicé IA como apoyo para organizar y redactar este README, documentar la prueba unitaria con xUnit, explicar Arrange, Act y Assert, y describir la configuración de Integración Continua con GitHub Actions.

El código, la estructura del proyecto, la ejecución local de las pruebas, la configuración del workflow y las decisiones principales fueron revisadas y ejecutadas como parte de la actividad escolar de Arquitectura de Software.
```
