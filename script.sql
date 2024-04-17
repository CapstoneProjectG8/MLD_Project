USE [master]
GO
/****** Object:  Database [MLD_Database]    Script Date: 4/18/2024 2:26:11 AM ******/
CREATE DATABASE [MLD_Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MLD_Database', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MLD_Database.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MLD_Database_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MLD_Database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MLD_Database] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MLD_Database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MLD_Database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MLD_Database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MLD_Database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MLD_Database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MLD_Database] SET ARITHABORT OFF 
GO
ALTER DATABASE [MLD_Database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MLD_Database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MLD_Database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MLD_Database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MLD_Database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MLD_Database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MLD_Database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MLD_Database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MLD_Database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MLD_Database] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MLD_Database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MLD_Database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MLD_Database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MLD_Database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MLD_Database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MLD_Database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MLD_Database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MLD_Database] SET RECOVERY FULL 
GO
ALTER DATABASE [MLD_Database] SET  MULTI_USER 
GO
ALTER DATABASE [MLD_Database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MLD_Database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MLD_Database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MLD_Database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MLD_Database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MLD_Database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MLD_Database', N'ON'
GO
ALTER DATABASE [MLD_Database] SET QUERY_STORE = ON
GO
ALTER DATABASE [MLD_Database] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MLD_Database]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/18/2024 2:26:11 AM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[active] [bit] NULL,
	[created_by] [nvarchar](max) NULL,
	[created_date] [date] NULL,
	[role_id] [int] NULL,
	[login_attempt] [int] NULL,
	[login_last] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
	[grade_ id] [int] NULL,
 CONSTRAINT [PK_Lớp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curriculum Distribution]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curriculum Distribution](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Phân phối chương trình] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 1]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[subject_id] [int] NULL,
	[grade_id] [int] NULL,
	[user_id] [int] NULL,
	[note] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[approve_by] [int] NULL,
	[isApprove] [bit] NULL,
	[created_date] [date] NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
	[other_tasks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kế Hoạch Dạy Học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 2]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[status] [bit] NULL,
	[approve_by] [int] NULL,
	[isApprove] [bit] NULL,
	[created_date] [date] NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 3]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 3](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[document1_id] [int] NULL,
	[user_id] [int] NULL,
	[claas_name] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[isApprove] [bit] NULL,
	[approve_by] [int] NULL,
	[created_date] [date] NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
	[other_tasks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kế hoạch giáo dục của GV] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 4]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 4](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[teaching_planner_id] [int] NULL,
	[status] [bit] NULL,
	[created_date] [nchar](10) NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Phu Luc 4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 5]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 5](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[document4_id] [int] NOT NULL,
	[user_id] [int] NULL,
	[total] [int] NULL,
	[created_date] [nchar](10) NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Phu Luc 5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_CurriculumDistribution]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_CurriculumDistribution](
	[document1_id] [int] NOT NULL,
	[curriculum_id] [int] NOT NULL,
	[slot] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_CurriculumDistribution] PRIMARY KEY CLUSTERED 
(
	[document1_id] ASC,
	[curriculum_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_SelectedTopics]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_SelectedTopics](
	[document1_id] [int] NOT NULL,
	[selected_topics_id] [int] NOT NULL,
	[slot] [int] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_SelectedTopics] PRIMARY KEY CLUSTERED 
(
	[document1_id] ASC,
	[selected_topics_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_Subject Room]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_Subject Room](
	[subject_room_id] [int] NOT NULL,
	[document1_id] [int] NOT NULL,
	[quantity] [int] NULL,
	[description] [nvarchar](max) NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_Subject Room] PRIMARY KEY CLUSTERED 
(
	[subject_room_id] ASC,
	[document1_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_TeachingEquipment]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_TeachingEquipment](
	[document1_id] [int] NOT NULL,
	[teaching_equipment_id] [int] NOT NULL,
	[quantity] [int] NULL,
	[note] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_TeachingEquipment] PRIMARY KEY CLUSTERED 
(
	[document1_id] ASC,
	[teaching_equipment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document2_Grade]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document2_Grade](
	[document2_id] [int] NOT NULL,
	[grade_id] [int] NOT NULL,
	[title_name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[slot] [int] NULL,
	[time] [date] NULL,
	[place] [nvarchar](max) NULL,
	[host_by] [int] NULL,
	[collaborate_with] [nvarchar](max) NULL,
	[condition] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document2_Grade] PRIMARY KEY CLUSTERED 
(
	[document2_id] ASC,
	[grade_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document3_CurriculumDistribution]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document3_CurriculumDistribution](
	[document3_id] [int] NOT NULL,
	[curriculum_id] [int] NOT NULL,
	[equipment_id] [int] NOT NULL,
	[subject_room_name] [nvarchar](max) NULL,
	[slot] [int] NULL,
	[time] [date] NULL,
 CONSTRAINT [PK_Document3_CurriculumDistribution] PRIMARY KEY CLUSTERED 
(
	[document3_id] ASC,
	[curriculum_id] ASC,
	[equipment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document3_SelectedTopics]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document3_SelectedTopics](
	[document3_id] [int] NOT NULL,
	[selectedTopics_id] [int] NOT NULL,
	[equipment_id] [int] NOT NULL,
	[subject_room_name] [nvarchar](max) NULL,
	[slot] [int] NULL,
	[time] [date] NULL,
 CONSTRAINT [PK_Document3_SelectedTopics] PRIMARY KEY CLUSTERED 
(
	[document3_id] ASC,
	[selectedTopics_id] ASC,
	[equipment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] NOT NULL,
	[user_id] [int] NULL,
	[content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Form Category]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hình thức thi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
	[total_student] [int] NULL,
	[total_student_selected_topics] [int] NULL,
 CONSTRAINT [PK_Khối Lớp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level Of Trainning]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level Of Trainning](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_LevelOfTrainning] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[id] [int] NOT NULL,
	[title_name] [nvarchar](max) NULL,
	[type] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[message] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodic Assessment]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodic Assessment](
	[testing_category_id] [int] NOT NULL,
	[form_category_id] [int] NOT NULL,
	[time] [int] NULL,
	[date] [date] NULL,
	[description] [nvarchar](max) NULL,
	[document1_id] [int] NOT NULL,
 CONSTRAINT [PK_Periodic Assessment] PRIMARY KEY CLUSTERED 
(
	[testing_category_id] ASC,
	[form_category_id] ASC,
	[document1_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professional Standards]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professional Standards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Professional Standards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](max) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[s3_file_metadata]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[s3_file_metadata](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[file_key] [nvarchar](200) NULL,
	[presigned_url] [nvarchar](250) NULL,
	[expiration_datetime] [datetime] NULL,
 CONSTRAINT [PK_s3_file_metadata] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scorm]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scorm](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[content] [varbinary](max) NULL,
	[category_id] [int] NOT NULL,
	[teaching_planner_id] [int] NOT NULL,
	[isAprrove] [bit] NULL,
	[status] [bit] NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Selected Topics]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Selected Topics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Chuyên đề / Bài Học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialized Department]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialized Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tổ chuyên Môn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Môn học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject Room]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Phòng Bộ Môn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teaching Equipment]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teaching Equipment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Thiết bị dậy học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teaching Planner]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teaching Planner](
	[user_id] [int] NULL,
	[class_id] [int] NULL,
	[subject_id] [int] NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_User - Lớp - Mon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Testing Category]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testing Category](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Loại Bài kiểm tra] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/18/2024 2:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](max) NULL,
	[last_name] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[full_name] [nvarchar](max) NULL,
	[photo] [varbinary](max) NULL,
	[address] [nvarchar](max) NULL,
	[gender] [bit] NULL,
	[place_of_birth] [nvarchar](max) NULL,
	[age] [int] NULL,
	[level_of_trainning_id] [int] NULL,
	[specialized_department_id] [int] NULL,
	[account_id] [int] NULL,
	[professional_standards_id] [int] NULL,
	[created_by] [nvarchar](max) NULL,
	[created_date] [date] NULL,
	[modified_by] [int] NULL,
	[modified_date] [date] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240306115137_Migration_v1', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240306115634_Migration_v2', N'6.0.27')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240306120535_Migration_v3', N'6.0.27')
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (15, N'dung', N'0hPRMzyYhb/9mUYubsZ8Ig==;Jx066FsZmoS1PsMxJnih0tR9quxwtWryKB+i4w69KK0=', 1, N'15', CAST(N'2023-04-06' AS Date), 1, NULL, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (16, N'nam anh', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'15', CAST(N'2023-04-06' AS Date), 2, NULL, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (17, N'dung', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'15', CAST(N'2023-04-06' AS Date), 3, NULL, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (18, N'an', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'15', CAST(N'2023-04-06' AS Date), 5, NULL, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (19, N'hung', N'ZyXnInHcq5BubJXlp4HZzQ==;ftOdV6yphY6pNTmm2wgozrp/uEvNFA9ThR+wIXzzg1g=', 1, N'ADMIN', CAST(N'2024-04-07' AS Date), 2, NULL, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (20, N'namanh12345', N'1kvz1mQJdpCiriNd+FY0BA==;Y0XyCnqLCh6XopBIrv8cYXKSJEjYNc4CmLJbvLNMRa8=', 1, N'ADMIN', CAST(N'2024-04-07' AS Date), 1, NULL, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (21, N'string', N'K7cdQX+mqbpQzzCfUkepLg==;iMLzDMMjJlA/v4XkWPf6mEYVGVdNoEmibqJjGaOrA0w=', 1, N'ADMIN', CAST(N'2024-04-15' AS Date), 1, NULL, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (22, N'namanhtest', N'liEg6313erBFFpsxhSTAEg==;foZD26uEzqlE9tQNPBNa9su+Wz14gPHsD6VZ1cr8vlU=', 1, N'ADMIN', CAST(N'2024-04-15' AS Date), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [name]) VALUES (1, N'.doc')
INSERT [dbo].[Category] ([Id], [name]) VALUES (2, N'.ppt')
INSERT [dbo].[Category] ([Id], [name]) VALUES (3, N'.pdf')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (1, N'6A1', 1)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (2, N'6A2', 1)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (3, N'6A3', 1)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (4, N'6A4', 1)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (5, N'6A5', 1)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (6, N'7A1', 2)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (7, N'7A2', 2)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (8, N'7A3', 2)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (9, N'7A4', 2)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (10, N'7A5', 2)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (11, N'8A1', 3)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (12, N'8A2', 3)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (13, N'8A3', 3)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (14, N'8A4', 3)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (15, N'8A5', 3)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (16, N'9A1', 4)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (17, N'9A2', 4)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (18, N'9A3', 4)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (19, N'9A4', 4)
INSERT [dbo].[Class] ([id], [name], [grade_ id]) VALUES (20, N'9A5', 4)
GO
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] ON 

INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (1, N'Thánh Gióng ')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (2, N'Sơn Tinh Thủy Tinh')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (3, N'3')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (4, N'4')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (6, N'6')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (7, N'777777')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (10, N'5')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (11, N'5')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (12, N'12')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (13, N'13')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (14, NULL)
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 1] ON 

INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (3, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC NGỮ VĂN, KHỐI LỚP 6', 2, 1, 9, NULL, 1, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (11, N'A', 2, 1, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 1] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 2] ON 

INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (1, N'Doc 1', 8, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (2, N'Doc 2', 9, 1, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 2] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 3] ON 

INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (1, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN
MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC NGỮ VĂN, LỚP 6A1', 3, 9, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 3] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 4] ON 

INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image]) VALUES (1, N'KeHoach1', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image]) VALUES (2, N'KeHoach2', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 4] OFF
GO
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 1, 10, N'string')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 2, 20, N'string')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 3, 30, N'string')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 4, 99, N'99')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 12, 12, N'12')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 13, 13, N'13')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 14, 50, N'string')
GO
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (3, 1, 2, N'2')
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (3, 2, 2, N'2')
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (3, 3, 3, N'3')
GO
INSERT [dbo].[Document1_Subject Room] ([subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (9, 3, 1, N'Mo ta 1 ', N'Ghi chu 1')
INSERT [dbo].[Document1_Subject Room] ([subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (10, 3, 1, N'Ma ta 2 ', N'Ghi Chu 2')
GO
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 3, 1, N'ghi chu 1', N'mo ta 1')
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 4, 1, N'ghi chu 2', N'ma ta 2')
GO
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (1, 1, N'1', N'1', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (1, 2, N'2', N'2', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (1, 3, N'3', N'3', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (1, 4, N'4', N'4', 4, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (2, 1, N'1', N'1', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (2, 2, N'2', N'2', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (2, 3, N'3', N'3', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (2, 4, N'4', N'4', 4, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Form Category] ON 

INSERT [dbo].[Form Category] ([id], [name]) VALUES (1, N'Tự Luận')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (2, N'Trắc Nghiệm')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (3, N'Tự Luận Kết Hợp Trắc Nghiệm')
SET IDENTITY_INSERT [dbo].[Form Category] OFF
GO
INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (1, N'6', 1000, 60)
INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (2, N'7', 1000, 70)
INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (3, N'8', 1000, 80)
INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (4, N'9', 1000, 90)
GO
SET IDENTITY_INSERT [dbo].[Level Of Trainning] ON 

INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (1, N'Junior College')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (2, N'Bachelor')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (3, N'Above Bachlor')
SET IDENTITY_INSERT [dbo].[Level Of Trainning] OFF
GO
SET IDENTITY_INSERT [dbo].[Professional Standards] ON 

INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (1, N'Excellent')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (2, N'Good')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (3, N'Pass')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (4, N'Not Pass')
SET IDENTITY_INSERT [dbo].[Professional Standards] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (1, N'Admin', 1)
INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (2, N'Teacher', 1)
INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (3, N'Leader', 1)
INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (5, N'Principle', 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[s3_file_metadata] ON 

INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (1, N'doc1/e09e8605-14cd-4318-9a48-b4f8bd756406.docx', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/e09e8605-14cd-4318-9a48-b4f8bd756406.docx?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741012&Signature=%2FYSQFYmmeQgvFdWM0x9Dgs99lbk%3D', CAST(N'2025-04-15T18:16:52.073' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (2, N'doc1/', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=mzHSdvHsALZ453cjcG85s8269rY%3D', CAST(N'2025-04-15T18:17:08.063' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (3, N'doc1/158624b6-102d-4e7f-9c9e-c1a6f708b0e5.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/158624b6-102d-4e7f-9c9e-c1a6f708b0e5.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=QbBo8h8sZEo1OJSyj9%2BoOhHRv8o%3D', CAST(N'2025-04-15T18:17:08.083' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (4, N'doc1/1712946874588_Screenshot 2024-03-28 184721.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/1712946874588_Screenshot%202024-03-28%20184721.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=arYQJ2Cj2AgxrZhJctCxF8rVWhM%3D', CAST(N'2025-04-15T18:17:08.093' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (5, N'doc1/1712947131312_Screenshot 2024-03-28 184721.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/1712947131312_Screenshot%202024-03-28%20184721.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=o8AZLgj4Pww43Lqhwj3D2f8%2B8Cg%3D', CAST(N'2025-04-15T18:17:08.100' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (6, N'doc1/1712947391761_Screenshot 2024-03-29 011546.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/1712947391761_Screenshot%202024-03-29%20011546.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=Bswc%2Bu9asDrzz7YOxTbp9uxnTb0%3D', CAST(N'2025-04-15T18:17:08.110' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (7, N'doc1/226d4bd4-256d-4306-aa7b-64ce50b3226c.pdf', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/226d4bd4-256d-4306-aa7b-64ce50b3226c.pdf?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=d9b7jpUzzzUQvVIUwz0fd9lAmKY%3D', CAST(N'2025-04-15T18:17:08.117' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (8, N'doc1/2a9ade3c-c97f-435c-a1b3-579bacb16317.pdf', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/2a9ade3c-c97f-435c-a1b3-579bacb16317.pdf?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=qWEGjfPGKzaky%2BLN7gCeLYpxstU%3D', CAST(N'2025-04-15T18:17:08.127' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (9, N'doc1/3017587f-d7eb-4dd7-82f7-29f218b00add.jpg', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/3017587f-d7eb-4dd7-82f7-29f218b00add.jpg?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=yMH0jyHtNp4Ub14Zah%2B30orVUSQ%3D', CAST(N'2025-04-15T18:17:08.133' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (10, N'doc1/41ec97ac-cbda-4bc8-b86d-010251ab15d0.pdf', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/41ec97ac-cbda-4bc8-b86d-010251ab15d0.pdf?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=RQFhsqx4cE4ZIiJ5j%2FkRqGcw65g%3D', CAST(N'2025-04-15T18:17:08.143' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (11, N'doc1/4207cf53-cc38-44e7-843f-c96c481f72a6.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/4207cf53-cc38-44e7-843f-c96c481f72a6.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=kBSB48PUmm%2BDzSArQqez8XMiwYU%3D', CAST(N'2025-04-15T18:17:08.150' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (12, N'doc1/9e5ada06-3bdc-4e98-beca-2d19380ce132.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/9e5ada06-3bdc-4e98-beca-2d19380ce132.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=Xi%2B42VnZVp9bNcrE%2FMKMOYcrhYs%3D', CAST(N'2025-04-15T18:17:08.160' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (13, N'doc1/Screenshot 2024-04-03 190306.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/Screenshot%202024-04-03%20190306.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=wAmL9mSyvoCyDyZKewULURCXTgI%3D', CAST(N'2025-04-15T18:17:08.167' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (14, N'doc1/a5dccd0e-af74-49a8-8011-6455b8bac2c5.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/a5dccd0e-af74-49a8-8011-6455b8bac2c5.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=qJThTVvaOi%2Bvf%2FuzNwJpMH8urFQ%3D', CAST(N'2025-04-15T18:17:08.173' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (15, N'doc1/bb264c76-9ab4-449d-95fa-86f107c5c452.png', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/bb264c76-9ab4-449d-95fa-86f107c5c452.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=r%2FyC%2Boe7HLR0sMgEEu6v25gkxic%3D', CAST(N'2025-04-15T18:17:08.183' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (16, N'doc1/eaee2563-8979-40e5-b7ae-1f3f65c689d7.docx', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc1/eaee2563-8979-40e5-b7ae-1f3f65c689d7.docx?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1744741028&Signature=LvO5x0O7wke8XodTLk3Nnl1W1To%3D', CAST(N'2025-04-15T18:17:08.200' AS DateTime))
SET IDENTITY_INSERT [dbo].[s3_file_metadata] OFF
GO
SET IDENTITY_INSERT [dbo].[Selected Topics] ON 

INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (1, N'Tiếng Anh ')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (2, N'Chân trời sáng tạo')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (3, N'Cánh Diều')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (4, N'Kết nối Tri Thức với cuộc sống')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (5, N'Tiếng Việt')
SET IDENTITY_INSERT [dbo].[Selected Topics] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialized Department] ON 

INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (1, N'Math')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (2, N'Engineering')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (3, N'Computer Science')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (4, N'Mathematics')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (5, N'Science ')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (6, N'Visual Arts')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (7, N'Media Arts')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (8, N'Performing Arts ')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (9, N'World Languages')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (10, N'Business')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (11, N'Vocational ')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (12, N'Special Education ')
SET IDENTITY_INSERT [dbo].[Specialized Department] OFF
GO
INSERT [dbo].[Subject] ([id], [name]) VALUES (1, N'Toán')
INSERT [dbo].[Subject] ([id], [name]) VALUES (2, N'Ngữ Văn')
INSERT [dbo].[Subject] ([id], [name]) VALUES (3, N'Tiếng Anh')
INSERT [dbo].[Subject] ([id], [name]) VALUES (4, N'Hóa Học')
INSERT [dbo].[Subject] ([id], [name]) VALUES (5, N'Sinh Học')
INSERT [dbo].[Subject] ([id], [name]) VALUES (6, N'Lịch Sử')
INSERT [dbo].[Subject] ([id], [name]) VALUES (7, N'Địa Lý')
INSERT [dbo].[Subject] ([id], [name]) VALUES (8, N'Giáo Dục Công Dân')
INSERT [dbo].[Subject] ([id], [name]) VALUES (9, N'Vật Lý')
INSERT [dbo].[Subject] ([id], [name]) VALUES (10, N'Công Nghệ')
INSERT [dbo].[Subject] ([id], [name]) VALUES (11, N'Tin Học')
INSERT [dbo].[Subject] ([id], [name]) VALUES (12, N'Giáo Dục Thể Chất')
INSERT [dbo].[Subject] ([id], [name]) VALUES (13, N'Nghệ Thuật')
GO
SET IDENTITY_INSERT [dbo].[Subject Room] ON 

INSERT [dbo].[Subject Room] ([id], [name]) VALUES (1, N'Toán học')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (2, N'Vật lý')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (3, N'Hóa học')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (4, N'Sinh học')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (5, N'Tin học')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (6, N'Ngoại ngữ')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (7, N'Âm nhạc')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (8, N'Thể dục')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (9, N'Thư viện')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (10, N'Phòng đọc sách')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (11, N'Phòng y tế')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (12, N'Phòng tâm lý học đường')
SET IDENTITY_INSERT [dbo].[Subject Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Teaching Equipment] ON 

INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (1, N'bảng đen')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (2, N'bảng trắng')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (3, N'máy chiếu')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (4, N'máy tính')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (5, N'bút')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (6, N'phấn')
SET IDENTITY_INSERT [dbo].[Teaching Equipment] OFF
GO
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (1, N'Giữa Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (2, N'Cuối Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (3, N'Giữa Học Kì 2')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (14, N'Cuối Học Kì 2')
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (8, N'dung', N'le', N'leenguyenquangdung1@gmail.com', N'dung le', NULL, NULL, 1, NULL, 20, 1, 1, 15, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (9, N'nam ', N'anh', N'damhuynamanh@gmail.com', N'nam anh', NULL, NULL, 1, NULL, 21, 1, 2, 16, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (10, N'nguyen', N'hoang', N'thangmubietnhin@gmail.com', N'nguyen hoang', NULL, NULL, 1, NULL, 22, 1, 3, 17, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (11, N'an', N'an', N'an@gmail.com', N'an an', NULL, NULL, 1, NULL, 23, 1, 4, 18, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (12, N'Nam', N'Anh', N'namanh@gmail.com', N'Nam Anh', NULL, NULL, 1, NULL, 23, 1, 4, 22, 1, NULL, CAST(N'2024-04-15' AS Date), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role1] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role1]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Grade] FOREIGN KEY([grade_ id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Grade]
GO
ALTER TABLE [dbo].[Document 1]  WITH CHECK ADD  CONSTRAINT [FK_Document 1_Grade] FOREIGN KEY([grade_id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Document 1] CHECK CONSTRAINT [FK_Document 1_Grade]
GO
ALTER TABLE [dbo].[Document 1]  WITH CHECK ADD  CONSTRAINT [FK_Document 1_Subject] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Document 1] CHECK CONSTRAINT [FK_Document 1_Subject]
GO
ALTER TABLE [dbo].[Document 1]  WITH CHECK ADD  CONSTRAINT [FK_Phu Luc 1_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 1] CHECK CONSTRAINT [FK_Phu Luc 1_User]
GO
ALTER TABLE [dbo].[Document 2]  WITH CHECK ADD  CONSTRAINT [FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 2] CHECK CONSTRAINT [FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User]
GO
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Document 3_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Document 3_Document 1]
GO
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Document 3_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Document 3_User]
GO
ALTER TABLE [dbo].[Document 4]  WITH CHECK ADD  CONSTRAINT [FK_Document 4_Teaching Planner1] FOREIGN KEY([teaching_planner_id])
REFERENCES [dbo].[Teaching Planner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document 4] CHECK CONSTRAINT [FK_Document 4_Teaching Planner1]
GO
ALTER TABLE [dbo].[Document 5]  WITH CHECK ADD  CONSTRAINT [FK_Document 5_Document 41] FOREIGN KEY([document4_id])
REFERENCES [dbo].[Document 4] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document 5] CHECK CONSTRAINT [FK_Document 5_Document 41]
GO
ALTER TABLE [dbo].[Document 5]  WITH CHECK ADD  CONSTRAINT [FK_Document 5_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 5] CHECK CONSTRAINT [FK_Document 5_User]
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document1_CurriculumDistribution_Curriculum Distribution] FOREIGN KEY([curriculum_id])
REFERENCES [dbo].[Curriculum Distribution] ([id])
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution] CHECK CONSTRAINT [FK_Document1_CurriculumDistribution_Curriculum Distribution]
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document1_CurriculumDistribution_Document 11] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution] CHECK CONSTRAINT [FK_Document1_CurriculumDistribution_Document 11]
GO
ALTER TABLE [dbo].[Document1_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document1_SelectedTopics_Document 11] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document1_SelectedTopics] CHECK CONSTRAINT [FK_Document1_SelectedTopics_Document 11]
GO
ALTER TABLE [dbo].[Document1_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document1_SelectedTopics_Selected Topics] FOREIGN KEY([selected_topics_id])
REFERENCES [dbo].[Selected Topics] ([id])
GO
ALTER TABLE [dbo].[Document1_SelectedTopics] CHECK CONSTRAINT [FK_Document1_SelectedTopics_Selected Topics]
GO
ALTER TABLE [dbo].[Document1_Subject Room]  WITH CHECK ADD  CONSTRAINT [FK_Document1_Subject Room_Document 11] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document1_Subject Room] CHECK CONSTRAINT [FK_Document1_Subject Room_Document 11]
GO
ALTER TABLE [dbo].[Document1_Subject Room]  WITH CHECK ADD  CONSTRAINT [FK_Document1_Subject Room_Subject Room] FOREIGN KEY([subject_room_id])
REFERENCES [dbo].[Subject Room] ([id])
GO
ALTER TABLE [dbo].[Document1_Subject Room] CHECK CONSTRAINT [FK_Document1_Subject Room_Subject Room]
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment]  WITH CHECK ADD  CONSTRAINT [FK_Document1_TeachingEquipment_Document 11] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment] CHECK CONSTRAINT [FK_Document1_TeachingEquipment_Document 11]
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment]  WITH CHECK ADD  CONSTRAINT [FK_Document1_TeachingEquipment_Teaching Equipment] FOREIGN KEY([teaching_equipment_id])
REFERENCES [dbo].[Teaching Equipment] ([id])
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment] CHECK CONSTRAINT [FK_Document1_TeachingEquipment_Teaching Equipment]
GO
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_Document2_Grade_Document 21] FOREIGN KEY([document2_id])
REFERENCES [dbo].[Document 2] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_Document2_Grade_Document 21]
GO
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_Document2_Grade_Grade] FOREIGN KEY([grade_id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_Document2_Grade_Grade]
GO
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_Document2_Grade_User] FOREIGN KEY([host_by])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_Document2_Grade_User]
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document3_CurriculumDistribution_Curriculum Distribution] FOREIGN KEY([curriculum_id])
REFERENCES [dbo].[Curriculum Distribution] ([id])
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution] CHECK CONSTRAINT [FK_Document3_CurriculumDistribution_Curriculum Distribution]
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document3_CurriculumDistribution_Document 31] FOREIGN KEY([document3_id])
REFERENCES [dbo].[Document 3] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution] CHECK CONSTRAINT [FK_Document3_CurriculumDistribution_Document 31]
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document3_CurriculumDistribution_Teaching Equipment] FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Teaching Equipment] ([id])
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution] CHECK CONSTRAINT [FK_Document3_CurriculumDistribution_Teaching Equipment]
GO
ALTER TABLE [dbo].[Document3_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document3_SelectedTopics_Document 31] FOREIGN KEY([document3_id])
REFERENCES [dbo].[Document 3] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document3_SelectedTopics] CHECK CONSTRAINT [FK_Document3_SelectedTopics_Document 31]
GO
ALTER TABLE [dbo].[Document3_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document3_SelectedTopics_Selected Topics] FOREIGN KEY([selectedTopics_id])
REFERENCES [dbo].[Selected Topics] ([id])
GO
ALTER TABLE [dbo].[Document3_SelectedTopics] CHECK CONSTRAINT [FK_Document3_SelectedTopics_Selected Topics]
GO
ALTER TABLE [dbo].[Document3_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document3_SelectedTopics_Teaching Equipment] FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Teaching Equipment] ([id])
GO
ALTER TABLE [dbo].[Document3_SelectedTopics] CHECK CONSTRAINT [FK_Document3_SelectedTopics_Teaching Equipment]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User]
GO
ALTER TABLE [dbo].[Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Periodic Assessment_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Periodic Assessment] CHECK CONSTRAINT [FK_Periodic Assessment_Document 1]
GO
ALTER TABLE [dbo].[Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Periodic Assessment_Form Category] FOREIGN KEY([form_category_id])
REFERENCES [dbo].[Form Category] ([id])
GO
ALTER TABLE [dbo].[Periodic Assessment] CHECK CONSTRAINT [FK_Periodic Assessment_Form Category]
GO
ALTER TABLE [dbo].[Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Periodic Assessment_Testing Category] FOREIGN KEY([testing_category_id])
REFERENCES [dbo].[Testing Category] ([id])
GO
ALTER TABLE [dbo].[Periodic Assessment] CHECK CONSTRAINT [FK_Periodic Assessment_Testing Category]
GO
ALTER TABLE [dbo].[Scorm]  WITH CHECK ADD  CONSTRAINT [FK_Doc_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Scorm] CHECK CONSTRAINT [FK_Doc_Category]
GO
ALTER TABLE [dbo].[Scorm]  WITH CHECK ADD  CONSTRAINT [FK_Scorm_Teaching Planner] FOREIGN KEY([teaching_planner_id])
REFERENCES [dbo].[Teaching Planner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Scorm] CHECK CONSTRAINT [FK_Scorm_Teaching Planner]
GO
ALTER TABLE [dbo].[Teaching Planner]  WITH CHECK ADD  CONSTRAINT [FK_Teaching Planner_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Teaching Planner] CHECK CONSTRAINT [FK_Teaching Planner_Class]
GO
ALTER TABLE [dbo].[Teaching Planner]  WITH CHECK ADD  CONSTRAINT [FK_Teaching Planner_Subject] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Teaching Planner] CHECK CONSTRAINT [FK_Teaching Planner_Subject]
GO
ALTER TABLE [dbo].[Teaching Planner]  WITH CHECK ADD  CONSTRAINT [FK_Teaching Planner_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Teaching Planner] CHECK CONSTRAINT [FK_Teaching Planner_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Account] FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([account_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Account]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Level Of Trainning] FOREIGN KEY([level_of_trainning_id])
REFERENCES [dbo].[Level Of Trainning] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Level Of Trainning]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Professional Standards] FOREIGN KEY([professional_standards_id])
REFERENCES [dbo].[Professional Standards] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Professional Standards]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Specialized Department] FOREIGN KEY([specialized_department_id])
REFERENCES [dbo].[Specialized Department] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Specialized Department]
GO
USE [master]
GO
ALTER DATABASE [MLD_Database] SET  READ_WRITE 
GO
