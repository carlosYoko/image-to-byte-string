# ImageToByteString

Aplicación de escritorio para Windows, desarrollada en **C# con Windows Forms y .NET 8**, que convierte el contenido de una imagen en una cadena hexadecimal. Permite copiar el resultado al portapapeles o guardarlo en un archivo `.txt`, por ejemplo para utilizarlo en scripts o consultas que acepten datos binarios en formato hexadecimal.

## Qué hace la aplicación

- Selecciona una imagen mediante un explorador de archivos, con filtros para PNG, JPG, JPEG y BMP.
- Lee todos los bytes del archivo y los muestra como una cadena hexadecimal continua, en mayúsculas y con el prefijo `0x` (por ejemplo, `0x89504E47...`).
- Guarda la cadena generada en un archivo de texto.
- Copia el resultado al portapapeles.

> La conversión representa el archivo completo, incluidas sus cabeceras y metadatos. No genera Base64 ni extrae únicamente los píxeles de la imagen.

## Requisitos

- **Windows**: la interfaz utiliza Windows Forms.
- **SDK de .NET 8**: [descargar .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0). Para compilar necesitas el SDK, no solo el runtime.
- Para trabajar desde Visual Studio: **Visual Studio 2022 17.8 o posterior**, con la carga de trabajo **Desarrollo de escritorio de .NET** y el SDK de .NET 8 instalado.
- Opcionalmente, puedes usar **Visual Studio Code** con la extensión **C# Dev Kit** y el SDK de .NET 8.

## Obtener el código

Clona el repositorio y entra en su carpeta:

```powershell
git clone https://github.com/carlosYoko/image-to-byte-string.git
cd image-to-byte-string
```

También puedes descargar el ZIP desde GitHub y descomprimirlo. Los comandos de las siguientes secciones se ejecutan desde la carpeta que contiene `ImageToByteString.sln`.

## Compilar y ejecutar desde el editor

### Visual Studio 2022

1. Abre el archivo `ImageToByteString.sln`.
2. Espera a que Visual Studio restaure las dependencias del proyecto.
3. Si es necesario, haz clic derecho sobre el proyecto **ImageToByteString** y selecciona **Establecer como proyecto de inicio**.
4. Selecciona la configuración **Debug** para desarrollo o **Release** para una compilación optimizada.
5. Usa **Compilar > Compilar solución** (`Ctrl + Mayús + B`).
6. Ejecuta con **F5** (con depuración) o **Ctrl + F5** (sin depuración).

Al compilar en Release, el ejecutable se genera en:

```text
ImageToByteString\bin\Release\net8.0-windows\ImageToByteString.exe
```

En Debug, sustituye `Release` por `Debug`. Esta compilación necesita el **.NET Desktop Runtime 8** en el equipo donde se ejecute y los archivos que la acompañan en la carpeta de salida; no basta con copiar únicamente el `.exe`. Para distribuir la aplicación sin instalar .NET, utiliza la publicación autocontenida descrita más abajo.

### Visual Studio Code

1. Abre la carpeta del repositorio e instala la extensión **C# Dev Kit**.
2. Abre `ImageToByteString.sln` desde el explorador de soluciones de la extensión si no se carga automáticamente.
3. Desde la terminal integrada, compila y ejecuta con:

   ```powershell
   dotnet build .\ImageToByteString.sln -c Debug
   dotnet run --project .\ImageToByteString\ImageToByteString.csproj
   ```

También puedes usar **F5** para depurar, seleccionando el proyecto **ImageToByteString** si el editor te lo solicita. Visual Studio Code no incluye el diseñador visual de Windows Forms de Visual Studio.

## Generar un .exe para distribuir

### Opción 1: desde la terminal (autocontenido y en un solo archivo)

Con el SDK de .NET 8 instalado, ejecuta en Windows:

```powershell
dotnet publish .\ImageToByteString\ImageToByteString.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o .\publish\win-x64
```

El ejecutable estará en:

```text
publish\win-x64\ImageToByteString.exe
```

- `-c Release`: genera una compilación optimizada.
- `-r win-x64`: genera la aplicación para Windows de 64 bits. Usa `win-arm64` para ARM64 o `win-x86` para Windows de 32 bits y cambia también la carpeta de salida para distinguirlas.
- `--self-contained true`: incluye .NET, por lo que el equipo de destino no necesita instalar el runtime.
- `PublishSingleFile=true`: agrupa la aplicación en un único ejecutable.
- `IncludeNativeLibrariesForSelfExtract=true`: incluye las bibliotecas nativas en el ejecutable; se extraen al ejecutar la aplicación.
- `-o`: indica la carpeta de salida.

Puedes distribuir ese `.exe`. Si aparece un archivo `.pdb`, contiene símbolos de depuración y no es necesario para ejecutar la aplicación. Al incluir .NET, el ejecutable será mayor que una compilación normal.

### Opción 2: desde Visual Studio 2022

1. Haz clic derecho sobre el proyecto **ImageToByteString** y selecciona **Publicar**.
2. Crea un perfil con destino **Carpeta** y elige la ubicación de salida.
3. Abre la configuración del perfil (los nombres pueden variar según la versión de Visual Studio) y selecciona:
   - **Configuración**: `Release`.
   - **Marco de destino**: `net8.0-windows`.
   - **Modo de implementación**: **Autocontenido**.
   - **Runtime de destino**: `win-x64` (o la arquitectura del equipo de destino).
   - En las opciones de publicación de archivos, activa **Producir un solo archivo**.
4. Para incluir también las bibliotecas nativas en ese único ejecutable, edita el archivo `.pubxml` del perfil generado en `ImageToByteString\Properties\PublishProfiles\` y añade dentro de su `<PropertyGroup>`:

   ```xml
   <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
   ```

5. Guarda los cambios y pulsa **Publicar**.
6. Abre la carpeta de publicación y comprueba que `ImageToByteString.exe` se ejecuta correctamente.

> **Compilar** genera los archivos para desarrollo o ejecución local. **Publicar** prepara la salida para distribuir la aplicación según el runtime y el modo de implementación elegidos.

## Cómo usar la aplicación

1. Ejecuta `ImageToByteString.exe`.
2. Pulsa **Seleccionar Imagen** y elige el archivo que quieres convertir.
3. La cadena hexadecimal aparecerá en el cuadro de texto.
4. Pulsa **Copiar al Portapapeles** para copiarla o **Guardar como TXT** para guardarla.

## Problemas habituales

- **No se reconoce `dotnet`**: instala el SDK de .NET 8 y vuelve a abrir la terminal o el editor. Puedes comprobar la instalación con `dotnet --list-sdks`.
- **Se solicita instalar .NET al abrir el ejecutable**: si usas una compilación normal, instala el **.NET Desktop Runtime 8** de la arquitectura correspondiente o genera una publicación autocontenida.
- **El ejecutable no funciona en otro equipo**: comprueba que el destino es Windows y que la arquitectura publicada coincide con la del equipo. Si no publicaste en un solo archivo, copia toda la carpeta de publicación.
