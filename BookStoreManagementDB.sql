USE [BookStoreManagementDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2/23/2024 11:33:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](80) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/23/2024 11:33:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImportDate] [datetime] NOT NULL,
	[OriginSource] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 2/23/2024 11:33:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
 CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [FullName], [Password], [Email], [Role]) VALUES (1, N'Admin', N'Admin@123', N'admin@gmail.com', N'Administrator')
INSERT [dbo].[Account] ([AccountId], [FullName], [Password], [Email], [Role]) VALUES (2, N'Staff1', N'Staff1@123', N'staff1@gmail.com', N'Staff')
INSERT [dbo].[Account] ([AccountId], [FullName], [Password], [Email], [Role]) VALUES (4, N'User1', N'User@123', N'ads@gmail.com', N'User')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookId], [Name], [Description], [ImportDate], [OriginSource], [Quantity], [Price], [IsAvailable], [CategoryId]) VALUES (6, N'Milk and Honey', N'#1 New York Times bestseller Milk and Honey is a collection of poetry and prose about survival. About the experience of violence, abuse, love, loss, and femininity.', CAST(N'2024-02-22T00:00:00.000' AS DateTime), N'Andrews Mcmeel Publishing', 0, 285, 0, 19)
INSERT [dbo].[Book] ([BookId], [Name], [Description], [ImportDate], [OriginSource], [Quantity], [Price], [IsAvailable], [CategoryId]) VALUES (8, N'She and her cat', N'The perfect curl-up gift for cat-lovers', CAST(N'2024-02-22T00:00:00.000' AS DateTime), N'Penguin Books', 10, 261.1, 1, 19)
INSERT [dbo].[Book] ([BookId], [Name], [Description], [ImportDate], [OriginSource], [Quantity], [Price], [IsAvailable], [CategoryId]) VALUES (9, N'Home Body', N'From the Number One Sunday Times bestselling author of milk and honey and the sun and her flowers comes her greatly anticipated third collection of poetry.', CAST(N'2024-02-22T11:22:07.243' AS DateTime), N'Simon & Schuster', 10, 359, 0, 19)
INSERT [dbo].[Book] ([BookId], [Name], [Description], [ImportDate], [OriginSource], [Quantity], [Price], [IsAvailable], [CategoryId]) VALUES (10, N'Worthy: How to Believe You Are Enough and Transform Your Life', N'This book is great', CAST(N'2024-02-15T00:00:00.000' AS DateTime), N'Jamie Kern Lima ', 5, 47, 0, 26)
INSERT [dbo].[Book] ([BookId], [Name], [Description], [ImportDate], [OriginSource], [Quantity], [Price], [IsAvailable], [CategoryId]) VALUES (11, N'Test book', N'the book for testing', CAST(N'2024-02-22T00:00:00.000' AS DateTime), N'Nguyen van a', 10, 10, 0, 14)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[BookCategory] ON 

INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (1, N'Fantasy')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (2, N'Science Fiction')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (3, N'Dystopian')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (4, N'Action & Adventure')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (5, N'Detective & Mystery')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (6, N'Thriller & Suspense')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (7, N'Romance')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (8, N'Horror')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (9, N'Historical Fiction')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (10, N'Young Adult (YA) ')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (11, N'Children’s Fiction')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (12, N'Literary Fiction')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (13, N'Graphic Novels')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (14, N'Short Story')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (15, N'Memoir & Autobiography')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (16, N'Biography')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (17, N'History')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (18, N'Food & Drink')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (19, N'Poetry')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (20, N'Self-Help')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (21, N'Travel')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (22, N'Art & Photography')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (23, N'Essays')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (24, N'Science & Technology')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (25, N'Humanities & Social Sciences')
INSERT [dbo].[BookCategory] ([CategoryId], [CategoryName]) VALUES (26, N'CookBooks')
SET IDENTITY_INSERT [dbo].[BookCategory] OFF
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_IsAvailable]  DEFAULT ((1)) FOR [IsAvailable]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BookCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookCategory]
GO
