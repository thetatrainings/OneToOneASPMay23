USE [master]
GO
/****** Object:  Database [ecommerce_app]    Script Date: 21/08/2023 14:26:59 ******/
CREATE DATABASE [ecommerce_app]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ecommerce_app', FILENAME = N'C:\Users\MuhammadUsman\ecommerce_app.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ecommerce_app_log', FILENAME = N'C:\Users\MuhammadUsman\ecommerce_app_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ecommerce_app] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ecommerce_app].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ecommerce_app] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ecommerce_app] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ecommerce_app] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ecommerce_app] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ecommerce_app] SET ARITHABORT OFF 
GO
ALTER DATABASE [ecommerce_app] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ecommerce_app] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ecommerce_app] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ecommerce_app] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ecommerce_app] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ecommerce_app] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ecommerce_app] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ecommerce_app] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ecommerce_app] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ecommerce_app] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ecommerce_app] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ecommerce_app] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ecommerce_app] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ecommerce_app] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ecommerce_app] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ecommerce_app] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ecommerce_app] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ecommerce_app] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ecommerce_app] SET  MULTI_USER 
GO
ALTER DATABASE [ecommerce_app] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ecommerce_app] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ecommerce_app] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ecommerce_app] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ecommerce_app] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ecommerce_app] SET QUERY_STORE = OFF
GO
USE [ecommerce_app]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ecommerce_app]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 21/08/2023 14:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[role] [nvarchar](10) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[modify_by] [nvarchar](50) NULL,
	[modified_date] [datetime] NULL,
	[image] [nvarchar](max) NULL,
	[status] [nvarchar](10) NULL,
	[system_user_id] [int] NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 21/08/2023 14:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[status] [nvarchar](10) NULL,
	[parent_id] [int] NULL,
	[created_by] [varchar](50) NULL,
	[created_date] [datetime] NULL,
	[modified_by] [nvarchar](50) NULL,
	[modified_date] [datetime] NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 21/08/2023 14:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone_number] [nvarchar](50) NULL,
	[status] [nvarchar](10) NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[modify_by] [nchar](50) NULL,
	[modified_date] [datetime] NULL,
	[image] [nvarchar](max) NULL,
	[role] [nvarchar](10) NULL,
	[system_user_id] [int] NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 21/08/2023 14:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NULL,
	[product_id] [int] NULL,
	[order_detail] [nvarchar](50) NULL,
	[customer_id] [int] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[modify_by] [nvarchar](50) NULL,
	[modified_date] [datetime] NULL,
	[status] [nvarchar](10) NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 21/08/2023 14:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[quantity] [int] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[modify_by] [nvarchar](50) NULL,
	[modified_date] [datetime] NULL,
	[category_id] [int] NULL,
	[price] [int] NULL,
	[image] [nvarchar](max) NULL,
	[status] [nvarchar](10) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seller]    Script Date: 21/08/2023 14:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seller](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone_number] [nvarchar](10) NULL,
	[join_date] [datetime] NULL,
	[company_name] [int] NULL,
	[created_by] [nvarchar](50) NULL,
	[created_date] [datetime] NULL,
	[modify_by] [nvarchar](50) NULL,
	[modified_date] [datetime] NULL,
	[image] [nvarchar](max) NULL,
	[status] [nvarchar](10) NULL,
	[role] [nvarchar](10) NULL,
	[system_user_id] [int] NULL,
 CONSTRAINT [PK_seller] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[system_user]    Script Date: 21/08/2023 14:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[system_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[role] [nvarchar](10) NULL,
	[status] [nvarchar](10) NULL,
 CONSTRAINT [PK_system_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[admin] ON 

INSERT [dbo].[admin] ([id], [user_name], [password], [role], [created_by], [created_date], [modify_by], [modified_date], [image], [status], [system_user_id]) VALUES (1, N'usmanmalikse1@gmail.com', N'12345', N'Admin', N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'/data/c943d33f-87fc-4b48-ace8-633b523deb78.jpg', N'Active', 2)
INSERT [dbo].[admin] ([id], [user_name], [password], [role], [created_by], [created_date], [modify_by], [modified_date], [image], [status], [system_user_id]) VALUES (2, N'JAMES CILIA', N'12343', N'Admin', N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'/data/f3cda15a-2996-4a96-acfa-3ca3e1fc92c2.jpeg', N'Active', 2)
SET IDENTITY_INSERT [dbo].[admin] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [name], [Description], [status], [parent_id], [created_by], [created_date], [modified_by], [modified_date]) VALUES (2, N'laptops', N'fgdhfghfdjfjr fjgkgf', N'inActive', 12, N'james', CAST(N'2023-08-12T14:05:00.000' AS DateTime), N'9', CAST(N'2023-08-26T14:05:00.000' AS DateTime))
INSERT [dbo].[category] ([id], [name], [Description], [status], [parent_id], [created_by], [created_date], [modified_by], [modified_date]) VALUES (4, N'laptops', N'THERE IS NO DESCRIPTION AVAILBLE', N'Active', 11, N'james', NULL, N'6', NULL)
INSERT [dbo].[category] ([id], [name], [Description], [status], [parent_id], [created_by], [created_date], [modified_by], [modified_date]) VALUES (5, N'laptops', N'THERE IS NO DESCRIPTION AVAILBLE', N'Active', 11, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[category] ([id], [name], [Description], [status], [parent_id], [created_by], [created_date], [modified_by], [modified_date]) VALUES (6, N'laptops', N'THERE IS NO DESCRIPTION AVAILBLE', N'Active', 11, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[category] ([id], [name], [Description], [status], [parent_id], [created_by], [created_date], [modified_by], [modified_date]) VALUES (7, N'laptops', N'THERE IS NO DESCRIPTION AVAILBLE', N'Active', 11, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[category] ([id], [name], [Description], [status], [parent_id], [created_by], [created_date], [modified_by], [modified_date]) VALUES (11, N'Desktop', N'Ram8gb,hard:1tb,', N'Active', 12, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[category] ([id], [name], [Description], [status], [parent_id], [created_by], [created_date], [modified_by], [modified_date]) VALUES (12, N'laptops', N'Device name	WS080-PC Processor	Intel(R) Core(TM) i7-7700 CPU @ 3.60GHz   3.60 GHz Installed RAM	16.0 GB Device ID	E714C7C5-6E94-4965-A475-BB9500602900 Product ID	00330-71301-53267-AAOEM System type	64-bit operating system, x64-based processor Pen and touch	No pen or touch input is available for this display', N'Active', 12, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([id], [name], [address], [phone_number], [status], [created_by], [created_date], [modify_by], [modified_date], [image], [role], [system_user_id]) VALUES (1, N'Muhammad Usman Usman', N'51, Antone', N'+393882582963', N'Active', N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022                                        ', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'/data/c7ef8230-7590-4e66-8095-e4a0b5693e47.PNG', N'Admin', 2)
INSERT [dbo].[customer] ([id], [name], [address], [phone_number], [status], [created_by], [created_date], [modify_by], [modified_date], [image], [role], [system_user_id]) VALUES (2, N'Muhammad Usman Usman', N'51, Antone', N'+393882582963', N'Active', N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022                                        ', CAST(N'2022-12-12T00:00:00.000' AS DateTime), NULL, N'Admin', 2)
INSERT [dbo].[customer] ([id], [name], [address], [phone_number], [status], [created_by], [created_date], [modify_by], [modified_date], [image], [role], [system_user_id]) VALUES (3, N'Muhammad Usman Usman', N'51, Antone', N'+393882582963', N'Active', N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022                                        ', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'/data/e71c4007-914a-42dc-8b26-30e0e5374ca7.jpeg', N'Admin', 2)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([id], [quantity], [product_id], [order_detail], [customer_id], [created_by], [created_date], [modify_by], [modified_date], [status]) VALUES (1, 4, 2, N'2344', 3, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'Active')
SET IDENTITY_INSERT [dbo].[order] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([id], [name], [description], [quantity], [created_by], [created_date], [modify_by], [modified_date], [category_id], [price], [image], [status]) VALUES (2, N'laptops', N'	Intel(R) Core(TM) i7-7700 CPU @ 3.60GHz   3.60 GHz Installed RAM	16.0 GB Device ID	E714C7C5-6E94-4965-A475-BB9500602900 Product ID	00330-71301-53267-AAOEM System type	64-bit operating system, x64-based processor Pen and touch	No pen or touch input is available for this display', 4, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime), 4, 344, N'null', N'Active')
INSERT [dbo].[products] ([id], [name], [description], [quantity], [created_by], [created_date], [modify_by], [modified_date], [category_id], [price], [image], [status]) VALUES (1002, N'img3', N'Device name	WS080-PC Processor	Intel(R) Core(TM) i7-7700 CPU @ 3.60GHz   3.60 GHz Installed RAM	16.0 GB Device ID	E714C7C5-6E94-4965-A475-BB9500602900 Product ID	00330-71301-53267-AAOEM System type	64-bit operating system, x64-based processor Pen and touch	No pen or touch input is available for this display', 4, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime), 4, 344, N'/data/f47d7f00-cdc9-4fa4-b9b7-6163235967e5.jpeg', N'Active')
INSERT [dbo].[products] ([id], [name], [description], [quantity], [created_by], [created_date], [modify_by], [modified_date], [category_id], [price], [image], [status]) VALUES (2002, N'image', N'Device name	WS080-PC Processor	Intel(R) Core(TM) i7-7700 CPU @ 3.60GHz   3.60 GHz Installed RAM	16.0 GB Device ID	E714C7C5-6E94-4965-A475-BB9500602900 Product ID	00330-71301-53267-AAOEM System type	64-bit operating system, x64-based processor Pen and touch	No pen or touch input is available for this display', 4, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime), 4, 344, N'/data/21181077-d123-4cb7-aa88-b248d6205c71.PNG', N'Active')
INSERT [dbo].[products] ([id], [name], [description], [quantity], [created_by], [created_date], [modify_by], [modified_date], [category_id], [price], [image], [status]) VALUES (3002, N'Muhammad Usman Usman', N'Device name	WS080-PC Processor	Intel(R) Core(TM) i7-7700 CPU @ 3.60GHz   3.60 GHz Installed RAM	16.0 GB Device ID	E714C7C5-6E94-4965-A475-BB9500602900 Product ID	00330-71301-53267-AAOEM System type	64-bit operating system, x64-based processor Pen and touch	No pen or touch input is available for this display', 4, N'james', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'12/12/2022', CAST(N'2022-12-12T00:00:00.000' AS DateTime), 4, 344, N'/data/774ccc55-c69e-485f-88f0-992a2996fa6b.PNG', NULL)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
USE [master]
GO
ALTER DATABASE [ecommerce_app] SET  READ_WRITE 
GO
