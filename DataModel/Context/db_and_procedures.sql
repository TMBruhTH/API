USE [DBThomasGreg]
GO
/****** Object:  Table [dbo].[tb_cliente]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Logotipo] [bit] NOT NULL,
 CONSTRAINT [PK_tb_cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_logradouro]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_logradouro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Logradouro] [varchar](50) NULL,
 CONSTRAINT [PK_tb_logradouro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_logradouro]  WITH CHECK ADD  CONSTRAINT [FK_tb_logradouro_tb_cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[tb_cliente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_logradouro] CHECK CONSTRAINT [FK_tb_logradouro_tb_cliente]
GO
/****** Object:  StoredProcedure [dbo].[atualizar_cliente]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atualizar_cliente]
	(@Id int, @Nome varchar(50), @Email varchar(50), @Logotipo bit)
AS
BEGIN
	UPDATE tb_cliente set Nome = @Nome, Email = @Email, Logotipo = @Logotipo
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[atualizar_logradouro]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[atualizar_logradouro] (@Id Int, @IdCliente Int, @Logradouro varchar(50))
AS
BEGIN
	UPDATE tb_logradouro SET IdCliente = @IdCliente, Logradouro = @Logradouro
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[inserir_cliente]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[inserir_cliente]
	(@Nome varchar(50), @Email varchar(50), @Logotipo bit)
AS
BEGIN
	
	IF NOT EXISTS(SELECT * FROM tb_cliente WHERE Email LIKE '%' + @Email + '%')
	BEGIN
		INSERT INTO tb_cliente VALUES (@Nome, @Email, @Logotipo)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[inserir_logradouro]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[inserir_logradouro] (@IdCliente Int, @Logradouro varchar(50))
AS
BEGIN
	INSERT INTO tb_logradouro VALUES (@IdCliente, @Logradouro)
END
GO
/****** Object:  StoredProcedure [dbo].[remover_cliente]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[remover_cliente] (@Id int)
AS
BEGIN
	DELETE FROM tb_cliente 
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[remover_logradouro]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[remover_logradouro] (@Id Int)
AS
BEGIN
	DELETE FROM tb_logradouro
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[visualizar_cliente]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[visualizar_cliente]
(@Id int = NULL)
AS
BEGIN
	IF (@Id > 0)
		BEGIN
			SELECT * FROM tb_cliente
			WHERE Id = @Id
		END
	ELSE
		BEGIN
			SELECT * FROM tb_cliente
		END
END
GO
/****** Object:  StoredProcedure [dbo].[visualizar_logradouro]    Script Date: 3/25/2024 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[visualizar_logradouro] (@Id int = null)
AS
BEGIN
	IF (@Id > 0)
		BEGIN
			SELECT * FROM tb_logradouro
			WHERE Id = @Id
		END
	ELSE
		BEGIN
			SELECT * FROM tb_logradouro
		END
END
GO
