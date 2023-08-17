-- If you want to run the code in this chapter, you'll need a CloudySkies database locally on SQL Server with a Flights table

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'CloudySkies')
BEGIN
    CREATE DATABASE CloudySkies;
END
GO

USE CloudySkies;

IF OBJECT_ID('[dbo].[Flights]', 'U') IS NOT NULL 
    DROP TABLE [dbo].[Flights];
GO

CREATE TABLE [dbo].[Flights]
(
    [Id] NVARCHAR(50) PRIMARY KEY,
    [Departure] NVARCHAR(50) NOT NULL,
    [Arrival] NVARCHAR(50) NOT NULL,
    [Miles] INT NOT NULL
);

INSERT INTO [dbo].[Flights] ([Id], [Departure], [Arrival], [Miles])
VALUES ('CSA1001', 'CMH', 'ATL', 550),
       ('CSA1002', 'ATL', 'LAX', 2100),
       ('CSA1003', 'LAX', 'DEN', 1000),
       ('CSA1004', 'DEN', 'SFO', 1050),
       ('CSA1005', 'SFO', 'LAS', 375);
