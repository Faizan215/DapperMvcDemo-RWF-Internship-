USE [saniya]
GO

/****** Object:  StoredProcedure [dbo].[sp_delete_person]    Script Date: 23-04-2025 19:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_delete_person]
    @Id INT
AS
BEGIN
    DELETE FROM Person WHERE Id = @Id;
END
GO

