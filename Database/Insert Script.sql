USE [Customer]
GO

INSERT INTO [dbo].[Customer]
           ([addressCity]
           ,[addressLine1]
           ,[addressLine2]
           ,[addressPostCode]
           ,[contactNumber]
           ,[dateOfBirth]
           ,[emailAddress]
           ,[firstName]
           ,[lastName])
     VALUES
           ('Northampton',
		   '1st Street',
		   'apartment lane',
		   'NN100NJ',
		   '01234567891',
		   DATEADD(YEAR,-25,GETUTCDATE()),
		   'john@email.com',
		   'John',
		   'Smith')
GO

INSERT INTO [dbo].[Customer]
           ([addressCity]
           ,[addressLine1]
           ,[addressLine2]
           ,[addressPostCode]
           ,[contactNumber]
           ,[dateOfBirth]
           ,[emailAddress]
           ,[firstName]
           ,[lastName])
     VALUES
           ('Northampton',
		   '45th Street',
		   NULL,
		   'NN100NJ',
		   '012345676788',
		   DATEADD(YEAR,-30,GETUTCDATE()),
		   'bob@email.com',
		   'BoB',
		   'Thomas')
GO



