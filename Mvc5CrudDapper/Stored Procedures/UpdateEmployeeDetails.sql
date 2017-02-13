Create Procedure [dbo].[UpdateEmployeeDetails]
(
	@Id int,
	@Name varchar (50),
	@City varchar (50),
	@Address varchar (50)
)
As
Begin
	Update Employees
	Set Name = @Name,
	City = @City,
	Address = @Address 
	Where Id = @Id
End