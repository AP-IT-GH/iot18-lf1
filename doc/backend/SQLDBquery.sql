CREATE TABLE [dbo].[LabFarms] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [Name]                         NVARCHAR (MAX) NULL,
    [AuthId]                       NVARCHAR (MAX) NULL,
    [PlantSpecies]                 NVARCHAR (MAX) NOT NULL,
    [OptimalAcidityLevelHigh]      REAL           NOT NULL,
    [OptimalAcidityLevelLow]       REAL           NOT NULL,
    [OptimalHumidityLevelHigh]     REAL           NOT NULL,
    [OptimalHumidityLevelLow]      REAL           NOT NULL,
    [OptimalLightLevelHigh]        REAL           NOT NULL,
    [OptimalLightLevelLow]         REAL           NOT NULL,
    [OptimalConductivityLevelHigh] REAL           NOT NULL,
    [OptimalConductivityLevelLow]  REAL           NOT NULL,
    [MinimumReservoirLevel]        REAL           NOT NULL,
    [AutoMode]                     BIT            NULL,
    CONSTRAINT [PK_LabFarms] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Pictures] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Content]   NVARCHAR (MAX) NOT NULL,
    [TimeStamp] DATETIME2 (7)  NOT NULL,
    [PlantId]   INT            NOT NULL,
    CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pictures_Plants_PlantId] FOREIGN KEY ([PlantId]) REFERENCES [dbo].[Plants] ([Id])
);

CREATE TABLE [dbo].[Plants] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [LabfarmId] INT            NOT NULL,
    [Column]    INT            NOT NULL,
    [Row]       INT            NOT NULL,
    CONSTRAINT [PK_Plants] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Plants_LabFarms_LabfarmId] FOREIGN KEY ([LabfarmId]) REFERENCES [dbo].[LabFarms] ([Id]) ON DELETE CASCADE
);

	CREATE TABLE [dbo].[Sensors] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [LabFarmId]    INT            NOT NULL,
    [SensorTypeId] INT            NOT NULL,
    CONSTRAINT [PK_Sensors] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sensors_LabFarms_LabFarmId] FOREIGN KEY ([LabFarmId]) REFERENCES [dbo].[LabFarms] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sensors_SensorTypes_SensorTypeId] FOREIGN KEY ([SensorTypeId]) REFERENCES [dbo].[SensorTypes] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[SensorTypes] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_SensorTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[SensorValues] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [SensorValue] REAL          NOT NULL,
    [TimeStamp]   DATETIME2 (7) NOT NULL,
    [SensorId]    INT           NOT NULL,
    CONSTRAINT [PK_SensorValues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SensorValues_Sensors_SensorId] FOREIGN KEY ([SensorId]) REFERENCES [dbo].[Sensors] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_Pictures_PlantId]
    ON [dbo].[Pictures]([PlantId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Plants_LabfarmId]
    ON [dbo].[Plants]([LabfarmId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Sensors_LabFarmId]
    ON [dbo].[Sensors]([LabFarmId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Sensors_SensorTypeId]
    ON [dbo].[Sensors]([SensorTypeId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_SensorValues_SensorId]
    ON [dbo].[SensorValues]([SensorId] ASC);
