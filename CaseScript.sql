USE [master]
GO
/****** Object:  Database [Case]    Script Date: 6/9/2017 1:23:00 PM ******/
CREATE DATABASE [Case]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Case', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Case.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Case_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Case_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Case] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Case].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Case] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Case] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Case] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Case] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Case] SET ARITHABORT OFF 
GO
ALTER DATABASE [Case] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Case] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Case] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Case] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Case] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Case] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Case] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Case] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Case] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Case] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Case] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Case] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Case] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Case] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Case] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Case] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Case] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Case] SET RECOVERY FULL 
GO
ALTER DATABASE [Case] SET  MULTI_USER 
GO
ALTER DATABASE [Case] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Case] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Case] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Case] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Case] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Case', N'ON'
GO
ALTER DATABASE [Case] SET QUERY_STORE = OFF
GO
USE [Case]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Case]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 6/9/2017 1:23:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[EmptyMessage] [nvarchar](5) NULL,
	[Date] [datetime] NULL,
	[Subject] [nvarchar](150) NULL,
	[MessageFrom] [nvarchar](100) NULL,
	[MessageTo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RssPage]    Script Date: 6/9/2017 1:23:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RssPage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RssLink] [nvarchar](max) NULL,
	[ContentXml] [xml] NULL,
 CONSTRAINT [PK_RssPage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/9/2017 1:23:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_Date]  DEFAULT (getdate()) FOR [Date]
GO
USE [master]
GO
ALTER DATABASE [Case] SET  READ_WRITE 
GO
