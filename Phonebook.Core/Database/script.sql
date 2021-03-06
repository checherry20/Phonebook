USE [PhonebookDB]
GO
/****** Object:  Table [dbo].[contacts]    Script Date: 10/13/2016 3:28:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](15) NULL,
	[number] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 10/13/2016 3:28:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NULL,
	[password] [varchar](20) NULL,
	[firstName] [varchar](30) NULL,
	[lastname] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[contacts] ON 

INSERT [dbo].[contacts] ([ID], [NAME], [number]) VALUES (1, N'eee', 2323)
INSERT [dbo].[contacts] ([ID], [NAME], [number]) VALUES (2, N'ERW', 2343)
INSERT [dbo].[contacts] ([ID], [NAME], [number]) VALUES (1004, N'Chewwy', 342342)
INSERT [dbo].[contacts] ([ID], [NAME], [number]) VALUES (2002, N'adfasd', 22)
SET IDENTITY_INSERT [dbo].[contacts] OFF
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([userID], [username], [password], [firstName], [lastname]) VALUES (1, N'cherry', N'cheche123', N'Cherrilyn', N'Ablay')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
