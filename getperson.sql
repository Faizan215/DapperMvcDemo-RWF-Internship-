USE [saniya]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_person]    Script Date: 23-04-2025 19:45:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_get_person]
    @Id INT
AS
BEGIN
    SELECT p.Id, p.Name, p.Email, p.Address, p.DepartmentId, d.Name AS DepartmentName 
    FROM Person p 
    JOIN Department d ON p.DepartmentId = d.Id
    WHERE p.Id = @Id;
END
GO

