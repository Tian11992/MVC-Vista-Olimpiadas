USE [master]
GO
CREATE DATABASE [bdolimpiadas] ON  PRIMARY 
( NAME = N'bdolimpiadas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\bdolimpiadas.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bdolimpiadas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\bdolimpiadas_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bdolimpiadas] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdolimpiadas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdolimpiadas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdolimpiadas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdolimpiadas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdolimpiadas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdolimpiadas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bdolimpiadas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdolimpiadas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdolimpiadas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdolimpiadas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdolimpiadas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdolimpiadas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdolimpiadas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdolimpiadas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bdolimpiadas] SET  MULTI_USER 
GO
ALTER DATABASE [bdolimpiadas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdolimpiadas] SET DB_CHAINING OFF 
GO
USE [bdolimpiadas]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblmodalidades](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblmodalidades] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblpaises](
	[idpais] [int] IDENTITY(1,1) NOT NULL,
	[nombrepais] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblpaises] PRIMARY KEY CLUSTERED 
(
	[idpais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblparticipantes](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[pais] [int] NOT NULL,
	[edad] [tinyint] NULL,
 CONSTRAINT [PK_tblparticipantes] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [tblpaises] ON 

INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (1, N'Colombia')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (2, N'Argentina')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (3, N'Perú')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (4, N'Bolivia')
INSERT [tblpaises] ([idpais], [nombrepais]) VALUES (5, N'Rusia')
SET IDENTITY_INSERT [tblpaises] OFF
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (123123, N'Pito Perez', 4, 20)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (1111111, N'Gerart de Rivia', 5, 100)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (1234567, N'Anastasia Romanov', 5, 17)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (12341234, N'Tales de Mileto', 2, 30)
INSERT [tblparticipantes] ([cedula], [nombre], [pais], [edad]) VALUES (435224334, N'Tom el Gato', 1, 18)
ALTER TABLE [tblparticipantes]  WITH CHECK ADD  CONSTRAINT [FK_tblparticipantes_tblpaises] FOREIGN KEY([pais])
REFERENCES [tblpaises] ([idpais])
GO
ALTER TABLE [tblparticipantes] CHECK CONSTRAINT [FK_tblparticipantes_tblpaises]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[spConsultaPaises]
as
select * from dbo.tblpaises order by nombrepais asc


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spConsultaParticipantes]
as
select 
par.cedula as "CÉDULA",
par.nombre as "NOMBRE PARTICIPANTE",
pai.nombrepais as "PAÍS",
par.edad as "EDAD"
from dbo.tblparticipantes par
inner join dbo.tblpaises pai
on par.pais = pai.idpais

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spEliminarPais]
@idpais int
as
delete from dbo.tblpaises where
idpais = @idpais


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spEliminarParticipantes]
@cedula INT
as
delete from dbo.tblparticipantes
where cedula = @cedula

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spGuardarCambios]
@idpais int,
@nombrepais varchar(50)
as
update dbo.tblpaises set
nombrepais = @nombrepais where
idpais = @idpais


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spGuardarCambiosParticipantesCONPais]
@cedula INT,
@nombre varchar(100),
@pais int,
@edad tinyint = null
as
update dbo.tblparticipantes set 
nombre=@nombre, pais = @pais, edad = @edad
where cedula = @cedula

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spGuardarCambiosParticipantesSINPais]
@cedula INT,
@nombre varchar(100),
@edad tinyint = null
as
update dbo.tblparticipantes set 
nombre=@nombre, edad = @edad
where cedula = @cedula

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spGuardarNuevoParticipantes]
@cedula INT,
@nombre varchar(100),
@pais int,
@edad tinyint = null
as
insert into dbo.tblparticipantes (cedula, nombre, pais, edad)
values (@cedula,@nombre, @pais, @edad)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [spNuevoPais]
@nombrepais varchar(50)
as 
insert into dbo.tblpaises(nombrepais)
values (@nombrepais)


GO
USE [master]
GO
ALTER DATABASE [bdolimpiadas] SET  READ_WRITE 
GO
