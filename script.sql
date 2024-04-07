USE master
GO
CREATE DATABASE MLD_Database
GO
USE [MLD_Database]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Class]    Script Date: 4/6/2024 8:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[grade_ id] [int] NULL,
 CONSTRAINT [PK_Lớp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curriculum Distribution]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Doc]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Document 1]    Script Date: 4/6/2024 8:39:44 PM ******/
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
 CONSTRAINT [PK_Kế Hoạch Dạy Học] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 2]    Script Date: 4/6/2024 8:39:44 PM ******/
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
 CONSTRAINT [PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 3]    Script Date: 4/6/2024 8:39:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document 3](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[document1_id] [int] NULL,
	[user_id] [int] NULL,
	[status] [bit] NULL,
	[isApprove] [bit] NULL,
	[approve_by] [int] NULL,
 CONSTRAINT [PK_Kế hoạch giáo dục của GV] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document 4]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Document 5]    Script Date: 4/6/2024 8:39:44 PM ******/
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
 CONSTRAINT [PK_Phu Luc 5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document1_CurriculumDistribution]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Document1_SelectedTopics]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Document1_Subject Room]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Document1_TeachingEquipment]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Document2_Grade]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Feedback]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Form Category]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Grade]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Level Of Trainning]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Periodic Assessment]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Professional Standards]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Selected Topics]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Specialized Department]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Subject Room]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Teaching Equipment]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Teaching Planner]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[Testing Category]    Script Date: 4/6/2024 8:39:44 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 4/6/2024 8:39:44 PM ******/
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

INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id]) VALUES (15, N'dung', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'15', CAST(N'2023-04-06' AS Date), 1)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id]) VALUES (16, N'nam anh', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'15', CAST(N'2023-04-06' AS Date), 2)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id]) VALUES (17, N'nguyen hoang', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'15', CAST(N'2023-04-06' AS Date), 3)
INSERT [dbo].[Account] ([account_id], [username], [password], [active], [created_by], [created_date], [role_id]) VALUES (18, N'an', N'nRI4efp627o/pFBsLORlGA==;tNZp7dVxq4egNLNyYKrvUeI+p296CYTgVFAWwmqKED8=', 1, N'15', CAST(N'2023-04-06' AS Date), 5)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [name]) VALUES (1, N'.doc')
INSERT [dbo].[Category] ([Id], [name]) VALUES (2, N'.ppt')
INSERT [dbo].[Category] ([Id], [name]) VALUES (3, N'.pdf')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

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
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] ON 

INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (1, N'Thánh Gióng ')
INSERT [dbo].[Curriculum Distribution] ([id], [name]) VALUES (2, N'Sơn Tinh Thủy Tinh')
SET IDENTITY_INSERT [dbo].[Curriculum Distribution] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 1] ON 

INSERT [dbo].[Document 1] ([id], [name], [subject_id], [grade_id], [user_id], [note], [status], [approve_by], [isApprove]) VALUES (3, N'KẾ HOẠCH DẠY HỌC CỦA TỔ CHUYÊN MÔN MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC NGỮ VĂN, KHỐI LỚP 6', 2, 1, 9, NULL, 1, NULL, 0)
SET IDENTITY_INSERT [dbo].[Document 1] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 3] ON 

INSERT [dbo].[Document 3] ([id], [name], [document1_id], [user_id], [status], [isApprove], [approve_by]) VALUES (1, N'KẾ HOẠCH GIÁO DỤC CỦA GIÁO VIÊN
MÔN HỌC/HOẠT ĐỘNG GIÁO DỤC NGỮ VĂN, LỚP 6A1', 3, 9, 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[Document 3] OFF
GO
SET IDENTITY_INSERT [dbo].[Document 4] ON 

INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status]) VALUES (1, N'KeHoach1', NULL, NULL)
INSERT [dbo].[Document 4] ([id], [name], [teaching_planner_id], [status]) VALUES (2, N'KeHoach2', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Document 4] OFF
GO
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 1, 1, N'Mo ta 1')
INSERT [dbo].[Document1_CurriculumDistribution] ([document1_id], [curriculum_id], [slot], [description]) VALUES (3, 2, 1, N'Mo ta 2')
GO
INSERT [dbo].[Document1_Subject Room] ([subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (9, 3, 1, N'Mo ta 1 ', N'Ghi chu 1')
INSERT [dbo].[Document1_Subject Room] ([subject_room_id], [document1_id], [quantity], [description], [note]) VALUES (10, 3, 1, N'Ma ta 2 ', N'Ghi Chu 2')
GO
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 3, 1, N'ghi chu 1', N'mo ta 1')
INSERT [dbo].[Document1_TeachingEquipment] ([document1_id], [teaching_equipment_id], [quantity], [note], [description]) VALUES (3, 4, 1, N'ghi chu 2', N'ma ta 2')
GO
SET IDENTITY_INSERT [dbo].[Form Category] ON 

INSERT [dbo].[Form Category] ([id], [name]) VALUES (1, N'Tự Luận')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (2, N'Trắc Nghiệm')
INSERT [dbo].[Form Category] ([id], [name]) VALUES (3, N'Tự Luận Kết Hợp Trắc Nghiệm')
SET IDENTITY_INSERT [dbo].[Form Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (1, N'6', 1000, 60)
INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (2, N'7', 1000, 70)
INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (3, N'8', 1000, 80)
INSERT [dbo].[Grade] ([id], [name], [total_student], [total_student_selected_topics]) VALUES (4, N'9', 1000, 90)
SET IDENTITY_INSERT [dbo].[Grade] OFF
GO
SET IDENTITY_INSERT [dbo].[Level Of Trainning] ON 

INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (1, N'Junior College')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (2, N'Bachelor')
INSERT [dbo].[Level Of Trainning] ([id], [name]) VALUES (3, N'Above Bachlor')
SET IDENTITY_INSERT [dbo].[Level Of Trainning] OFF
GO
SET IDENTITY_INSERT [dbo].[Professional Standards] ON 

INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (1, N'Giáo viên Bậc 1')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (2, N'Giáo viên Bậc 2')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (3, N'Giáo viên Bậc 3')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (4, N'Giáo viên Bậc 4')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (5, N'Giáo viên Bậc 5')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (6, N'Giáo viên Bậc 6')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (7, N'Giáo viên Bậc 7')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (8, N'Giáo viên Bậc 8')
INSERT [dbo].[Professional Standards] ([id], [name]) VALUES (9, N'Giáo viên Bậc 9')
SET IDENTITY_INSERT [dbo].[Professional Standards] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (1, N'Admin', 1)
INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (2, N'Teacher', 1)
INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (3, N'Leader', 1)
INSERT [dbo].[Role] ([role_id], [role_name], [active]) VALUES (5, N'Principle', 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Selected Topics] ON 

INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (1, N'Tiếng Anh ')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (2, N'Chân trời sáng tạo')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (3, N'Cánh Diều')
INSERT [dbo].[Selected Topics] ([id], [name]) VALUES (4, N'Kết nối Tri Thức với cuộc sống')
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
SET IDENTITY_INSERT [dbo].[Subject] ON 

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
SET IDENTITY_INSERT [dbo].[Subject] OFF
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
SET IDENTITY_INSERT [dbo].[Testing Category] ON 

INSERT [dbo].[Testing Category] ([id], [name]) VALUES (1, N'5 Phút')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (2, N'15 Phút')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (3, N'30 Phút')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (14, N'45 Phút')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (15, N'90 Phút')
INSERT [dbo].[Testing Category] ([id], [name]) VALUES (16, N'120 Phút')
SET IDENTITY_INSERT [dbo].[Testing Category] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (8, N'dung', N'le', N'dungle@gmail.com', N'dung le', NULL, NULL, 1, NULL, 20, 1, 1, 15, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (9, N'nam ', N'anh', N'namanh@gmail.com', N'nam anh', NULL, NULL, 1, NULL, 21, 1, 2, 16, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (10, N'nguyen', N'hoang', N'nguyenhoang@gmail.com', N'nguyen hoang', NULL, NULL, 1, NULL, 22, 1, 3, 17, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[User] ([id], [first_name], [last_name], [email], [full_name], [photo], [address], [gender], [place_of_birth], [age], [level_of_trainning_id], [specialized_department_id], [account_id], [professional_standards_id], [created_by], [created_date], [modified_by], [modified_date], [active]) VALUES (11, N'an', N'an', N'an@gmail.com', N'an an', NULL, NULL, 1, NULL, 23, 1, 4, 18, 1, NULL, NULL, NULL, NULL, 1)
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
ALTER TABLE [dbo].[Doc]  WITH CHECK ADD  CONSTRAINT [FK_Doc_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Doc] CHECK CONSTRAINT [FK_Doc_Category]
GO
ALTER TABLE [dbo].[Doc]  WITH CHECK ADD  CONSTRAINT [FK_Doc_Document 4] FOREIGN KEY([document4_id])
REFERENCES [dbo].[Document 4] ([id])
GO
ALTER TABLE [dbo].[Doc] CHECK CONSTRAINT [FK_Doc_Document 4]
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
ALTER TABLE [dbo].[Document 4]  WITH CHECK ADD  CONSTRAINT [FK_Document 4_Teaching Planner] FOREIGN KEY([teaching_planner_id])
REFERENCES [dbo].[Teaching Planner] ([Id])
GO
ALTER TABLE [dbo].[Document 4] CHECK CONSTRAINT [FK_Document 4_Teaching Planner]
GO
ALTER TABLE [dbo].[Document 5]  WITH CHECK ADD  CONSTRAINT [FK_Document 5_Document 4] FOREIGN KEY([document4_id])
REFERENCES [dbo].[Document 4] ([id])
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
ALTER TABLE [dbo].[Document1_CurriculumDistribution]  WITH CHECK ADD  CONSTRAINT [FK_Document1_CurriculumDistribution_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_CurriculumDistribution] CHECK CONSTRAINT [FK_Document1_CurriculumDistribution_Document 1]
GO
ALTER TABLE [dbo].[Document1_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document1_SelectedTopics_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_SelectedTopics] CHECK CONSTRAINT [FK_Document1_SelectedTopics_Document 1]
GO
ALTER TABLE [dbo].[Document1_SelectedTopics]  WITH CHECK ADD  CONSTRAINT [FK_Document1_SelectedTopics_Selected Topics] FOREIGN KEY([selected_topics_id])
REFERENCES [dbo].[Selected Topics] ([id])
GO
ALTER TABLE [dbo].[Document1_SelectedTopics] CHECK CONSTRAINT [FK_Document1_SelectedTopics_Selected Topics]
GO
ALTER TABLE [dbo].[Document1_Subject Room]  WITH CHECK ADD  CONSTRAINT [FK_Document1_Subject Room_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_Subject Room] CHECK CONSTRAINT [FK_Document1_Subject Room_Document 1]
GO
ALTER TABLE [dbo].[Document1_Subject Room]  WITH CHECK ADD  CONSTRAINT [FK_Document1_Subject Room_Subject Room] FOREIGN KEY([subject_room_id])
REFERENCES [dbo].[Subject Room] ([id])
GO
ALTER TABLE [dbo].[Document1_Subject Room] CHECK CONSTRAINT [FK_Document1_Subject Room_Subject Room]
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment]  WITH CHECK ADD  CONSTRAINT [FK_Document1_TeachingEquipment_Document 1] FOREIGN KEY([document1_id])
REFERENCES [dbo].[Document 1] ([id])
GO
ALTER TABLE [dbo].[Document1_TeachingEquipment] CHECK CONSTRAINT [FK_Document1_TeachingEquipment_Document 1]
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
ALTER TABLE [dbo].[Document2_Grade]  WITH CHECK ADD  CONSTRAINT [FK_Document2_Grade_Grade] FOREIGN KEY([grade_id])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Document2_Grade] CHECK CONSTRAINT [FK_Document2_Grade_Grade]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
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
