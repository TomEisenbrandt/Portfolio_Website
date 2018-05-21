/*
Name:		Tom Eisenbrandt
ZID:		Z1771209
Class:		CSCI 466
Section:	2
Project:	Assignment 5
Due:		Monday October 9th 2017
*/

/*
CSCI 466/566 Assignment 5 Fall 2017

SQL using a single table

100 points

For this assignment you will be using the classic models database on our unix system. 
Test your queries, then put them in a script named your_zid.sql, with comments. 
(for example z1234567.sql)
Run the script in MySQL putting the output into a file named your_zid.txt
(for example z1234567.txt).
*/

/*	~	~	~	~	~	*/

/*	1.	How many tables are there and what are their names?		*/
show tables ;
/*	Number of returned rows = table count	*/

/*	~	~	~	~	~	*/

/*	2.	What are the column names and domains for each table?	*/ 
select * from information_schema.columns where table_schema = 'classicmodels' ;

/*	~	~	~	~	~	*/

/*	3.	*/ 
/*	(A)	How many customers are there?	*/
select count(customerNumber) from Customers ;

/*	(B)	How many customers have orders?	*/
select count(customerNumber) from Orders ;

/*	~	~	~	~	~	*/

/*	4.	*/
/*	(A)	How many products are there?	*/
select count(productCode) from Products ;

/*	(B)	List all the details for the first 10 products.(Use limit)	*/
select * from Products order by productCode desc limit 10 ;

/*	~	~	~	~	~	*/

/*	5.		What is the total payment amount for each customer who has made a payment? 
			list only the first 15.	*/
select sum(amount) from Payments order by customerNumber desc limit 15 ;

/*	~	~	~	~	~	*/

/*	6.	What are the names of the cities where there are offices? 
		List them in alphabetic order.	*/
select city from Offices order by city ;

/*	~	~	~	~	~	*/

/*	7.	*/
/*	(A)	How many employees are there?	*/
select count(employeeNumber) from Employees ;

/*	(B)	How many employees work in each office?	
	List the count and the office code.	*/
select count(officeCode), officeCode from Employees group by officeCode ;

/*	~	~	~	~	~	*/

/*	9.	*/
/*	(A)	How many orders are there?	*/
select count(orderNumber) from Orders ;

/*	(B)	How many orders are there for each customer who has placed an order? 
	List only those with more than 5 orders.	*/
select customerNumber, count(*) as order_count from Orders group by customerOrder having count(*) > 5 ;

/*	(C)	How many orders have shipped?	*/
select count(status) from Orders where Orders.status='shipped' ;

/*	(D)	What possible status can an order have?	*/
select distinct status from Orders ;

/*	~	~	~	~	~	*/

/*	10.		List all the employee names in the format last, first (for example Green, Joe).
			List them in reverse alphabetic order of last name. (Use the concat function)	*/
select * from Employees order by lastName, firstName ;
select * from Employees order by lastName desc ;

/*	~	~	~	~	~	*/

/*	11.		List all of the employees who work in London. 
			You cannot use more than one table in a single select statement.	*/
select * from Employees where officeCode = 7 ;

/*	~	~	~	~	~	*/


