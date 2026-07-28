
USE [master]
GO

/****** Object:  Database [SGIT]    Script Date: 07/25/2026 23:37:24 ******/
CREATE DATABASE [SGIT]
 ON  PRIMARY 
( NAME = N'SGIT', FILENAME = N'C:\repos\davidalexandermites\SGFT\BDD\SGIT.mdf' , SIZE = 10MB , MAXSIZE = 1GB, FILEGROWTH = 10MB )
 LOG ON 
( NAME = N'SGIT_Log', FILENAME = N'C:\repos\davidalexandermites\SGFT\BDD\SGIT_Log.ldf' , SIZE = 10MB , MAXSIZE = 1GB , FILEGROWTH = 10MB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO



USE [SGIT]
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](64) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Telefono] [nvarchar](32) NULL,
	[Activo] [bit] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL
 CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [SGIT]
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](64) NOT NULL,
	[FechaVencimiento] [datetime] NULL,
	[Activo] [bit] NOT NULL,
	[Importancia] [int] NULL
 CONSTRAINT [PK_dbo.Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [SGIT]
GO
CREATE TABLE [dbo].[ProductoUsuario](
	[IdProductoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaAsignacion] [datetime] NULL
 CONSTRAINT [PK_dbo.ProductoUsuario] PRIMARY KEY CLUSTERED 
(
	[IdProductoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_ProductoUsuario_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProductoUsuario] CHECK CONSTRAINT [FK_ProductoUsuario_Producto]
GO


ALTER TABLE [dbo].[ProductoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_ProductoUsuario_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProductoUsuario] CHECK CONSTRAINT [FK_ProductoUsuario_Usuario]
GO


/*****
Data PRODUCTOS
*****/


USE [SGIT]
GO

INSERT INTO [dbo].[Producto]
           ([Nombre]
           ,[FechaVencimiento]
           ,[Activo]
           ,[Importancia])
     VALUES
           ('PRODUCTO A'
           ,DATEADD(DAY, 5, GETDATE())
           ,1
           ,2)


INSERT INTO [dbo].[Producto]
           ([Nombre]
           ,[FechaVencimiento]
           ,[Activo]
           ,[Importancia])
     VALUES
           ('PRODUCTO B'
           ,DATEADD(DAY, 20, GETDATE())
           ,1
           ,2)
GO


INSERT INTO [dbo].[Producto]
           ([Nombre]
           ,[FechaVencimiento]
           ,[Activo]
           ,[Importancia])
     VALUES
           ('PRODUCTO C'
           ,DATEADD(DAY, 3, GETDATE())
           ,1
           ,2)
GO


INSERT INTO [dbo].[Producto]
           ([Nombre]
           ,[FechaVencimiento]
           ,[Activo]
           ,[Importancia])
     VALUES
           ('PRODUCTO D'
           ,DATEADD(DAY, 5, GETDATE())
           ,1
           ,2)
GO


/*****
Data USUARIOS
*****/

USE [SGIT]
GO

INSERT INTO [dbo].[Usuario]
           ([Nombres]
           ,[Email]
           ,[Telefono]
           ,[Activo]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion])
     VALUES
           ('PRIMER USUARIO'
           ,'PRIMER@MAIL.COM'
           ,'123456789'
           ,1
           ,1
           ,GETDATE()
           ,1
           ,GETDATE())
GO


INSERT INTO [dbo].[Usuario]
           ([Nombres]
           ,[Email]
           ,[Telefono]
           ,[Activo]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion])
     VALUES
           ('SEGUNDO USUARIO'
           ,'SEGUNDO@MAIL.COM'
           ,'123456780'
           ,1
           ,1
           ,GETDATE()
           ,1
           ,GETDATE())
GO


INSERT INTO [dbo].[Usuario]
           ([Nombres]
           ,[Email]
           ,[Telefono]
           ,[Activo]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion])
     VALUES
           ('TERCER USUARIO'
           ,'TERCER@MAIL.COM'
           ,'1234567811'
           ,1
           ,1
           ,GETDATE()
           ,1
           ,GETDATE())
GO


/*****
Data ASIGNACIONES
*****/

USE [SGIT]
GO

INSERT INTO [dbo].[ProductoUsuario]
           ([IdProducto]
           ,[IdUsuario]
           ,[FechaAsignacion])
     VALUES
           (1
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ProductoUsuario]
           ([IdProducto]
           ,[IdUsuario]
           ,[FechaAsignacion])
     VALUES
           (2
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ProductoUsuario]
           ([IdProducto]
           ,[IdUsuario]
           ,[FechaAsignacion])
     VALUES
           (3
           ,1
           ,GETDATE())
GO

INSERT INTO [dbo].[ProductoUsuario]
           ([IdProducto]
           ,[IdUsuario]
           ,[FechaAsignacion])
     VALUES
           (3
           ,2
           ,GETDATE())
GO

INSERT INTO [dbo].[ProductoUsuario]
           ([IdProducto]
           ,[IdUsuario]
           ,[FechaAsignacion])
     VALUES
           (4
           ,3
           ,GETDATE())
GO



select top 20 *
from Usuario;

select top 20 *
from Producto;

select top 20 * 
from ProductoUsuario;