

CREATE TABLE dbo.FifaNations
(
    FifaNationId int Identity(1,1) Primary Key NOT NULL,
    NationName varchar(100) NOT NULL,
	NationImagePath varchar(100) NOT NULL
);