create database SaintGobain
use SaintGobain

create table Student (
       StudentName varchar(50),
	   DOB date,
	   Age int,
	   FatherName varchar(50),
	   Address varchar(50),
	   Course varchar(50),
	   SemesterFees int,
	   HostelFees int,
	   TotalFees int
)
select * from Student order by StudentName
delete from Student where Age=11
select @@SERVERNAME