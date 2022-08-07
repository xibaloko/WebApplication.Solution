CREATE DATABASE gti

USE gti

CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cpf] [varchar](50) NOT NULL,
	[Rg] [varchar](50) NULL,
	[DataExpedicao] [datetime] NULL,
	[OrgaoExpedicao] [varchar](50) NULL,
	[UfExpedicao] [varchar](50) NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sexo] [varchar](50) NOT NULL,
	[EstadoCivil] [varchar](50) NOT NULL)
 
CREATE TABLE [dbo].[EnderecoCliente](
	[IdEndereco] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Complemento] [varchar](50) NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[Uf] [varchar](50) NOT NULL,
	[Cep] [varchar](50) NOT NULL,
	[IdCliente] [int] NOT NULL)
 
ALTER TABLE [dbo].[EnderecoCliente] ADD  CONSTRAINT [FK_EnderecoCliente_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])