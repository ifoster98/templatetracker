USE Gametracker;
GO
IF OBJECT_ID(N'dbo.TestData', N'U') IS NULL BEGIN  

	CREATE TABLE [dbo].[TestData](
		[Id] [int] IDENTITY(1,1) NOT NULL,
        [Name] [VARCHAR](255) NOT NULL,
		[DateOfBirth] [DATETIME] NOT NULL,
        [Address] [VARCHAR](255) NOT NULL,
		CONSTRAINT [PK_TestDataId] PRIMARY KEY ([Id])
	) WITH (DATA_COMPRESSION = PAGE)

END;
GO
