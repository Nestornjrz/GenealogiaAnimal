/*
Created: 31/10/2016
Modified: 07/11/2016
Model: RegistroGanadero
Database: MS SQL Server 2014
*/


-- Create tables section -------------------------------------------------

-- Table RegG.Razas

CREATE TABLE [RegG].[Razas]
(
 [RazaID] Int IDENTITY(1,1) NOT NULL,
 [NombreRaza] Varchar(50) NOT NULL
)
go

 INSERT INTO [RegG].[Razas]([NombreRaza])
VALUES
     ('BRAFORD'),('BRAHMAN'),('HEREFORD'), ('NELORE')
GO


-- Create indexes for table RegG.Razas

CREATE UNIQUE INDEX [Index_RazaSet_NombreRaza] ON [RegG].[Razas] ([NombreRaza])
go

-- Add keys for table RegG.Razas

ALTER TABLE [RegG].[Razas] ADD CONSTRAINT [pk_RazaSet] PRIMARY KEY ([RazaID])
go

-- Table RegG.Generaciones

CREATE TABLE [RegG].[Generaciones]
(
 [GeneracionID] Int IDENTITY(1,1) NOT NULL,
 [RazaID] Int NOT NULL,
 [NombreGeneracion] Varchar(50) NOT NULL,
 [Descripcion] Varchar(max) NULL
)
go

 INSERT INTO [RegG].[Generaciones]
           ([RazaID]
           ,[NombreGeneracion]
           ,[Descripcion])
     VALUES
           (1,'BASE',null),
           (1,'PREPARATORIO',null),
           (1,'DEFINITIVO',null),
           (1,'AVANZADO',null),
           (1,'CONTROLADO',null),
           (2,'1/2',null), 
           (2,'3/4',null),
           (2,'15/16',null),
           (2,'7/8',null),
           (2,'PP',null)
           

-- Create indexes for table RegG.Generaciones

CREATE UNIQUE INDEX [Index_GeneracionSet_Raza_NombreGeneracion] ON [RegG].[Generaciones] ([RazaID],[NombreGeneracion])
go

-- Add keys for table RegG.Generaciones

ALTER TABLE [RegG].[Generaciones] ADD CONSTRAINT [pk_GeneracionSet] PRIMARY KEY ([GeneracionID])
go

-- Table RegG.GradoSangres

CREATE TABLE [RegG].[GradoSangres]
(
 [GradoSangreID] Int IDENTITY(1,1) NOT NULL,
 [RazaID] Int NOT NULL,
 [NombreGradoSangre] Varchar(10) NOT NULL,
 [Descripcion] Varchar(max) NULL
)
go

 INSERT INTO [RegG].[GradoSangres]
           ([NombreGradoSangre]
           ,[RazaID]
           ,[Descripcion])
     VALUES            
           ('1/2',1,'Media Sangre'), 
           ('1/2',2,'Media Sangre'),
           ('1/4',1,'Un Cuarto de sangre'),
           ('3/4',1,'Tres cuarto de sangre'),   
           ('3/4',2,'Tres cuarto de sangre'),
           ('3/8',1,'Tres octavos de sangre'),
           ('7/8',2,'Siete octavos de sangre'),
           ('A',2,'Avanzado'),
           ('D',2,'Definitivo'),
           ('15/16',2,''),
           ('PP',2,'Puro de pedigri'),
           ('5/8',1,'')         
GO


-- Create indexes for table RegG.GradoSangres

CREATE UNIQUE INDEX [Index_GradoSangreSet_Raza_NombreGradoSangre] ON [RegG].[GradoSangres] ([RazaID],[NombreGradoSangre])
go

-- Add keys for table RegG.GradoSangres

ALTER TABLE [RegG].[GradoSangres] ADD CONSTRAINT [pk_CategoriaSet] PRIMARY KEY ([GradoSangreID])
go

-- Table RegG.Pelajes

CREATE TABLE [RegG].[Pelajes]
(
 [PelajeID] Int IDENTITY(1,1) NOT NULL,
 [ColorPelaje] Varchar(15) NOT NULL
)
go

INSERT INTO [RegG].[Pelajes]
           ([ColorPelaje])
     VALUES
           ('COLORADO'),('COLORADO'),('GRIS CLARO'),
           ('GRIS MEDIO'),('COLORADO')

-- Add keys for table RegG.Pelajes

ALTER TABLE [RegG].[Pelajes] ADD CONSTRAINT [pk_PelajeSet] PRIMARY KEY ([PelajeID])
go

-- Table RegG.Establecimientos

CREATE TABLE [RegG].[Establecimientos]
(
 [EstablecimientoID] Int IDENTITY(1,1) NOT NULL,
 [NombreEstablecimiento] Varchar(50) NOT NULL,
 [CiudadID] Int NOT NULL,
 [PropietarioID] Int NOT NULL
)
go

INSERT INTO [RegG].[Establecimientos]
           ([NombreEstablecimiento]
           ,[PropietarioID]
           ,[CiudadID])
     VALUES
           ('LA FLORIDA',1,1)

-- Create indexes for table RegG.Establecimientos

CREATE INDEX [IX_Establecimientos_PropietarioID] ON [RegG].[Establecimientos] ([PropietarioID])
go

-- Add keys for table RegG.Establecimientos

ALTER TABLE [RegG].[Establecimientos] ADD CONSTRAINT [pk_Establecimientos] PRIMARY KEY ([EstablecimientoID])
go

-- Table RegG.Ciudades

CREATE TABLE [RegG].[Ciudades]
(
 [CiudadID] Int IDENTITY(1,1) NOT NULL,
 [NombreCiudad] Varchar(50) NOT NULL,
 [DepartamentoID] Int NOT NULL
)
go

INSERT INTO [RegG].[Ciudades]
           ([NombreCiudad]
           ,[DepartamentoID])
     VALUES
           ('Villa del Rosario',1)

-- Add keys for table RegG.Ciudades

ALTER TABLE [RegG].[Ciudades] ADD CONSTRAINT [pk_CiudadSet] PRIMARY KEY ([CiudadID])
go

-- Table RegG.Departamentos

CREATE TABLE [RegG].[Departamentos]
(
 [DepartamentoID] Int IDENTITY(1,1) NOT NULL,
 [NombreDepartamento] Varchar(50) NOT NULL,
 [PaisID] Int NOT NULL
)
go

INSERT INTO [RegG].[Departamentos]
           ([NombreDepartamento]           ,[PaisID])
     VALUES
          ('San Pedro',1), ('Boqueron',2)

-- Add keys for table RegG.Departamentos

ALTER TABLE [RegG].[Departamentos] ADD CONSTRAINT [pk_DepartamentoSet] PRIMARY KEY ([DepartamentoID])
go

-- Table RegG.Paises

CREATE TABLE [RegG].[Paises]
(
 [PaisID] Int IDENTITY(1,1) NOT NULL,
 [NombrePais] Varchar(50) NOT NULL,
 [Abreviatura] Varchar(2) NOT NULL
)
go

INSERT INTO [RegG].[Paises]
           ([NombrePais]
           ,[Abreviatura])
     VALUES
          ('PARAGUAY','PY'),('ARGENTINA','AR')

-- Add keys for table RegG.Paises

ALTER TABLE [RegG].[Paises] ADD CONSTRAINT [pk_PaisSet] PRIMARY KEY ([PaisID])
go

-- Table RegG.Origenes

CREATE TABLE [RegG].[Origenes]
(
 [OrigenID] Int IDENTITY(1,1) NOT NULL,
 [NombreOrigen] Varchar(50) NOT NULL
)
go

-- Create indexes for table RegG.Origenes

CREATE UNIQUE INDEX [Index_OrigenSet_NombreOrigen] ON [RegG].[Origenes] ([NombreOrigen])
go

-- Add keys for table RegG.Origenes

ALTER TABLE [RegG].[Origenes] ADD CONSTRAINT [pk_OrigenSet] PRIMARY KEY ([OrigenID])
go

-- Table RegG.Compras

CREATE TABLE [RegG].[Compras]
(
 [VacunoID] Bigint NOT NULL,
 [OrigenID] Int NOT NULL,
 [FechaCompra] Datetime2 NOT NULL,
 [PrecioCompra] Money NOT NULL,
 [PesoAlComprarKg] Float NOT NULL,
 [Observacion] Text NULL
)
go
EXEC sp_addextendedproperty 'MS_Description', 'Valor en Kg.', 'SCHEMA', 'RegG', 'TABLE', 'Compras', 'COLUMN', 'PesoAlComprarKg'
go

-- Create indexes for table RegG.Compras

CREATE INDEX [IX_Compras_Origenes] ON [RegG].[Compras] ([OrigenID])
go

-- Add keys for table RegG.Compras

ALTER TABLE [RegG].[Compras] ADD CONSTRAINT [Pk_Compras] PRIMARY KEY ([VacunoID])
go

-- Table RegG.Vacunos

CREATE TABLE [RegG].[Vacunos]
(
 [VacunoID] Bigint IDENTITY(1,1) NOT NULL,
 [FechaNacimiento] Date NOT NULL,
 [Nombre] Varchar(50) NOT NULL,
 [RegistroParticular] Int NOT NULL,
 [Rp_temporal] Int NOT NULL,
 [MomentoCarga] Datetime2 NOT NULL
)
go
EXEC sp_addextendedproperty 'MS_Description', 'El registro particular deve ser colocado antes de los 6 meses', 'SCHEMA', 'RegG', 'TABLE', 'Vacunos', 'COLUMN', 'RegistroParticular'
go
EXEC sp_addextendedproperty 'MS_Description', 'El registro particular temporal solo se utiliza como un auxiliar, pues lo que vale es el REGISTRO PARTICULAR DADO por el registro genealogico', 'SCHEMA', 'RegG', 'TABLE', 'Vacunos', 'COLUMN', 'Rp_temporal'
go

-- Add keys for table RegG.Vacunos

ALTER TABLE [RegG].[Vacunos] ADD CONSTRAINT [Key1] PRIMARY KEY ([VacunoID])
go

-- Table RegG.VacunoCaracteristicas

CREATE TABLE [RegG].[VacunoCaracteristicas]
(
 [VacunoID] Bigint NOT NULL,
 [EstablecimientoID] Int NOT NULL,
 [PelajeID] Int NOT NULL,
 [RazaID] Int NOT NULL
)
go

-- Create indexes for table RegG.VacunoCaracteristicas

CREATE INDEX [IX_VacunoCaracteristicas_PelajeID] ON [RegG].[VacunoCaracteristicas] ([PelajeID])
go

CREATE INDEX [IX_VacunoCaracteristicas_RazaID] ON [RegG].[VacunoCaracteristicas] ([RazaID])
go

CREATE INDEX [IX_VacunoCaracteristicas_EstablecimientoID] ON [RegG].[VacunoCaracteristicas] ([EstablecimientoID])
go

-- Add keys for table RegG.VacunoCaracteristicas

ALTER TABLE [RegG].[VacunoCaracteristicas] ADD CONSTRAINT [Pk_VacunoCaracteristicas] PRIMARY KEY ([VacunoID])
go

-- Table RegG.RegistroZootecnicos

CREATE TABLE [RegG].[RegistroZootecnicos]
(
 [VacunoID] Bigint NOT NULL,
 [GeneracionID] Int NOT NULL,
 [GradoSangreID] Int NOT NULL,
 [NroRebano] Int NOT NULL,
 [HBP] Varchar(12) NULL,
 [FechaRegistro] Date NULL,
 [MomentoCarga] Datetime2 NOT NULL
)
go
EXEC sp_addextendedproperty 'MS_Description', 'Este numero lo asigna la rural, por medio de una solicitud de trabajo.', 'SCHEMA', 'RegG', 'TABLE', 'RegistroZootecnicos', 'COLUMN', 'NroRebano'
go
EXEC sp_addextendedproperty 'MS_Description', 'Significa  Herd book Paraguay (Ligro genealogico del paraguay), Esta compuesto por Las iniciales del propietario + el numero de rebaño +  el R.P. + el pais, ej: FGC961815PY, puede estar controlado o no.
En el caso de los terneros PROPIOS (es decir nacidos en la hacienda) no tienen HBP', 'SCHEMA', 'RegG', 'TABLE', 'RegistroZootecnicos', 'COLUMN', 'HBP'
go
EXEC sp_addextendedproperty 'MS_Description', 'Es la fecha que se registro en la rural.
En el caso de los terneros no se registran todavia en la rural por lo tanto no tienen fecha de registro.', 'SCHEMA', 'RegG', 'TABLE', 'RegistroZootecnicos', 'COLUMN', 'FechaRegistro'
go

-- Create indexes for table RegG.RegistroZootecnicos

CREATE INDEX [IX_RegistroZootecnicos_GeneracionID] ON [RegG].[RegistroZootecnicos] ([GeneracionID])
go

CREATE INDEX [IX_RegistroZootecnicos_GradoSangreID] ON [RegG].[RegistroZootecnicos] ([GradoSangreID])
go

-- Add keys for table RegG.RegistroZootecnicos

ALTER TABLE [RegG].[RegistroZootecnicos] ADD CONSTRAINT [Key3] PRIMARY KEY ([VacunoID])
go

-- Table RegG.VacunoHembras

CREATE TABLE [RegG].[VacunoHembras]
(
 [VacunoID] Bigint NOT NULL
)
go

-- Add keys for table RegG.VacunoHembras

ALTER TABLE [RegG].[VacunoHembras] ADD CONSTRAINT [Key4] PRIMARY KEY ([VacunoID])
go

-- Table RegG.VacunoMachos

CREATE TABLE [RegG].[VacunoMachos]
(
 [VacunoID] Bigint NOT NULL
)
go

-- Add keys for table RegG.VacunoMachos

ALTER TABLE [RegG].[VacunoMachos] ADD CONSTRAINT [Key5] PRIMARY KEY ([VacunoID])
go

-- Table RegG.Propietarios

CREATE TABLE [RegG].[Propietarios]
(
 [PropietarioID] Int IDENTITY(1,1) NOT NULL,
 [NombrePropietario] Varchar(50) NOT NULL,
 [Siglas] Varchar(30) NOT NULL,
 [Ruc_Ci] Varchar(11) NOT NULL
)
go

INSERT INTO [RegG].[Propietarios]
           ([NombrePropietario]
           ,[Siglas]
           ,[Ruc_Ci])
     VALUES
           ('XXX XXX XXX','FGC','314331-7')

-- Add keys for table RegG.Propietarios

ALTER TABLE [RegG].[Propietarios] ADD CONSTRAINT [Pk_Propietarios] PRIMARY KEY ([PropietarioID])
go

-- Create relationships section ------------------------------------------------- 

ALTER TABLE [RegG].[VacunoCaracteristicas] ADD CONSTRAINT [pk_Vacunos-VacunoCaracteristicas] FOREIGN KEY ([VacunoID]) REFERENCES [RegG].[Vacunos] ([VacunoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[GradoSangres] ADD CONSTRAINT [fk_GradoSangreSet-RazaSet] FOREIGN KEY ([RazaID]) REFERENCES [RegG].[Razas] ([RazaID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[Generaciones] ADD CONSTRAINT [fk_GeneracionSet-RazaSet] FOREIGN KEY ([RazaID]) REFERENCES [RegG].[Razas] ([RazaID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[VacunoCaracteristicas] ADD CONSTRAINT [fk_VacunoCaracteristicas-Pelajes] FOREIGN KEY ([PelajeID]) REFERENCES [RegG].[Pelajes] ([PelajeID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[VacunoCaracteristicas] ADD CONSTRAINT [fk_VacunoCaracteristicas-Razas] FOREIGN KEY ([RazaID]) REFERENCES [RegG].[Razas] ([RazaID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[RegistroZootecnicos] ADD CONSTRAINT [pk_VacunoCaracteristicas-RegistroZootecnicos] FOREIGN KEY ([VacunoID]) REFERENCES [RegG].[VacunoCaracteristicas] ([VacunoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[RegistroZootecnicos] ADD CONSTRAINT [fk_RegistroZootecnicos-Generaciones] FOREIGN KEY ([GeneracionID]) REFERENCES [RegG].[Generaciones] ([GeneracionID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[RegistroZootecnicos] ADD CONSTRAINT [fk_RegistroZootecnicos-GradoSangres] FOREIGN KEY ([GradoSangreID]) REFERENCES [RegG].[GradoSangres] ([GradoSangreID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[Departamentos] ADD CONSTRAINT [fk_Departamentos-Paises] FOREIGN KEY ([PaisID]) REFERENCES [RegG].[Paises] ([PaisID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[Ciudades] ADD CONSTRAINT [fk_Ciudades-Departamentos] FOREIGN KEY ([DepartamentoID]) REFERENCES [RegG].[Departamentos] ([DepartamentoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[Establecimientos] ADD CONSTRAINT [Fk-Establecimientos-Ciudades] FOREIGN KEY ([CiudadID]) REFERENCES [RegG].[Ciudades] ([CiudadID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[VacunoCaracteristicas] ADD CONSTRAINT [fk_VacunoCaracteristicas-Establecimientos] FOREIGN KEY ([EstablecimientoID]) REFERENCES [RegG].[Establecimientos] ([EstablecimientoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[Compras] ADD CONSTRAINT [pk_VacunoCaracteristicas-Compras] FOREIGN KEY ([VacunoID]) REFERENCES [RegG].[VacunoCaracteristicas] ([VacunoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[Compras] ADD CONSTRAINT [pk_Compras-Origenes] FOREIGN KEY ([OrigenID]) REFERENCES [RegG].[Origenes] ([OrigenID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[VacunoHembras] ADD CONSTRAINT [Pfk_VacunosHembras-Vacunos] FOREIGN KEY ([VacunoID]) REFERENCES [RegG].[Vacunos] ([VacunoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[VacunoMachos] ADD CONSTRAINT [Pfk_VacunoMachos-Vacunos] FOREIGN KEY ([VacunoID]) REFERENCES [RegG].[Vacunos] ([VacunoID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [RegG].[Establecimientos] ADD CONSTRAINT [fk_Estable-Propie] FOREIGN KEY ([PropietarioID]) REFERENCES [RegG].[Propietarios] ([PropietarioID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



