# Proyecto: Sistema Gestor de Flujo de Trabajo - SGFT

## Resumen
Aplicación esta implementada en C# con .NET Core 8.0 para gestionar el flujo de trabajo.
Permite registrar la cantidad de items de trabajo asignados a un usuario, ademas de distribuirlos segun fecha de entrega y relevancia, con persistencia en SQL Server se aplico microservicio.


## Arquitectura
- **Backend:** ASP.NET Core Web API Rest .NET 8.0, 
- **Base de datos:** SQL Server con EF Core 8.0.29
- **Patrones:** Repository + Dependency Injection

## Endpoints
Microservicio SGUT
| Método | Ruta | Descripción | Request Body | Response |
| --- | --- | --- | --- | --- |
| GET | ``/Usuario/ObtenerUsuarios`` | Lista todos los usuarios con sus items de trabajo ordenados por fecha proxima y relevancia | N/A | JSON |
| GET | ``/Usuario/ObtenerUsuariosPorEstado?estado={idEstado}`` | Obtiene usuarios por Estado con sus items de trabajo | N/A | JSON |
| GET | ``/Usuario/ObtenerUsuarioPorID?idCliente={idUsuario}`` | Obtiene usuarios por ID con sus items de trabajo  | N/A | JSON  |
| POST | ``/Usuario/AsignarItemUsuario`` | Asignar Item a Usuario | JSON ``{
  "idProducto": 5,
  "fechaVencimiento": "2026-07-31T19:13:34.335Z"
}`` | JSON actualizado |

Microservicio SGIT
| Método | Ruta | Descripción | Request Body | Response |
| --- | --- | --- | --- | --- |
| GET | ``/api/tareas`` | Lista todas las tareas | N/A | JSON |
| GET | ``/Producto/ObtenerProductosPorID?{idProducto}`` | Obtiene lo item por ID | N/A | JSON |
| POST | ``/Producto/CrearProducto`` | Crea nueva item de trabajo | JSON ``{
  "nombre": "PRODUCTO G",
  "fechaVencimiento": "2026-08-28T18:56:41.333Z",
  "importancia": 0
}`` | JSON con Item creado |

## Screemshots

API Distribucion de Items de Trabajo a Usuarios.

Endpoint Obtener usuarios con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.
<img width="630" height="716" alt="image" src="https://github.com/user-attachments/assets/1414426f-7a8a-4aec-be6e-e81fc5bbbcf0" />

Endpoint Obtener usuarios filtrado por id del cliente con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.
<img width="665" height="681" alt="image" src="https://github.com/user-attachments/assets/42708b0b-a726-431f-a1f9-6dcf5740f33e" />

Endpoint Obtener usuarios filtrado por estado (1=SATURADOS; 2=NO SATURADOS)de asignacion del cliente con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.

<img width="613" height="594" alt="image" src="https://github.com/user-attachments/assets/5de683c4-1b63-4fbd-aa09-421ca3d6e177" />
 
Endpoint para asignar items de trabajo usuarios con menor carga y posteior obtener usuarioal cual fue asignado con sus Items de trabajo ordenados por fecha de vencimiento y relevancia.
<img width="671" height="713" alt="image" src="https://github.com/user-attachments/assets/9024679d-68f3-48c6-a3d8-599c530436a3" />

API Items de Trabajo.

Endpoint Obtener el listado de items con sus Items de trabajo ordenados por relevancia.
<img width="610" height="732" alt="image" src="https://github.com/user-attachments/assets/df5339b7-e9c0-4c1a-ba8f-17ca3f1b192c" />

<img width="641" height="737" alt="image" src="https://github.com/user-attachments/assets/5a122983-8668-4e03-b0a1-688e0453b488" />

Endpoint Obtener un items filtrado por ID del Item.
<img width="530" height="483" alt="image" src="https://github.com/user-attachments/assets/786cc38c-8c01-4910-9a8c-7fc22a4423e6" />

Endpoint para crear items de trabajo
<img width="705" height="722" alt="image" src="https://github.com/user-attachments/assets/6c267190-0b31-4fde-8934-21c65c86d9de" />

##  Estructura del Código
| Capa | Aplicacion | Responsabilidad principal |
| --- | --- | --- |
| **Capa de Negocio** | **Application + Domain** | Casos de uso, reglas de negocio, validaciones |
| **Capa de DAO** | **Infrastructure** | Acceso a datos (repositorios, EF Core, SQL) |
| **Capa de Models** | **Domain** | Entidades y DTOs |
| **WebAPI** | **Presentation** | Controladores, endpoints, entrada/salida |

                 +-------------------+
                 |      WebAPI       |
                 | (Controllers,     |
                 | Endpoints REST)   |
                 +-------------------+
                          |
                          v
                 +-------------------+
                 | Capa de Negocio   |
                 | Casos de uso,     |
                 | lógica de negocio |
                 +-------------------+
                          |
                          v
                 +-------------------+
                 |     Models        |
                 | Entidades, DTOs   |
                 +-------------------+
                          ^
                          |
                 +-------------------+
                 |      DAO          |
                 | Repositorios,     |
                 | EF Core, SQL      |
                 +-------------------+

































