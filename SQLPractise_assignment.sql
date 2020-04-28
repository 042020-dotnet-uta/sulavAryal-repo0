SELECT FirstName + ' ' + LastName AS FullName, CustomerId, Country
FROM Customer
WHERE Country != 'USA';

SELECT FirstName + ' ' + LastName AS FullName, Country
FROM Customer
WHERE Country = 'Brazil';

SELECT *
FROM Employee
WHERE Title Like '%Sales%Agent';

SELECT BillingAddress, BillingCountry
FROM Invoice
ORDER BY BillingCountry;

SELECT COUNT (InvoiceId) AS InvoiceCount, SUM (Total) AS SalesTotal
FROM Invoice
WHERE InvoiceDate LIKE '%2009%';

SELECT COUNT (*)
FROM InvoiceLine
WHERE InvoiceId = '37';

select Count(*) as NumberofCountry, BillingCountry
From Invoice 
Group By BillingCountry;

select SUM(Total) as 'Country Sales', BillingCountry
From Invoice 
Group By BillingCountry Order By [Country Sales] DESC;







