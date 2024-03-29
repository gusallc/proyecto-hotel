CREATE DATABASE dbhotel
GO
USE [dbhotel]
GO
/****** Object:  Table [categoria_habitacion]    Script Date: 8/10/2019 20:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [categoria_habitacion](
	[cat_id] [int] IDENTITY(1,1) NOT NULL,
	[desc_cat] [varchar](45) NOT NULL,
	[estado_cat] [char](1) NOT NULL,
 CONSTRAINT [pk_cat_hab] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [clientes]    Script Date: 8/10/2019 20:36:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [clientes](
	[dni_clientes] [varchar](8) NOT NULL,
	[apenom_cli] [varchar](255) NULL,
	[edad_cli] [int] NULL,
	[dni_usu] [varchar](8) NOT NULL,
	[estado_cli] [char](1) NOT NULL,
 CONSTRAINT [pk_cli] PRIMARY KEY CLUSTERED 
(
	[dni_clientes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [detalle_reserva]    Script Date: 8/10/2019 20:36:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [detalle_reserva](
	[idDetReserva] [int] IDENTITY(1,1) NOT NULL,
	[fk_num_habi] [char](3) NOT NULL,
	[fk_id_reserva] [int] NOT NULL,
	[estado_det] [int] NOT NULL,
 CONSTRAINT [PK_detalle_reserva] PRIMARY KEY CLUSTERED 
(
	[idDetReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [habitacion]    Script Date: 8/10/2019 20:36:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [habitacion](
	[num_habi] [char](3) NOT NULL,
	[desc_habi] [varchar](200) NOT NULL,
	[precio_habi] [money] NOT NULL,
	[cat_id] [int] NOT NULL,
	[id_piso] [int] NOT NULL,
	[img_habi] [varchar](max) NULL,
	[estado_habi] [char](1) NOT NULL,
 CONSTRAINT [pk_habi] PRIMARY KEY CLUSTERED 
(
	[num_habi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [piso]    Script Date: 8/10/2019 20:36:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [piso](
	[id_piso] [int] IDENTITY(1,1) NOT NULL,
	[desc_piso] [varchar](65) NOT NULL,
	[estado_piso] [char](1) NOT NULL,
 CONSTRAINT [PK_piso] PRIMARY KEY CLUSTERED 
(
	[id_piso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [reserva]    Script Date: 8/10/2019 20:36:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [reserva](
	[res_id] [int] IDENTITY(1,1) NOT NULL,
	[fecha_ingreso] [datetime] NOT NULL,
	[fecha_salida] [datetime] NOT NULL,
	[cant_personas] [int] NOT NULL,
	[dni_clientes] [varchar](8) NOT NULL,
	[estado_pago] [char](1) NOT NULL,
 CONSTRAINT [pk_res] PRIMARY KEY CLUSTERED 
(
	[res_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [usuario]    Script Date: 8/10/2019 20:36:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [usuario](
	[dni_usu] [varchar](8) NOT NULL,
	[apenom_usu] [varchar](45) NOT NULL,
	[password_usu] [varchar](45) NOT NULL,
	[direccion_usu] [varchar](45) NOT NULL,
	[estado_usu] [char](1) NOT NULL,
 CONSTRAINT [PK_dni_usu] PRIMARY KEY CLUSTERED 
(
	[dni_usu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [categoria_habitacion] ADD  DEFAULT ((1)) FOR [estado_cat]
GO
ALTER TABLE [clientes] ADD  DEFAULT ((1)) FOR [estado_cli]
GO
ALTER TABLE [detalle_reserva] ADD  CONSTRAINT [DF_detalle_reserva_estado_det]  DEFAULT ((1)) FOR [estado_det]
GO
ALTER TABLE [habitacion] ADD  DEFAULT ((1)) FOR [estado_habi]
GO
ALTER TABLE [piso] ADD  DEFAULT ((1)) FOR [estado_piso]
GO
ALTER TABLE [clientes]  WITH CHECK ADD  CONSTRAINT [fk_cliente_usu] FOREIGN KEY([dni_usu])
REFERENCES [usuario] ([dni_usu])
GO
ALTER TABLE [clientes] CHECK CONSTRAINT [fk_cliente_usu]
GO
ALTER TABLE [detalle_reserva]  WITH CHECK ADD  CONSTRAINT [FK_detalle_reserva_habitacion] FOREIGN KEY([fk_num_habi])
REFERENCES [habitacion] ([num_habi])
GO
ALTER TABLE [detalle_reserva] CHECK CONSTRAINT [FK_detalle_reserva_habitacion]
GO
ALTER TABLE [detalle_reserva]  WITH CHECK ADD  CONSTRAINT [FK_detalle_reserva_reserva] FOREIGN KEY([fk_id_reserva])
REFERENCES [reserva] ([res_id])
GO
ALTER TABLE [detalle_reserva] CHECK CONSTRAINT [FK_detalle_reserva_reserva]
GO
ALTER TABLE [habitacion]  WITH CHECK ADD  CONSTRAINT [fk_habi_cat_habi] FOREIGN KEY([cat_id])
REFERENCES [categoria_habitacion] ([cat_id])
GO
ALTER TABLE [habitacion] CHECK CONSTRAINT [fk_habi_cat_habi]
GO
ALTER TABLE [habitacion]  WITH CHECK ADD  CONSTRAINT [fk_habi_piso] FOREIGN KEY([id_piso])
REFERENCES [piso] ([id_piso])
GO
ALTER TABLE [habitacion] CHECK CONSTRAINT [fk_habi_piso]
GO
ALTER TABLE [reserva]  WITH CHECK ADD  CONSTRAINT [fk_res_cli] FOREIGN KEY([dni_clientes])
REFERENCES [clientes] ([dni_clientes])
GO
ALTER TABLE [reserva] CHECK CONSTRAINT [fk_res_cli]
GO
