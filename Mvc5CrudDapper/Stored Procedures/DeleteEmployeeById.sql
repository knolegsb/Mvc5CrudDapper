Create Procedure [dbo].[DeleteEmployeeById]
(
	@Id int
)
As
Begin
	Delete From Employees Where Id = @Id
End