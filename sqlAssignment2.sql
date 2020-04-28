CREATE DATABASE employeeinfo;
go
use employeeinfo;
CREATE TABLE Department(
ID int NOT NULL, PRIMARY KEY (ID),
[Name] varchar(255),
[Location] varchar(255),
);
CREATE TABLE Employee(
	ID int NOT NULL, PRIMARY KEY (ID),
	FirstName varchar(255),
	LastName varchar(255),
	SSN int,
	DeptID int FOREIGN KEY REFERENCES Department(ID),
);
CREATE TABLE EmpDetails(
ID int NOT NULL, PRIMARY KEY (ID),
EmployeeID int FOREIGN KEY REFERENCES Employee(ID),
Salary decimal NOT NULL,
[Address 1] varchar(255) NOT NULL,
[Address 2] varchar(255) NOT NULL,
City varchar(255) NOT NULL,
[State] varchar(255) NOT NULL,
Country varchar(255) NOT NULL,
);
*******************************************************************************************
INSERT INTO Department (Name, Location)
VALUES ('Marketing', ' 858 Trusel Court
    Danvers, MA 01923'), ('Finance', '35 Silver Spear St.
    Wappingers Falls, NY 12590'), ('HR', '7681 South Glen Ridge Lane
    East Elmhurst, NY 11369');
*******************************************************************************************
INSERT INTO Employee (FirstName, LastName, SSN)
VALUES ('Tina', 'Smith', '764-82-7328'), ('David', 'Aguilar', '402-69-2991'), ('Sulav', 'Aryal', '222-56-8590');
*******************************************************************************************
INSERT INTO EmpDetails
    (EmployeeID)
SELECT
    '1' AS EmployeeID
FROM
    Employee WHERE FirstName = 'Tina';
*******************************************************************************************
INSERT INTO EmpDetails (EmployeeID, Salary, [Address 1], [Address 2], City, State, Country)
VALUES ('SELECT (ID) FROM Employee WHERE ID = 1', '45000', '399 San Pablo Street
Ridgefield, CT 06877', '91 Green Lake Dr.
Coram, NY 11727', 'Ridgefield', 'CT', 'USA'),
('SELECT (ID) FROM Employee WHERE ID = 2', '45000', '380 E. Beach Drive
Taylor, MI 48180', '', 'Taylor', 'MI', 'USA'),
('SELECT (ID) FROM Employee WHERE ID = 3', '45000', '84 Rockaway Ave.
Bensalem, PA 19020', '', 'Bensalem', 'PA', 'USA');



-- add at least 3 records into each table.
-- add department Marketing
INSERT INTO Department (Name, Location)
VALUES ('Marketing', '406 Oklahoma St.
Teaneck, NJ 07666'), ('Billing', '406 Oklahoma St.
Teaneck, NJ 07666'), ('Human Resources', '406 Oklahoma St.
Teaneck, NJ 07666');
-- add employee Tina Smith
INSERT INTO Employee (FirstName, LastName, SSN, DeptID)
VALUES ('Tina', 'Smith', '123-45-6789', (SELECT ID FROM Department WHERE Name = 'Marketing')),
('John', 'Kear', '987-65-4321', (SELECT ID FROM Department WHERE Name = 'Billing')),
('Arthur', 'Pendragon', '789-56-4321', (SELECT ID FROM Department WHERE Name = 'Human Resources'));
INSERT INTO EmpDetails (EmployeeID, Salary, Address1, City, State, Country)
VALUES ((SELECT ID FROM Employee WHERE FirstName = 'Tina'), 45000, '7174 Bridge Ave.', 'Wethersfield', 'Conneticut', '06109'),
((SELECT ID FROM Employee WHERE FirstName = 'John'), 35000, '727 Valley Dr.', 'Neptune', 'New Jersey', '07753'),
((SELECT ID FROM Employee WHERE FirstName = 'Arthur'), 45000, '7174 Bridge Ave.', 'Wethersfield', 'Conneticut', '06109');
-- list all employees in Marketing
SELECT * FROM Employee WHERE DeptID = (SELECT ID FROM Department WHERE Name = 'Marketing');
-- report total salary of marketing
SELECT SUM(Salary) AS 'Marketing Salaries' FROM EmpDetails WHERE EmployeeID = (SELECT ID FROM Employee WHERE DeptID = (SELECT ID FROM Department WHERE Name = 'Marketing'))
-- report total employees by department.
SELECT
	d.Name,
	COUNT(*) headcount
FROM
	Employee e
INNER JOIN Department d ON d.ID = e.DeptID
GROUP BY
	d.Name ORDER BY d.Name ASC;
-- increase salary of Tina Smith to $90,000
UPDATE EmpDetails
SET Salary = 90000
Where EmployeeID = (SELECT ID FROM Employee WHERE FirstName = 'Tina')
SELECT Salary FROM EmpDetails WHERE EmployeeID = (SELECT ID FROM Employee WHERE FirstName = 'Tina');





