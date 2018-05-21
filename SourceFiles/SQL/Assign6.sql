

/*
~	~	~	~	~	~	~	~	~	~

	Name:		Tom Eisenbrandt
	ZID:		Z1771209
	Class:		CSCI 466
	Section:	2
	Project:	5
	Due:		October 18th 2017 11:59PM

~	~	~	~	~	~	~	~	~	~
*/

use classicmodels ;




/*
#1
How many employees work in each city?
List the city name.
*/

Select
Count(Employees.officeCode), 
Offices.officeCode, 
Offices.city
From
Employees, 
Offices
Group by
Offices.city
Order by
Offices.city
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
#2
List each Employee First Name and Last Name 
and the number of customers for each one.
*/

Select
Count(Customers.salesRepEmployeeNumber), 
Employees.lastName, 
Employees.firstName
From 
Customers, 
Employees
Where
Customers.salesRepEmployeeNumber = Employees.employeeNumber
Group by
Employees.employeeNumber
Order by
Employees.lastName
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
#3
For the first 25 customers 
list the First and Last Name and the total amount of payments.
*/

Select
Customers.contactLastName,
Customers.contactFirstName,
Customers.customerNumber,
Payments.customerNumber,
Payments.amount
From
Customers, 
Payments
Where
Customers.customerNumber = Payments.customerNumber
Group by
Customers.customerNumber
Order by
Customers.contactLastName
Limit 25 
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
#4
How many customers live in the same city as their sales rep works?
*/

Select
Count( Customers.city ),
Offices.officeCode,
Offices.city
From
Customers, 
Offices
Where
Customers.city = Offices.city
Group by
Customers.salesRepEmployeeNumber
Order by
Offices.officeCode
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
#5
How many customers live in the same city as their sales rep works? 
List the name of the city and the number of customers.
*/

Select
Count( Customers.city ),
Offices.officeCode,
Offices.city
From
Customers, 
Offices
Where
Customers.city = Offices.city
Group by
Customers.salesRepEmployeeNumber
Order by
Offices.officeCode
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
#6
Which customer (just the customer name) has ordered the most expensive product? 
(based on the buyPrice)
*/

Select
Customers.customerName,
Max( Products.buyPrice )
From
Customers,
Products,
OrderDetails,
Orders
Where
OrderDetails.orderNumber = Orders.orderNumber
And
Orders.customerNumber = Customers.customerNumber
And
Products.productCode = OrderDetails.productCode
And
OrderDetails.orderNumber = Orders.orderNumber
Order by
Customers.customerName
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
#7
Which customer has made the largest payment? 
list just the customer name.
*/

Select
Customers.customerName
From
Customers,
Payments
Where
Customers.customerNumber = Payments.customerNumber
Order by
Payments.amount
Desc
Limit 1
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
#8
List all of the product descriptions for products from 
Min Lin Diecast and Exoto Designs. 
Do this in at least two different ways
(Don't use wild cards)
*/

/*
Part 1
*/

Select
Products.productDescription
From
Products
Where
Products.productVendor 
in 
( 'Min Lin Diecast','Exoto Designs' )
Order by
Products.productDescription
;

/*
Part 2
*/

Select
Products.productDescription
From
Products
Where
Products.productVendor = 'Min Lin Diecast'
Or
Products.productVendor = 'Exoto Designs'
Order by
Products.productDescription
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
EXTRE CREDIT
Part 1
For the first 10 orders, 
list the order number, 
the customer name
and all of the product names on that order 
in ascending order of customer name.
*/

Select
Orders.orderNumber,
Customers.customerName,
Products.productName
From
Orders,
OrderDetails,
Customers,
Products
Where
Customers.customerNumber = Orders.customerNumber
And
Orders.orderNumber = OrderDetails.orderNumber
And
OrderDetails.productCode = Products.productCode
Order by
Customers.customerName
Limit 10
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
EXTRE CREDIT
Part 2
What is the average dollar amount for each order?
*/

Select
AVG( Payments.amount )
As
'Average Cost'
From
Payments
;

/*
~	~	~	~	~	~	~	~	~	~
*/

/*
	END
*/


