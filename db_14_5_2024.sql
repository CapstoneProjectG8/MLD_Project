USE [master]
GO
/****** Object:  Database [MLD_Database_2]    Script Date: 5/14/2024 11:26:49 PM ******/
CREATE DATABASE [MLD_Database_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MLD_Database_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MLD_Database_2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Class]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Curriculum Distribution]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document 1]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document 2]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document 3]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document 4]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document 5]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document1_CurriculumDistribution]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document1_Periodic Assessment]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document1_SelectedTopics]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document1_Subject Room]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document1_TeachingEquipment]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document2_Grade]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document3_CurriculumDistribution]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Document3_SelectedTopics]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Evaluate]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Form Category]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Grade]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[IsApprove]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Level Of Trainning]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Notification]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Professional Standards]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Report]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[s3_file_metadata]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Scorm]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Selected Topics]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Specialized Department]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Subject Room]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Teaching Equipment]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Teaching Planner]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[Testing Category]    Script Date: 5/14/2024 11:26:49 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 5/14/2024 11:26:49 PM ******/
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

INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (3, N'teacher1', N'ryAt5YQlNbtECzsQtKuBFg==;2xVX1XoxtFh0lZjuuVKXOJgTxAiVG2oHmy7mJAcVyBg=', 1, 12, CAST(N'2024-04-30' AS Date), 2, 4, CAST(N'2024-05-14T23:23:07.157' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (4, N'leader1', N'+rA04jdg0kW/x+P3YHuLCQ==;/CLXfaiGfe3zyJFpMRF9qJn4YYnco73Xh6gxJwi5CuY=', 1, 12, CAST(N'2024-05-01' AS Date), 3, 2, CAST(N'2024-05-14T23:23:53.753' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (5, N'principal', N'PtKjQxZHbUdRJ2IqZUjqdw==;cM2ZW/GEyj2qHSF7MTJXKKiQYkMq+F8TcZAzPmQW4ok=', 1, 12, CAST(N'2024-05-01' AS Date), 4, 2, CAST(N'2024-05-14T23:24:00.513' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (6, N'teacher2', N'ryAt5YQlNbtECzsQtKuBFg==;2xVX1XoxtFh0lZjuuVKXOJgTxAiVG2oHmy7mJAcVyBg=', 1, 12, CAST(N'2024-04-30' AS Date), 2, 2, CAST(N'2024-05-14T23:24:06.563' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (7, N'teacher3', N'ryAt5YQlNbtECzsQtKuBFg==;2xVX1XoxtFh0lZjuuVKXOJgTxAiVG2oHmy7mJAcVyBg=', 1, 12, CAST(N'2024-04-30' AS Date), 2, 2, CAST(N'2024-05-14T23:24:13.443' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (12, N'ADMIN', N'ryAt5YQlNbtECzsQtKuBFg==;2xVX1XoxtFh0lZjuuVKXOJgTxAiVG2oHmy7mJAcVyBg=', 1, NULL, CAST(N'2024-04-30' AS Date), 1, 1, CAST(N'2024-05-14T23:24:13.443' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (1, N'8A', 30, 0, 8)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (2, N'8B', 31, 0, 8)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (3, N'8C', 32, 0, 8)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (4, N'8D', 33, 0, 8)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (5, N'8E', 34, 0, 8)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (6, N'7A', 30, 0, 7)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (7, N'7B', 31, 0, 7)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (8, N'7C', 32, 0, 7)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (9, N'7D', 33, 0, 7)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (10, N'7E', 34, 0, 7)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (11, N'6A', 30, 0, 6)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (12, N'6B', 31, 0, 6)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (13, N'6C', 32, 0, 6)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (14, N'6D', 33, 0, 6)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (15, N'6E', 34, 0, 6)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (16, N'9A', 30, 0, 9)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (17, N'9B', 31, 0, 9)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (18, N'9C', 32, 0, 9)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (19, N'9D', 33, 0, 9)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (20, N'9E', 34, 0, 9)
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] ON 

INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (1, N'Bài 1. Đơn thức')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (2, N'Bài 2. Đa thức')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (3, N'Bài 3. Phép cộng và phép')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (4, N'Bài 4. Phép nhân đa thức')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (5, N'Bài 5. Phép chia đa thức cho đơn thức')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (6, N'Bài 6. Hiệu hai bình phương. Bình phương của một tổng hay một hiệu')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (7, N'Bài 7. Lập phương của một tổng hay một hiệu')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (8, N'Bài 8. Tổng và hiệu hai lập phương')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (9, N'Bài 9. Phân tích đa thức thành nhân tử')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (10, N'Luyện tập chung')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (11, N'Lược sử công cụ tính toán')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (12, N'Thông tin trong môi trường số')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (13, N'Đạo đức và văn hoá trong sử dụng công nghệ kĩ thuật số')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (14, N'Thực hành: Khai thác thông tin số')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (15, N'Sử dụng bảng tính giải quyết bài toán thực tế')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (16, N'Sắp xếp và lọc dữ liệu')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (17, N'Trực quan hoá dữ liệu')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (18, N'Làm việc với danh sách dạng liệt kê và hình ảnh trong

văn bản')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (19, N'Tạo đầu trang, chân trang cho văn bản')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (20, N'Định dạng nâng cao cho trang chiếu')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (21, N'Sử dụng bản mẫu tạo bài trình chiếu')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (22, N'Phần mềm chỉnh sửa ảnh')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (23, N'Thay đổi khung hình, kích thước ảnh')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (24, N' Thêm văn bản, tạo hiệu ứng cho ảnh')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (25, N'Từ thuật toán đến chương trình')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (26, N'Biểu diễn dữ liệu')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (27, N'Cấu trúc điều khiển')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (28, N'Gỡ lỗi')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (29, N'Thực hành tổng hợp')
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 1] ON 

INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (2, N'Ke Hoach Mon Toan', 1, 8, 4, NULL, 1, 5, 4, CAST(N'2024-05-06' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (3, N'Ke Hoach Mon Tin', 2, 8, 4, NULL, 1, 5, 4, CAST(N'2024-05-06' AS Date), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 1] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 2] ON 

INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (1, N'Ke Hoach Hoat Dong Giao Duc Cua To Chuyen Mon Cua Mon Toan ', 4, 1, 5, 4, CAST(N'2024-05-06' AS Date), NULL, NULL)
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (2, N'Ke Hoach Hoat Dong Giao Duc Cua To Chuyen Mon Cua Mon Tin', 4, 1, 5, 4, CAST(N'2024-05-06' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 2] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 3] ON 

INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (1, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN MÔN TOÁN 8', 2, 3, N'8A', 1, 4, 4, CAST(N'2024-05-06' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (3, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN MÔN TOÁN 8', 2, 3, N'8C', 1, 4, 4, CAST(N'2024-05-07' AS Date), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 3] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 4] ON 

INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (3, N'Đơn thức', 2, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (4, N'Đa thức', 3, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (5, N'Phép cộng và phép trừ đa thức', 4, 1, CAST(N'2024-06-05' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (6, N'Phép nhân đa thức', 5, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (7, N'Phép chia đa thức cho đơn thức', 6, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (8, N'Hiệu hai bình phương. Bình phương của một tổng hay một hiệu', 7, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (9, N'Lập phương của một tổng hay một hiệu', 8, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (10, N'Tổng và hiệu hai lập hương', 9, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (11, N'Phân tích đa thức thành nhân tử', 10, 1, CAST(N'2024-06-05' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (12, N'Luyện tập chung', 11, 1, CAST(N'2024-06-05' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (15, N' Lược sử công cụ tính toán', 13, 1, CAST(N'2024-06-05' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (16, N'Thông tin trong môi trường số', 14, 1, CAST(N'2024-06-05' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (17, N' Đạo đức và văn hoá trong sử dụng công nghệ kĩ thuật số', 15, 1, CAST(N'2024-06-05' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (18, N'Thực hành: Khai thác thông tin số', 16, 1, CAST(N'2024-06-05' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (19, N'Sử dụng bảng tính giải quyết bài toán thực tế', 17, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (20, N'Sắp xếp và lọc dữ liệu', 18, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (21, N'Trực quan hoá dữ liệu', 19, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image], [isApprove]) VALUES (22, N'Làm việc với danh sách dạng liệt kê và hình ảnh trong

văn bản', 20, 1, CAST(N'2024-05-06' AS Date), NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[Document 4] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 5] ON 

INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (1, N'Đơn thức', 3, 3, 2, CAST(N'2024-09-06' AS Date), 20, CAST(N'2024-09-06' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (2, N'Đa thức', 4, 3, 2, CAST(N'2024-09-13' AS Date), 18, CAST(N'2024-09-13' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (3, N'Phép cộng và phép trừ đa thức', 5, 3, 1, CAST(N'2024-09-20' AS Date), 19, CAST(N'2024-09-20' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (4, N'Phép nhân đa thức', 6, 3, 2, CAST(N'2024-09-22' AS Date), 18, CAST(N'2024-09-22' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (5, N'Phép chia đa thức cho đơn thức', 7, 3, 2, CAST(N'2024-09-29' AS Date), 20, CAST(N'2024-09-29' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (6, N'Hiệu hai bình phương. Bình phương của một tổng hay một hiệu', 8, 3, 2, CAST(N'2024-10-06' AS Date), 17, CAST(N'2024-10-06' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (7, N'Lập phương của một tổng hay một hiệu', 9, 3, 2, CAST(N'2024-10-13' AS Date), 20, CAST(N'2024-10-13' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (8, N'Tổng và hiệu hai lập hương', 10, 3, 1, CAST(N'2024-10-20' AS Date), 16, CAST(N'2024-10-20' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (9, N'Phân tích đa thức thành nhân tử', 11, 3, 2, CAST(N'2024-10-23' AS Date), 20, CAST(N'2024-10-23' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (10, N'Luyện tập chung', 12, 3, 1, CAST(N'2024-10-27' AS Date), 20, CAST(N'2024-10-27' AS Date), NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (11, N'Thực hành: Khai thác thông tin số', 6, 6, 2, CAST(N'2024-09-27' AS Date), 20, CAST(N'2024-09-27' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 5] OFF
GO
SET IDENTITY_INSERT [dbo].[Document1_CurriculumDistribution] ON 

INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (1, 2, 1, 2, N'- Nhận biết đơn thức, đơn thức thu gọn, hệ số, phần biến và bậc của đơn thức - Thu gọn đơn thức. - Nhận biết đơn thức đồng dạng. - Cộng và trừ hai đơn thức đồng dạng')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (2, 2, 2, 2, N'- Nhận biết các khái niệm: đa thức, hạng tử của đa thức, đa thức thu gọn và bậc của đa thức. - Thu gọn đa thức. - Tính giá trị của đa thức khi biết giá trị của các biến')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (3, 2, 3, 1, N'- Nắm được cách cộng, trừ hai đa thức - Thực hiện các phép tính cộng, trừ đa thức')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (4, 2, 4, 2, N'- Thực hiện phép tính nhân đơn thức với đa thức và nhân đa thức với đa thức. - Biến đổi, thu gọn biểu thức đại số có sử dụng phép nhân đa thức')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (5, 2, 5, 2, N'- Nắm được cách chia đơn thức cho đơn thức (trường hợp chia hết), chia đa thức cho đơn thức (trường hợp chia hết) - Thực hiện được các phép tính trên đa thức.')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (6, 2, 6, 2, N'- Nắm được cách chia đơn thức cho đơn thức (trường hợp chia hết), chia đa thức cho đơn thức (trường hợp chia hết) - Thực hiện được các phép tính trên đa thức.')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (7, 2, 7, 2, N'- Nhận biết hằng đẳng thức. - Mô tả hằng đẳng thức hiệu hai bình phương, bình phương của một tổng, bình phương của một hiệu. - Vận dụng ba hằng đẳng thức này để tính nhanh, rút gọn biểu thức')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (8, 2, 8, 1, N'- Mô tả các hằng đẳng thức: tổng, hiệu hai lập phương. - Vận dụng hai hằng đẳng thức này để rút gọn biểu thức hay viết biểu thức dưới dạng tích.')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (9, 2, 9, 2, N'- Nhận biết phân tích đa thức thành nhân tử. - Mô tả ba cách phân tích đa thức thành nhân tử: Đặt nhân tử chung; Nhóm các hạng tử; Sử dụng hằng đẳng thức - Vận dụng các cách này để khai triển, giải toán tìm x, rút gọn biểu thức')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (10, 2, 10, 1, N'- Luyện tập củng cố các kiến thức đã học')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (11, 3, 11, 2, N'Lược sử công cụ tính toán')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (12, 3, 12, 2, N'Thông tin trong môi trường số')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (13, 3, 13, 2, N'Đạo đức và văn hoá trong sử dụng công nghệ kĩ thuật số')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (14, 3, 14, 2, N'Thực hành: Khai thác thông tin số')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (15, 3, 15, 2, N'Sử dụng bảng tính giải quyết bài toán thực tế')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (16, 3, 16, 2, N'Sắp xếp và lọc dữ liệu')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (17, 3, 17, 2, N'Trực quan hoá dữ liệu')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (18, 3, 18, 2, N'Làm việc với danh sách dạng liệt kê và hình ảnh trong

văn bản')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (19, 3, 19, 2, N'Tạo đầu trang, chân trang cho văn bản')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (20, 3, 20, 2, N'Định dạng nâng cao cho trang chiếu')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (21, 3, 21, 2, N'Sử dụng bản mẫu tạo bài trình chiếu')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (22, 3, 22, 2, N'Phần mềm chỉnh sửa ảnh')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (23, 3, 23, 2, N'Thay đổi khung hình, kích thước ảnh')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (24, 3, 24, 2, N'Thêm văn bản, tạo hiệu ứng cho ảnh')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (25, 3, 25, 2, N'Từ thuật toán đến chương trình')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (26, 3, 26, 2, N'Biểu diễn dữ liệu')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (27, 3, 27, 2, N'Cấu trúc điều khiển')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (28, 3, 28, 2, N'Gỡ lỗi')
INSERT [dbo].[Document1_CurriculumDistribution] ([id], [document1_id], [curriculum_id], [slot], [description]) VALUES (29, 3, 29, 2, N'Thực hành tổng hợp')
SET IDENTITY_INSERT [dbo].[Document1_CurriculumDistribution] OFF
GO
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (1, 3, 90, CAST(N'2024-11-01' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong nửa học kì 1', 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (1, 3, 90, CAST(N'2024-11-02' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong nửa học kì 1', 3)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (2, 3, 90, CAST(N'2024-12-20' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong học kì I – Thực hiện được các kĩ năng cơ bản trong học kì 1', 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (2, 4, 90, CAST(N'2024-12-21' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong học kì I – Thực hiện được các kĩ năng cơ bản trong học kì 1', 3)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (3, 3, 90, CAST(N'2025-03-01' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong nửa học kì 2', 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (3, 3, 90, CAST(N'2025-03-02' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong nửa học kì 2', 3)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (4, 3, 90, CAST(N'2025-05-20' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong học kì II – Thực hiện được các kĩ năng cơ bản trong học kì 2', 2)
INSERT [dbo].[Document1_Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (4, 4, 90, CAST(N'2025-05-21' AS Date), N'– Kiểm tra, đánh giá mức mộ nhận thức về các kiến thức đã học trong học kì II – Thực hiện được các kĩ năng cơ bản trong học kì 2', 3)
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

INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (1, 1, 2, 1, N'Ứng dụng định lí Thalès, định lí Pythagore và tam giác đồng dạng để đo chiều cao, khoảng cách', N'')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (2, 2, 2, 1, N'Thực hành phần mềm GEOGEBRA Mô tả thí nghiệm ngẫu nhiên với phần mềm Excel', N'')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (3, 3, 3, 1, N'Dùng để thực hành các nội dung được học trong các tiết lý thuyết của môn Tin học.', N'')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (4, 2, 3, 1, N'1', N'1')
INSERT [dbo].[Document1_Subject Room] ([id], [subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (5, 3, 3, 1, N'1', N'1')
SET IDENTITY_INSERT [dbo].[Document1_Subject Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Document1_TeachingEquipment] ON 

INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (1, 2, 1, 1, N'', N'Các bài học và các hoạt động trải nghiệm')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (2, 2, 2, 1, N'', N'Dùng cho các tiết dạy có ứng dụng CNTT')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 2, 3, 1, N'', N'Dùng cho các tiết có sử dụng máy tính cầm tay')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (4, 2, 4, 1, N'', N'Dụng cụ vẽ hình dùng cho các tiết hình học')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (5, 2, 5, 1, N'', N'Dụng cụ vẽ hình dùng cho các tiết hình học')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (6, 2, 6, 1, N'', N'Dụng cụ vẽ hình dùng cho các tiết hình học')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (7, 2, 7, 1, N'', N'Dụng cụ vẽ hình dùng cho các tiết hình học')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (8, 2, 8, 1, N'', N'Dụng cụ vẽ hình dùng cho các tiết hình học')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (9, 2, 9, 1, N'', N'Dùng cho các tiết tạo hình, hoạt động trải nghiệm')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (10, 2, 10, 1, N'', N'Dùng cho các tiết tạo hình, hoạt động trải nghiệm')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (11, 2, 11, 1, N'', N'Dùng cho các tiết tạo hình, hoạt động trải nghiệm')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (12, 3, 1, 1, N'', N'Bài lý thuyết, thực hành')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (13, 3, 2, 30, N'', N'Bài thực hành sgk')
INSERT [dbo].[Document1_TeachingEquipment] ([id], [document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (20, 3, 3, 1, N'May chieu', N'May xin')
SET IDENTITY_INSERT [dbo].[Document1_TeachingEquipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Document2_Grade] ON 

INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (1, 1, 8, N'Tính diện tích, thể tích các vật trên thực t', N'- Lập đước công thức tính diện tích tam giác, tứ giác. - Ứng dụng được các công thức đó vào trong đo đạc một số vật dụng trong lớp học như bàn, ghế, lớp học', 1, CAST(N'2024-10-21' AS Date), N'Trên Lớp', 4, N'', N'- Thước đo độ dài (thước mét, thước dây..). Giấy A4, bút, máy tính cầm tay, phiếu học tập cá nhân, nhóm. -Một số đồ vật có dạng hình hộp.')
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (2, 1, 8, N'Thực hành đo gián tiếp chiều cao một vật và đo khoảng cách giữa hai điểm trên mặt đất, trong đó có một điểm không thể tới được', N'- HS biết cách đo gián tiếp chiều cao một vật và đo khoảng cách giữa hai điểm trên mặt đất, trong đó có một điểm không thể tới được. - Phát huy năng lực giải quyết vấn đề toán học, năng lực hợp tác', 2, CAST(N'2025-04-30' AS Date), N'Ngoài Trời', 4, N'Hai giáo viên dạy cùng môn toán 8 phối hợp với nhau', N'- Địa điểm thực hành cho các tổ HS - Mỗi tổ HS có một nhóm thực hành, cùng với GV chuẩn bị đủ dụng cụ thực hành của tổ')
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (3, 2, 8, N'Tìm kiếm thông tin trên Internet', N'- Biết được tài khoảng - Nêu được công dụng của máy tìm kiếm  -Xác định được từ khóa ứng với mục đích tìm kiếm cho trước', 2, CAST(N'2024-10-23' AS Date), N'Trên Lớp', 4, N'', N'Máy tính có kết nối mạng Internet')
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document2_Grade] OFF
GO
SET IDENTITY_INSERT [dbo].[Document3_CurriculumDistribution] ON 

INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (1, 1, 1, 1, 7, 2, CAST(N'2024-09-06' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (2, 1, 2, 1, 7, 2, CAST(N'2024-09-13' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (3, 1, 3, 1, 7, 1, CAST(N'2024-09-20' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (4, 1, 4, 1, 7, 2, CAST(N'2024-09-22' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (5, 1, 5, 1, 7, 2, CAST(N'2024-09-29' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (6, 1, 6, 1, 7, 2, CAST(N'2024-10-06' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (7, 1, 7, 2, 7, 2, CAST(N'2024-10-13' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (8, 1, 8, 2, 7, 1, CAST(N'2024-10-20' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (9, 1, 9, 1, 7, 2, CAST(N'2024-10-23' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([id], [document3_id], [curriculum_id], [equipment_id], [subject_room_id], [slot], [time]) VALUES (10, 1, 10, 2, 7, 1, CAST(N'2024-10-27' AS Date))
SET IDENTITY_INSERT [dbo].[Document3_CurriculumDistribution] OFF
GO
SET IDENTITY_INSERT [dbo].[Evaluate] ON 

INSERT [dbo].[Evaluate] ([id], [document5_id], [evaluate_1_1], [evaluate_1_2], [evaluate_1_3], [evaluate_1_4], [evaluate_2_1], [evaluate_2_2], [evaluate_2_3], [evaluate_2_4], [evaluate_3_1], [evaluate_3_2], [evaluate_3_3], [evaluate_3_4]) VALUES (1, 1, 1, 2, 1, 2, 2, 1, 2, 2, 2, 2, 1, 2)
INSERT [dbo].[Evaluate] ([id], [document5_id], [evaluate_1_1], [evaluate_1_2], [evaluate_1_3], [evaluate_1_4], [evaluate_2_1], [evaluate_2_2], [evaluate_2_3], [evaluate_2_4], [evaluate_3_1], [evaluate_3_2], [evaluate_3_3], [evaluate_3_4]) VALUES (2, 2, 1, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 2)
INSERT [dbo].[Evaluate] ([id], [document5_id], [evaluate_1_1], [evaluate_1_2], [evaluate_1_3], [evaluate_1_4], [evaluate_2_1], [evaluate_2_2], [evaluate_2_3], [evaluate_2_4], [evaluate_3_1], [evaluate_3_2], [evaluate_3_3], [evaluate_3_4]) VALUES (3, 11, 1, 2, 2, 1, 1, 2, 2, 2, 2, 2, 1, 2)
SET IDENTITY_INSERT [dbo].[Evaluate] OFF
GO
SET IDENTITY_INSERT [dbo].[Form Category] ON 

INSERT [dbo].[Form Category] ([id], [name]) VALUES (1, N'Tự Luận')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (2, N'Trắc Nghiệm ')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (3, N'Tự Luận & Trắc Nghiệm')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (4, N'Thực Hành')
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

INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (1, N'Toán-Lý')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (2, N'Tự Nhiên')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (3, N'Ngữ Văn')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (4, N'Xã Hội')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (5, N'Ngoại Ngữ')
INSERT [dbo].[Specialized Department] ([id], [name]) VALUES (6, N'Âm Nhạc - Mỹ Thuật')
SET IDENTITY_INSERT [dbo].[Specialized Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (1, N'Toán ', 1)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (2, N'Tin', 1)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (3, N'Vật Lý', 2)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (4, N'Công Nghệ', 2)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (5, N'Hóa', 2)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (6, N'Sinh', 2)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (7, N'Văn', 3)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (8, N'Lịch Sử', 4)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (9, N'Địa Lý', 4)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (10, N'GDCD', 4)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (11, N'Thể Dục', 4)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (12, N'Quốc Phòng', 4)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (13, N'Ngoại Ngữ', 5)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (14, N'Âm Nhạc', 6)
INSERT [dbo].[Subject] ([id], [name], [department_id]) VALUES (15, N'Mỹ Thuật', 6)
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject Room] ON 

INSERT [dbo].[Subject Room] ([id], [name]) VALUES (1, N'Sân Trường')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (2, N'Phòng Tin Học')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (3, N'Phòng Thí Nghiệm')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (4, N'Phòng Kỹ Thuật')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (5, N'Phòng Sinh Học')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (6, N'Phòng Nghệ Thuật')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (7, N'Phòng Học')
SET IDENTITY_INSERT [dbo].[Subject Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Teaching Equipment] ON 

INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (1, N'Máy chiếu')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (2, N'Máy tính kết nối mạng')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (3, N'Máy tính bỏ túi')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (4, N'Thước kẻ')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (5, N'Eke')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (6, N'Compa')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (7, N'Bộ thực hành đo đạc')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (8, N'Bộ hình không gian')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (9, N'Bìa giấy cứng')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (10, N'Keo dán')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (11, N'Dụng cụ thủ công')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (12, N'Nhiệt kế')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (13, N'Bộ dụng cụ vật lý')
SET IDENTITY_INSERT [dbo].[Teaching Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Teaching Planner] ON 

INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 2)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 3)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 4)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 5)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 6)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 7)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 8)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 9)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 10)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 11)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (3, 1, 1, 12)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 13)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 14)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 15)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 16)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 17)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 18)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 19)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 20)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 21)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 22)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 23)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 24)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 26)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 27)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 28)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 29)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 30)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 31)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 32)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 33)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (6, 2, 2, 34)
SET IDENTITY_INSERT [dbo].[Teaching Planner] OFF
GO
SET IDENTITY_INSERT [dbo].[Testing Category] ON 

INSERT [dbo].[Testing Category] ([id], [name]) VALUES (1, N'Giữa Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (2, N'Cuối Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (3, N'Giữa Học Kì 2')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (4, N'Cuối Học Kì 2')
SET IDENTITY_INSERT [dbo].[Testing Category] OFF
GO
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (3, N'teacher1', N'teacher1', N'teacher1@gmail.com', N'string', N'HaNoi', 1, CAST(N'2024-04-30' AS Date), 20, NULL, 3, 3, 4, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (4, N'leader1', N'leader1', N'leader1@gmail.com', N'string ', N'HCM', 1, CAST(N'2024-04-30' AS Date), 30, NULL, 3, 4, 4, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (5, N'principle1', N'principle1', N'principle1@gmail.com', N'string', N'DaNang', 0, CAST(N'2024-04-30' AS Date), 50, NULL, 3, 5, 4, NULL)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (6, N'teacher2', N'teacher2', N'teacher2@gmail.com', N'string', N'HaNoi', 1, CAST(N'2024-04-30' AS Date), 20, NULL, 3, 6, 4, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (7, N'leader2', N'leader2', N'leader2@gmail.com', NULL, N'HaNoi', 1, NULL, 20, NULL, 3, 7, 4, 2)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [photo], [address], [gender], [date_of_birth], [age], [signature], [level_of_trainning_id], [account_id], [professional_standards_id], [department_id]) VALUES (12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, NULL)
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
/****** Object:  Trigger [dbo].[trgCreateUserForAccount]    Script Date: 5/14/2024 11:26:49 PM ******/
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
