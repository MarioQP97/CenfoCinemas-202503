/****** Object: Table [dbo].[tblUsers] Scripts Date: 9/13/2025 11:14:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUsers](
	[Id] [int] identity(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[UserCode] [nvarchar](25) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Status] [nvarchar](2) NOT NULL,
CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO