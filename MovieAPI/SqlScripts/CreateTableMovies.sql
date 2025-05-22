USE [Movies]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 22/05/2025 14:22:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Movies]') AND type in (N'U'))
DROP TABLE [dbo].[Movies]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 22/05/2025 14:22:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
	[Release_Date] [datetime] NULL,
	[Title] [nvarchar](255) NULL,
	[Overview] [nvarchar](max) NULL,
	[Popularity] [float] NULL,
	[Vote_Count] [float] NULL,
	[Vote_Average] [float] NULL,
	[Original_Language] [nvarchar](255) NULL,
	[Genre] [nvarchar](255) NULL,
	[Poster_Url] [nvarchar](255) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


