create database Ticker;

USE [Ticker]
GO

/****** Object:  Table [dbo].[Ticker_history]    Script Date: 19.02.2023 22:25:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ticker_history](
	[id] [int] NULL,
	[sub_id] [int] NULL,
	[days_history] [int] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Ticker_names](
	[id] [int] NULL,
	[type] [int] NULL,
	[name] [nchar](10) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Ticker_prices](
	[sub_id] [int] NOT NULL,
	[date] [nchar](10) NOT NULL,
	[open] [decimal](18, 2) NULL,
	[high] [decimal](18, 2) NULL,
	[low] [decimal](18, 2) NULL,
	[close] [decimal](18, 2) NULL,
	[volume] [decimal](18, 2) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Ticker_purchase_date](
	[sub_id] [int] NULL,
	[purchase_date] [nvarchar](10) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Ticker_volumes](
	[id] [int] NULL,
	[volume] [decimal](18, 5) NULL
) ON [PRIMARY]
GO




