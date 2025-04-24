USE [saniya]
GO

/****** Object:  StoredProcedure [dbo].[sp_SearchPersons]    Script Date: 23-04-2025 19:46:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SearchPersons]
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT p.Id, p.Name, p.Email, p.Address, p.DepartmentId, d.Name AS DepartmentName
    FROM Person p
    JOIN Department d ON p.DepartmentId = d.Id
    WHERE p.Name LIKE @SearchTerm OR p.Email LIKE @SearchTerm;
END
GO

