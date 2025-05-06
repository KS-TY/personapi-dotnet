# Laboratorio de Arquitectura de Software en .NET

![.NET Core](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

## 📋 Requisitos Previos

* Microsoft SQL Server 2019 instalado
* Navegador web (Chrome, Firefox, Edge, etc.)
* Conexión a internet para descargar los archivos necesarios

## 📥 Descarga

Puedes descargar los archivos necesarios desde el siguiente enlace:

[Descargar archivos del laboratorio](https://drive.google.com/drive/folders/1X2Cp9tnQlbGgD1wGOv__lV4A6vawgbsd?usp=sharing)

En este enlace encontrarás dos archivos comprimidos:
* `personapi-dotnet-windows.zip` - Para sistemas Windows
* `personapi-dotnet-linux.zip` - Para sistemas Linux

Descarga el archivo correspondiente a tu sistema operativo y descomprímelo en la ubicación de tu preferencia.

## 🛠️ Configuración de la Base de Datos

1. Abre SQL Server Management Studio (SSMS) o tu cliente SQL preferido.
2. Conéctate a tu instancia de SQL Server 2019.
3. Abre el archivo `persona-db-ddl.txt` desde la carpeta descargada.
4. Ejecuta el script para crear la estructura de la base de datos.
5. (Opcional) Si deseas cargar datos de ejemplo, abre el archivo `persona-db-dml.txt` y ejecuta el script.

## 🚀 Ejecución de la Aplicación

### En Windows

1. Navega hasta la carpeta donde descomprimiste el archivo.
2. Busca el archivo `personapi-dotnet` (sin extensión).
3. Haz doble clic en el archivo para ejecutar la aplicación.

### En Linux

1. Abre una terminal.
2. Navega hasta la carpeta donde descomprimiste el archivo.
3. Otorga permisos de ejecución al archivo:
   ```bash
   chmod +x personapi-dotnet
   ```
4. Ejecuta la aplicación:
   ```bash
   ./personapi-dotnet
   ```

## 🌐 Acceso a la Aplicación

Una vez que la aplicación esté en ejecución, abre tu navegador web y accede a la siguiente URL:

[http://localhost:5000](http://localhost:5000)

## 📝 Notas Importantes

* Asegúrate de que SQL Server esté funcionando correctamente antes de ejecutar la aplicación.
* Si encuentras algún problema de conexión, verifica que los datos de conexión en la aplicación coincidan con tu configuración de SQL Server.
* La aplicación debe ejecutarse con permisos de administrador en algunos sistemas.
