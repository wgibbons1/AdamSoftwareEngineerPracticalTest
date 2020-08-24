CREATE TABLE [dbo].[Customer](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[addressCity] [nvarchar](max) NULL,
	[addressLine1] [nvarchar](max) NULL,
	[addressLine2] [nvarchar](max) NULL,
	[addressPostCode] [nvarchar](max) NULL,
	[contactNumber] [nvarchar](max) NULL,
	[dateOfBirth] [datetime2](7) NOT NULL,
	[emailAddress] [nvarchar](max) NULL,
	[firstName] [nvarchar](max) NULL,
	[lastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

