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

### Es necesario tambien poblar la base:
Aca estan ambos scripts:
```postgresql
INSERT INTO "Products" ("ProductCode", "OriginalPrice", "Price", "Title", "Commission", "ShippingCost", "CreatedDate", "IsActive") VALUES
('MLM001', 5000, 3000, 'Guitar', 500, 149.5, '2023-05-21 00:00:00', TRUE),
('MLM002', 3000, 1500, 'Chair', 500, 170, '2023-05-21 00:00:00', TRUE),
('MLM003', 100000, 80000, 'PC', 20000, 5000, '2023-05-21 00:00:00', TRUE),
('MLM004', 15000, 8000, 'RAM1', 2000, 1000, '2023-05-21 00:00:00', TRUE),
('MLM005', 500, 100, 'USB', 50, 10, '2023-05-21 00:00:00', TRUE);

INSERT INTO "ProductCosts" ("ProductCode", "IVA", "Cost", "ProductId") VALUES
('MLM001', 0.16, 500, 1),
('MLM002', 0.16, 1000, 2),
('MLM003', 0.21, 70000, 3),
('MLM004', 0.21, 9000, 4),
('MLM005', 0.16, 200, 5);
```

Link a la api:
https://localhost:5001/swagger


