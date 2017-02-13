Create Procedure [dbo].[AddNewEmployeeDetails]
(
	@Name varchar (50),
	@City varchar (50),
	@Address varchar (50)
)
As
Begin
	Insert Into Employees Values (@Name, @City, @Address)
End