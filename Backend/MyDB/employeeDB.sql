CREATE DATABASE EmployeeDB

create table dbo.Departments 
(
	DepartmentID int IDENTITY(1,1) NOT NULL,
	DepartmentName varchar(1000)
)

select * from Departments

insert into Departments values ('Finance')
insert into Departments values ('Software')

create table dbo.Employees
(
	EmployeeID int IDENTITY(1,1) NOT NULL,
	EmployeeName varchar(1000),
	Department varchar(1000),
	MailID varchar(1000), 
	DateOfJoining date
)

select * from Employees

insert into Employees values ('Tuðba','Software','tugbakac45@gmail.com','8-15-2020')
insert into Employees values('Deneme','Finance','deneme@mail.com','8-15-2020')

select DepartmentID,DepartmentName from Departments

select EmployeeID,EmployeeName,Department,MailID,CONVERT(varchar(10),DateOfJoining,120) as DOJ from Employees