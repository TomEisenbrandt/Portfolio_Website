/*
Name:		Tom Eisenbrandt
ZID:		Z1771209
Class:		CSCI 466
Section:	2
Project:	7
Due:		27 October 2017
*/

Use z1771209 ;

/*
~	~	~	~	~	~	~	~	~	~
1. 
Drop/delete all of the tables/views you will be creating below

The Command for #1 will be placed at the begining and end of the script
*/

DROP TABLE IF EXISTS Pet ;

DROP TABLE IF EXISTS Owner ;

DROP VIEW IF EXISTS List ;

/*
~	~	~	~	~	~	~	~	~	~
2. 
Create a table [named] owner with an owner id and a name.
Owner id should be an auto-increment primary key.
*/

CREATE TABLE Owner
(
Owner_ID INT NOT NULL AUTO_INCREMENT,

Owner_Name	VARCHAR(20),

PRIMARY KEY(Owner_ID)
)
;

/*
~	~	~	~	~	~	~	~	~	~
3. 
Put at least 5 records in this table
*/

INSERT INTO Owner
(Owner_ID,Owner_Name)
VALUES('2580','Tom Eisenbrandt')
;

INSERT INTO Owner
(Owner_ID,Owner_Name)
VALUES('1234','Jose Cuervo')
;

INSERT INTO Owner
(Owner_ID,Owner_Name)
VALUES('6464','David Braben')
;

INSERT INTO Owner
(Owner_ID,Owner_Name)
VALUES('1111','Phil T. Kasual')
;

INSERT INTO Owner
(Owner_ID,Owner_Name)
VALUES( '1010','Bardley Chompers')
;

INSERT INTO Owner
(Owner_ID,Owner_Name)
VALUES('2468','Ronald McDonald')
;

/*
~	~	~	~	~	~	~	~	~	~
4. 
Do a select * on this table to show all the records
*/
SELECT
*
FROM
Owner
;

/*
~	~	~	~	~	~	~	~	~	~
5. 
Create a table called pet 
with a pet id (auto-increment primary key), 
pet name and owner-id which is a foreign key into the owner table
*/

CREATE TABLE Pet
(
Pet_ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,

Pet_Name VARCHAR(20),

Owner_ID INT
)
;

/*
~	~	~	~	~	~	~	~	~	~
6. 
Put at least 5 records in this table, 
with at least two pets owned by the same owner
*/

INSERT INTO Pet
(Pet_Name,Owner_ID)
VALUES('Oliver','2580')
;

INSERT INTO Pet
(Pet_Name,Owner_ID)
VALUES('Ella','2580')
;

INSERT INTO Pet
(Pet_Name,Owner_ID)
VALUES('Cody','1234')
;

INSERT INTO Pet
(Pet_Name,Owner_ID)
VALUES('Bubba','6464')
;

INSERT INTO Pet
(Pet_Name,Owner_ID)
VALUES('Tucker','1111')
;

INSERT INTO Pet
(Pet_Name,Owner_ID)
VALUES('Fenris','1010')
;

INSERT INTO Pet
(Pet_Name,Owner_ID)
VALUES('Donut','2468')
;

/*
~	~	~	~	~	~	~	~	~	~
7. 
Do a select * on this table to show all the records
*/

SELECT
*
FROM
Pet
;

/*
~	~	~	~	~	~	~	~	~	~
8. 
Add a column to the pet table for type of pet 
(for example: dog, cat, or fish)
*/

ALTER TABLE
Pet
ADD 
Pet_Type VARCHAR(10)
;

/*
~	~	~	~	~	~	~	~	~	~
9. 
Update several rows to add the pet type
*/

UPDATE Pet
SET Pet_Type = 'Dog'
WHERE
'Pet_Name' = 'Oliver'
;

UPDATE Pet
SET Pet_Type = 'Dog'
WHERE
'Pet_Name' = 'Ella'
;

UPDATE Pet
SET Pet_Type = 'Cat'
WHERE
'Pet_Name' = 'Cody'
;

UPDATE Pet
SET Pet_Type = 'Dog'
WHERE
'Pet_Name' = 'Bubba'
;

UPDATE Pet
SET Pet_Type = 'Kraken'
WHERE
'Pet_Name' = 'Tucker'
;

UPDATE Pet
SET Pet_Type = 'Wolf'
WHERE
'Pet_Name' = 'Fenris'
;

UPDATE Pet
SET Pet_Type = 'Squirrel'
WHERE
'Pet_Name' = 'Donut'
;

/*
~	~	~	~	~	~	~	~	~	~
10. 
Do a select * on this table to show all the records
*/

SELECT
*
FROM
Pet
;

/*
~	~	~	~	~	~	~	~	~	~
11. 
Define a view that will list each owner with their pet, 
just the names
*/

CREATE VIEW
List
AS
SELECT
Pet.Pet_Name,
Owner.Owner_Name
FROM
Pet,
Owner
WHERE
Owner.Owner_ID = Pet.Owner_ID
;

/*
~	~	~	~	~	~	~	~	~	~
12. 
Do a select * on this view to show all the records
Once you have debugged and corrected the above sql statements, 
put them in the script (with comments), 
run the script using the \T
command to put the results in a text file. 
Turn in both the script and the output file
*/

SELECT
*
FROM
List
;


/*
~	~	~	~	~	~	~	~	~	~
***************************
#1 is located here!!!
Drop/delete all of the tables/views you will be creating below
***************************
*/

DROP TABLE Pet ;

DROP TABLE Owner ;

DROP VIEW List ;

/*
~	~	~	~	~	~	~	~	~	~

END OF SCRIPT

*/








