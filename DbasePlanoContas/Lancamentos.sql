CREATE TABLE [dbo].[Lancamentos]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Descricao] NCHAR(100) NULL, 
    [Codigo] NCHAR(10) NULL, 
    [Tipo] SMALLINT NULL, 
    [AceitaLancamentos] BIT NULL
)
