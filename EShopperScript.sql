USE [master]
GO
/****** Object:  Database [EShopper]    Script Date: 15.06.2025 23:19:48 ******/
CREATE DATABASE [EShopper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EShopper', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EShopper.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EShopper_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EShopper_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EShopper] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EShopper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EShopper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EShopper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EShopper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EShopper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EShopper] SET ARITHABORT OFF 
GO
ALTER DATABASE [EShopper] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EShopper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EShopper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EShopper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EShopper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EShopper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EShopper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EShopper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EShopper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EShopper] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EShopper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EShopper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EShopper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EShopper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EShopper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EShopper] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EShopper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EShopper] SET RECOVERY FULL 
GO
ALTER DATABASE [EShopper] SET  MULTI_USER 
GO
ALTER DATABASE [EShopper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EShopper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EShopper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EShopper] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EShopper] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EShopper] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EShopper', N'ON'
GO
ALTER DATABASE [EShopper] SET QUERY_STORE = ON
GO
ALTER DATABASE [EShopper] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EShopper]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUsers]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_ApplicationUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrandCategory]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandCategory](
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_BrandCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mails]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[From] [nvarchar](max) NOT NULL,
	[To] [nvarchar](max) NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[IsHtml] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DeletedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Mails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 15.06.2025 23:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[WebID] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Stock] [smallint] NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250410131837_CreateDatabase', N'8.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250520123459_NewMigrationUpdate', N'8.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250520190706_CreateDatabase', N'8.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250523113027_IdentityDatabase', N'8.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250523123906_MailDatabase', N'8.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250604133620_AddCategoryIdToProduct', N'8.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250612125621_FixMapping', N'8.0.14')
GO
INSERT [dbo].[ApplicationUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'61a9c91e-13f8-4fb2-9c56-16bfcd5646af', N'deniz', N'kirtas', N'denizkirtas', N'DENIZKIRTAS', N'denhis_1905@hotmail.com', N'DENHIS_1905@HOTMAIL.COM', 0, N'AQAAAAIAAYagAAAAEOJ7XJe1hKvWMXmGiIT3VFlZ9V3JOpxKHXys6KqXnFLy6kU9Z1+7yWWO1EAXx4mMVA==', N'7S4MJELQU2ZR62RDOEVV5EA52L6QR2ZF', N'1f454dc2-8c11-42fb-a65c-aec6fcd5f847', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[ApplicationUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'cc2e5c7e-6796-40dd-a4bd-3e11ab43a257', N'deniz', N'akakka', N'denizakakka', N'DENIZAKAKKA', N'denizkirtass@gmail.com', N'DENIZKIRTASS@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEGlztgzLOPmGC9afMHjLL5cO0bxqsi50S3J5UXg+uo8jj8lt81KtkykBcvrs5Ts9CQ==', N'Q6B5XI7UQGY4MESEZFJM2V5Y3HCRQRDI', N'5c21788d-8f94-43be-9d16-645a4f6f4341', NULL, 0, 0, NULL, 1, 1)
GO
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (1, 1)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (1, 2)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (1, 3)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (2, 2)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (2, 4)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (3, 3)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (4, 7)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (4, 8)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (5, 1)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (5, 5)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (5, 6)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (5, 10)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (6, 2)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (6, 3)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (6, 5)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (6, 8)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (6, 9)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (6, 10)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (7, 1)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (7, 2)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (7, 3)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (7, 7)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (7, 8)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (8, 5)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (8, 7)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (8, 9)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (8, 10)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (9, 1)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (9, 3)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (9, 4)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (9, 5)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (9, 6)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (9, 9)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (9, 10)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (10, 1)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (10, 2)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (10, 3)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (10, 4)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (10, 5)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (10, 9)
INSERT [dbo].[BrandCategory] ([BrandId], [CategoryId]) VALUES (10, 10)
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [Name]) VALUES (1, N'Adidas')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (2, N'Nike')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (3, N'Puma')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (4, N'Under Armour')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (5, N'Calvin Klein')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (6, N'LCW')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (7, N'Skechers')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (8, N'Michael Kors')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (9, N'Tommy Hilfiger')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (10, N'Zara')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Ayakkabı')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Şapka')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Eşofman Altı')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Ceket')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'T-Shirt')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Spor')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Erkek')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (8, N'Kadın')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (9, N'Çocuk')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (10, N'Çanta')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Url], [ProductId]) VALUES (2, N'product1.jpg', 1)
INSERT [dbo].[Images] ([Id], [Url], [ProductId]) VALUES (8, N'product2.jpg', 2)
INSERT [dbo].[Images] ([Id], [Url], [ProductId]) VALUES (16, N'product3.jpg', 4)
INSERT [dbo].[Images] ([Id], [Url], [ProductId]) VALUES (20, N'product4.jpg', 6)
INSERT [dbo].[Images] ([Id], [Url], [ProductId]) VALUES (21, N'product5.jpg', 7)
INSERT [dbo].[Images] ([Id], [Url], [ProductId]) VALUES (23, N'product6.jpg', 9)
INSERT [dbo].[Images] ([Id], [Url], [ProductId]) VALUES (31, N'20250612164315482.png', 31)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Title], [WebID], [Rating], [Price], [Stock], [BrandId], [CategoryId], [CreatedDate]) VALUES (1, N'Beyaz Çizgili Siyah Eşofman', 273617283, 85, 100, 100, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [Title], [WebID], [Rating], [Price], [Stock], [BrandId], [CategoryId], [CreatedDate]) VALUES (2, N'Super Star', 982091823, 100, 200, 100, 2, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [Title], [WebID], [Rating], [Price], [Stock], [BrandId], [CategoryId], [CreatedDate]) VALUES (4, N'Polo Yaka T-Shirt', 123432556, 100, 200, 100, 3, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [Title], [WebID], [Rating], [Price], [Stock], [BrandId], [CategoryId], [CreatedDate]) VALUES (6, N'Deri Çanta', 123090431, 80, 350, 500, 4, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [Title], [WebID], [Rating], [Price], [Stock], [BrandId], [CategoryId], [CreatedDate]) VALUES (7, N'Kot Pantolon', 999888543, 90, 250, 50, 5, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [Title], [WebID], [Rating], [Price], [Stock], [BrandId], [CategoryId], [CreatedDate]) VALUES (9, N'Kazak', 123912391, 100, 300, 250, 6, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Products] ([Id], [Title], [WebID], [Rating], [Price], [Stock], [BrandId], [CategoryId], [CreatedDate]) VALUES (31, N'Deri Ceket', 123456789, 5, 1111, 5, 2, 4, CAST(N'2025-06-12T16:43:17.8338714' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/****** Object:  Index [IX_BrandCategory_BrandId]    Script Date: 15.06.2025 23:19:49 ******/
CREATE NONCLUSTERED INDEX [IX_BrandCategory_BrandId] ON [dbo].[BrandCategory]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_ProductId]    Script Date: 15.06.2025 23:19:49 ******/
CREATE NONCLUSTERED INDEX [IX_Comments_ProductId] ON [dbo].[Comments]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Images_ProductId]    Script Date: 15.06.2025 23:19:49 ******/
CREATE NONCLUSTERED INDEX [IX_Images_ProductId] ON [dbo].[Images]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_BrandId]    Script Date: 15.06.2025 23:19:49 ******/
CREATE NONCLUSTERED INDEX [IX_Products_BrandId] ON [dbo].[Products]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 15.06.2025 23:19:49 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[BrandCategory]  WITH CHECK ADD  CONSTRAINT [FK_BrandCategory_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BrandCategory] CHECK CONSTRAINT [FK_BrandCategory_Brands_BrandId]
GO
ALTER TABLE [dbo].[BrandCategory]  WITH CHECK ADD  CONSTRAINT [FK_BrandCategory_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BrandCategory] CHECK CONSTRAINT [FK_BrandCategory_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Products_ProductId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [EShopper] SET  READ_WRITE 
GO
