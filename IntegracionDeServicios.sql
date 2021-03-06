USE [IntegracionDeServicios]
GO
/****** Object:  Table [dbo].[Beneficiario]    Script Date: 6/6/2013 5:28:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiario](
	[id_Key] [int] IDENTITY(1,1) NOT NULL,
	[SSN1] [nchar](3) NOT NULL,
	[SSN2] [nchar](2) NOT NULL,
	[SSN3] [nchar](4) NOT NULL,
	[Nombre] [nvarchar](20) NULL,
	[SegundoNombre] [nvarchar](20) NULL,
	[ApellidoPaterno] [nvarchar](20) NULL,
	[ApellidoMaterno] [nvarchar](20) NULL,
	[FechaDeNac] [datetime] NULL,
	[Sexo] [nvarchar](1) NULL,
	[MunicipioResidencia] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Beneficiario] PRIMARY KEY CLUSTERED 
(
	[id_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Serv_Benef]    Script Date: 6/6/2013 5:28:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Serv_Benef](
	[Id_Serv] [int] NOT NULL,
	[id_key] [int] NOT NULL,
	[Activo] [bit] NULL,
	[FechaServ] [datetime] NULL,
 CONSTRAINT [PK_Serv_Benef] PRIMARY KEY CLUSTERED 
(
	[Id_Serv] ASC,
	[id_key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 6/6/2013 5:28:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[Id_Serv] [int] NOT NULL,
	[Servicio] [nvarchar](10) NOT NULL,
	[CodServ] [nvarchar](10) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[Id_Serv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Serv_Benef]  WITH CHECK ADD  CONSTRAINT [FK_Serv_Benef_Beneficiario] FOREIGN KEY([id_key])
REFERENCES [dbo].[Beneficiario] ([id_Key])
GO
ALTER TABLE [dbo].[Serv_Benef] CHECK CONSTRAINT [FK_Serv_Benef_Beneficiario]
GO
ALTER TABLE [dbo].[Serv_Benef]  WITH CHECK ADD  CONSTRAINT [FK_Serv_Benef_Servicio] FOREIGN KEY([Id_Serv])
REFERENCES [dbo].[Servicio] ([Id_Serv])
GO
ALTER TABLE [dbo].[Serv_Benef] CHECK CONSTRAINT [FK_Serv_Benef_Servicio]
GO
