# guild-dapper-ef-demo
Demo for guild session on Dapper-EntityFramework

Please follow below steps to run on local:
1. Create the database on local sql server
2. Update the conn string in App.config file 
3. For Dapper - update LocalConnectionString
4. For Entity Framework - update SchoolContext
5. Create Sproc on newly created database
--------------------------------

--SQL Stored Procedure <br/>
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteEmployeeByFirstName]	
	@FirstName VARCHAR(50)
AS
BEGIN    
	DELETE FROM dbo.Employee WHERE FirstName = @FirstName;
END

--------------------------------
6. Uncomment Program.cs Line # 18 and comment Line # 19 to run the Dapper Demo
7. Uncomment Program.cs Line # 19 and comment Line # 18 to run the Entity Framework Demo
