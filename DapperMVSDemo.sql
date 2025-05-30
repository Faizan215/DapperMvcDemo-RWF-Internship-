USE [DapperMvcDemo]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 28-02-2025 12:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Department] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddDepartment]    Script Date: 28-02-2025 12:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddDepartment]  
    @Department NVARCHAR(100)  
AS  
BEGIN  
    INSERT INTO dbo.Person (Department)  
    VALUES (@Department);  
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_create_person]    Script Date: 28-02-2025 12:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [dbo].[sp_create_person](
@name nvarchar(100),
@email nvarchar(100),
@address nvarchar(200),
@department nvarchar(200)
)
as
begin
  insert into dbo.Person (Name , Email, [Address],Department)
  values(@name,@email,@address,@department)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_person]    Script Date: 28-02-2025 12:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_delete_person]( @id int)
as

begin
 select * from dbo.Person where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_get_people]    Script Date: 28-02-2025 12:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_get_people]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ISNULL(Id, 0) AS Id,  -- ✅ Replaces NULL with 0
        Name,
        Email,
        Address,
		Department
    FROM Person;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_get_person]    Script Date: 28-02-2025 12:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_get_person](
@id int
)
as
begin
 select * from dbo.Person
 where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_update_person]    Script Date: 28-02-2025 12:56:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_update_person](
@id int,
@name nvarchar(100),
@email nvarchar(100),
@address nvarchar(200)
)
as
begin
  update dbo.Person set name=@name, email=@email, [address]=@address
  where id=@id
end
GO
