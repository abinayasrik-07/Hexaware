create database CarConnect

use CarConnect


-- 1. Customer Table


create table Customer
(
CustomerID int primary key not null,
FirstName varchar(25),
LastName varchar(25),
Email varchar(50),
PhoneNumber bigint,
[Address] varchar(50),
Username varchar(30) unique,
[Password] varchar(30),
RegistrationDate date
)

insert into Customer (CustomerID, FirstName, LastName, PhoneNumber, [Address], Username)
values (111, 'Abi', 'Sri', 1234567899, 'Coimbatore', 'abisri07'),
	   (112, 'Karishma', 'Carolin', 1345678901, 'Chennai', 'karishma06')

update Customer
set Email = Lower(FirstName+ '' +LastName+ '@gmail.com')

select * from Customer

/*
insert into Customer
values (111, 'Abi', 'Sri', 'abisri@gmail.com', 1234567899, 'Coimbatore'),
	   (112, 'Karishma', 'Carolin', 'karishmacarolin@gmail.com', 1345678901, 'Chennai'),
	   (113, 'Nivetha', 'Angel', 'nivethangel@gmail.com', 1456789012, 'Erode'),
	   (114, 'Sri', 'Mathi', 'srimathi@gmail.com', 1567890123, 'Pondicherry'),
	   (115, 'Oveya', 'Thean', 'oveyathean@gmail.com', 1678901234, 'Banglore'),
	   (116, 'Kavya', 'Dharsh', 'kavyadharsh@gmail.com', 1789012345, 'Hyderabad'),
	   (117, 'Brindha', 'Sri', 'brindhasri@gmail.com', 1890123456, 'Jammu&Kashmir'),
	   (118, 'Cathrine', 'Therasa', 'cathrinetherasa@gmail.com', 1901234567, 'UttarPradesh'),
	   (119, 'Bhakya', 'Lakshmi', 'bhakyalakshmi@gmail.com', 11012345678, 'Delhi'),
	   (120, 'Siva', 'Priya', 'sivapriya@gmail.com', 1123456789, 'Mumbai')
*/



--2. Vehicle Table


create table Vehicle
(
VehicleID int primary key not null,
Model varchar(25),
Make varchar(25),
[Year] int,
Color varchar(15),
RegistrationNo int unique,
[Availability] varchar(10),
DailyRate decimal(8, 2)
)

select * from Vehicle


--3. Reservation Table


create table Reservation
(
ReservationID int primary key not null,
CustomerID int,
VehicleID int,
StartDate date,
EndDate date,
TotalCost decimal(8, 2),
[Status] varchar(15),
constraint FK_Reservation
foreign key (CustomerID) references Customer(CustomerID)
on delete cascade,
foreign key (VehicleID) references Vehicle(VehicleID)
on delete cascade
)
drop table Reservation
select * from Reservation


-- 4. Admin Table


create table [Admin]
(
AdminID int primary key not null,
FirstName varchar(25),
LastName varchar(25),
Email varchar(50),
PhoneNumber bigint,
Username varchar(30) unique,
[Password] varchar(30),
[Role] varchar(30),
JoinDate date
)

select * from [Admin]