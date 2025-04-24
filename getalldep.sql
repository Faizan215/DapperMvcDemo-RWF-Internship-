USE [saniya]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllDepartments]    Script Date: 23-04-2025 19:45:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllDepartments]
AS
BEGIN
    SELECT Id, Name FROM Department;
END
GO

