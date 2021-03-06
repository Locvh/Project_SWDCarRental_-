USE [master]
GO
/****** Object:  Database [CarRentalDB]    Script Date: 3/5/2021 5:25:05 PM ******/
CREATE DATABASE [CarRentalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRentalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarRentalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRentalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarRentalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarRentalDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRentalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRentalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRentalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRentalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRentalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRentalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRentalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRentalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRentalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRentalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRentalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRentalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRentalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRentalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRentalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRentalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRentalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRentalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRentalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRentalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRentalDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CarRentalDB] SET  MULTI_USER 
GO
ALTER DATABASE [CarRentalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRentalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRentalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRentalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRentalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRentalDB] SET QUERY_STORE = OFF
GO
USE [CarRentalDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/5/2021 5:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [nvarchar](30) NOT NULL,
	[AccountName] [nvarchar](50) NULL,
	[Role] [nvarchar](10) NULL,
	[Status] [bit] NULL,
	[GoogleID] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 3/5/2021 5:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[ResID] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[FullName] [nvarchar](50) NULL,
	[AccountID] [nvarchar](30) NULL,
	[TotalPayment] [float] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[ResID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingDetail]    Script Date: 3/5/2021 5:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ResID] [int] NOT NULL,
	[VelNo] [int] NOT NULL,
	[AmountOfMoney] [float] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
 CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/5/2021 5:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CateID] [int] IDENTITY(1,1) NOT NULL,
	[Colour] [nvarchar](50) NULL,
	[Manufacture] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garage]    Script Date: 3/5/2021 5:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garage](
	[GarageID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](70) NULL,
	[Description] [nvarchar](50) NULL,
	[ImageLink] [nvarchar](200) NULL,
 CONSTRAINT [PK_Garage] PRIMARY KEY CLUSTERED 
(
	[GarageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/5/2021 5:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileImage] [nvarchar](50) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](70) NULL,
	[IdentityCard] [varchar](15) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[AccountID] [nvarchar](30) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 3/5/2021 5:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VelNo] [int] IDENTITY(1,1) NOT NULL,
	[CateID] [int] NULL,
	[VehicleFare] [nvarchar](50) NULL,
	[Seat] [int] NULL,
	[DescriptionCar] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[ImageLink] [nvarchar](200) NULL,
	[LicensePlates] [nvarchar](50) NULL,
	[Brand] [nvarchar](50) NULL,
	[CheckInDate] [datetime] NULL,
	[CheckOutDate] [datetime] NULL,
	[GarageID] [int] NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[VelNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountID], [AccountName], [Role], [Status], [GoogleID], [Password]) VALUES (N'A123', N'sieunhando', N'admin', 1, N'A123', N'1234')
INSERT [dbo].[Account] ([AccountID], [AccountName], [Role], [Status], [GoogleID], [Password]) VALUES (N'A12334', N'LocVH2', N'admin', 1, N'A3121', N'1234')
INSERT [dbo].[Account] ([AccountID], [AccountName], [Role], [Status], [GoogleID], [Password]) VALUES (N'A221', N'LocVH', N'admin', 0, N'11221ccas1', N'1232')
INSERT [dbo].[Account] ([AccountID], [AccountName], [Role], [Status], [GoogleID], [Password]) VALUES (N'A321', N'sieunhanxanh', N'admin', 1, N'1', N'8520')
INSERT [dbo].[Account] ([AccountID], [AccountName], [Role], [Status], [GoogleID], [Password]) VALUES (N'E1234', N'SieunhanVang', N'user', 1, N'Null', N'2665')
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([ResID], [Phone], [FullName], [AccountID], [TotalPayment]) VALUES (1, N'123456', N'Loc', N'A123', 12000)
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[BookingDetail] ON 

INSERT [dbo].[BookingDetail] ([ID], [ResID], [VelNo], [AmountOfMoney], [FromDate], [ToDate]) VALUES (3, 1, 12, 14500, CAST(N'2011-11-11T00:00:00.000' AS DateTime), CAST(N'2021-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[BookingDetail] ([ID], [ResID], [VelNo], [AmountOfMoney], [FromDate], [ToDate]) VALUES (4, 1, 13, 1515115, CAST(N'2021-01-11T00:00:00.000' AS DateTime), CAST(N'2021-01-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[BookingDetail] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CateID], [Colour], [Manufacture], [Model]) VALUES (1, N'den', N'USA', N'Honda')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Garage] ON 

INSERT [dbo].[Garage] ([GarageID], [Address], [Description], [ImageLink]) VALUES (1, N'XVNT', N'xa qua troi', N'khong co')
INSERT [dbo].[Garage] ([GarageID], [Address], [Description], [ImageLink]) VALUES (2, N'string', N'string', N'tim')
SET IDENTITY_INSERT [dbo].[Garage] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [ProfileImage], [Phone], [Email], [Address], [IdentityCard], [FullName], [AccountID], [Status]) VALUES (1, N'A123', N'123456789', N'ld@gmail.com', N'adasdasd', N'123213123', N'Vo Huu Loc', N'A123', 1)
INSERT [dbo].[User] ([UserID], [ProfileImage], [Phone], [Email], [Address], [IdentityCard], [FullName], [AccountID], [Status]) VALUES (4, N'aaa', N'1234567', N'c@gds.com', N'dasdas', N'few1', N'sieu nhan do', N'A123', 1)
INSERT [dbo].[User] ([UserID], [ProfileImage], [Phone], [Email], [Address], [IdentityCard], [FullName], [AccountID], [Status]) VALUES (1002, N'sadas', N'123456721', N'c@gds.com', N'dasdas', N'few1', N'sieu nhan do', N'A123', 0)
INSERT [dbo].[User] ([UserID], [ProfileImage], [Phone], [Email], [Address], [IdentityCard], [FullName], [AccountID], [Status]) VALUES (1003, N'eeee', N'12313242', N'fsd', N'dsfsdf', N'e1', N'sieunhan', N'A123', 1)
INSERT [dbo].[User] ([UserID], [ProfileImage], [Phone], [Email], [Address], [IdentityCard], [FullName], [AccountID], [Status]) VALUES (1004, N'eeee', N'12313242', N'fsd', N'dsfsdf', N'e1', N'sieunhan', N'A123', 1)
INSERT [dbo].[User] ([UserID], [ProfileImage], [Phone], [Email], [Address], [IdentityCard], [FullName], [AccountID], [Status]) VALUES (1005, N'ads', N'123', N'dds', N'fds', N'sdd1', N'dsfsd', N'A123', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([VelNo], [CateID], [VehicleFare], [Seat], [DescriptionCar], [Status], [ImageLink], [LicensePlates], [Brand], [CheckInDate], [CheckOutDate], [GarageID], [Price]) VALUES (12, 1, N'Xe hơi', 4, N'ngon', 0, N'da co', N'das', N'vvv', CAST(N'2012-11-11T00:00:00.000' AS DateTime), CAST(N'2021-11-12T00:00:00.000' AS DateTime), 1, 10000)
INSERT [dbo].[Vehicle] ([VelNo], [CateID], [VehicleFare], [Seat], [DescriptionCar], [Status], [ImageLink], [LicensePlates], [Brand], [CheckInDate], [CheckOutDate], [GarageID], [Price]) VALUES (13, 1, N'sieunhando', 6, N'xe sang', 1, N'Ok', N'khong co', N'khong coo', CAST(N'2021-05-10T00:00:00.000' AS DateTime), CAST(N'2021-08-20T00:00:00.000' AS DateTime), 1, 10000)
INSERT [dbo].[Vehicle] ([VelNo], [CateID], [VehicleFare], [Seat], [DescriptionCar], [Status], [ImageLink], [LicensePlates], [Brand], [CheckInDate], [CheckOutDate], [GarageID], [Price]) VALUES (14, 1, N'ko bk', 9, N'no', 1, N'ko co', N'fdsd', N'fsd', CAST(N'2021-02-21T04:00:11.653' AS DateTime), CAST(N'2021-02-21T04:00:11.653' AS DateTime), 1, 100520)
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Account]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_Booking1] FOREIGN KEY([ResID])
REFERENCES [dbo].[Booking] ([ResID])
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_Booking1]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_Vehicle] FOREIGN KEY([VelNo])
REFERENCES [dbo].[Vehicle] ([VelNo])
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_Vehicle]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Account]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Car_Category] FOREIGN KEY([CateID])
REFERENCES [dbo].[Category] ([CateID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Car_Category]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Garage] FOREIGN KEY([GarageID])
REFERENCES [dbo].[Garage] ([GarageID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Garage]
GO
USE [master]
GO
ALTER DATABASE [CarRentalDB] SET  READ_WRITE 
GO
