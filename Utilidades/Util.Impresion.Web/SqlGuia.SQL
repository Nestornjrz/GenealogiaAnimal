/*
Created: 21/11/2016
Modified: 29/11/2016
Model: Utilidades
Database: MS SQL Server 2014
*/


-- Create tables section -------------------------------------------------

-- Table guias.Guias

CREATE TABLE [guias].[Guias]
(
 [GuiaID] Bigint IDENTITY(1,1) NOT NULL,
 [Numero] Bigint NOT NULL,
 [Fecha] Date NOT NULL
)
go

-- Add keys for table guias.Guias

ALTER TABLE [guias].[Guias] ADD CONSTRAINT [Key1] PRIMARY KEY ([GuiaID])
go

-- Table guias.GuiasDet

CREATE TABLE [guias].[GuiasDet]
(
 [GuiaDetID] Bigint IDENTITY(1,1) NOT NULL,
 [GuiaID] Bigint NOT NULL,
 [ImagenID] Int NULL,
 [ClienteID] Int NULL
)
go

-- Create indexes for table guias.GuiasDet

CREATE INDEX [IX_GuiasDet_GuiaID] ON [guias].[GuiasDet] ([GuiaID])
go

CREATE INDEX [IX_GuiasDet_ImagenID] ON [guias].[GuiasDet] ([ImagenID])
go

CREATE INDEX [IX_GuasDet_ClienteID] ON [guias].[GuiasDet] ([ClienteID])
go

-- Add keys for table guias.GuiasDet

ALTER TABLE [guias].[GuiasDet] ADD CONSTRAINT [Pk_GuiasDet] PRIMARY KEY ([GuiaDetID])
go

-- Table guias.Imagenes

CREATE TABLE [guias].[Imagenes]
(
 [ImagenID] Int IDENTITY(1,1) NOT NULL,
 [ProveedorID] Int NOT NULL,
 [VigenteSn] Bit NOT NULL,
 [Nombre] Varchar(100) NOT NULL
)
go

-- Create indexes for table guias.Imagenes

CREATE INDEX [IX_Imagenes_ProveedorID] ON [guias].[Imagenes] ([ProveedorID])
go

-- Add keys for table guias.Imagenes

ALTER TABLE [guias].[Imagenes] ADD CONSTRAINT [pk_Imagenes] PRIMARY KEY ([ImagenID])
go

-- Table guias.ProveeClientes

CREATE TABLE [guias].[ProveeClientes]
(
 [ProveeClienteID] Int IDENTITY(1,1) NOT NULL,
 [Nombre] Varchar(100) NOT NULL,
 [ProveedorSn] Bit DEFAULT 0 NOT NULL,
 [ClienteSn] Bit DEFAULT 0 NOT NULL
)
go

-- Add keys for table guias.ProveeClientes

ALTER TABLE [guias].[ProveeClientes] ADD CONSTRAINT [pk_Estancias] PRIMARY KEY ([ProveeClienteID])
go

-- Create relationships section ------------------------------------------------- 

ALTER TABLE [guias].[GuiasDet] ADD CONSTRAINT [Fk_Guias-GuiasDet] FOREIGN KEY ([GuiaID]) REFERENCES [guias].[Guias] ([GuiaID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [guias].[GuiasDet] ADD CONSTRAINT [fk_GuiasDet-Imagenes] FOREIGN KEY ([ImagenID]) REFERENCES [guias].[Imagenes] ([ImagenID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [guias].[Imagenes] ADD CONSTRAINT [Fk_Imagenes-ProveeClientes] FOREIGN KEY ([ProveedorID]) REFERENCES [guias].[ProveeClientes] ([ProveeClienteID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [guias].[GuiasDet] ADD CONSTRAINT [Fk_GuiasDet-ProveeClientes] FOREIGN KEY ([ClienteID]) REFERENCES [guias].[ProveeClientes] ([ProveeClienteID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



