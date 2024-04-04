USE [master]
GO
/****** Object:  Database [MLD_Database]    Script Date: 4/4/2024 4:54:23 PM ******/
CREATE DATABASE [MLD_Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'demo1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\demo1.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'demo1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\demo1_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 4/4/2024 4:54:23 PM ******/
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
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Class]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Curriculum Distribution]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Doc]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[content] [varbinary](max) NULL,
	[category_id] [int] NOT NULL,
	[document4_id] [int] NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 1]    Script Date: 4/4/2024 4:54:23 PM ******/
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
 CONSTRAINT [PK_Kế Hoạch Dạy Học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 2]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 3]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 3](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document1_id] [int] NULL,
	[user_id] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Kế hoạch giáo dục của GV] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 4]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 4](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[teaching_planner_id] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Phu Luc 4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 5]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 5](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[document4_id] [int] NOT NULL,
	[evaluate_by] [int] NULL,
 CONSTRAINT [PK_Phu Luc 5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_CurriculumDistribution]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_CurriculumDistribution](
	[document1_id] [int] NOT NULL,
	[curriculum_id] [int] NOT NULL,
	[slot] [int] NOT NULL,
	[description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_SelectedTopics]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_SelectedTopics](
	[document1_id] [int] NULL,
	[selected_topics_id] [int] NULL,
	[slot] [int] NULL,
	[description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_Subject Room]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_Subject Room](
	[subject_room_id] [int] NULL,
	[document1_id] [int] NULL,
	[quantity] [int] NULL,
	[description] [nvarchar](max) NULL,
	[note] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_TeachingEquipment]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document1_TeachingEquipment](
	[document1_id] [int] NULL,
	[teaching_equipment_id] [int] NULL,
	[quantity] [int] NULL,
	[note] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document2_Grade]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document2_Grade](
	[document2_id] [int] NULL,
	[grade_id] [int] NULL,
	[title_name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[slot] [int] NULL,
	[time] [date] NULL,
	[place] [nvarchar](max) NULL,
	[host_by] [nvarchar](max) NULL,
	[collaborate_with] [nvarchar](max) NULL,
	[condition] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Form Category]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Grade]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[total_student] [int] NULL,
	[total_student_selected_topics] [int] NULL,
 CONSTRAINT [PK_Khối Lớp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level Of Trainning]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Periodic Assessment]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodic Assessment](
	[testing_category_id] [int] NULL,
	[form_category_id] [int] NULL,
	[time] [int] NULL,
	[date] [date] NULL,
	[description] [nvarchar](max) NULL,
	[document1_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professional Standards]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](max) NULL,
	[role_note] [nvarchar](max) NULL,
	[active] [bit] NULL,
	[created_by] [int] NULL,
	[created_date] [date] NULL,
	[modified_by] [int] NULL,
	[modified_date] [date] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scorm]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scorm](
	[id] [int] NOT NULL,
	[content] [varbinary](max) NULL,
 CONSTRAINT [PK_Scorm] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Selected Topics]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Specialized Department]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 4/4/2024 4:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Môn học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject Room]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Teaching Equipment]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Teaching Planner]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[Testing Category]    Script Date: 4/4/2024 4:54:23 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 4/4/2024 4:54:23 PM ******/
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
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Lớp_Khối Lớp] FOREIGN KEY([grade_ id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Lớp_Khối Lớp]
GO
ALTER TABLE [dbo].[Doc]  WITH CHECK ADD  CONSTRAINT [FK_Document_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Doc] CHECK CONSTRAINT [FK_Document_Category]
GO
ALTER TABLE [dbo].[Doc]  WITH CHECK ADD  CONSTRAINT [FK_Document_Phu Luc 4] FOREIGN KEY([document4_id])
REFERENCES [dbo].[Document 4] ([id])
GO
ALTER TABLE [dbo].[Doc] CHECK CONSTRAINT [FK_Document_Phu Luc 4]
GO
ALTER TABLE [dbo].[Document 1]  WITH CHECK ADD  CONSTRAINT [FK_Kế Hoạch Dạy Học_Khối Lớp] FOREIGN KEY([grade_id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Document 1] CHECK CONSTRAINT [FK_Kế Hoạch Dạy Học_Khối Lớp]
GO
ALTER TABLE [dbo].[Document 1]  WITH CHECK ADD  CONSTRAINT [FK_Kế Hoạch Dạy Học_Môn học] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Document 1] CHECK CONSTRAINT [FK_Kế Hoạch Dạy Học_Môn học]
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
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học]
GO
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Kế hoạch giáo dục của GV_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Kế hoạch giáo dục của GV_User]
GO
ALTER TABLE [dbo].[Document 4]  WITH CHECK ADD  CONSTRAINT [FK_Phu Luc 4_User - Lớp - Mon] FOREIGN KEY([teaching_planner_id])
REFERENCES [dbo].[Teaching Planner] ([Id])
GO
ALTER TABLE [dbo].[Document 4] CHECK CONSTRAINT [FK_Phu Luc 4_User - Lớp - Mon]
GO
ALTER TABLE [dbo].[Document 5]  WITH CHECK ADD  CONSTRAINT [FK_Phu Luc 5_Phu Luc 4] FOREIGN KEY([document4_id])
REFERENCES [dbo].[Document 4] ([id])
GO
ALTER TABLE [dbo].[Document 5] CHECK CONSTRAINT [FK_Phu Luc 5_Phu Luc 4]
GO
ALTER TABLE [dbo].[Document 5]  WITH CHECK ADD  CONSTRAINT [FK_Phu Luc 5_User] FOREIGN KEY([evaluate_by])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 5] CHECK CONSTRAINT [FK_Phu Luc 5_User]
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_khdh-pptc_Kế Hoạch Dạy Học] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution] CHECK CONSTRAINT [FK_khdh-pptc_Kế Hoạch Dạy Học]
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_khdh-pptc_Phân phối chương trình] FOREIGN KEY([curriculum_id])
REFERENCES [dbo].[Curriculum Distribution] ([id])
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution] CHECK CONSTRAINT [FK_khdh-pptc_Phân phối chương trình]
GO
ALTER TABLE [dbo].[Document1_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_khdh _ CD / BH_Chuyên đề / Bài Học] FOREIGN KEY([selected_topics_id])
REFERENCES [dbo].[Selected Topics] ([id])
GO
ALTER TABLE [dbo].[Document1_SelectedTopics] CHECK CONSTRAINT [FK_khdh _ CD / BH_Chuyên đề / Bài Học]
GO
ALTER TABLE [dbo].[Document1_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_khdh _ CD / BH_Kế Hoạch Dạy Học] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_SelectedTopics] CHECK CONSTRAINT [FK_khdh _ CD / BH_Kế Hoạch Dạy Học]
GO
ALTER TABLE [dbo].[Document1_Subject Room]  WITH CHECK ADD  CONSTRAINT [FK_khdh - Phòng bộ môn_Kế Hoạch Dạy Học] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_Subject Room] CHECK CONSTRAINT [FK_khdh - Phòng bộ môn_Kế Hoạch Dạy Học]
GO
ALTER TABLE [dbo].[Document1_Subject Room]  WITH CHECK ADD  CONSTRAINT [FK_khdh - Phòng bộ môn_Phòng Bộ Môn] FOREIGN KEY([subject_room_id])
REFERENCES [dbo].[Subject Room] ([id])
GO
ALTER TABLE [dbo].[Document1_Subject Room] CHECK CONSTRAINT [FK_khdh - Phòng bộ môn_Phòng Bộ Môn]
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment]  WITH CHECK ADD  CONSTRAINT [FK_KHDH_TBDH_Kế Hoạch Dạy Học] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment] CHECK CONSTRAINT [FK_KHDH_TBDH_Kế Hoạch Dạy Học]
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment]  WITH CHECK ADD  CONSTRAINT [FK_KHDH_TBDH_Thiết bị dậy học] FOREIGN KEY([teaching_equipment_id])
REFERENCES [dbo].[Teaching Equipment] ([id])
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment] CHECK CONSTRAINT [FK_KHDH_TBDH_Thiết bị dậy học]
GO
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_KHTCHDGD - KHỐI LỚP_Kế hoạch Tổ chức Hoạt Động Giáo Dục] FOREIGN KEY([document2_id])
REFERENCES [dbo].[Document 2] ([id])
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_KHTCHDGD - KHỐI LỚP_Kế hoạch Tổ chức Hoạt Động Giáo Dục]
GO
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_KHTCHDGD - KHỐI LỚP_Khối Lớp] FOREIGN KEY([grade_id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_KHTCHDGD - KHỐI LỚP_Khối Lớp]
GO
ALTER TABLE [dbo].[Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Kiểm tra, đánh giá định kỳ_Hình thức thi] FOREIGN KEY([testing_category_id])
REFERENCES [dbo].[Form Category] ([id])
GO
ALTER TABLE [dbo].[Periodic Assessment] CHECK CONSTRAINT [FK_Kiểm tra, đánh giá định kỳ_Hình thức thi]
GO
ALTER TABLE [dbo].[Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Kiểm tra, đánh giá định kỳ_Kế Hoạch Dạy Học] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Periodic Assessment] CHECK CONSTRAINT [FK_Kiểm tra, đánh giá định kỳ_Kế Hoạch Dạy Học]
GO
ALTER TABLE [dbo].[Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Kiểm tra, đánh giá định kỳ_Loại Bài kiểm tra] FOREIGN KEY([form_category_id])
REFERENCES [dbo].[Testing Category] ([id])
GO
ALTER TABLE [dbo].[Periodic Assessment] CHECK CONSTRAINT [FK_Kiểm tra, đánh giá định kỳ_Loại Bài kiểm tra]
GO
ALTER TABLE [dbo].[Teaching Planner]  WITH CHECK ADD  CONSTRAINT [FK_GV - Lớp_Lớp] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Teaching Planner] CHECK CONSTRAINT [FK_GV - Lớp_Lớp]
GO
ALTER TABLE [dbo].[Teaching Planner]  WITH CHECK ADD  CONSTRAINT [FK_GV - Lớp_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Teaching Planner] CHECK CONSTRAINT [FK_GV - Lớp_User]
GO
ALTER TABLE [dbo].[Teaching Planner]  WITH CHECK ADD  CONSTRAINT [FK_User - Lớp - Mon_Môn học1] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Teaching Planner] CHECK CONSTRAINT [FK_User - Lớp - Mon_Môn học1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Account1] FOREIGN KEY([account_id])
REFERENCES [dbo].[Account] ([account_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Account1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_LevelOfTrainning] FOREIGN KEY([level_of_trainning_id])
REFERENCES [dbo].[Level Of Trainning] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_LevelOfTrainning]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Professional Standards] FOREIGN KEY([professional_standards_id])
REFERENCES [dbo].[Professional Standards] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Professional Standards]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Tổ chuyên Môn] FOREIGN KEY([specialized_department_id])
REFERENCES [dbo].[Specialized Department] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Tổ chuyên Môn]
GO
USE [master]
GO
ALTER DATABASE [MLD_Database] SET  READ_WRITE 
GO
