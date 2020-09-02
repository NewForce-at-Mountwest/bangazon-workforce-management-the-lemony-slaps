USE MASTER
 GO

 IF NOT EXISTS (
     SELECT [name]
     FROM sys.databases
     WHERE [name] = N'BangazonMVC'
 )
 CREATE DATABASE BangazonMVC
 GO

 USE BangazonMVC
 GO

 -- ALTER TABLE Employee DROP CONSTRAINT [FK_EmployeeDepartment];
 -- ALTER TABLE ComputerEmployee DROP CONSTRAINT [FK_ComputerEmployee_Employee];
 -- ALTER TABLE ComputerEmployee DROP CONSTRAINT [FK_ComputerEmployee_Computer];
 -- ALTER TABLE EmployeeTraining DROP CONSTRAINT [FK_EmployeeTraining_Employee];
 -- ALTER TABLE EmployeeTraining DROP CONSTRAINT [FK_EmployeeTraining_Training];
 -- ALTER TABLE Product DROP CONSTRAINT [FK_Product_ProductType];
 -- ALTER TABLE Product DROP CONSTRAINT [FK_Product_Customer];
 -- ALTER TABLE PaymentType DROP CONSTRAINT [FK_PaymentType_Customer];
 -- ALTER TABLE [Order] DROP CONSTRAINT [FK_Order_Customer];
 -- ALTER TABLE [Order] DROP CONSTRAINT [FK_Order_Payment];
 -- ALTER TABLE OrderProduct DROP CONSTRAINT [FK_OrderProduct_Product];
 -- ALTER TABLE OrderProduct DROP CONSTRAINT [FK_OrderProduct_Order];


 DROP TABLE IF EXISTS OrderProduct;
 DROP TABLE IF EXISTS ComputerEmployee;
 DROP TABLE IF EXISTS EmployeeTraining;
 DROP TABLE IF EXISTS Employee;
 DROP TABLE IF EXISTS TrainingProgram;
 DROP TABLE IF EXISTS Computer;
 DROP TABLE IF EXISTS Department;
 DROP TABLE IF EXISTS [Order];
 DROP TABLE IF EXISTS PaymentType;
 DROP TABLE IF EXISTS Product;
 DROP TABLE IF EXISTS ProductType;
 DROP TABLE IF EXISTS Customer;

 CREATE TABLE Department (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Budget 	INTEGER NOT NULL
);

CREATE TABLE Employee (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	FirstName VARCHAR(55) NOT NULL,
	LastName VARCHAR(55) NOT NULL,
	DepartmentId INTEGER NOT NULL,
	IsSuperVisor BIT NOT NULL DEFAULT(0),
    CONSTRAINT FK_EmployeeDepartment FOREIGN KEY(DepartmentId) REFERENCES Department(Id)
);

CREATE TABLE Computer (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	PurchaseDate DATETIME NOT NULL,
	DecomissionDate DATETIME,
	Make VARCHAR(55) NOT NULL,
	Manufacturer VARCHAR(55) NOT NULL
);

CREATE TABLE ComputerEmployee (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	EmployeeId INTEGER NOT NULL,
	ComputerId INTEGER NOT NULL,
	AssignDate DATETIME NOT NULL,
	UnassignDate DATETIME,
    CONSTRAINT FK_ComputerEmployee_Employee FOREIGN KEY(EmployeeId) REFERENCES Employee(Id),
    CONSTRAINT FK_ComputerEmployee_Computer FOREIGN KEY(ComputerId) REFERENCES Computer(Id)
);


CREATE TABLE TrainingProgram (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(255) NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	MaxAttendees INTEGER NOT NULL
);

CREATE TABLE EmployeeTraining (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	EmployeeId INTEGER NOT NULL,
	TrainingProgramId INTEGER NOT NULL,
    CONSTRAINT FK_EmployeeTraining_Employee FOREIGN KEY(EmployeeId) REFERENCES Employee(Id),
    CONSTRAINT FK_EmployeeTraining_Training FOREIGN KEY(TrainingProgramId) REFERENCES TrainingProgram(Id)
);

CREATE TABLE ProductType (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL
);

CREATE TABLE Customer (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	FirstName VARCHAR(55) NOT NULL,
	LastName VARCHAR(55) NOT NULL,
	CreationDate DATETIME NOT NULL,
	LastActiveDate DATETIME NOT NULL
);

CREATE TABLE Product (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	ProductTypeId INTEGER NOT NULL,
	CustomerId INTEGER NOT NULL,
	Price MONEY NOT NULL,
	Title VARCHAR(255) NOT NULL,
	[Description] VARCHAR(255) NOT NULL,
	Quantity INTEGER NOT NULL,
    CONSTRAINT FK_Product_ProductType FOREIGN KEY(ProductTypeId) REFERENCES ProductType(Id),
    CONSTRAINT FK_Product_Customer FOREIGN KEY(CustomerId) REFERENCES Customer(Id)
);


CREATE TABLE PaymentType (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	AcctNumber VARCHAR(55) NOT NULL,
	[Name] VARCHAR(55) NOT NULL,
	CustomerId INTEGER NOT NULL,
    CONSTRAINT FK_PaymentType_Customer FOREIGN KEY(CustomerId) REFERENCES Customer(Id)
);

CREATE TABLE [Order] (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	CustomerId INTEGER NOT NULL,
	PaymentTypeId INTEGER,
    CONSTRAINT FK_Order_Customer FOREIGN KEY(CustomerId) REFERENCES Customer(Id),
    CONSTRAINT FK_Order_Payment FOREIGN KEY(PaymentTypeId) REFERENCES PaymentType(Id)
);

CREATE TABLE OrderProduct (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	OrderId INTEGER NOT NULL,
	ProductId INTEGER NOT NULL,
    CONSTRAINT FK_OrderProduct_Product FOREIGN KEY(ProductId) REFERENCES Product(Id),
    CONSTRAINT FK_OrderProduct_Order FOREIGN KEY(OrderId) REFERENCES [Order](Id)
);


INSERT INTO ProductType VALUES ('Red Meat');
INSERT INTO ProductType VALUES ('Fish');

INSERT INTO Customer (FirstName, LastName, CreationDate, LastActiveDate) VALUES ('Sarah', 'Brooks', '2020-01-01', '2020-08-18');
INSERT INTO Customer (FirstName, LastName, CreationDate, LastActiveDate) VALUES ('Derek', 'Stapleton', '2019-12-17', '2020-03-14');
INSERT INTO Customer (FirstName, LastName, CreationDate, LastActiveDate) VALUES ('Mandy', 'Campbell', '2015-06-01', '2020-08-18');
INSERT INTO Customer (FirstName, LastName, CreationDate, LastActiveDate) VALUES ('Princess', 'Shithead', '2016-08-01', '2020-08-20');

INSERT INTO Product (ProductTypeId, CustomerId, Price, Title, Description, Quantity) VALUES (1, 1, 10.99, 'Salmon sandwhich', 'This is a salmon sanwhich!', 1);
INSERT INTO Product (ProductTypeId, CustomerId, Price, Title, Description, Quantity) VALUES (2, 1, 10.99, 'Roast Beef sandwhich', 'This is a roast beef sanwhich!', 1);

INSERT INTO PaymentType VALUES ('1234567890', 'VISA', 1);
INSERT INTO PaymentType VALUES ('3456789120', 'MC', 2);

INSERT INTO Department VALUES ('Accounting', 5000);
INSERT INTO Department VALUES ('Marketing', 7500);
INSERT INTO Department VALUES ('IT', 12000);
INSERT INTO Department VALUES ('HR', 2500);

INSERT INTO Employee VALUES ('Pat', 'Shaver', 3, 0);
INSERT INTO Employee VALUES ('Derek', 'Stapleton', 4, 1);
INSERT INTO Employee VALUES ('Sarah', 'Brooks', 2, 1);
INSERT INTO Employee VALUES ('Mandy', 'Campbell', 1, 0);

INSERT INTO TrainingProgram VALUES ('Introduction to Marketing', '2020-09-29', '2020-10-05', 15);
INSERT INTO TrainingProgram VALUES ('Introduction to Accounting', '2020-06-01', '2020-06-06', 25);
INSERT INTO TrainingProgram VALUES ('Human Resources Today', '2020-10-20', '2020-10-25', 10);
INSERT INTO TrainingProgram VALUES ('Customer Service Best Practices', '2020-01-02', '2020-01-05', 30);
INSERT INTO TrainingProgram VALUES ('Computer Hardware', '2020-11-10', '2020-11-15', 20);

INSERT INTO EmployeeTraining VALUES (1, 5);
INSERT INTO EmployeeTraining VALUES (2, 3);
INSERT INTO EmployeeTraining VALUES (3, 1);
INSERT INTO EmployeeTraining VALUES (4, 2);
INSERT INTO EmployeeTraining VALUES (2, 4);


INSERT INTO Computer VALUES ('2020-01-01', null, 'Laptop', 'HP');
INSERT INTO Computer VALUES ('2017-03-01', '2019-05-01', 'Server', 'IBM');
INSERT INTO Computer VALUES ('2020-05-01', null, 'Notebook', 'DELL');
INSERT INTO Computer VALUES ('2019-10-10', null, 'Notebook', 'HP');
INSERT INTO Computer VALUES ('2018-01-01', '2020-01-31', 'Tower', 'HP');
INSERT INTO Computer VALUES ('2020-02-20', null, 'Server', 'HP');
INSERT INTO Computer VALUES ('2020-06-15', null, 'Desktop', 'DELL');


INSERT INTO ComputerEmployee VALUES (1, 2, '2017-03-14', '2019-05-01');
INSERT INTO ComputerEmployee VALUES (1, 6, '2019-05-01', null);
INSERT INTO ComputerEmployee VALUES (2, 5, '2018-01-15', '2019-10-01');
INSERT INTO ComputerEmployee VALUES (2, 4, '2019-10-11', null);
INSERT INTO ComputerEmployee VALUES (3, 7, '2020-07-01', null);
INSERT INTO ComputerEmployee VALUES (4, 1, '2020-03-14', null);

