# Proyecto: Sistema Gestor de Flujo de Trabajo - SGFT

## Resumen
Aplicación esta implementada en C# con .NET Core 8.0 para gestionar el flujo de trabajo.
Permite registrar la cantidad de items de trabajo asignados a un usuario, ademas de distribuirlos segun fecha de entrega y relevancia, con persistencia en SQL Server se aplico microservicio.


## Arquitectura
- **Backend:** ASP.NET Core Web API .NET 8.0, 
- **Base de datos:** SQL Server con EF Core
- **Patrones:** Repository + Dependency Injection


## Screemshots

API Distribucion de Items de Trabajo a Usuarios.

Endpoint Obtener usuarios con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.
<img width="630" height="716" alt="image" src="https://github.com/user-attachments/assets/1414426f-7a8a-4aec-be6e-e81fc5bbbcf0" />

Endpoint Obtener usuarios filtrado por id del cliente con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.
<img width="665" height="681" alt="image" src="https://github.com/user-attachments/assets/42708b0b-a726-431f-a1f9-6dcf5740f33e" />

Endpoint Obtener usuarios filtrado por estado de asignacion del cliente con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.

<img width="613" height="594" alt="image" src="https://github.com/user-attachments/assets/5de683c4-1b63-4fbd-aa09-421ca3d6e177" />
 













































