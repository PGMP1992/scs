-- SQL File to Delete all tables in SCS Db
-- Author: Pedro Martinez
-- 
USE [SCS]
GO

DELETE FROM [dbo].[AspNetUsers]
GO

DELETE FROM [dbo].[Addresses]
GO

DELETE FROM [dbo].[Products]
GO

DELETE FROM [dbo].[ProductImages]
GO

DELETE FROM [dbo].[CertificationSlots]
GO

DELETE FROM [dbo].[Carts]
GO

DELETE FROM [dbo].[OrderHeaders]
GO

DELETE FROM [dbo].[OrderDetails]
GO




