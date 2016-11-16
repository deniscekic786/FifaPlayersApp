CREATE TABLE [dbo].[Player] ( 
    [Id] INT IDENTITY (1, 1) Primary Key NOT NULL, 
    [Name] VARCHAR (100) NOT NULL, 
    [Nationality]  VARCHAR (100) NOT NULL, 
	[ClubName]  VARCHAR (100) NOT NULL, 
	[Position]  VARCHAR (100) NOT NULL, 
	[WeakFootRating]  int NOT NULL, 
	[SkillMovesRating]  int NOT NULL, 
	[MinWorth]  DECIMAL NOT NULL, 
	[MaxWorth]  DECIMAL NOT NULL, 
	[Foot] VARCHAR(20) NOT NULL
); 
 
CREATE TABLE [dbo].[Image] ( 
    [ImageId] INT IDENTITY (1, 1) NOT NULL, 
    [Id] int NOT NULL, 
    [PlayerPath] varchar(200) NOT NULL, 
    [NationalityPath] varchar(200) NOT NULL, 
	[ClubPath] varchar(200) NOT NULL, 
	CONSTRAINT [PK_dbo.Id] PRIMARY KEY CLUSTERED ([Id] ASC),
); 
 CREATE TABLE [dbo].[Rating] ( 
    [RatingId] INT IDENTITY (1, 1) NOT NULL, 
    [Id] int NOT NULL, 
    [Overall] int NOT NULL, 
    [Pace] int NOT NULL, 
	[Shooting] int NOT NULL, 
	[Passing] int NOT NULL, 
	[Dribbling] int NOT NULL, 
	[Defense] int NOT NULL, 
	[Physical] int NOT NULL, 
	[TotalStats] int NOT NULL, 
	CONSTRAINT [PK_dbo.Id] PRIMARY KEY CLUSTERED ([Id] ASC),
); 

CREATE TABLE [dbo].[FifaThumbnails] ( 
    [FifaThumbnailsId] INT IDENTITY (1, 1) Primary Key NOT NULL,
	[PlayerPath]  VARCHAR (100) NOT NULL, 
    [NationalityPath]  VARCHAR (100) NOT NULL, 
	[ClubPath]  VARCHAR (100) NOT NULL, 
	
); 
 

