/****** Object:  Table [dbo].[Album]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Album_Id] [int] IDENTITY(1,1) NOT NULL,
	[Album_Name] [nchar](20) NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_ArtistProfile] PRIMARY KEY CLUSTERED 
(
	[Album_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Play]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Play](
	[Playlist_Id] [int] NOT NULL,
	[Song_Name] [nchar](30) NOT NULL,
	[Artist_Name] [nchar](20) NOT NULL,
	[Song_Id] [int] NOT NULL,
	[Artist_Id] [int] NOT NULL,
	[Playlist_Entry] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Play] PRIMARY KEY CLUSTERED 
(
	[Playlist_Entry] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[Playlist_Id] [int] IDENTITY(1,1) NOT NULL,
	[Playlist_Name] [nchar](25) NOT NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[Playlist_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistTbl]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistTbl](
	[Entry_Id] [int] IDENTITY(1,1) NOT NULL,
	[Playlist_Id] [int] NOT NULL,
	[Song_Id] [int] NOT NULL,
	[Playlist_Name] [nvarchar](15) NOT NULL,
	[Created_By] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileArtist]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileArtist](
	[Artist_Id] [int] IDENTITY(1,1) NOT NULL,
	[Artist_Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ProfileArtist] PRIMARY KEY CLUSTERED 
(
	[Artist_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Song]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Song](
	[Song_Id] [int] IDENTITY(1,1) NOT NULL,
	[Song_Name] [nchar](30) NOT NULL,
	[Duration] [int] NOT NULL,
	[Artist_Id] [int] NOT NULL,
	[Album_Id] [int] NULL,
	[Playlist_Id] [int] NULL,
 CONSTRAINT [PK_Song] PRIMARY KEY CLUSTERED 
(
	[Song_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionTable]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionTable](
	[Subscription_ID] [int] IDENTITY(1,1) NOT NULL,
	[Subscription] [nchar](20) NOT NULL,
	[Price] [int] NOT NULL,
	[Ads] [bit] NOT NULL,
 CONSTRAINT [PK_SubscriptionTable] PRIMARY KEY CLUSTERED 
(
	[Subscription_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 12/10/2020 5:14:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[Country] [nvarchar](20) NOT NULL,
	[Subscription] [int] NOT NULL,
	[Pwd] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Album] ON 

INSERT [dbo].[Album] ([Album_Id], [Album_Name], [Year]) VALUES (1, N'Kitan               ', 2018)
INSERT [dbo].[Album] ([Album_Id], [Album_Name], [Year]) VALUES (2, N'Viva la Vida        ', 2011)
INSERT [dbo].[Album] ([Album_Id], [Album_Name], [Year]) VALUES (3, N'Fire                ', 2020)
SET IDENTITY_INSERT [dbo].[Album] OFF
GO
SET IDENTITY_INSERT [dbo].[Play] ON 

INSERT [dbo].[Play] ([Playlist_Id], [Song_Name], [Artist_Name], [Song_Id], [Artist_Id], [Playlist_Entry]) VALUES (1, N'Desire                        ', N'Pelican_Fanclub     ', 1, 2, 2)
INSERT [dbo].[Play] ([Playlist_Id], [Song_Name], [Artist_Name], [Song_Id], [Artist_Id], [Playlist_Entry]) VALUES (1, N'As you like it                ', N'E ve                ', 1, 1, 4)
SET IDENTITY_INSERT [dbo].[Play] OFF
GO
SET IDENTITY_INSERT [dbo].[PlaylistTbl] ON 

INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (33, 1, 6, N'Chill', 1)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (38, 5, 5, N'Hill', 1)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (8, 1, 1, N'Chill', 1)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (9, 1, 2, N'Chill', 1)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (10, 1, 3, N'Chill', 1)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (13, 2, 2, N'NewMan', 3)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (14, 2, 4, N'NewMan', 3)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (46, 2, 1, N'Desire', 38)
INSERT [dbo].[PlaylistTbl] ([Entry_Id], [Playlist_Id], [Song_Id], [Playlist_Name], [Created_By]) VALUES (47, 2, 3, N'Desire', 38)
SET IDENTITY_INSERT [dbo].[PlaylistTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ProfileArtist] ON 

INSERT [dbo].[ProfileArtist] ([Artist_Id], [Artist_Name]) VALUES (1, N'E ve')
INSERT [dbo].[ProfileArtist] ([Artist_Id], [Artist_Name]) VALUES (2, N'Pelican Fanclub')
INSERT [dbo].[ProfileArtist] ([Artist_Id], [Artist_Name]) VALUES (3, N'Bad Bunny')
INSERT [dbo].[ProfileArtist] ([Artist_Id], [Artist_Name]) VALUES (4, N'Drake')
INSERT [dbo].[ProfileArtist] ([Artist_Id], [Artist_Name]) VALUES (5, N'Coldplay')
INSERT [dbo].[ProfileArtist] ([Artist_Id], [Artist_Name]) VALUES (6, N'Maroon 5')
INSERT [dbo].[ProfileArtist] ([Artist_Id], [Artist_Name]) VALUES (7, N'Siames')
SET IDENTITY_INSERT [dbo].[ProfileArtist] OFF
GO
SET IDENTITY_INSERT [dbo].[Song] ON 

INSERT [dbo].[Song] ([Song_Id], [Song_Name], [Duration], [Artist_Id], [Album_Id], [Playlist_Id]) VALUES (1, N'Desire                        ', 300, 2, NULL, NULL)
INSERT [dbo].[Song] ([Song_Id], [Song_Name], [Duration], [Artist_Id], [Album_Id], [Playlist_Id]) VALUES (2, N'Kaikai Kitan                  ', 200, 1, NULL, NULL)
INSERT [dbo].[Song] ([Song_Id], [Song_Name], [Duration], [Artist_Id], [Album_Id], [Playlist_Id]) VALUES (3, N'Viva La Vida                  ', 250, 5, NULL, NULL)
INSERT [dbo].[Song] ([Song_Id], [Song_Name], [Duration], [Artist_Id], [Album_Id], [Playlist_Id]) VALUES (4, N'Callaita                      ', 200, 3, NULL, NULL)
INSERT [dbo].[Song] ([Song_Id], [Song_Name], [Duration], [Artist_Id], [Album_Id], [Playlist_Id]) VALUES (5, N'As you like it                ', 200, 1, NULL, NULL)
INSERT [dbo].[Song] ([Song_Id], [Song_Name], [Duration], [Artist_Id], [Album_Id], [Playlist_Id]) VALUES (6, N'Stone                         ', 300, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Song] OFF
GO
SET IDENTITY_INSERT [dbo].[SubscriptionTable] ON 

INSERT [dbo].[SubscriptionTable] ([Subscription_ID], [Subscription], [Price], [Ads]) VALUES (1, N'free                ', 0, 1)
INSERT [dbo].[SubscriptionTable] ([Subscription_ID], [Subscription], [Price], [Ads]) VALUES (2, N'Premium             ', 15, 0)
SET IDENTITY_INSERT [dbo].[SubscriptionTable] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (1, N'Juan_Carlos', N'juancarlos@hotmail.com', N'United States', 2, N'12345')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (3, N'carlos', N'carlos@hotmail.com', N'United States', 2, N'234')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (4, N'LeBron James', N'Lebron@hotmail.com', N'United States', 2, N'34567')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (5, N'LeBron Carl', N'Lebron23@hotmail.com', N'Mexico', 2, N'343')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (6, N'Cristian', N'cristian@hotmail.com', N'United States', 2, N'45678')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (8, N'Soap', N'Soap@hotmail.com', N'United States', 2, N'3456')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (17, N'Kebin Bin', N'elpepe@gmail.com', N'United States', 2, N'asdf898Ja')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (30, N'randy', N'ran@hotmail.com', N'Hawaii', 1, N'1234')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (31, N'TT', N'randy0320@gmail.com', N'United States', 1, N'tras12')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (32, N'el pepe 809', N'elpepe809@gmail.com', N'United States', 1, N'akljsdh879')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (33, N'Yagami', N'Yagami@hotmail.com', N'United States', 1, N'2345')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (34, N'Dakota20', N'dakota@hotmail.com', N'United States', 1, N'12345')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (35, N'Dakota30', N'Dakora@hotmail.com', N'Hawaii', 2, N'12345')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (38, N'KiosoKen', N'rand@gmail.com', N'United States', 2, N'nissan350z')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (41, N'python test', N'python.test@gmail.com', N'United States', 1, N'asdfqwer12')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (42, N'askdf', N'asdf', N'United States', 1, N'asdfa')
INSERT [dbo].[UserProfile] ([User_Id], [User_Name], [Email], [Country], [Subscription], [Pwd]) VALUES (43, N'qer', N'adf', N'United States', 1, N'asdfa')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
ALTER TABLE [dbo].[PlaylistTbl]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTbl_Song] FOREIGN KEY([Song_Id])
REFERENCES [dbo].[Song] ([Song_Id])
GO
ALTER TABLE [dbo].[PlaylistTbl] CHECK CONSTRAINT [FK_PlaylistTbl_Song]
GO
ALTER TABLE [dbo].[PlaylistTbl]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistTbl_UserProfile] FOREIGN KEY([Created_By])
REFERENCES [dbo].[UserProfile] ([User_Id])
GO
ALTER TABLE [dbo].[PlaylistTbl] CHECK CONSTRAINT [FK_PlaylistTbl_UserProfile]
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD  CONSTRAINT [FK_Song_Album] FOREIGN KEY([Album_Id])
REFERENCES [dbo].[Album] ([Album_Id])
GO
ALTER TABLE [dbo].[Song] CHECK CONSTRAINT [FK_Song_Album]
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD  CONSTRAINT [FK_Song_Playlist] FOREIGN KEY([Playlist_Id])
REFERENCES [dbo].[Playlist] ([Playlist_Id])
GO
ALTER TABLE [dbo].[Song] CHECK CONSTRAINT [FK_Song_Playlist]
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD  CONSTRAINT [FK_Song_ProfileArtist] FOREIGN KEY([Artist_Id])
REFERENCES [dbo].[ProfileArtist] ([Artist_Id])
GO
ALTER TABLE [dbo].[Song] CHECK CONSTRAINT [FK_Song_ProfileArtist]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_SubscriptionTable] FOREIGN KEY([Subscription])
REFERENCES [dbo].[SubscriptionTable] ([Subscription_ID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_SubscriptionTable]
GO
/****** Object:  StoredProcedure [dbo].[AddInPlaylist]    Script Date: 12/10/2020 5:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[AddInPlaylist]
(
    -- Add the parameters for the stored procedure here
	@PlaylistID int,
	@Song_Id int,
	@Playlist_Name nvarchar(15),
	@Created_By int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
	INSERT INTO dbo.PlaylistTbl (Playlist_Id, Song_Id, Playlist_Name, Created_By) VALUES (@PlaylistID, @Song_Id, @Playlist_Name, @Created_By)
END
GO
/****** Object:  StoredProcedure [dbo].[CreatePlaylist]    Script Date: 12/10/2020 5:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[CreatePlaylist]
(
    -- Add the parameters for the stored procedure here
	@PlaylistId int,
	@Song_Id int,
	@Playlist_Name nvarchar(15),
	@Created_By int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
	INSERT INTO dbo.PlaylistTbl(Playlist_Id, Song_Id, Playlist_Name, Created_By) VALUES (@PlaylistId, @Song_Id, @Playlist_Name, @Created_By)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 12/10/2020 5:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
(
    -- Add the parameters for the stored procedure here
    @Username nvarchar(20),
	@Email nvarchar(40),
	@Country nvarchar(20),
	@Subscription int,
	@Password nvarchar(10)
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO dbo.UserProfile (User_Name, Email, Country, Subscription, Pwd) VALUES (@Username, @Email, @Country, @Subscription, @Password)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertSub]    Script Date: 12/10/2020 5:14:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[InsertSub]
(
    -- Add the parameters for the stored procedure here
	@Subscription nchar(20),
	@Price int,
	@Ads bit
	)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO dbo.SubscriptionTable (Subscription, Price, Ads) VALUES (@Subscription, @Price, @Ads)
END
GO
