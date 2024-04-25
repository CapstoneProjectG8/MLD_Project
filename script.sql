USE [master]
GO
/****** Object:  Database [MLD_Database]    Script Date: 4/25/2024 1:24:18 PM ******/
CREATE DATABASE [MLD_Database]
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 4/25/2024 1:24:18 PM ******/
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
	[login_last] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Class]    Script Date: 4/25/2024 1:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Curriculum Distribution]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document 1]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document 2]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document 3]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document 4]    Script Date: 4/25/2024 1:24:18 PM ******/
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
 CONSTRAINT [PK_Phu Luc 4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 5]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document1_CurriculumDistribution]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document1_SelectedTopics]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document1_Subject Room]    Script Date: 4/25/2024 1:24:18 PM ******/
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
 CONSTRAINT [PK_Document1_Subject Room_1] PRIMARY KEY CLUSTERED 
(
	[subject_room_id] ASC,
	[document1_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_TeachingEquipment]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document2_Grade]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document3_CurriculumDistribution]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Document3_SelectedTopics]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Evaluate]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Feedback]    Script Date: 4/25/2024 1:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
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
/****** Object:  Table [dbo].[Form Category]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Grade]    Script Date: 4/25/2024 1:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Khối Lớp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level Of Trainning]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Notification]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Periodic Assessment]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Professional Standards]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[s3_file_metadata]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Scorm]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Selected Topics]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Specialized Department]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Subject Room]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Teaching Equipment]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Teaching Planner]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[Testing Category]    Script Date: 4/25/2024 1:24:18 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 4/25/2024 1:24:18 PM ******/
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
	[photo] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[gender] [bit] NULL,
	[date_of_birth] [date] NULL,
	[age] [int] NULL,
	[level_of_trainning_id] [int] NULL,
	[specialized_department_id] [int] NULL,
	[account_id] [int] NOT NULL,
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
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (15, N'dung', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'ADMIN', CAST(N'2023-04-06' AS Date), 3, 13, CAST(N'2024-04-25T10:39:29.163' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (16, N'namanh', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'ADMIN', CAST(N'2023-04-06' AS Date), 2, 13, CAST(N'2024-04-25T10:14:01.883' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (17, N'ABC', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'ADMIN', CAST(N'2023-04-06' AS Date), 2, 2, CAST(N'2024-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (18, N'an', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'ADMIN', CAST(N'2023-04-06' AS Date), 5, 4, CAST(N'2024-04-25T04:50:26.947' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (19, N'hung', N'ZyXnInHcq5BubJXlp4HZzQ==;ftOdV6yphY6pNTmm2wgozrp/uEvNFA9ThR+wIXzzg1g=', 1, N'ADMIN', CAST(N'2024-04-07' AS Date), 2, 1, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (20, N'namanh12345', N'1kvz1mQJdpCiriNd+FY0BA==;Y0XyCnqLCh6XopBIrv8cYXKSJEjYNc4CmLJbvLNMRa8=', 1, N'ADMIN', CAST(N'2024-04-07' AS Date), 1, 1, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (21, N'string', N'K7cdQX+mqbpQzzCfUkepLg==;iMLzDMMjJlA/v4XkWPf6mEYVGVdNoEmibqJjGaOrA0w=', 1, N'ADMIN', CAST(N'2024-04-15' AS Date), 3, 1, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (22, N'namanhtest', N'UwbUTwF1zOmjnEKLkCq3sA==;ZgSzZu8CIEoCr2FAxXc+79d7NZz2Owr9Hhjj9UL8jMM=', 1, N'ADMIN', CAST(N'2024-04-15' AS Date), 2, 1, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (24, N'anhminh120401', N'Cyz89rbxlMEtXde73Knlbg==;dr6WOBToZyl+nHbcSzVFqmpX4oG+60iGo0R7zV0zeec=', 1, N'ADMIN', CAST(N'2024-04-19' AS Date), 5, 1, NULL)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (25, N'minh', N'Bs1xQERWcKI1aaBbocvJNw==;6dDGHrpHdvg6F3tj3uLk0xg4jYmiPkS64g23ug+XrMk=', 1, N'ADMIN', CAST(N'2024-04-19' AS Date), 3, 2, CAST(N'2024-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id], [login_attempt], [login_last]) VALUES (26, N'QQQQQQQ', N'wpd7vWxHB3n5otbf+1ZAxg==;NHSunjUMOIUoNFzOOJ9eBD0shv1v5jmWXODZXVKLEGo=', 1, N'ADMIN', CAST(N'2024-04-21' AS Date), 2, 1, CAST(N'2024-04-21T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [name]) VALUES (1, N'.doc')
INSERT [dbo].[Category] ([Id], [name]) VALUES (2, N'.ppt')
INSERT [dbo].[Category] ([Id], [name]) VALUES (3, N'.pdf')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (1, N'6A1', 61, 60, 1)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (2, N'6A2', 62, 60, 1)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (3, N'6A3', 63, 60, 1)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (4, N'6A4', 64, 60, 1)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (5, N'6A5', 65, 60, 1)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (6, N'7A1', 71, 60, 2)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (7, N'7A2', 72, 60, 2)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (8, N'7A3', 73, 60, 2)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (9, N'7A4', 74, 60, 2)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (10, N'7A5', 75, 60, 2)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (11, N'8A1', 81, 60, 3)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (12, N'8A2', 82, 60, 3)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (13, N'8A3', 83, 60, 3)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (14, N'8A4', 84, 60, 3)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (15, N'8A5', 85, 60, 3)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (16, N'9A1', 91, 60, 4)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (17, N'9A2', 92, 60, 4)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (18, N'9A3', 93, 60, 4)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (19, N'9A4', 94, 60, 4)
INSERT [dbo].[Class] ([id], [name], [total_student], [total_student_selected_topics], [grade_ id]) VALUES (20, N'9A5', 95, 60, 4)
GO
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] ON 

INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (1, N'Thánh Gióng ')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (2, N'Sơn Tinh Thủy Tinh')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (3, N'Ứng dụng chuyển động bằng phản lực chế tạo tên lửa nước.')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (4, N'Ứng dụng hiện tượng cảm ứng điện từ chế tạo nam châm điện')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (6, N'NHẬP MÔN HÓA HỌC




')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (7, N'Thành phần của nguyên tử



')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (10, N'Nguyên tố hóa học





')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (11, N'
Chuyên đề: Thực hành thí nghiệm hóa học ảo

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (12, N'Cấu trúc lớp vỏ electron nguyên tử




')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (13, N'Chuyên đề: Ôn tập
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (14, N'Đánh giá giữa HK I')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (15, N'Cấu tạo của bảng tuần hoàn các nguyên tố hóa học




')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (16, N'

Xu hướng biến đổi tính chất của đơn chất, biến đổi thành phần và tính chất của hợp chất trong một chu kì và trong một nhóm
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (17, N'Chuyên đề: Phản ứng hạt nhân
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (18, N'Định luật tuần hoàn và ý nghĩa của bảng tuần hoàn các nguyên tố hóa học')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (19, N'Quy tắc Octet')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (20, N'Liên kết ion
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (21, N'Liên kết ion (tt)')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (22, N'Liên kết Cộng hóa trị

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (23, N'ÔN TẬP HK1')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (24, N'ĐÁNH GIÁ HK1')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (25, N'Sửa bài đánh giá HK2')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (26, N'Chuyên đề: Liên kết hóa học
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (27, N'Tính biến thiên enthalpy của phản ứng hóa học')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (28, N'Liên kết hydrogen và tương tác (liên kết) Van der Waals





')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (29, N'Phản ứng oxi hóa khử

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (30, N'

Entropy và biến thiên năng lượng tự do Gibbs
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (31, N'Enthalpy tạo thành và biến thiên enthalpy của phản ứng hóa học





Entropy và biến thiên năng lượng tự do Gibbs

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (32, N'Enthalpy tạo thành và biến thiên enthalpy của phản ứng hóa học





Entropy và biến thiên năng lượng tự do Gibbs

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (33, N'
Kiểm tra chuyên đề 1
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (34, N'Đánh giá giữa HK II')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (35, N'Tốc độ phản ứng hóa học




')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (36, N'Tốc độ phản ứng (tt)


')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (37, N'

Chuyên đề: Sơ lược về phản ứng cháy và nổ
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (38, N'huyên đề: Điểm chớp cháy, nhiệt độ tự bốc cháy và nhiệt độ cháy


')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (39, N'Tính chất vật lí và hóa học các đơn chất nhóm VIIA

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (40, N'Hydrogen halide – Một số phản ứng của ion halide






Chuyên đề: Điểm chớp cháy, nhiệt độ tự bốc cháy và nhiệt độ cháy
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (41, N'

Chuyên đề: Hóa học về phản ứng cháy và nổ (Kiểm tra chuyên đề 2)')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (42, N'ÔN TẬP HK2





')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (43, N'Đánh giá HK II')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (44, N'Chuyên đề: Hóa học về phản ứng cháy và nổ')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (45, N'Ôn tập chủ đề 7
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (46, N'ÔN TẬP')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (47, N'



Chuyên đề: Vẽ cấu trúc phân tử

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (48, N'

Kiểm tra Chuyên đề 3

')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (49, N'Chuyên đề: Năng lượng hoạt hóa
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (50, N'
Chuyên đề: Hóa học về phản ứng cháy và nổ
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (51, N'Câu chuyện của 
lịch sử')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (52, N'Vè đẹp cổ điển')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (53, N'Lời sông núi')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (54, N'Ôn tập và kiểm tra giữa kì I
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (55, N'Tiếng cười trào phúng trong thơ')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (56, N'Những câu chuyện hài')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (57, N'Ôn tập và kiểm tra cuối kì I')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (58, N'Chân dung
 cuộc sống
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (59, N'Tin yêu và ước
vọng
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (60, N'Nhà văn và
 trang viết
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (61, N'Ôn tập, kiểm tra giữa kì II')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (62, N'Hôm nay và
ngày mai
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (63, N'Sách-Người
bạn đồng hành
')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (64, N'Ôn tập và kiểm tra cuối kì II')
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 1] ON 

INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (3, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC NGỮ VĂN, KHỐI LỚP 12
', 2, 4, 8, NULL, 1, 11, 1, CAST(N'2023-12-12' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (15, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC TOÁN HỌC, KHỐI LỚP 11
', 1, 4, 8, NULL, 0, 11, 2, CAST(N'2024-01-01' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (16, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC VẬT LÝ, KHỐI LỚP 9
', 9, 4, 8, NULL, 0, 11, 1, CAST(N'2023-12-13' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (17, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC HÓA HỌC, KHỐI LỚP 8', 4, 3, 8, NULL, 0, 11, 2, CAST(N'2023-12-15' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (18, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC ĐỊA LÝ, KHỐI LỚP 10', 7, 2, 8, NULL, 1, 11, 1, CAST(N'2023-12-10' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (20, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC GIÁO DỤC CÔNG DÂN, KHỐI LỚP 6', 8, 1, 8, NULL, 1, 11, 1, CAST(N'2023-11-30' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (22, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC CÔNG NGHỆ, KHỐI LỚP 7', 10, 2, 8, NULL, 1, 11, 2, CAST(N'2024-01-10' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (24, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC LỊCH SỬ, KHỐI LỚP 11', 6, 3, 8, NULL, 1, 11, 2, CAST(N'2024-02-24' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (26, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC TIN HỌC, KHỐI LỚP 12
', 11, 3, 8, NULL, 1, 11, 2, CAST(N'2024-02-07' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (27, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC SINH HỌC, KHỐI LỚP 10', 5, 2, 8, NULL, 1, 11, 2, CAST(N'2023-12-23' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (28, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC TIẾNG ANH, KHỐI LỚP 6', 3, 1, 8, NULL, 1, 11, 2, CAST(N'2024-02-21' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (29, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC TOÁN, KHỐI LỚP 10', 1, 3, 8, NULL, 1, NULL, 2, CAST(N'2023-10-05' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (30, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC VẬT LÝ, KHỐI LỚP 11', 9, 2, 8, NULL, 1, NULL, 2, CAST(N'2023-11-27' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (31, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC HÓA HỌC, KHỐI LỚP 12
', 4, 3, 8, NULL, 1, NULL, 2, CAST(N'2024-03-09' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (32, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC SINH HỌC, KHỐI LỚP 9', 5, 4, 8, NULL, 1, NULL, 2, CAST(N'2024-02-01' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (35, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC TIẾNG ANH, KHỐI LỚP 8
', 3, 3, 8, NULL, 1, NULL, 2, CAST(N'2024-01-03' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (38, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC LỊCH SỬ, KHỐI LỚP 7', 6, 2, 8, NULL, 1, NULL, 2, CAST(N'2024-01-05' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (39, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC ĐỊA LÝ, KHỐI LỚP 12
', 7, 3, 8, NULL, 1, NULL, 2, CAST(N'2024-02-12' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (41, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC GIÁO DỤC CÔNG DÂN, KHỐI LỚP 9', 8, 4, 8, NULL, 1, NULL, 2, CAST(N'2023-12-05' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (42, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC CÔNG NGHỆ, KHỐI LỚP 7', 10, 2, 8, NULL, 1, NULL, 2, CAST(N'2024-02-13' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image], [other_tasks]) VALUES (44, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC HÓA HỌC, KHỐI LỚP 10', 4, 1, 8, NULL, 1, NULL, 2, CAST(N'2024-10-22' AS Date), N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com//image18afa841-3a5c-4c85-a0e4-95d3bb7d42f2.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745426359&Signature=oyOdv2G9%2BwrukZwya4dv%2FY%2FRrMA%3D', NULL)
SET IDENTITY_INSERT [dbo].[Document 1] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 2] ON 

INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (1, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 TOÁN', 8, 1, 11, 2, CAST(N'2024-02-17' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (2, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 NGỮ VĂN', 8, 1, 11, 2, CAST(N'2024-02-18' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (5, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 VẬT LÝ', 8, 1, 11, 2, CAST(N'2024-02-19' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (7, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 SINH HỌC', 8, 1, 11, 2, CAST(N'2024-02-20' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (8, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 TIN HỌC', 8, 1, 11, 2, CAST(N'2024-02-21' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (10, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 GIÁO DỤC CÔNG DÂN', 8, 1, 11, 2, CAST(N'2024-02-11' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (11, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 LỊCH SỬ', 8, 1, 11, 2, CAST(N'2024-01-20' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (12, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 ĐỊA LÝ', 8, 1, 1, 2, CAST(N'2024-01-21' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (13, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 HÓA HỌC', 8, 1, 1, 2, CAST(N'2024-01-22' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (17, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 NGHỆ THUẬT', 8, 1, 1, 2, CAST(N'2024-01-23' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (18, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 TIẾNG ANH', 8, 1, 1, 2, CAST(N'2024-01-25' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (19, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
 CÔNG NGHỆ', 8, 1, 1, 2, CAST(N'2024-01-24' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tkhttps://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/f40e7fa8-31fb-4f4a-ab32-5062d7b756c8.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745103880&Signature=FP%2FnU3Y0VXs8ugSHZeTpQH%2Fp4tk%3D%3D')
INSERT [dbo].[Document 2] ([id], [name], [user_id], [status], [approve_by], [isApprove], [created_date], [link_file], [link_image]) VALUES (20, N'KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC - PHỤ LỤC II 
MÔN HỌC: NGỮ VĂN 8 – BỘ SÁCH KNTT VỚI CUỘC SỐNG
', 8, 1, 1, 2, CAST(N'2024-01-25' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/ab2086a0-6e3c-4fc6-859f-944caf728f55.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745107099&Signature=JabFKctQ27BuB8kN0Lynypnztak%3D')
SET IDENTITY_INSERT [dbo].[Document 2] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 3] ON 

INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (1, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN
 MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC NGỮ VĂN, LỚP 6A1', 3, 9, N'6A1', 1, 0, NULL, CAST(N'2024-03-01' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/57982cce-64cf-4204-8197-497fe0ddb422.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102636&Signature=mqep8xNLEYibiCQIMMsXKBZCJio%3D', NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (5, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN
 
MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC TOÁN, LỚP 10A1', 15, 9, N'6A2', 1, 1, NULL, CAST(N'2024-03-02' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/57982cce-64cf-4204-8197-497fe0ddb422.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102636&Signature=mqep8xNLEYibiCQIMMsXKBZCJio%3D', NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (7, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN
 MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC VẬT LÝ, LỚP 11B2', 16, 9, N'7A3', 1, 1, NULL, CAST(N'2024-03-04' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/57982cce-64cf-4204-8197-497fe0ddb422.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102636&Signature=mqep8xNLEYibiCQIMMsXKBZCJio%3D', NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (8, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN
 MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC VẬT LÝ, LỚP 10C3', 44, 9, N'10C3', 1, 1, NULL, CAST(N'2024-03-04' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/57982cce-64cf-4204-8197-497fe0ddb422.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102636&Signature=mqep8xNLEYibiCQIMMsXKBZCJio%3D', NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (9, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN', 3, 9, N'9A2', 1, 1, NULL, CAST(N'2024-04-25' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/57982cce-64cf-4204-8197-497fe0ddb422.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102636&Signature=mqep8xNLEYibiCQIMMsXKBZCJio%3D', NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (10, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN', 3, 9, N'9A2', 1, 1, NULL, CAST(N'2024-04-25' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/57982cce-64cf-4204-8197-497fe0ddb422.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102636&Signature=mqep8xNLEYibiCQIMMsXKBZCJio%3D', NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (11, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN', 3, 9, N'9A2', 1, 1, NULL, CAST(N'2024-04-25' AS Date), N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc3/d860e6d9-6cb0-4f62-b90a-315197e8f7e4.pdf?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745531904&Signature=U2N1Py6fxaF%2B6qbqXtKuC82tCIM%3D', NULL, NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (12, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN', 3, 9, N'9A2', 1, 1, NULL, CAST(N'2024-04-25' AS Date), N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc3/15321eba-bf1c-47ac-af08-6bd462e55af7.pdf?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745532290&Signature=oACO4ouE1HWSqt4ZMmhW7YUVplQ%3D', NULL, NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (13, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN', 3, 9, N'9A2', 1, 1, NULL, CAST(N'2024-04-25' AS Date), N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc3/7e26a6c4-e006-422a-b995-27f226ee5687.pdf?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745533253&Signature=%2FC8F8afwgYpPOFH9V6bPf99cG28%3D', NULL, NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (14, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN', 24, 9, N'8A3', 1, 1, NULL, CAST(N'2024-04-25' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [claas_name], [status], [isApprove], [approve_by], [created_date], [link_file], [link_image], [other_tasks]) VALUES (17, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN', 24, 9, N'8A2', 1, 1, NULL, CAST(N'2024-04-25' AS Date), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 3] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 4] ON 

INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image]) VALUES (3, N'Âm nhạc và sắc màu', 10, 1, CAST(N'2024-04-22' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/08b66227-2510-4765-8ede-99974813609a.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102282&Signature=Y0hXnLrVvVRYcS5XeMQlCg7sOKM%3D')
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image]) VALUES (4, N'string', 2, 1, CAST(N'2024-04-22' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/08b66227-2510-4765-8ede-99974813609a.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102282&Signature=Y0hXnLrVvVRYcS5XeMQlCg7sOKM%3D')
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status], [created_date], [link_file], [link_image]) VALUES (5, N'string', 2, 1, CAST(N'2024-04-22' AS Date), NULL, N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/Image/08b66227-2510-4765-8ede-99974813609a.png?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745102282&Signature=Y0hXnLrVvVRYcS5XeMQlCg7sOKM%3D')
SET IDENTITY_INSERT [dbo].[Document 4] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 5] ON 

INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (2, N'ABC', 3, 8, 3, CAST(N'2024-04-23' AS Date), 20, NULL, NULL, NULL)
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (3, N'BBB', 3, 8, 20, CAST(N'2024-04-23' AS Date), 20, CAST(N'2024-04-24' AS Date), N'string', N'string')
INSERT [dbo].[Document 5] ([id], [name], [document4_id], [user_id], [slot], [date], [total], [created_date], [link_file], [link_image]) VALUES (4, N'CCC', 3, 8, 10, CAST(N'2024-04-23' AS Date), 10, CAST(N'2024-04-24' AS Date), N'string', N'string')
SET IDENTITY_INSERT [dbo].[Document 5] OFF
GO
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 1, 10, N'-Trình bày được thành phần của nguyên tử …
-So sánh được khối lượng của electron với proton và neutron, kích thước của hạt nhân với kích thước nguyên tử.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 2, 20, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 3, 30, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 4, 99, N'-Trình bày được thành phần của nguyên tử …
-So sánh được khối lượng của electron với proton và neutron, kích thước của hạt nhân với kích thước nguyên tử.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 12, 12, N'-Trình bày được thành phần của nguyên tử …
-So sánh được khối lượng của electron với proton và neutron, kích thước của hạt nhân với kích thước nguyên tử.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 13, 13, N'-Trình bày được thành phần của nguyên tử …
-So sánh được khối lượng của electron với proton và neutron, kích thước của hạt nhân với kích thước nguyên tử.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 14, 50, N'-Trình bày được thành phần của nguyên tử …
-So sánh được khối lượng của electron với proton và neutron, kích thước của hạt nhân với kích thước nguyên tử.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 6, 2, N'-Nêu được đối tượng nghiên cứu của hoá học.
-Trình bày được phương pháp học tập và nghiên cứu hoá học.
-Nêu được vai trò của hoá học đối với đời sống, sản xuất...
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 7, 3, N'-Trình bày được thành phần của nguyên tử …
-So sánh được khối lượng của electron với proton và neutron, kích thước của hạt nhân với kích thước nguyên tử.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 10, 3, N'-Trình bày được khái niệm về nguyên tố hoá học, số hiệu nguyên tử và kí hiệu nguyên tử.
-Phát biểu được khái niệm đồng vị, nguyên tử khối.
Tính được nguyên tử khối trung bình (theo amu) …
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 11, 2, N'-Thực hiện được các thí nghiệm ảo theo nội dung được cho trước từ giáo viên. Phân tích và lí giải được kết quả thí nghiệm ảo.')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 12, 4, N'-Trình bày được khái niệm lớp, phân lớp electron và mối quan hệ về số lượng phân lớp trong một lớp. Liên hệ được về số lượng AO trong một phân lớp, trong một lớp.
-Viết được cấu hình electron nguyên tử theo lớp, phân lớp electron và theo ô orbital khi biết số hiệu nguyên tử Z của 20 nguyên tố đầu tiên trong bảng tuần hoàn.
-Dựa vào đặc điểm cấu hình electron lớp ngoài cùng của nguyên tử dự đoán được tính chất hoá học cơ bản (kim loại hay phi kim) của nguyên tố tương ứng.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 13, 1, N'Vẽ công thức phân tử chất hữu cơ và vô cơ, lưu file, chèn vào Word, Powerpoint
Thực hiện được các thí nghiệm ảo theo nội dung được cho trước từ giáo viên. Phân tích và lí giải được kết quả thí nghiệm ảo.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 14, 1, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 15, 3, N'-Nêu được về lịch sử phát minh định luật tuần hoàn và bảng tuần hoàn các nguyên tố hoá học.
-Mô tả được cấu tạo của bảng tuần hoàn các nguyên tố hoá học và nêu được các khái niệm liên quan (ô, chu kì, nhóm).
 -Phân loại được nguyên tố (dựa theo cấu hình electron: nguyên tố s, p, d, f; dựa theo tính chất hoá học: kim loại, phi kim, khí hiếm).')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (22, 16, 3, N'-Nhận xét và giải thích được xu hướng biến đổi tính kim loại, phi kim của nguyên tử các nguyên tố trong một chu kì, trong một nhóm (nhóm A).
-Nhận xét được xu hướng biến đổi thành phần và tính chất acid/base của các oxide và các hydroxide theo chu kì. Viết được phương trình hoá học minh hoạ.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 17, 3, N'-Nêu được sơ lược về sự phóng xạ tự nhiên; lấy được ví dụ về sự phóng xạ tự nhiên.

-Vận dụng được các định luật bảo toàn số khối và điện tích cho phản ứng hạt nhân.
 -Nêu được sơ lược về sự phóng xạ nhân tạo, phản ứng hạtnhân.

-Nêu được ứng dụng của phản ứng hạt nhân phục vụ nghiên cứu khoa học, đời sống và sản xuất
. -Nêu được các ứng dụng điển hình của phản ứng hạt nhân: xác định niên đại cổ vật, các ứng dụng trong lĩnh vực y tế, năng lượng,...')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 18, 2, N'-Phát biểu được định luật tuần hoàn
-Trình bày được ý nghĩa của bảng tuần hoàn các nguyên tố hoá học: mối liên hệ giữa vị trí (trong bảng tuần hoàn các nguyên tố hoá học) với tính chất và ngược lại.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 19, 1, N'Trình bày và vận dụng được quy tắc octet trong quá trình hình thành liên kết hoá học cho các nguyên tố nhóm A.')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 20, 1, N'-Trình bày được khái niệm và sự hình thành liên kết ion (nêu một số ví dụ điển hình tuân theo quy tắc octet).')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 21, 1, N'-Nêu được cấu tạo tinh thể NaCl. Giải thích được vì sao các hợp chất ion thường ở trạng thái rắn trong điều kiện thường (dạng tinh thể ion).
-Lắp được mô hình tinh thể NaCl (theo mô hình có sẵn).
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 22, 5, N'-Trình bày được khái niệm và lấy được ví dụ về liên kết cộng hoá trị (liên kết đơn, đôi, ba) khi áp dụng quy tắc octet.')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 23, 2, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 24, 1, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 25, 1, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 26, 3, N'-Trình bày được khái niệm về sự lai hoá AO (sp, sp2, sp3), vận dụng giải thích liên kết trong một số phân tử (CO2; BF3; CH4;...).')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 27, 2, N'-Nêu được ý nghĩa của dấu và giá trị  
-Tính được   của một phản ứng dựa vào bảng số liệu năng lượng liên kết, nhiệt tạo thành cho sẵn, vận dụng công thức: 
 và  
 ,   là tổng năng lượng liên kết trong phân tử chất đầu và sản phẩm phản ứng.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 28, 2, N'-Trình bày được khái niệm liên kết hydrogen. Vận dụng để giải thích được sự xuất hiện liên kết hydrogen (với nguyên tố có độ âm điện lớn: N, O, F).
-Nêu được vai trò, ảnh hưởng của liên kết hydrogen tới tính chất vật lí của H2O.
-Nêu được khái niệm về tương tác Van der Waals và ảnh hưởng của tương tác này tới nhiệt độ nóng chảy, nhiệt độ sôi của các chất.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 29, 4, N'-Nêu được khái niệm và xác định được số oxi hoá của nguyên tử các nguyên tố trong hợp chất.
-Nêu được khái niệm về phản ứng oxi hoá – khử và ý nghĩa của phản ứng oxi hoá – khử.
 -Mô tả được một số phản ứng oxi hoá – khử quan trọng gắn liền với cuộc sống. 
-Cân bằng được phản ứng oxi hoá – khử bằng phương pháp thăng bằng electron.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 30, 4, N'-Nêu được khái niệm về Entropy S (đại lượng đặc trưng cho độ mất trật tự của hệ). -Nêu được ý nghĩa của dấu và trị số của biến thiên năng lượng tự do Gibbs (không cần giải thích ΔrG là gì, chỉ cần nêu: Để xác định chiều hướng phản ứng, người ta dựa vào biến thiên năng lượng tự do ΔrG) của phản ứng (G) để dự đoán hoặc giải thích chiều hướng của một phản ứng hoá học. -Tính được rGo theo công thức rGo = rHo – T.rSo từ bảng cho sẵn các giá trị fHo và So của các chất.')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 31, 4, N'-Trình bày được khái niệm phản ứng toả nhiệt, thu nhiệt; điều kiện chuẩn (áp suất 1 bar và thường chọn nhiệt độ 25oC hay 298 K); enthalpy tạo thành (nhiệt tạo thành)   và biến thiên enthalpy (nhiệt phản ứng) của phản ứng  
Nêu được ý nghĩa của dấu và giá trị  
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 33, 1, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (24, 34, 1, N'-Hệ thống hóa và BT về chủ đề năng lượng hóa học')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 35, 2, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 36, 2, N'-Thực hiện được một số thí nghiệm nghiên cứu các yếu tố ảnh hưởng tới tốc độ phản ứng (nồng độ, nhiệt độ, áp suất, diện tích bề mặt, chất xúc tác). 
-Giải thích được các yếu tố ảnh hưởng tới tốc độ phản ứng như: nồng độ, nhiệt độ, áp suất, diện tích bề mặt, chất xúc tác.
-Nêu được ý nghĩa của hệ số nhiệt độ Van’t Hoff (γ).
-Vận dụng được kiến thức tốc độ phản ứng hoá học vào việc giải thích một số vấn đề trong cuộc sống và sản xuất.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 37, 2, N'-Nêu được khái niệm, đặc điểm của phản ứng cháy (thuộc loại phản ứng oxi hoá – khử và là phản ứng toả nhiệt, phát ra ánh sáng). Nêu được một số ví dụ về sự cháy các chất vô cơ và hữu cơ (xăng, dầu cháy trong không khí; Mg cháy trong CO2,...).
-Chỉ ra được những sp của pứ cháy và tác hại với con người.
 -Phân tích được dấu hiệu để nhận biết về những nguy cơ và cách giảm nguy cơ gây cháy, nổ.')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 38, 1, N'-Nêu được khái niệm về điểm chớp cháy, nhiệt độ tự bốc cháy, nhiệt độ ngọn lửa.
Trình bày được việc sử dụng điểm chớp cháy để phân biệt chất lỏng dễ cháy và có thể gây cháy
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 39, 5, N'-Phát biểu được trạng thái tự nhiên của các nguyên tố halogen.
-Mô tả được trạng thái, màu sắc, nhiệt độ nóng chảy, nhiệt độ sôi của các đơn chất halogen.
-Giải thích được sự biến đổi nhiệt độ nóng chảy, nhiệt độ sôi của các đơn chất halogen dựa vào tương tác van der Waals.
-Trình bày được xu hướng nhận thêm 1 electron (từ kim loại) hoặc dùng chung electron (với phi kim) để tạo hợp chất ion hoặc hợp chất cộng hoá trị dựa theo cấu hình electron.
 -Thực hiện được (hoặc quan sát video) thí nghiệm chứng minh được xu hướng giảm dần tính oxi hoá của các halogen thông qua một số phản ứng: Thay thế halogen trong dung dịch muối bởi một halogen khác; Halogen tác dụng với hydrogen và với nước.
-Giải thích được xu hướng phản ứng của các đơn chất halogen với hydrogen theo khả năng hoạt động của halogen và năng lượng liên kết H–X (điều kiện phản ứng, hiện tượng phản ứng và hỗn hợp chất có trong bình phản ứng).
-Viết được phương trình hoá học của phản ứng tự oxi hoá – khử của chlorine trong phản ứng với dung dịch sodium hydroxide ở nhiệt độ thường và khi đun nóng; ứng dụng của phản ứng này trong sản xuất chất tẩy rửa.
 -Thực hiện được (hoặc quan sát video) một số thí nghiệm chứng minh tính oxi hoá mạnh của các halogen và so sánh tính oxi hoá giữa chúng (thí nghiệm tính tẩy màu của khí chlorine ẩm; thí nghiệm nước chlorine, nước bromine tương tác với các dung dịch sodium chloride, sodium bromide, sodium iodide).')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 40, 3, N'-Thực hiện được thí nghiệm phân biệt các ion F–, Cl–, Br–, I– bằng cách cho dung dịch silver nitrate vào dung dịch muối của chúng. 
-Trình bày được tính khử của các ion halide (Cl–, Br–, I–) thông qua phản ứng với chất oxi hoá là sulfuric acid đặc.
-Nêu được ứng dụng của một số hydrogen halide.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 41, 1, N'-Tính được rHo một số phản ứng cháy, nổ (theo fHo hoặc năng lượng liên kết) để dự đoán mức độ mãnh liệt của phản ứng cháy, nổ.
-Tính được sự thay đổi của tốc độ phản ứng cháy, “tốc độ phản ứng hô hấp” theo giả định về sự phụ thuộc vào nồng độ O2.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 42, 2, N'Tính enthalpy của phản ứng
Tốc độ phản ứng
Hệ thống hóa được kiến thức của chủ đề Nguyên tố nhóm VIIA.
-Vận dụng các kiến thức đã học để làm các bài tập liên quan đến chủ đề Nguyên tố nhóm VIIA.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 43, 1, N'-Hệ thống hóa được kiến thức của chủ đề nguyên tử;')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 44, 2, N'-Nêu được nguyên tắc xử lí và phòng chống cháy nổ.
-Giải thích được vì sao lại hay dùng CO2  để chữa cháy (cách li và làm giảm nồng độ O2; CO2 nặng hơn không khí).
-Giải thích được vì sao lại hay dùng nước để chữa cháy (làm giảm nhiệt độ xuống dưới nhiệt độ cháy,...).
 -Giải thích được tại sao đám cháy có mặt các kim loại hoạt động mạnh như kim loại kiềm, kiềm thổ và nhôm... không sử dụng nước, CO2, cát (thành phần chính là SiO2), bọt chữa cháy (hỗn hợp không khí, nước và chất hoạt động bề mặt) để dập tắt đám cháy.')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 46, 6, N'Tính enthalpy của phản ứng
Tốc độ phản ứng
Hệ thống hóa được kiến thức của chủ đề Nguyên tố nhóm VIIA.
-Vận dụng các kiến thức đã học để làm các bài tập liên quan đến chủ đề Nguyên tố nhóm VIIA.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 48, 1, N'Vẽ công thức phân tử chất hữu cơ và vô cơ, lưu file, chèn vào Word, Powerpoint
Thực hiện được các thí nghiệm ảo theo nội dung được cho trước từ giáo viên. Phân tích và lí giải được kết quả thí nghiệm ảo.
')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (44, 49, 3, N'-Trình bày được khái niệm năng lượng hoạt hoá (theo khía cạnh ảnh hưởng đến tốc độ phản ứng). -Nêu được ảnh hưởng của năng lượng hoạt hoá và nhiệt độ tới tốc độ phản ứng thông qua phương trình Arrhenius k  A.e(– Ea / RT ) . Giải thích được vai trò của chất xúc tác.')
GO
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (3, 1, 1, N'Chuyên đề 1')
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (3, 2, 2, N'Chuyên đề 2')
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (3, 3, 3, N'Chuyên đề 3')
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (22, 6, 10, N'Chuyên đề 4')
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (22, 7, 15, N'Chuyên đề 5')
INSERT [dbo].[Document1_SelectedTopics] ([document1_id], [selected_topics_id], [slot], [description]) VALUES (22, 8, 10, NULL)
GO
INSERT [dbo].[Document1_Subject Room] ([subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (3, 22, 10, N'Phòng Thí Nghiệm', N'10')
INSERT [dbo].[Document1_Subject Room] ([subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (10, 22, 1, N'Ma ta 2 ', N'Ghi Chu 2')
GO
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 3, 1, N'ghi chu 1', N'mo ta 1')
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 4, 1, N'ghi chu 2', N'ma ta 2')
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (22, 7, 12, N'Đã có đủ', N'Các yếu tố ảnh hưởng đến tốc độ phản ứng Hóa học')
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (22, 8, 12, N'Đã có đủ', N'Nguyên tố nhóm VII - HALOGEN')
GO
SET IDENTITY_INSERT [dbo].[Document2_Grade] ON 

INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (1, 2, 1, N'string', N'string', 0, CAST(N'2024-04-22' AS Date), N'string', 8, N'string', N'string')
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (2, 2, 2, N'string', N'string', 0, CAST(N'2024-04-22' AS Date), N'string', NULL, N'string', N'string')
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (3, 2, 3, N'8', NULL, NULL, NULL, NULL, 10, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (4, 2, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (5, 13, 5, N'10', NULL, 95, NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (6, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (7, 2, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Document2_Grade] ([id], [document2_id], [grade_id], [title_name], [description], [slot], [time], [place], [host_by], [collaborate_with], [condition]) VALUES (8, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document2_Grade] OFF
GO
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 7, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 10, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 11, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 12, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 13, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 14, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 15, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 16, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 17, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 18, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 19, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 20, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 21, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 22, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 23, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 24, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 26, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 27, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 28, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 29, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 30, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 31, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 33, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 34, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 35, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 36, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 37, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 39, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 40, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 41, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 42, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 44, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 46, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 47, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 49, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (8, 50, 9, NULL, NULL, NULL)
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (10, 3, 4, N'Phòng đọc sách', 1, CAST(N'2024-04-02' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (11, 3, 4, N'Phòng đọc sách', 1, CAST(N'2024-04-02' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (12, 4, 4, N'Phòng đọc sách', 1, CAST(N'2024-04-09' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (13, 4, 4, N'Phòng đọc sách', 123, CAST(N'2024-04-08' AS Date))
INSERT [dbo].[Document3_CurriculumDistribution] ([document3_id], [curriculum_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (17, 17, 7, N'Hóa học', 25, CAST(N'2024-04-01' AS Date))
GO
INSERT [dbo].[Document3_SelectedTopics] ([document3_id], [selectedTopics_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (10, 2, 3, N'Phòng đọc sách', 1, CAST(N'2024-04-09' AS Date))
INSERT [dbo].[Document3_SelectedTopics] ([document3_id], [selectedTopics_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (11, 1, 3, N'Phòng đọc sách', 1, CAST(N'2024-04-09' AS Date))
INSERT [dbo].[Document3_SelectedTopics] ([document3_id], [selectedTopics_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (11, 2, 4, N'Phòng đọc sách', 1, CAST(N'2024-04-16' AS Date))
INSERT [dbo].[Document3_SelectedTopics] ([document3_id], [selectedTopics_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (12, 1, 4, N'Phòng đọc sách', 1, CAST(N'2024-04-01' AS Date))
INSERT [dbo].[Document3_SelectedTopics] ([document3_id], [selectedTopics_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (13, 1, 3, N'Phòng đọc sách', 12, CAST(N'2024-03-31' AS Date))
INSERT [dbo].[Document3_SelectedTopics] ([document3_id], [selectedTopics_id], [equipment_id], [subject_room_name], [slot], [time]) VALUES (17, 6, 7, N'Hóa học', 24, CAST(N'2024-04-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Evaluate] ON 

INSERT [dbo].[Evaluate] ([id], [document5_id], [evaluate_1_1], [evaluate_1_2], [evaluate_1_3], [evaluate_1_4], [evaluate_2_1], [evaluate_2_2], [evaluate_2_3], [evaluate_2_4], [evaluate_3_1], [evaluate_3_2], [evaluate_3_3], [evaluate_3_4]) VALUES (1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Evaluate] ([id], [document5_id], [evaluate_1_1], [evaluate_1_2], [evaluate_1_3], [evaluate_1_4], [evaluate_2_1], [evaluate_2_2], [evaluate_2_3], [evaluate_2_4], [evaluate_3_1], [evaluate_3_2], [evaluate_3_3], [evaluate_3_4]) VALUES (2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Evaluate] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (0, 8, N'Vi phạm bản quyền', 1, 3, NULL, 0)
INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (1, 8, N'Có lỗi kỹ thuật', 1, 17, NULL, 0)
INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (2, 9, N'Không dùng để dạy học', 3, 10, NULL, 0)
INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (5, 12, N'Có lỗi kỹ thuật', 2, 12, NULL, 0)
INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (6, 8, N'Vi phạm bản quyền', 3, 1, NULL, 0)
INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (8, 8, N'Có lỗi kỹ thuật', 3, 12, NULL, 0)
INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (10, 8, N'Không dùng để dạy học', 2, 13, NULL, 0)
INSERT [dbo].[Feedback] ([id], [user_id], [message], [doc_type], [doc_id], [description], [read]) VALUES (11, 8, N'Có lỗi kỹ thuật', 1, 28, NULL, 0)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Form Category] ON 

INSERT [dbo].[Form Category] ([id], [name]) VALUES (1, N'Tự Luận')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (2, N'Trắc Nghiệm')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (3, N'Tự Luận Kết Hợp Trắc Nghiệm')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (4, N'
Viết trên giấy
')
SET IDENTITY_INSERT [dbo].[Form Category] OFF
GO
INSERT [dbo].[Grade] ([id], [name]) VALUES (1, N'6')
INSERT [dbo].[Grade] ([id], [name]) VALUES (2, N'7')
INSERT [dbo].[Grade] ([id], [name]) VALUES (3, N'8')
INSERT [dbo].[Grade] ([id], [name]) VALUES (4, N'9')
INSERT [dbo].[Grade] ([id], [name]) VALUES (5, N'10')
INSERT [dbo].[Grade] ([id], [name]) VALUES (6, N'11')
INSERT [dbo].[Grade] ([id], [name]) VALUES (7, N'12')
GO
SET IDENTITY_INSERT [dbo].[Level Of Trainning] ON 

INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (1, N'Junior College')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (2, N'Bachelor')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (3, N'Above Bachlor')
SET IDENTITY_INSERT [dbo].[Level Of Trainning] OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (14, N'Z', 8, 1, N'Z', 3, 1)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (15, N'Z', 8, 2, N'Z', 3, 1)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (16, N'Z', 8, 3, N'Z', 3, 1)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (17, N'Z', 8, 4, N'Z', 3, 1)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (18, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 11, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 9)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (19, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 11, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 10)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (20, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 11, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 11)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (21, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 11, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 12)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (22, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 8, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 13)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (23, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 9, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 14)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (24, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 9, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 15)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (25, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 9, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 16)
INSERT [dbo].[Notification] ([id], [title_name], [sent_by], [receive_by], [message], [doc_type], [docId]) VALUES (26, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 9, 9, N'KẾ HOẠCH DẠY HỌC CỦA GIÁO VIÊN ĐÃ ĐƯỢC ĐĂNG TẢI, HÃY XÉT DUYỆT', 3, 17)
SET IDENTITY_INSERT [dbo].[Notification] OFF
GO
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (1, 1, 40, CAST(N'2020-04-04' AS Date), N'Kiem tra tren giay ', 3)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (1, 2, 50, CAST(N'2024-04-22' AS Date), N'string', 3)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (1, 2, 40, CAST(N'2024-04-21' AS Date), N'string', 15)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (2, 1, 40, CAST(N'2020-04-28' AS Date), N'Kiem tra trac nghiem ', 3)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (2, 1, 40, CAST(N'2020-04-28' AS Date), N'Kiem tra tren giay ', 15)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (3, 1, 40, CAST(N'2020-02-28' AS Date), N'Kiem tra trac nghiem ', 3)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (3, 1, 40, CAST(N'2020-02-28' AS Date), N'Kiem tra tren giay ', 15)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (14, 1, 40, CAST(N'2020-04-04' AS Date), N'Kiem tra trac nghiem ', 3)
INSERT [dbo].[Periodic Assessment] ([testing_category_id], [form_category_id], [time], [date], [description], [document1_id]) VALUES (14, 1, 40, CAST(N'2020-04-04' AS Date), N'Kiem tra tren giay ', 15)
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
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (17, N'scorm/70ed4b7a-b072-4011-ab9f-7ba475074b72.zip', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/scorm/70ed4b7a-b072-4011-ab9f-7ba475074b72.zip?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745059591&Signature=cuMOrX9y45ehXFmHnztD%2BmdXBck%3D', CAST(N'2025-04-19T10:46:30.697' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (18, N'doc2/', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc2/?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745076467&Signature=WpwxbhhjjVk1VGNjw8OcaEPzA08%3D', CAST(N'2025-04-19T15:27:46.870' AS DateTime))
INSERT [dbo].[s3_file_metadata] ([id], [file_key], [presigned_url], [expiration_datetime]) VALUES (19, N'doc2/bd22300a-4e96-43c5-b3bb-1e532d90e1ba.pdf', N'https://meldsep490.s3.ap-southeast-2.amazonaws.com/doc2/bd22300a-4e96-43c5-b3bb-1e532d90e1ba.pdf?AWSAccessKeyId=AKIAZI2LIC2BIRYILRSM&Expires=1745076467&Signature=tpVV1zO%2Bks7mfhi6j6Zp4nZk00U%3D', CAST(N'2025-04-19T15:27:46.910' AS DateTime))
SET IDENTITY_INSERT [dbo].[s3_file_metadata] OFF
GO
SET IDENTITY_INSERT [dbo].[Selected Topics] ON 

INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (1, N'Tiếng Anh ')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (2, N'Chân trời sáng tạo')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (3, N'Cánh Diều')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (4, N'Kết nối Tri Thức với cuộc sống')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (5, N'Tiếng Việt')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (6, N'Thực hành Hóa học và công nghệ thông tin')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (7, N'Cơ sở Hóa học')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (8, N'Hóa học trong việc phòng chống cháy nổ')
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
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (13, N'Ngữ Văn')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (14, N'Sân trường')
INSERT [dbo].[Subject Room] ([id], [name]) VALUES (15, N'')
SET IDENTITY_INSERT [dbo].[Subject Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Teaching Equipment] ON 

INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (1, N'bảng đen')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (2, N'bảng trắng')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (3, N'máy chiếu')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (4, N'máy tính')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (5, N'bút')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (6, N'phấn')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (7, N'Dụng cụ: kẹp ống nghiệm,
ống nghiệm, đèn cồn, ống hút    
Hóa chất: Na2S2O3, H2SO4 loãng, H2C2O4, CaCO3, HCl, H2O2, MnO2
')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (8, N'Dụng cụ: kẹp ống nghiệm,
ống nghiệm, đèn cồn, ống hút, nút cao su và ống dẫn khí, giá đỡ    
 Hóa chất: AgNO3, NaCl , NaBr, NaI, KMnO4, HCl, H2O, NaCl khan, H2SO4 đđ, HNO3, NaCl
Nước clo, nước brom, NaI, NaBr
')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (9, NULL)
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (10, N'- Máy chiếu, máy tính, Giấy A1 hoặc bảng phụ để HS làm việc nhóm.
- Tranh ảnh 
- Sgk, kế hoạch bài dạy, sách tham khảo, phiếu học tập.
')
INSERT [dbo].[Teaching Equipment] ([id], [name]) VALUES (11, N'- SGK, SGV, SBT, TL tham khảo,...
- KHBD, máy tính, máy chiếu, PHT, rubic, bảng kiểm
')
SET IDENTITY_INSERT [dbo].[Teaching Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Teaching Planner] ON 

INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 10, 2, 2)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 12, 3, 3)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 17, 7, 4)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 18, 8, 5)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 13, 5, 6)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 14, 6, 7)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 5, 1, 8)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 9, 10, 9)
INSERT [dbo].[Teaching Planner] ([user_id], [class_id], [subject_id], [Id]) VALUES (9, 11, 13, 10)
SET IDENTITY_INSERT [dbo].[Teaching Planner] OFF
GO
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (1, N'Giữa Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (2, N'Cuối Học Kì 1')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (3, N'Giữa Học Kì 2')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (14, N'Cuối Học Kì 2')
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [date_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (8, N'dung', N'le', N'leenguyenquangdung1@gmail.com', N'Trần Văn Dũng', NULL, NULL, 1, NULL, 20, 1, 1, 15, 1, NULL, CAST(N'2024-04-22' AS Date), NULL, NULL, 0)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [date_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (9, N'nam ', N'anh', N'damhuynamanh@gmail.com', N'Đào Nam Anh', NULL, NULL, 1, NULL, 21, 1, 1, 16, 1, NULL, CAST(N'2024-04-25' AS Date), NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [date_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (10, N'nguyen', N'hoang', N'thangmubietnhin@gmail.com', N'Nguyễn Đình Hoàng', NULL, NULL, 1, NULL, 22, 1, 2, 17, 1, NULL, CAST(N'2024-04-25' AS Date), NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [date_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (11, N'an', N'Hiệu trưởng', N'an@gmail.com', N'Trần Đại An', NULL, NULL, 1, NULL, 23, 1, 2, 18, 1, NULL, CAST(N'2024-04-23' AS Date), NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [date_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (12, N'Nam', N'Anh', N'anhminh120401@gmail.com', N'Nguyễn Đức Nam', NULL, NULL, 1, NULL, 23, 1, 2, 22, 1, NULL, CAST(N'2024-04-15' AS Date), NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [date_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (22, N'minh', N'anh', N'anhminhtran120401@gmail.com', N'Lê Anh Minh', NULL, NULL, 1, NULL, 25, 1, 2, 25, 1, NULL, CAST(N'2024-04-19' AS Date), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
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
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Document 3_Document 1]
GO
ALTER TABLE [dbo].[Document 3]  WITH CHECK ADD  CONSTRAINT [FK_Document 3_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Document 3] CHECK CONSTRAINT [FK_Document 3_User]
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
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_Document2_Grade_Document 2]
GO
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_Document2_Grade_Grade1] FOREIGN KEY([grade_id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_Document2_Grade_Grade1]
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
ALTER TABLE [dbo].[Evaluate]  WITH CHECK ADD  CONSTRAINT [FK_Evaluate_Document 5] FOREIGN KEY([document5_id])
REFERENCES [dbo].[Document 5] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluate] CHECK CONSTRAINT [FK_Evaluate_Document 5]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User] FOREIGN KEY([sent_by])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User]
GO
ALTER TABLE [dbo].[Periodic Assessment]  WITH CHECK ADD  CONSTRAINT [FK_Periodic Assessment_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
ON DELETE CASCADE
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
