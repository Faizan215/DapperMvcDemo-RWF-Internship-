USE [saniya]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetPersonsByDepartment]    Script Date: 23-04-2025 19:46:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetPersonsByDepartment]
    @DepartmentId INT
AS
BEGIN
    SELECT p.Id, p.Name, p.Email, p.Address, p.DepartmentId, d.Name AS DepartmentName
    FROM Person p
    JOIN Department d ON p.DepartmentId = d.Id
    WHERE p.DepartmentId = @DepartmentId;
END
GO

