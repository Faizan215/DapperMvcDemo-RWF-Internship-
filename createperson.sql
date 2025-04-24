USE [saniya]
GO

/****** Object:  StoredProcedure [dbo].[sp_create_person]    Script Date: 23-04-2025 19:45:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_create_person]
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255),
    @DepartmentId INT
AS
BEGIN
    INSERT INTO Person (Name, Email, Address, DepartmentId) 
    VALUES (@Name, @Email, @Address, @DepartmentId);
END
GO

