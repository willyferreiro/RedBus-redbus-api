
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2017 20:55:51
-- Generated from EDMX file: E:\Projetos\AppsFactory\RedBus\RedBus-api\RedBus-api\Models\redbusdb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [redbusdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Filho_Motorista]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filho] DROP CONSTRAINT [FK_Filho_Motorista];
GO
IF OBJECT_ID(N'[dbo].[FK_Filho_Responsavel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filho] DROP CONSTRAINT [FK_Filho_Responsavel];
GO
IF OBJECT_ID(N'[dbo].[FK_ViagemFilho_Filho]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViagemFilho] DROP CONSTRAINT [FK_ViagemFilho_Filho];
GO
IF OBJECT_ID(N'[dbo].[FK_Mensagem_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mensagem] DROP CONSTRAINT [FK_Mensagem_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Mensagem_Usuario1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mensagem] DROP CONSTRAINT [FK_Mensagem_Usuario1];
GO
IF OBJECT_ID(N'[dbo].[FK_Motorista_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Motorista] DROP CONSTRAINT [FK_Motorista_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Viagem_Motorista]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Viagem] DROP CONSTRAINT [FK_Viagem_Motorista];
GO
IF OBJECT_ID(N'[dbo].[FK_Responsavel_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Responsavel] DROP CONSTRAINT [FK_Responsavel_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_ViagemFilho_Viagem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViagemFilho] DROP CONSTRAINT [FK_ViagemFilho_Viagem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Filho]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Filho];
GO
IF OBJECT_ID(N'[dbo].[Mensagem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mensagem];
GO
IF OBJECT_ID(N'[dbo].[Motorista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Motorista];
GO
IF OBJECT_ID(N'[dbo].[Responsavel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Responsavel];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Viagem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Viagem];
GO
IF OBJECT_ID(N'[dbo].[ViagemFilho]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ViagemFilho];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Filho'
CREATE TABLE [dbo].[Filho] (
    [idFilho] bigint IDENTITY(1,1) NOT NULL,
    [idResponsavel] bigint  NOT NULL,
    [idMotorista] bigint  NOT NULL,
    [nome] varchar(100)  NOT NULL,
    [emViagem] bit  NULL,
    [embarcado] bit  NULL,
    [posicao_latitudeCasa] float  NULL,
    [posicao_longitutdeCasa] float  NULL,
    [posicao_latitudeEscola] float  NULL,
    [posicao_longitutdeEscola] float  NULL,
    [foto] varbinary(max)  NULL,
    [fotoCompleta] varbinary(max)  NULL
);
GO

-- Creating table 'Mensagem'
CREATE TABLE [dbo].[Mensagem] (
    [idMensagem] bigint IDENTITY(1,1) NOT NULL,
    [idUsuarioDe] bigint  NOT NULL,
    [idUsuarioPara] bigint  NOT NULL,
    [dataMensagem] datetime  NOT NULL,
    [mensagem] varchar(500)  NOT NULL,
    [entregue] bit  NOT NULL,
    [visualizada] bit  NOT NULL
);
GO

-- Creating table 'Motorista'
CREATE TABLE [dbo].[Motorista] (
    [idUsuario] bigint  NOT NULL,
    [emViagem] bit  NOT NULL,
    [posicao_latitude] float  NULL,
    [posicao_longitude] float  NULL,
    [adimplente] bit  NOT NULL,
    [foto] varbinary(max)  NULL
);
GO

-- Creating table 'Responsavel'
CREATE TABLE [dbo].[Responsavel] (
    [idUsuario] bigint  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [idUsuario] bigint IDENTITY(1,1) NOT NULL,
    [telefone] decimal(11,0)  NOT NULL,
    [nome] varchar(100)  NOT NULL,
    [senha] char(10)  NOT NULL,
    [tipoUsuario] char(1)  NOT NULL
);
GO

-- Creating table 'Viagem'
CREATE TABLE [dbo].[Viagem] (
    [idViagem] bigint IDENTITY(1,1) NOT NULL,
    [idMotorista] bigint  NOT NULL,
    [dataInicioViagem] datetime  NOT NULL,
    [dataFimViagem] datetime  NULL,
    [posicaoInicio_latitude] float  NOT NULL,
    [posicaoInicio_longitude] float  NOT NULL,
    [posicaoFim_latitude] float  NULL,
    [posicaoFim_longitude] float  NULL,
    [statusViagem] decimal(1,0)  NOT NULL
);
GO

-- Creating table 'ViagemFilho'
CREATE TABLE [dbo].[ViagemFilho] (
    [idVIagem] bigint  NOT NULL,
    [idFilho] bigint  NOT NULL,
    [dataEmbarque] datetime  NULL,
    [dataDesembarque] datetime  NULL,
    [posicaoEmbarque_latitude] float  NULL,
    [posicaoEmbarque_longitude] float  NULL,
    [posicaoDesembarque_latitude] float  NULL,
    [posicaoDesembarque_longitude] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idFilho] in table 'Filho'
ALTER TABLE [dbo].[Filho]
ADD CONSTRAINT [PK_Filho]
    PRIMARY KEY CLUSTERED ([idFilho] ASC);
GO

-- Creating primary key on [idMensagem] in table 'Mensagem'
ALTER TABLE [dbo].[Mensagem]
ADD CONSTRAINT [PK_Mensagem]
    PRIMARY KEY CLUSTERED ([idMensagem] ASC);
GO

-- Creating primary key on [idUsuario] in table 'Motorista'
ALTER TABLE [dbo].[Motorista]
ADD CONSTRAINT [PK_Motorista]
    PRIMARY KEY CLUSTERED ([idUsuario] ASC);
GO

-- Creating primary key on [idUsuario] in table 'Responsavel'
ALTER TABLE [dbo].[Responsavel]
ADD CONSTRAINT [PK_Responsavel]
    PRIMARY KEY CLUSTERED ([idUsuario] ASC);
GO

-- Creating primary key on [idUsuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([idUsuario] ASC);
GO

-- Creating primary key on [idViagem] in table 'Viagem'
ALTER TABLE [dbo].[Viagem]
ADD CONSTRAINT [PK_Viagem]
    PRIMARY KEY CLUSTERED ([idViagem] ASC);
GO

-- Creating primary key on [idVIagem], [idFilho] in table 'ViagemFilho'
ALTER TABLE [dbo].[ViagemFilho]
ADD CONSTRAINT [PK_ViagemFilho]
    PRIMARY KEY CLUSTERED ([idVIagem], [idFilho] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idMotorista] in table 'Filho'
ALTER TABLE [dbo].[Filho]
ADD CONSTRAINT [FK_Filho_Motorista]
    FOREIGN KEY ([idMotorista])
    REFERENCES [dbo].[Motorista]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Filho_Motorista'
CREATE INDEX [IX_FK_Filho_Motorista]
ON [dbo].[Filho]
    ([idMotorista]);
GO

-- Creating foreign key on [idResponsavel] in table 'Filho'
ALTER TABLE [dbo].[Filho]
ADD CONSTRAINT [FK_Filho_Responsavel]
    FOREIGN KEY ([idResponsavel])
    REFERENCES [dbo].[Responsavel]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Filho_Responsavel'
CREATE INDEX [IX_FK_Filho_Responsavel]
ON [dbo].[Filho]
    ([idResponsavel]);
GO

-- Creating foreign key on [idFilho] in table 'ViagemFilho'
ALTER TABLE [dbo].[ViagemFilho]
ADD CONSTRAINT [FK_ViagemFilho_Filho]
    FOREIGN KEY ([idFilho])
    REFERENCES [dbo].[Filho]
        ([idFilho])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViagemFilho_Filho'
CREATE INDEX [IX_FK_ViagemFilho_Filho]
ON [dbo].[ViagemFilho]
    ([idFilho]);
GO

-- Creating foreign key on [idUsuarioDe] in table 'Mensagem'
ALTER TABLE [dbo].[Mensagem]
ADD CONSTRAINT [FK_Mensagem_Usuario]
    FOREIGN KEY ([idUsuarioDe])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mensagem_Usuario'
CREATE INDEX [IX_FK_Mensagem_Usuario]
ON [dbo].[Mensagem]
    ([idUsuarioDe]);
GO

-- Creating foreign key on [idUsuarioPara] in table 'Mensagem'
ALTER TABLE [dbo].[Mensagem]
ADD CONSTRAINT [FK_Mensagem_Usuario1]
    FOREIGN KEY ([idUsuarioPara])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mensagem_Usuario1'
CREATE INDEX [IX_FK_Mensagem_Usuario1]
ON [dbo].[Mensagem]
    ([idUsuarioPara]);
GO

-- Creating foreign key on [idUsuario] in table 'Motorista'
ALTER TABLE [dbo].[Motorista]
ADD CONSTRAINT [FK_Motorista_Usuario]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idMotorista] in table 'Viagem'
ALTER TABLE [dbo].[Viagem]
ADD CONSTRAINT [FK_Viagem_Motorista]
    FOREIGN KEY ([idMotorista])
    REFERENCES [dbo].[Motorista]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Viagem_Motorista'
CREATE INDEX [IX_FK_Viagem_Motorista]
ON [dbo].[Viagem]
    ([idMotorista]);
GO

-- Creating foreign key on [idUsuario] in table 'Responsavel'
ALTER TABLE [dbo].[Responsavel]
ADD CONSTRAINT [FK_Responsavel_Usuario]
    FOREIGN KEY ([idUsuario])
    REFERENCES [dbo].[Usuario]
        ([idUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idVIagem] in table 'ViagemFilho'
ALTER TABLE [dbo].[ViagemFilho]
ADD CONSTRAINT [FK_ViagemFilho_Viagem]
    FOREIGN KEY ([idVIagem])
    REFERENCES [dbo].[Viagem]
        ([idViagem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------