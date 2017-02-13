Create Procedure [dbo].[GetEmployees]
As
Begin
	Select Id As EmployeeId, Name, City, Address From Employees
End