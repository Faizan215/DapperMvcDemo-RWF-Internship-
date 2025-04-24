USE [saniya]
GO

/****** Object:  StoredProcedure [dbo].[sp_update_person]    Script Date: 23-04-2025 19:46:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_update_person]
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255),
    @DepartmentId INT
AS
BEGIN
    UPDATE Person 
    SET Name = @Name, Email = @Email, Address = @Address, DepartmentId = @DepartmentId
    WHERE Id = @Id;
END
GO

