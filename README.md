# Script de criação da estrutura de dados do SQL Server
CREATE TABLE [dbo].[Pessoas](

	[PessoaId] [int] IDENTITY(1,1) NOT NULL,
 
	[Nome] [varchar](100) NOT NULL,
 
	[CPF] [varchar](11) NULL,
 
	[DataNascimento] [date] NOT NULL,
 
	[ValorRenda] [float] NULL
 
)
