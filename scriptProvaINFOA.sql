USE [dbcontrolemensagem]
GO
/****** Object:  Table [dbo].[tbl_mensagem]    Script Date: 20/03/2016 19:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_mensagem](
	[id_mensagem] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario_remetente] [int] NULL,
	[id_usuario_destinatario] [int] NULL,
	[assunto] [varchar](255) NULL,
	[mensagem] [text] NULL,
 CONSTRAINT [PK_tbl_mensagem] PRIMARY KEY CLUSTERED 
(
	[id_mensagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

create database dbcontrolemensagem 

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 20/03/2016 19:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](255) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tbl_mensagem]  WITH CHECK ADD  CONSTRAINT [FK_tbl_mensagem_tbl_usuario_destinatario] FOREIGN KEY([id_usuario_destinatario])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[tbl_mensagem] CHECK CONSTRAINT [FK_tbl_mensagem_tbl_usuario_destinatario]
GO
ALTER TABLE [dbo].[tbl_mensagem]  WITH CHECK ADD  CONSTRAINT [FK_tbl_mensagem_tbl_usuario_remetente] FOREIGN KEY([id_usuario_remetente])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[tbl_mensagem] CHECK CONSTRAINT [FK_tbl_mensagem_tbl_usuario_remetente]
GO

