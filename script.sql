USE [master]
GO
/****** Object:  Database [Dale]    Script Date: 30/03/2022 22:54:42 ******/
CREATE DATABASE [Dale]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dale', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dale.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Dale_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dale_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Dale] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dale] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dale] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dale] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dale] SET RECOVERY FULL 
GO
ALTER DATABASE [Dale] SET  MULTI_USER 
GO
ALTER DATABASE [Dale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dale] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dale] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dale] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Dale] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Dale] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dale', N'ON'
GO
ALTER DATABASE [Dale] SET QUERY_STORE = OFF
GO
USE [Dale]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 30/03/2022 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[documentNumber] [varchar](15) NOT NULL,
	[phone] [varchar](13) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 30/03/2022 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[orderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[value] [decimal](18, 0) NULL,
 CONSTRAINT [PK_orderDetails] PRIMARY KEY CLUSTERED 
(
	[orderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 30/03/2022 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[reference] [uniqueidentifier] NOT NULL,
	[totalValue] [decimal](18, 0) NOT NULL,
	[totalQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 30/03/2022 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[productName] [varchar](50) NOT NULL,
	[productValue] [decimal](18, 0) NOT NULL,
	[productStock] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([customerId], [firstName], [lastName], [documentNumber], [phone]) VALUES (1, N'Miguel Angel', N'Barahona', N'1012425252', N'3115812200')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([orderDetailId], [orderId], [productId], [quantity], [value]) VALUES (1, 1, 1, 1, CAST(1200 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([orderDetailId], [orderId], [productId], [quantity], [value]) VALUES (2, 1, 2, 1, CAST(1500 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([orderId], [customerId], [reference], [totalValue], [totalQuantity]) VALUES (1, 1, N'64890258-81ab-4390-b83d-ea53b697ecb3', CAST(2700 AS Decimal(18, 0)), 2)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([productId], [productName], [productValue], [productStock]) VALUES (1, N'Agua Mineral', CAST(1200 AS Decimal(18, 0)), 200)
INSERT [dbo].[Products] ([productId], [productName], [productValue], [productStock]) VALUES (2, N'Agua brisa', CAST(1500 AS Decimal(18, 0)), 100)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderDetails_Orders] FOREIGN KEY([orderId])
REFERENCES [dbo].[Orders] ([orderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_orderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderDetails_Products] FOREIGN KEY([productId])
REFERENCES [dbo].[Products] ([productId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_orderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([customerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
USE [master]
GO
ALTER DATABASE [Dale] SET  READ_WRITE 
GO
