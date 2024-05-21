# Marketplace API

¡Hola! Este es un proyecto de API para un marketplace, hecho con .NET 6.0, Entity Framework Core y PostgreSQL.

## ¿Qué necesitas antes de empezar?

1. **.NET 6.0 SDK**: Asegurate de tenerlo instalado. Podés descargarlo [acá](https://dotnet.microsoft.com/download/dotnet/6.0).
2. **PostgreSQL**: Instala PostgreSQL desde [acá](https://www.postgresql.org/download/).
3. **pgAdmin**: O cualquier herramienta que te guste para manejar PostgreSQL.

## Cómo levantar el repo

### 1. Clonar el Repositorio

Primero, clona este repo:

```sh
git clone https://github.com/tu-usuario/tu-repositorio.git
```
### 2. Crea la Base de datos, yo use postgressql

```sh
CREATE DATABASE marketplace;
```

### 3. Hay que configurar el appsettings con el string de conexion a la bd
```c#
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=marketplace;Username=postgres;Password=postgre321"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
Igual en el repo quedaron mis credenciales, pero bastaria con cambiar user y password

### 4. Restaurar las dependencias

Hay que restaurar las dependencias, por lo tanto te tenes que parar en el repositorio y hacer lo siguiente:

```sh 
cd tu-repositorio/MarketPlaceApi
dotnet restore
```

### 5. Hay que aplicar las migraciones y updatear la base de datos
```sh 
dotnet ef migrations add InitialCreate
```

```sh 
dotnet ef database update
```

### 6. Correr la api

```sh 
dotnet run
```

### Consideraciones
Un error que tuve fue con los certificados SSL, para solucionar:
```sh 
dotnet dev-certs https --trust
```
Tambien hay que tener en cuenta que se debe instalar swagger, mas que nada para probar la api facilmente
```sh 
dotnet add package Swashbuckle.AspNetCore
```

Link a la api:
https://localhost:5001/swagger


