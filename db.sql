USE [master]
GO
/****** Object:  Database [NhocGiftShopDb]    Script Date: 12/12/2019 3:28:42 PM ******/
CREATE DATABASE [NhocGiftShopDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NhocGiftShopDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AKAKSHUKI\MSSQL\DATA\NhocGiftShopDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NhocGiftShopDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AKAKSHUKI\MSSQL\DATA\NhocGiftShopDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NhocGiftShopDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NhocGiftShopDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NhocGiftShopDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NhocGiftShopDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NhocGiftShopDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NhocGiftShopDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NhocGiftShopDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NhocGiftShopDb] SET  MULTI_USER 
GO
ALTER DATABASE [NhocGiftShopDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NhocGiftShopDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NhocGiftShopDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NhocGiftShopDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NhocGiftShopDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NhocGiftShopDb] SET QUERY_STORE = OFF
GO
USE [NhocGiftShopDb]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Name] [nvarchar](250) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nchar](10) NULL,
	[Birth] [datetime] NULL,
	[Male] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailProduct]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](50) NULL,
	[Size] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
	[CreateBy] [int] NULL,
	[DateCreate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_DetailProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] NOT NULL,
	[CustomerId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[Total] [nchar](10) NULL,
	[Date] [datetime] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[DetailProductId] [int] NULL,
	[Quatity] [int] NULL,
	[Amout] [int] NULL,
	[OrderId] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Detail] [ntext] NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[Image] [nvarchar](250) NULL,
	[CreateBy] [int] NULL,
	[DateCreate] [datetime] NOT NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[ProductId] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[ContentService] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CategoryId] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/12/2019 3:28:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Name] [nvarchar](250) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nchar](10) NULL,
	[Birth] [datetime] NOT NULL,
	[RoleId] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Birth]  DEFAULT (getdate()) FOR [Birth]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Male]  DEFAULT ((1)) FOR [Male]
GO
ALTER TABLE [dbo].[DetailProduct] ADD  CONSTRAINT [DF_DetailProduct_DateCreate]  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[DetailProduct] ADD  CONSTRAINT [DF_DetailProduct_ModifyDate]  DEFAULT (getdate()) FOR [ModifyDate]
GO
ALTER TABLE [dbo].[DetailProduct] ADD  CONSTRAINT [DF_DetailProduct_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_DateCreate]  DEFAULT (getdate()) FOR [DateCreate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ModifyDate]  DEFAULT (getdate()) FOR [ModifyDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ProductImage] ADD  CONSTRAINT [DF_ProductImage_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Service] ADD  CONSTRAINT [DF_Service_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[SubCategory] ADD  CONSTRAINT [DF_SubCategory_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Birth]  DEFAULT (getdate()) FOR [Birth]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[DetailProduct]  WITH CHECK ADD  CONSTRAINT [FK_DetailProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[DetailProduct] CHECK CONSTRAINT [FK_DetailProduct_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product1]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [NhocGiftShopDb] SET  READ_WRITE 
GO
