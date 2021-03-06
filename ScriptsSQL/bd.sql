
/****** Object:  Table [dbo].[Administrador]    Script Date: 24/10/2017 15:45:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Contraseña] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado]    Script Date: 24/10/2017 15:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evento]    Script Date: 24/10/2017 15:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreSolicitante] [nvarchar](50) NOT NULL,
	[TelefonoSolicitante] [nvarchar](100) NOT NULL,
	[EmailSolicitante] [nvarchar](100) NOT NULL,
	[MotivoNombre] [nvarchar](300) NULL,
	[Fecha] [datetime] NOT NULL,
	[Lugar] [nvarchar](100) NOT NULL,
	[Duracion] [nvarchar](50) NULL,
	[Dimensiones] [nvarchar](100) NULL,
	[Comentarios] [ntext] NULL,
	[Transporte] [ntext] NULL,
	[LinkFacebook] [nvarchar](50) NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Integrante]    Script Date: 24/10/2017 15:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Integrante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImagenUri] [nvarchar](400) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](100) NOT NULL,
	[TelefonoEmergencia] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[EstadoId] [int] NULL,
 CONSTRAINT [PK_Integrante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MesCuota]    Script Date: 24/10/2017 15:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MesCuota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Año] [int] NOT NULL,
	[Mes] [int] NULL,
	[CantidadPagos] [int] NULL,
 CONSTRAINT [PK_MesCuota] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MesCuota_Pago]    Script Date: 24/10/2017 15:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MesCuota_Pago](
	[PagoId] [int] NOT NULL,
	[MesCuotaId] [int] NOT NULL,
	[Total] [int] NOT NULL,
 CONSTRAINT [PK_MesCuota_Pago] PRIMARY KEY CLUSTERED 
(
	[PagoId] ASC,
	[MesCuotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pago]    Script Date: 24/10/2017 15:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[TalonPago] [int] NOT NULL,
	[Comentarios] [ntext] NULL,
	[IntegranteId] [int] NOT NULL,
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Estado]    Script Date: 24/10/2017 15:45:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Estado] ON [dbo].[Estado]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Integrante]    Script Date: 24/10/2017 15:45:06 ******/
CREATE NONCLUSTERED INDEX [IX_Integrante] ON [dbo].[Integrante]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Integrante]  WITH CHECK ADD  CONSTRAINT [FK_Integrante_Estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Integrante] CHECK CONSTRAINT [FK_Integrante_Estado]
GO
ALTER TABLE [dbo].[MesCuota_Pago]  WITH CHECK ADD  CONSTRAINT [FK_MesCuota_Pago_MesCuota] FOREIGN KEY([PagoId])
REFERENCES [dbo].[MesCuota] ([Id])
GO
ALTER TABLE [dbo].[MesCuota_Pago] CHECK CONSTRAINT [FK_MesCuota_Pago_MesCuota]
GO
ALTER TABLE [dbo].[MesCuota_Pago]  WITH CHECK ADD  CONSTRAINT [FK_MesCuota_Pago_Pago] FOREIGN KEY([MesCuotaId])
REFERENCES [dbo].[Pago] ([Id])
GO
ALTER TABLE [dbo].[MesCuota_Pago] CHECK CONSTRAINT [FK_MesCuota_Pago_Pago]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Integrante] FOREIGN KEY([IntegranteId])
REFERENCES [dbo].[Integrante] ([Id])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Integrante]
GO
USE [master]
GO
ALTER DATABASE [TaikoCordoba] SET  READ_WRITE 
GO
