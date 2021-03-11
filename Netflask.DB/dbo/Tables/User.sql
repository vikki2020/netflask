CREATE TABLE [dbo].[User] (
    [IdUser]    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (50)  NOT NULL,
    [Login]     NVARCHAR (50)  NULL,
    [Password]  NVARCHAR (600) NULL,
    [Salt]      NVARCHAR (250) NULL,
    [WebSite] NVARCHAR(50) NULL, 
    [Twitter] NVARCHAR(50) NULL, 
    [Instagram] NVARCHAR(50) NULL, 
    [Facebook] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(323) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [Mobile] NVARCHAR(50) NULL, 
    [Country] INT NULL, 
    [City] NVARCHAR(50) NULL, 
    [Picture] NVARCHAR(50) NULL, 
    CONSTRAINT [PK__User__B7C9263864CFD1F1] PRIMARY KEY CLUSTERED ([IdUser] ASC)
);



