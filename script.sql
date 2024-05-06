USE [master]
GO
/****** Object:  Database [MLD_Database_2]    Script Date: 5/6/2024 11:40:45 AM ******/
CREATE DATABASE [MLD_Database_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MLD_Database_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MLD_Database_2.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MLD_Database_2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MLD_Database_2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MLD_Database_2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MLD_Database_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MLD_Database_2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MLD_Database_2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MLD_Database_2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MLD_Database_2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MLD_Database_2] SET ARITHABORT OFF 
GO
ALTER DATABASE [MLD_Database_2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MLD_Database_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MLD_Database_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MLD_Database_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MLD_Database_2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MLD_Database_2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MLD_Database_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MLD_Database_2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MLD_Database_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MLD_Database_2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MLD_Database_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MLD_Database_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MLD_Database_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MLD_Database_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MLD_Database_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MLD_Database_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MLD_Database_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MLD_Database_2] SET RECOVERY FULL 
GO
ALTER DATABASE [MLD_Database_2] SET  MULTI_USER 
GO
ALTER DATABASE [MLD_Database_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MLD_Database_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MLD_Database_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MLD_Database_2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MLD_Database_2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MLD_Database_2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MLD_Database_2', N'ON'
GO
ALTER DATABASE [MLD_Database_2] SET QUERY_STORE = ON
GO
ALTER DATABASE [MLD_Database_2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MLD_Database_2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[active] [bit] NULL,
	[created_by] [int] NULL,
	[created_date] [date] NULL,
	[role_id] [int] NULL,
	[login_attempt] [int] NULL,
	[login_last] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[total_student] [int] NULL,
	[total_student_selected_topics] [int] NULL,
	[grade_ id] [int] NOT NULL,
 CONSTRAINT [PK_Lớp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curriculum Distribution]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Document 1]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[subject_id] [int] NOT NULL,
	[grade_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[note] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[approve_by] [int] NULL,
	[isApprove] [int] NULL,
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
/****** Object:  Table [dbo].[Document 2]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[user_id] [int] NOT NULL,
	[status] [bit] NULL,
	[approve_by] [int] NULL,
	[isApprove] [int] NULL,
	[created_date] [date] NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 3]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 3](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[document1_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[claas_name] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[isApprove] [int] NULL,
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
/****** Object:  Table [dbo].[Document 4]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 4](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[teaching_planner_id] [int] NOT NULL,
	[status] [bit] NULL,
	[created_date] [date] NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
	[isApprove] [int] NULL,
 CONSTRAINT [PK_Phu Luc 4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 5]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 5](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[document4_id] [int] NOT NULL,
	[user_id] [int] NULL,
	[slot] [int] NULL,
	[date] [date] NULL,
	[total] [int] NULL,
	[created_date] [date] NULL,
	[link_file] [nvarchar](max) NULL,
	[link_image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Phu Luc 5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_CurriculumDistribution]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_CurriculumDistribution](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document1_id] [int] NOT NULL,
	[curriculum_id] [int] NULL,
	[slot] [int] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_CurriculumDistribution_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_Periodic Assessment]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_Periodic Assessment](
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
/****** Object:  Table [dbo].[Document1_SelectedTopics]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_SelectedTopics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document1_id] [int] NOT NULL,
	[selected_topics_id] [int] NULL,
	[slot] [int] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_SelectedTopics_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_Subject Room]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_Subject Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject_room_id] [int] NULL,
	[document1_id] [int] NOT NULL,
	[quantity] [int] NULL,
	[description] [nvarchar](max) NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_Subject Room] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_TeachingEquipment]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_TeachingEquipment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document1_id] [int] NOT NULL,
	[teaching_equipment_id] [int] NULL,
	[quantity] [int] NULL,
	[note] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Document1_TeachingEquipment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document2_Grade]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document2_Grade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document2_id] [int] NULL,
	[grade_id] [int] NULL,
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
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document3_CurriculumDistribution]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document3_CurriculumDistribution](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document3_id] [int] NOT NULL,
	[curriculum_id] [int] NULL,
	[equipment_id] [int] NULL,
	[subject_room_id] [int] NULL,
	[slot] [int] NULL,
	[time] [date] NULL,
 CONSTRAINT [PK_Document3_CurriculumDistribution_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document3_SelectedTopics]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document3_SelectedTopics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document3_id] [int] NOT NULL,
	[selectedTopics_id] [int] NULL,
	[equipment_id] [int] NULL,
	[subject_room_id] [int] NULL,
	[slot] [int] NULL,
	[time] [date] NULL,
 CONSTRAINT [PK_Document3_SelectedTopics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluate]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document5_id] [int] NOT NULL,
	[evaluate_1_1] [int] NULL,
	[evaluate_1_2] [int] NULL,
	[evaluate_1_3] [int] NULL,
	[evaluate_1_4] [int] NULL,
	[evaluate_2_1] [int] NULL,
	[evaluate_2_2] [int] NULL,
	[evaluate_2_3] [int] NULL,
	[evaluate_2_4] [int] NULL,
	[evaluate_3_1] [int] NULL,
	[evaluate_3_2] [int] NULL,
	[evaluate_3_3] [int] NULL,
	[evaluate_3_4] [int] NULL,
 CONSTRAINT [PK_Evaluate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Form Category]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Grade]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Khối Lớp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IsApprove]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IsApprove](
	[id] [int] NOT NULL,
	[name] [nchar](10) NULL,
 CONSTRAINT [PK_IsApprove] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level Of Trainning]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Notification]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title_name] [nvarchar](max) NULL,
	[sent_by] [int] NOT NULL,
	[receive_by] [int] NULL,
	[message] [nvarchar](max) NULL,
	[doc_type] [int] NULL,
	[docId] [int] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professional Standards]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Report]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[message] [nvarchar](max) NULL,
	[doc_type] [int] NULL,
	[doc_id] [int] NULL,
	[description] [nvarchar](max) NULL,
	[read] [bit] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[s3_file_metadata]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[s3_file_metadata](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[file_key] [nvarchar](max) NULL,
	[presigned_url] [nvarchar](max) NULL,
	[expiration_datetime] [datetime] NULL,
 CONSTRAINT [PK_s3_file_metadata] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scorm]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scorm](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[content] [varbinary](max) NULL,
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
/****** Object:  Table [dbo].[Selected Topics]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Specialized Department]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[department_id] [int] NULL,
 CONSTRAINT [PK_Môn học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject Room]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Teaching Equipment]    Script Date: 5/6/2024 11:40:45 AM ******/
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
/****** Object:  Table [dbo].[Teaching Planner]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teaching Planner](
	[user_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_User - Lớp - Mon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Testing Category]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testing Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Loại Bài kiểm tra] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[first_name] [nvarchar](max) NULL,
	[last_name] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[photo] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[gender] [bit] NULL,
	[date_of_birth] [date] NULL,
	[age] [int] NULL,
	[signature] [nvarchar](max) NULL,
	[level_of_trainning_id] [int] NULL,
	[account_id] [int] NOT NULL,
	[professional_standards_id] [int] NULL,
	[department_id] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (1, N'string123', N'cDCCWxF7qmSvl8RIoYESBg==;U6YyvnBTS8dacXmz8SDKBPxUxx3oqnwEuHfyJSD4u6c=', 1, 1, CAST(N'2024-04-28' AS Date), 1, 1, CAST(N'2024-04-28T23:55:15.417' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (2, N'dung2', N'NQKvnjJPETS/enzPXpz9FA==;dCopKI+pZaVTEvL6qQJflTKDqSwO+mYfu5lg1CW0eFA=', 1, 1, CAST(N'2024-04-28' AS Date), 1, 1, CAST(N'2024-04-28T23:39:57.783' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (3, N'teacher1', N'ryAt5YQlNbtECzsQtKuBFg==;2xVX1XoxtFh0lZjuuVKXOJgTxAiVG2oHmy7mJAcVyBg=', 1, 1, CAST(N'2024-04-30' AS Date), 2, 1, CAST(N'2024-04-30T23:40:48.840' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (4, N'leader1', N'+rA04jdg0kW/x+P3YHuLCQ==;/CLXfaiGfe3zyJFpMRF9qJn4YYnco73Xh6gxJwi5CuY=', 1, 1, CAST(N'2024-05-01' AS Date), 3, 1, CAST(N'2024-05-01T18:05:55.780' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (5, N'principal', N'PtKjQxZHbUdRJ2IqZUjqdw==;cM2ZW/GEyj2qHSF7MTJXKKiQYkMq+F8TcZAzPmQW4ok=', 1, 1, CAST(N'2024-05-01' AS Date), 4, 1, CAST(N'2024-05-01T18:13:04.557' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (6, N'teacher2', N'ryAt5YQlNbtECzsQtKuBFg==;2xVX1XoxtFh0lZjuuVKXOJgTxAiVG2oHmy7mJAcVyBg=', 1, 1, CAST(N'2024-04-30' AS Date), 2, 1, CAST(N'2024-05-01T18:13:04.557' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (7, N'teacher3', NULL, NULL, NULL, NULL, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] ON 

INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (1, N'Phan Phoi 1')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (2, N'Phan Phoi 2')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (3, N'Phan Phoi 3')
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 1] ON 

INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (2, N'Ke Hoach 2', 1, 6, 4, NULL, 1, 4, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (3, N'Ke Hoach 3', 1, 6, 4, NULL, 1, 4, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 1] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 2] ON 

INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (1, N'Ke Hoach 1 ', 4, 1, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (2, N'Ke Hoach 2', 4, 1, NULL, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 2] OFF
GO
SET IDENTITY_INSERT [dbo].[Document1_CurriculumDistribution] ON 

INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (1, 2, 1, 1, N'1')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (2, 2, 2, 1, N'1')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (3, 2, 3, 1, N'1')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (4, 3, 1, 1, N'1')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (5, 3, 2, 1, N'1')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (6, 3, 3, 1, N'1')
SET IDENTITY_INSERT [dbo].[Document1_CurriculumDistribution] OFF
GO
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (1, 1, 1, NULL, NULL, 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (1, 1, 1, NULL, NULL, 3)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (2, 1, 1, NULL, NULL, 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (2, 1, 1, NULL, NULL, 3)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (3, 1, 1, NULL, NULL, 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (3, 1, 1, NULL, NULL, 3)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (4, 1, 1, NULL, NULL, 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (4, 1, 1, NULL, NULL, 3)
GO
SET IDENTITY_INSERT [dbo].[Document1_SelectedTopics] ON 

INSERT [dbo].[Document1_SelectedTopics] ([id], [document1_id], [selected_topics_id], [slot], [description]) VALUES (1, 2, 1, 1, N'1')
INSERT [dbo].[Document1_SelectedTopics] ([id], [document1_id], [selected_topics_id], [slot], [description]) VALUES (2, 2, 2, 1, N'1')
INSERT [dbo].[Document1_SelectedTopics] ([id], [document1_id], [selected_topics_id], [slot], [description]) VALUES (3, 2, 3, 1, N'1')
INSERT [dbo].[Document1_SelectedTopics] ([id], [document1_id], [selected_topics_id], [slot], [description]) VALUES (4, 3, 2, 1, N'1')
INSERT [dbo].[Document1_SelectedTopics] ([id], [document1_id], [selected_topics_id], [slot], [description]) VALUES (5, 3, 3, 1, N'1')
SET IDENTITY_INSERT [dbo].[Document1_SelectedTopics] OFF
GO
SET IDENTITY_INSERT [dbo].[Document1_Subject Room] ON 

INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (1, 1, 2, 1, N'1', N'1')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (2, 2, 2, 1, N'1', N'1')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (3, 3, 2, 1, N'1', N'1')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (4, 2, 3, 1, N'1', N'1')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (5, 3, 3, 1, N'1', N'1')
SET IDENTITY_INSERT [dbo].[Document1_Subject Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Document1_TeachingEquipment] ON 

INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (1, 2, 1, 1, N'1', N'1')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (2, 2, 2, 1, N'1', N'1')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 2, 3, 1, N'1', N'1')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (4, 3, 2, 1, N'1', N'1')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (5, 3, 3, 1, N'1', N'1')
SET IDENTITY_INSERT [dbo].[Document1_TeachingEquipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Document2_Grade] ON 

INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (1, 1, 6, N'Ke Hoach 1', N'1', 1, NULL, NULL, 1, N'1', N'1')
SET IDENTITY_INSERT [dbo].[Document2_Grade] OFF
GO
SET IDENTITY_INSERT [dbo].[Form Category] ON 

INSERT [dbo].[Form Category] ([id], [name]) VALUES (1, N'Tự Luận')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (2, N'Trắc Nghiệm ')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (3, N'Tự Luận & Trắc Nghiệm')
SET IDENTITY_INSERT [dbo].[Form Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([id], [name]) VALUES (6, N'6')
INSERT [dbo].[Grade] ([id], [name]) VALUES (7, N'7')
INSERT [dbo].[Grade] ([id], [name]) VALUES (8, N'8')
INSERT [dbo].[Grade] ([id], [name]) VALUES (9, N'9')
SET IDENTITY_INSERT [dbo].[Grade] OFF
GO
INSERT [dbo].[IsApprove] ([id], [name]) VALUES (1, N'Draft     ')
INSERT [dbo].[IsApprove] ([id], [name]) VALUES (2, N'Review    ')
INSERT [dbo].[IsApprove] ([id], [name]) VALUES (3, N'Approve   ')
INSERT [dbo].[IsApprove] ([id], [name]) VALUES (4, N'Refuse    ')
GO
SET IDENTITY_INSERT [dbo].[Level Of Trainning] ON 

INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (1, N'Cao Đẳng')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (2, N'Đại Học')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (3, N'Trên Đại Học')
SET IDENTITY_INSERT [dbo].[Level Of Trainning] OFF
GO
SET IDENTITY_INSERT [dbo].[Professional Standards] ON 

INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (1, N'Chưa Đạt')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (2, N'Đạt')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (3, N'Khá')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (4, N'Tốt')
SET IDENTITY_INSERT [dbo].[Professional Standards] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (2, N'Teacher')
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (3, N'Leader')
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (4, N'Principal')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Selected Topics] ON 

INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (1, N'Chuyen De 1')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (2, N'Chuyen De 2')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (3, N'Chuyen De 3')
SET IDENTITY_INSERT [dbo].[Selected Topics] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialized Department] ON 

INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (1, N'Toan')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (2, N'Van')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (3, N'Anh')
SET IDENTITY_INSERT [dbo].[Specialized Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (1, N'Toán ', NULL)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (2, N'Ly', NULL)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (3, N'Hoa', NULL)
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject Room] ON 

INSERT [dbo].[Subject Room] ([id], [name]) VALUES (1, N'Phong 1')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (2, N'Phong 2')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (3, N'Phong 3')
SET IDENTITY_INSERT [dbo].[Subject Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Teaching Equipment] ON 

INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (1, N'Thiet Bi 1')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (2, N'Thiet Bi 2')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (3, N'Thiet Bi 3')
SET IDENTITY_INSERT [dbo].[Teaching Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Testing Category] ON 

INSERT [dbo].[Testing Category] ([id], [name]) VALUES (1, N'Giữa Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (2, N'Cuối Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (3, N'Giữa Học Kì 2')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (4, N'Cuối Học Kì 2')
SET IDENTITY_INSERT [dbo].[Testing Category] OFF
GO
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (1, N'Dung', N'Le', N'leenguyenquangdung1@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (3, N'teacher1', N'teacher1', N'teacher1@gmail.com', N'string', N'HaNoi', 1, CAST(N'2024-04-30' AS Date), 20, NULL, 3, 3, 4, NULL)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (4, N'leader1', N'leader1', N'leader1@gmail.com', N'string ', N'HCM', 1, CAST(N'2024-04-30' AS Date), 30, NULL, 3, 4, 4, NULL)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (5, N'principle1', N'principle1', N'principle1@gmail.com', N'string', N'DaNang', 0, CAST(N'2024-04-30' AS Date), 50, NULL, 3, 5, 4, NULL)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (6, N'teacher2', N'teacher2', N'teacher2@gmail.com', N'string', N'HaNoi', 1, CAST(N'2024-04-30' AS Date), 20, NULL, 3, 6, 4, NULL)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (7, N'leader2', N'leader2', N'leader2@gmail.com', NULL, N'HaNoi', 1, NULL, 20, NULL, 3, 7, 4, NULL)
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
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
ALTER TABLE [dbo].[Document 1]  WITH CHECK ADD  CONSTRAINT [FK_Document 1_IsApprove] FOREIGN KEY([isApprove])
REFERENCES [dbo].[IsApprove] ([id])
GO
ALTER TABLE [dbo].[Document 1] CHECK CONSTRAINT [FK_Document 1_IsApprove]
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
ALTER TABLE [dbo].[Document 2]  WITH CHECK ADD  CONSTRAINT [FK_Document 2_IsApprove] FOREIGN KEY([isApprove])
REFERENCES [dbo].[IsApprove] ([id])
GO
ALTER TABLE [dbo].[Document 2] CHECK CONSTRAINT [FK_Document 2_IsApprove]
GO
ALTER TABLE [dbo].[Document 2]  WITH CHECK ADD  CONSTRAINT [FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 2] CHECK CONSTRAINT [FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User]
GO
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Document 3_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Document 3_Document 1]
GO
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Document 3_IsApprove] FOREIGN KEY([isApprove])
REFERENCES [dbo].[IsApprove] ([id])
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Document 3_IsApprove]
GO
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Document 3_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Document 3_User]
GO
ALTER TABLE [dbo].[Document 4]  WITH CHECK ADD  CONSTRAINT [FK_Document 4_IsApprove] FOREIGN KEY([isApprove])
REFERENCES [dbo].[IsApprove] ([id])
GO
ALTER TABLE [dbo].[Document 4] CHECK CONSTRAINT [FK_Document 4_IsApprove]
GO
ALTER TABLE [dbo].[Document 4]  WITH CHECK ADD  CONSTRAINT [FK_Document 4_Teaching Planner] FOREIGN KEY([teaching_planner_id])
REFERENCES [dbo].[Teaching Planner] ([Id])
GO
ALTER TABLE [dbo].[Document 4] CHECK CONSTRAINT [FK_Document 4_Teaching Planner]
GO
ALTER TABLE [dbo].[Document 5]  WITH CHECK ADD  CONSTRAINT [FK_Document 5_Document 4] FOREIGN KEY([document4_id])
REFERENCES [dbo].[Document 4] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document 5] CHECK CONSTRAINT [FK_Document 5_Document 4]
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
ALTER TABLE [dbo].[Document1_Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Document1_Periodic Assessment_Form Category] FOREIGN KEY([form_category_id])
REFERENCES [dbo].[Form Category] ([id])
GO
ALTER TABLE [dbo].[Document1_Periodic Assessment] CHECK CONSTRAINT [FK_Document1_Periodic Assessment_Form Category]
GO
ALTER TABLE [dbo].[Document1_Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Document1_Periodic Assessment_Testing Category] FOREIGN KEY([testing_category_id])
REFERENCES [dbo].[Testing Category] ([id])
GO
ALTER TABLE [dbo].[Document1_Periodic Assessment] CHECK CONSTRAINT [FK_Document1_Periodic Assessment_Testing Category]
GO
ALTER TABLE [dbo].[Document1_Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Periodic Assessment_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document1_Periodic Assessment] CHECK CONSTRAINT [FK_Periodic Assessment_Document 1]
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
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_Document2_Grade_Document 2] FOREIGN KEY([document2_id])
REFERENCES [dbo].[Document 2] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_Document2_Grade_Document 2]
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
ALTER TABLE [dbo].[Document3_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document3_CurriculumDistribution_Document 3] FOREIGN KEY([document3_id])
REFERENCES [dbo].[Document 3] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution] CHECK CONSTRAINT [FK_Document3_CurriculumDistribution_Document 3]
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document3_CurriculumDistribution_Subject Room] FOREIGN KEY([subject_room_id])
REFERENCES [dbo].[Subject Room] ([id])
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution] CHECK CONSTRAINT [FK_Document3_CurriculumDistribution_Subject Room]
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document3_CurriculumDistribution_Teaching Equipment] FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Teaching Equipment] ([id])
GO
ALTER TABLE [dbo].[Document3_CurriculumDistribution] CHECK CONSTRAINT [FK_Document3_CurriculumDistribution_Teaching Equipment]
GO
ALTER TABLE [dbo].[Document3_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document3_SelectedTopics_Document 3] FOREIGN KEY([document3_id])
REFERENCES [dbo].[Document 3] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document3_SelectedTopics] CHECK CONSTRAINT [FK_Document3_SelectedTopics_Document 3]
GO
ALTER TABLE [dbo].[Document3_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document3_SelectedTopics_Selected Topics] FOREIGN KEY([selectedTopics_id])
REFERENCES [dbo].[Selected Topics] ([id])
GO
ALTER TABLE [dbo].[Document3_SelectedTopics] CHECK CONSTRAINT [FK_Document3_SelectedTopics_Selected Topics]
GO
ALTER TABLE [dbo].[Document3_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document3_SelectedTopics_Subject Room] FOREIGN KEY([subject_room_id])
REFERENCES [dbo].[Subject Room] ([id])
GO
ALTER TABLE [dbo].[Document3_SelectedTopics] CHECK CONSTRAINT [FK_Document3_SelectedTopics_Subject Room]
GO
ALTER TABLE [dbo].[Document3_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document3_SelectedTopics_Teaching Equipment] FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Teaching Equipment] ([id])
GO
ALTER TABLE [dbo].[Document3_SelectedTopics] CHECK CONSTRAINT [FK_Document3_SelectedTopics_Teaching Equipment]
GO
ALTER TABLE [dbo].[Evaluate]  WITH CHECK ADD  CONSTRAINT [FK_Evaluate_Document 5] FOREIGN KEY([document5_id])
REFERENCES [dbo].[Document 5] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluate] CHECK CONSTRAINT [FK_Evaluate_Document 5]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User] FOREIGN KEY([sent_by])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_User] FOREIGN KEY([id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_User]
GO
ALTER TABLE [dbo].[Scorm]  WITH CHECK ADD  CONSTRAINT [FK_Scorm_Teaching Planner] FOREIGN KEY([teaching_planner_id])
REFERENCES [dbo].[Teaching Planner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Scorm] CHECK CONSTRAINT [FK_Scorm_Teaching Planner]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Specialized Department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Specialized Department] ([id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Specialized Department]
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
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Specialized Department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Specialized Department] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Specialized Department]
GO
/****** Object:  Trigger [dbo].[trgCreateUserForAccount]    Script Date: 5/6/2024 11:40:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgCreateUserForAccount]
ON [dbo].[Account]
AFTER INSERT
AS
BEGIN
    -- Lấy ID của tài khoản vừa được chèn vào
    DECLARE @AccountID INT;
    SELECT @AccountID = account_id FROM inserted;
    
    -- Chèn một bản ghi mới vào bảng người dùng với cùng ID như tài khoản
    INSERT INTO [user] (id, account_id)
    VALUES (@AccountID, @AccountID);
END;
GO
ALTER TABLE [dbo].[Account] ENABLE TRIGGER [trgCreateUserForAccount]
GO
USE [master]
GO
ALTER DATABASE [MLD_Database_2] SET  READ_WRITE 
GO
