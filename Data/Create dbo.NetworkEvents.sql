USE [ProtnoxDb]
GO

/****** Object: Table [dbo].[NetworkEvents] Script Date: 8/11/2020 8:28:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NetworkEvents] (
    [Event_id]   INT            NOT NULL,
    [Switch_Ip]  NVARCHAR (MAX) NULL,
    [Port_id]    INT            NOT NULL,
    [Device_Mac] NVARCHAR (MAX) NULL
);


