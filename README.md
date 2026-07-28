# Proyecto: Sistema Gestor de Flujo de Trabajo - SGFT

## Resumen
Aplicación esta implementada en C# con .NET Core 8.0 para gestionar el flujo de trabajo.
Permite registrar la cantidad de items de trabajo asignados a un usuario, ademas de distribuirlos segun fecha de entrega y relevancia, con persistencia en SQL Server se aplico microservicio.


## Arquitectura
- **Backend:** ASP.NET Core Web API .NET 8.0, 
- **Base de datos:** SQL Server con EF Core
- **Patrones:** Repository + Dependency Injection


## Screemshots

API Distribucion de Items de Trabajo a Usuarios
Endpoint Obtener usuarios con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.





Endpoint Obtener usuarios filtrado por id del cliente con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.




Endpoint Obtener usuarios filtrado por estado de asignacion del cliente con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.

 













































