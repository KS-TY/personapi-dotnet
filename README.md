# Taller de Arquitectura de Software en .NET

Taller práctico de Arquitectura de Software utilizando .NET!

Este taller fue elaborado por:
- María Andrea Mendez
- Juan David Castillo
- Luis Fernando Lee

## Primeros pasos

Para poder participar en este taller y ejecutar el código de ejemplo, se necesitará tener configurado tu entorno de desarrollo. Sigue los pasos a continuación cuidadosamente.

### Prerrequisitos

Asegúrate de tener instalado lo siguiente antes de comenzar con la configuración:

* **Visual Studio Community 2022** - Descárgalo desde el sitio oficial de Microsoft. Asegúrate de seleccionar las cargas de trabajo de desarrollo de .NET.
* **SDK y Runtimes de .NET** - Visual Studio generalmente instala lo necesario, pero puedes verificarlos o descargarlos por separado desde el sitio oficial de .NET.
* **SQL Server Express (Modo Basic)** - La edición Express es gratuita y suficiente para este taller. Descárgala desde el sitio oficial de Microsoft.
* **SQL Server Management Studio (SSMS)** - La herramienta gráfica para administrar SQL Server. Descárgala desde el sitio oficial de Microsoft.

### Pasos de Configuración y Ejecución

Una vez que tengas los prerrequisitos instalados, sigue estos pasos para configurar el proyecto y la base de datos:

1.  **Clonar o descargar el repositorio:** Obtén el código fuente de este taller en tu máquina local. Si estás en GitHub, puedes clonarlo usando `git clone <URL_DEL_REPOSITORIO>` o descargarlo como ZIP.

2.  **Instalar Visual Studio:** Si aún no lo has hecho, instala **Visual Studio Community**. Durante la instalación, asegúrate de seleccionar las cargas de trabajo de desarrollo de `.NET desktop`, `ASP.NET and web development`, y `Data storage and processing`.

3.  **Instalar SQL Server (Modo Basic) y SSMS:** Ejecuta los instaladores que descargaste y sigue las instrucciones para instalar **SQL Server Express** en modo básico y **SQL Server Management Studio (SSMS)**.

4.  **Abrir la Solución en Visual Studio:** Navega hasta la carpeta donde descargaste el código y abre el archivo de solución (`.sln`) con Visual Studio.

5.  **Configurar la Conexión a la Base de Datos en Visual Studio:**
    * Dentro de Visual Studio, abre la ventana **"SQL Server Object Explorer"**. Puedes encontrarla en el menú `View > SQL Server Object Explorer`.
    * Haz clic en el icono de "Add SQL Server" (parece un enchufe o un cilindro con un signo más verde).
    * En la ventana de conexión, para "Server Name", escribe `localhost\sqlexpress`.
    * En "Authentication", selecciona `Windows Authentication` (a menos que hayas configurado SQL Server de otra manera).
    * **Crucial:** Expande "Options >>" y en "Encrypt", selecciona `Optional`.
    * Haz clic en "Connect". Deberías ver tu instancia de SQL Server Express en el explorador.

6.  **Configurar la Conexión a la Base de Datos en SSMS:**
    * Abre **SQL Server Management Studio (SSMS)**.
    * En la ventana de conexión, para "Server name", escribe `localhost\sqlexpress`.
    * En "Authentication", selecciona `Windows Authentication`.
    * **Crucial:** Haz clic en "Options >>" y en "Encryption", selecciona `Optional`.
    * Haz clic en "Connect".

7.  **Crear la Estructura de la Base de Datos (Ejecutar DDL):**
    * En SSMS, una vez conectado, haz clic en "New Query".
    * **Pega el script DDL adjunto a este taller** en la ventana de consulta. (Deberás asegurarte de que el archivo o el contenido del DDL esté accesible para los participantes, quizás en el propio repositorio).
    * Ejecuta la consulta (presionando `F5` o haciendo clic en "Execute"). Esto creará la base de datos y sus tablas.

8.  **Gestionar Migraciones con Entity Framework Core (dentro de Visual Studio):**
    * En Visual Studio, abre la **Consola del Administrador de Paquetes (Package Manager Console)**. Puedes encontrarla en el menú `Tools > NuGet Package Manager > Package Manager Console`.
    * Asegúrate de que el "Default project" seleccionado sea el proyecto que contiene las migraciones de Entity Framework Core (generalmente es el proyecto de datos o infraestructura).
    * **Paso 10.1: Eliminar migraciones existentes (si es necesario, usar con precaución):**
        ```powershell
        Drop-Database
        ```
   
    * **Paso 10.2: Añadir y aplicar la migración:**
        ```powershell
        Remove-Migration
        Add-Migration UpdateDeleteCascade 
        Update-Database
        ```
        *(**Explicación:** `Remove-Migration` borra la última migración que no ha sido aplicada a la base de datos. `Add-Migration UpdateDeleteCascade` crea una nueva migración basada en los cambios en tu modelo de Entity Framework, nombrándola "UpdateDeleteCascade". `Update-Database` aplica las migraciones pendientes a la base de datos.)*

9.  **Ejecutar la Aplicación:**
    * Una vez completados los pasos anteriores, la base de datos estará lista y configurada.
    * En Visual Studio, asegúrate de que el proyecto de inicio (Startup Project) sea la aplicación ejecutable (web, API, consola, etc.).
    * Presiona `Ctrl + F5` para ejecutar la aplicación sin depurar. Esto iniciará la aplicación.
