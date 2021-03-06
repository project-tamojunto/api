USE [db_tamo_junto]
GO
/****** Object:  Table [dbo].[tb_agenda_servico]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_agenda_servico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idServico] [int] NULL,
	[data] [date] NULL,
	[horarioIni] [time](0) NULL,
	[horarioFim] [time](0) NULL,
	[qtdVagas] [int] NULL,
	[dtExclusao] [datetime] NULL,
 CONSTRAINT [PK_tb_agenda_servico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_agenda_usuario]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_agenda_usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[idAgendaServico] [int] NULL,
	[flagRealizado] [bit] NULL,
	[avaliacao] [decimal](2, 1) NULL,
	[comentarioAvaliacao] [varchar](500) NULL,
	[dtCancelamento] [datetime] NULL,
	[dtExclusao] [datetime] NULL,
 CONSTRAINT [PK_tb_agenda_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_categoria_servico]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_categoria_servico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](255) NULL,
	[dtExclusao] [datetime] NULL,
 CONSTRAINT [PK_tb_categoria_servico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_categoria_servico_profissao]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_categoria_servico_profissao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCategoriaServico] [int] NOT NULL,
	[idProfissao] [int] NOT NULL,
 CONSTRAINT [PK_tb_categoria_servico_profissao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_instrutor_profissao]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_instrutor_profissao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idInstrutor] [int] NULL,
	[idProfissao] [int] NULL,
	[dtExclusao] [datetime] NULL,
 CONSTRAINT [PK_tb_usuario_profissao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_profissao]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_profissao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](255) NULL,
	[dtExclusao] [datetime] NULL,
 CONSTRAINT [PK_tb] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_servico]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_servico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idInstrutor] [int] NULL,
	[idCategoriaServico] [int] NULL,
	[nome] [varchar](255) NULL,
	[preco] [decimal](10, 2) NULL,
	[descricao] [varchar](max) NULL,
	[latitude] [varchar](30) NULL,
	[longitude] [varchar](30) NULL,
	[servicosAdicionais] [varchar](2000) NULL,
	[dtExclusao] [datetime] NULL,
 CONSTRAINT [PK_tb_servico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_servico_instrutor]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_servico_instrutor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idServico] [int] NOT NULL,
	[idInstrutor] [int] NOT NULL,
	[dtExclusao] [datetime] NULL,
 CONSTRAINT [PK_tb_servico_instrutor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_tipo_usuario]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_tipo_usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](255) NULL,
 CONSTRAINT [PK_tb_perfil] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 20/08/2017 12:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTipoUsuario] [int] NOT NULL,
	[login] [varchar](100) NULL,
	[senha] [varchar](100) NULL,
	[flagPessoaJuridica] [bit] NOT NULL,
	[flagProfissional] [bit] NOT NULL,
	[nome] [varchar](255) NULL,
	[meuPerfil] [varchar](max) NULL,
	[nroDocumento] [varchar](20) NULL,
	[rg] [varchar](20) NULL,
	[nroCelular] [varchar](20) NULL,
	[nroTelefone] [varchar](20) NULL,
	[flagValidado] [bit] NULL,
 CONSTRAINT [PK_tb_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_agenda_servico] ON 

INSERT [dbo].[tb_agenda_servico] ([id], [idServico], [data], [horarioIni], [horarioFim], [qtdVagas], [dtExclusao]) VALUES (3, NULL, NULL, CAST(N'12:00:00' AS Time), CAST(N'23:00:00' AS Time), 120, NULL)
INSERT [dbo].[tb_agenda_servico] ([id], [idServico], [data], [horarioIni], [horarioFim], [qtdVagas], [dtExclusao]) VALUES (5, 2, NULL, CAST(N'10:10:00' AS Time), CAST(N'10:10:00' AS Time), 20, NULL)
INSERT [dbo].[tb_agenda_servico] ([id], [idServico], [data], [horarioIni], [horarioFim], [qtdVagas], [dtExclusao]) VALUES (6, 1, CAST(N'2018-04-15' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 20, NULL)
INSERT [dbo].[tb_agenda_servico] ([id], [idServico], [data], [horarioIni], [horarioFim], [qtdVagas], [dtExclusao]) VALUES (7, 3, CAST(N'2019-08-15' AS Date), CAST(N'15:00:00' AS Time), CAST(N'15:50:00' AS Time), 10, NULL)
SET IDENTITY_INSERT [dbo].[tb_agenda_servico] OFF
SET IDENTITY_INSERT [dbo].[tb_agenda_usuario] ON 

INSERT [dbo].[tb_agenda_usuario] ([id], [idUsuario], [idAgendaServico], [flagRealizado], [avaliacao], [comentarioAvaliacao], [dtCancelamento], [dtExclusao]) VALUES (1, 9, 3, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tb_agenda_usuario] OFF
SET IDENTITY_INSERT [dbo].[tb_categoria_servico] ON 

INSERT [dbo].[tb_categoria_servico] ([id], [descricao], [dtExclusao]) VALUES (1, N'Paraquedismo', NULL)
INSERT [dbo].[tb_categoria_servico] ([id], [descricao], [dtExclusao]) VALUES (2, N'Trilha', NULL)
INSERT [dbo].[tb_categoria_servico] ([id], [descricao], [dtExclusao]) VALUES (3, N'Bungee jumping', NULL)
SET IDENTITY_INSERT [dbo].[tb_categoria_servico] OFF
SET IDENTITY_INSERT [dbo].[tb_categoria_servico_profissao] ON 

INSERT [dbo].[tb_categoria_servico_profissao] ([id], [idCategoriaServico], [idProfissao]) VALUES (1, 1, 1)
INSERT [dbo].[tb_categoria_servico_profissao] ([id], [idCategoriaServico], [idProfissao]) VALUES (2, 3, 2)
SET IDENTITY_INSERT [dbo].[tb_categoria_servico_profissao] OFF
SET IDENTITY_INSERT [dbo].[tb_instrutor_profissao] ON 

INSERT [dbo].[tb_instrutor_profissao] ([id], [idInstrutor], [idProfissao], [dtExclusao]) VALUES (6, 7, 1, NULL)
INSERT [dbo].[tb_instrutor_profissao] ([id], [idInstrutor], [idProfissao], [dtExclusao]) VALUES (7, 7, 2, NULL)
INSERT [dbo].[tb_instrutor_profissao] ([id], [idInstrutor], [idProfissao], [dtExclusao]) VALUES (8, 8, 1, NULL)
INSERT [dbo].[tb_instrutor_profissao] ([id], [idInstrutor], [idProfissao], [dtExclusao]) VALUES (9, 8, 2, NULL)
SET IDENTITY_INSERT [dbo].[tb_instrutor_profissao] OFF
SET IDENTITY_INSERT [dbo].[tb_profissao] ON 

INSERT [dbo].[tb_profissao] ([id], [descricao], [dtExclusao]) VALUES (1, N'Paraquedista', NULL)
INSERT [dbo].[tb_profissao] ([id], [descricao], [dtExclusao]) VALUES (2, N'Salto', NULL)
SET IDENTITY_INSERT [dbo].[tb_profissao] OFF
SET IDENTITY_INSERT [dbo].[tb_servico] ON 

INSERT [dbo].[tb_servico] ([id], [idInstrutor], [idCategoriaServico], [nome], [preco], [descricao], [latitude], [longitude], [servicosAdicionais], [dtExclusao]) VALUES (1, 8, 1, N'Paraquedismo', CAST(600.00 AS Decimal(10, 2)), N'Parequedismo', NULL, NULL, N'Fotografica à drone', NULL)
INSERT [dbo].[tb_servico] ([id], [idInstrutor], [idCategoriaServico], [nome], [preco], [descricao], [latitude], [longitude], [servicosAdicionais], [dtExclusao]) VALUES (2, 8, 3, N'Na montanha', CAST(250.00 AS Decimal(10, 2)), N'ASDFWSGEFFWEDFWDFWdf
wFWEFWFCSDGFGERWF
', NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_servico] ([id], [idInstrutor], [idCategoriaServico], [nome], [preco], [descricao], [latitude], [longitude], [servicosAdicionais], [dtExclusao]) VALUES (3, 8, 2, N'Hack', CAST(150.00 AS Decimal(10, 2)), N'Descrição', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tb_servico] OFF
SET IDENTITY_INSERT [dbo].[tb_tipo_usuario] ON 

INSERT [dbo].[tb_tipo_usuario] ([id], [descricao]) VALUES (1, N'Cliente')
INSERT [dbo].[tb_tipo_usuario] ([id], [descricao]) VALUES (2, N'Instrutor')
INSERT [dbo].[tb_tipo_usuario] ([id], [descricao]) VALUES (3, N'Adminstrador')
SET IDENTITY_INSERT [dbo].[tb_tipo_usuario] OFF
SET IDENTITY_INSERT [dbo].[tb_usuario] ON 

INSERT [dbo].[tb_usuario] ([id], [idTipoUsuario], [login], [senha], [flagPessoaJuridica], [flagProfissional], [nome], [meuPerfil], [nroDocumento], [rg], [nroCelular], [nroTelefone], [flagValidado]) VALUES (5, 2, NULL, NULL, 0, 1, N'Charles Alberto', N'I''m Happy', N'44664483880', NULL, N'(11) 994464314', N'(11) 994464314', 0)
INSERT [dbo].[tb_usuario] ([id], [idTipoUsuario], [login], [senha], [flagPessoaJuridica], [flagProfissional], [nome], [meuPerfil], [nroDocumento], [rg], [nroCelular], [nroTelefone], [flagValidado]) VALUES (7, 2, NULL, NULL, 0, 1, N'Charles Alberto', N'I''m Happy', N'44664483880', NULL, N'(11) 994464314', NULL, 1)
INSERT [dbo].[tb_usuario] ([id], [idTipoUsuario], [login], [senha], [flagPessoaJuridica], [flagProfissional], [nome], [meuPerfil], [nroDocumento], [rg], [nroCelular], [nroTelefone], [flagValidado]) VALUES (8, 2, N'CCharles', N'Caos6553', 0, 1, N'Charles Alberto', N'I''m Happy', N'44664483880', NULL, N'(11) 994464314', NULL, 1)
INSERT [dbo].[tb_usuario] ([id], [idTipoUsuario], [login], [senha], [flagPessoaJuridica], [flagProfissional], [nome], [meuPerfil], [nroDocumento], [rg], [nroCelular], [nroTelefone], [flagValidado]) VALUES (9, 1, N'', NULL, 0, 0, N'Charles Alberto', N'I''m Happy', N'44664483880', NULL, N'(11) 994464314', N'(11) 994464314', NULL)
INSERT [dbo].[tb_usuario] ([id], [idTipoUsuario], [login], [senha], [flagPessoaJuridica], [flagProfissional], [nome], [meuPerfil], [nroDocumento], [rg], [nroCelular], [nroTelefone], [flagValidado]) VALUES (11, 2, N'Cesinha', N'123123', 0, 0, N'Cesar', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tb_usuario] OFF
ALTER TABLE [dbo].[tb_agenda_servico]  WITH CHECK ADD  CONSTRAINT [FK_tb_agenda_servico_tb_servico] FOREIGN KEY([idServico])
REFERENCES [dbo].[tb_servico] ([id])
GO
ALTER TABLE [dbo].[tb_agenda_servico] CHECK CONSTRAINT [FK_tb_agenda_servico_tb_servico]
GO
ALTER TABLE [dbo].[tb_agenda_usuario]  WITH CHECK ADD  CONSTRAINT [FK_tb_agenda_usuario_tb_agenda_servico] FOREIGN KEY([idAgendaServico])
REFERENCES [dbo].[tb_agenda_servico] ([id])
GO
ALTER TABLE [dbo].[tb_agenda_usuario] CHECK CONSTRAINT [FK_tb_agenda_usuario_tb_agenda_servico]
GO
ALTER TABLE [dbo].[tb_agenda_usuario]  WITH CHECK ADD  CONSTRAINT [FK_tb_agenda_usuario_tb_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[tb_usuario] ([id])
GO
ALTER TABLE [dbo].[tb_agenda_usuario] CHECK CONSTRAINT [FK_tb_agenda_usuario_tb_usuario]
GO
ALTER TABLE [dbo].[tb_instrutor_profissao]  WITH CHECK ADD  CONSTRAINT [FK_tb_usuario_profissao_tb_profissao] FOREIGN KEY([idProfissao])
REFERENCES [dbo].[tb_profissao] ([id])
GO
ALTER TABLE [dbo].[tb_instrutor_profissao] CHECK CONSTRAINT [FK_tb_usuario_profissao_tb_profissao]
GO
ALTER TABLE [dbo].[tb_instrutor_profissao]  WITH CHECK ADD  CONSTRAINT [FK_tb_usuario_profissao_tb_usuario] FOREIGN KEY([idInstrutor])
REFERENCES [dbo].[tb_usuario] ([id])
GO
ALTER TABLE [dbo].[tb_instrutor_profissao] CHECK CONSTRAINT [FK_tb_usuario_profissao_tb_usuario]
GO
ALTER TABLE [dbo].[tb_servico]  WITH CHECK ADD  CONSTRAINT [FK_tb_servico_tb_categoria_servico] FOREIGN KEY([idCategoriaServico])
REFERENCES [dbo].[tb_categoria_servico] ([id])
GO
ALTER TABLE [dbo].[tb_servico] CHECK CONSTRAINT [FK_tb_servico_tb_categoria_servico]
GO
ALTER TABLE [dbo].[tb_servico]  WITH CHECK ADD  CONSTRAINT [FK_tb_servico_tb_usuario] FOREIGN KEY([idInstrutor])
REFERENCES [dbo].[tb_usuario] ([id])
GO
ALTER TABLE [dbo].[tb_servico] CHECK CONSTRAINT [FK_tb_servico_tb_usuario]
GO
ALTER TABLE [dbo].[tb_usuario]  WITH CHECK ADD  CONSTRAINT [FK_tb_usuario_tb_usuario] FOREIGN KEY([idTipoUsuario])
REFERENCES [dbo].[tb_tipo_usuario] ([id])
GO
ALTER TABLE [dbo].[tb_usuario] CHECK CONSTRAINT [FK_tb_usuario_tb_usuario]
GO
