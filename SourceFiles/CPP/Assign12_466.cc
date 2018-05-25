
/************************************************

FILE INFO

NAME:		Tom Eisenbrandt
ZID:		Z1771209
CLASS:		CSCI 466
SECTION:	02
PROJECT:	12
DUE DATE:	December 6th 2017 11:59PM

PURPOSE:    User enters input and gets SQL queries

************************************************/

//	Included libraies/files
#include <iostream>		//	Input / output library
#include <mysql.h>		//	Mysql library

//	Constants
#define SERVER "students"				//	Server name
#define USER "z1771209"					//	User login
#define PASSWORD "1994Aug20"			//	Password
#define DATABASE "z1771209"				//	Database to use
#define ZERO 0							//	literal
#define ONE 1							//	literal
#define HORSE "SELECT * FROM horse;"	//	literal string
#define RACE "SELECT * FROM race;"		//	literal string

int main( ) {	//	Open main

char INPUT = 'A' ;		//	Initialize input variable
bool ESCAPE = false ;	//	Initialize exit toggle
int COUNTER = ZERO ;	//	Initialize counter - appended to output for formating

MYSQL *CONNECT, mysql ;				//	Pointer to MySQL
CONNECT = mysql_init( &mysql ) ;	//	Initialize Instance

//	Connection variable
CONNECT = mysql_real_connect( CONNECT , SERVER , USER , PASSWORD , DATABASE , 0 , NULL , 0 ) ;

if( CONNECT ) {	//	Test Connection
	
MYSQL_RES *res_set ;	//	Pointer for return values
MYSQL_ROW ROW ;			//	Row Varible
	
std::cout << "\n" ;
std::cout << " Connection successful " ;    //	Output success message

do{	//	Enter input Loop

std::cout << "\n" ;	//	Output options to user
std::cout << "H : List all horses" ;    //  View data in horse table
std::cout << "\n" ;
std::cout << "R : List all races" ;     //  View data in race table
std::cout << "\n" ;
std::cout << "X : Exit the program" ;   //  Exit program
std::cout << "\n" ;
std::cout << "Enter option: ";
std::cin >> INPUT ;						//	Users stores his/her choice in INPUT
INPUT = std::tolower( INPUT ) ; 		//  changes all characters to lower case

switch( INPUT ) {

//	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~
// Option H - HORSE - Show all data in the horse table ( name , sire , dam )
case 'h':
	
std::cout << "\n" ;
std::cout << "	~	Listing All Horses	~	" ;
std::cout << "\n" ;
std::cout << "		Name  -  Sire  -  Dam" ;
std::cout << "\n" ;

COUNTER = ZERO ;							//	Reset Counter
mysql_query( CONNECT , HORSE ) ;			//	Query
res_set = mysql_use_result( CONNECT ) ;		//	Cursor

while( ( ROW = mysql_fetch_row( res_set ) ) != NULL ) {		//	Loop while ROW!=NULL
COUNTER += ONE ;
std::cout << " Record " ;

if( COUNTER < 10 ) {
std::cout << ZERO ;     //  1 - > 2 digits
}
else{
//  None
}

std::cout << COUNTER ;
std::cout << ": " ;
std::cout << ROW[1] ;
std::cout << " " ;
std::cout << ROW[2] ;
std::cout << " " ;
std::cout << ROW[3] ;
std::cout << " " ;
std::cout << "\n" ;
}	//	End while ROW!=NULL

COUNTER = ZERO ;				//	Reset Counter
mysql_free_result( res_set ) ;	//	Frees Cursor Pointer
break ; 						//  Break from option H

//	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~
// Option R - RACE - Show all data in the race table ( name , distance )
case 'r':
	
std::cout << "\n" ;
std::cout << "	~	Listing All Races	~	" ;
std::cout << "\n" ;
std::cout << "		Race Name  -  Distance" ;
std::cout << "\n" ;

COUNTER = ZERO ;							//	Reset Counter
mysql_query( CONNECT , RACE ) ;    			//	Query
res_set = mysql_store_result( CONNECT ) ;	//	Cursor

while( ( ROW = mysql_fetch_row( res_set ) ) != NULL ){
COUNTER += ONE ;
std::cout << " Record " ;

if( COUNTER < 10 ) {    //	1 -> 3 digits
std::cout << ZERO ;
std::cout << ZERO ;
}
else if( COUNTER < 100 ) {	//	2 -> 3 digits
std::cout << ZERO ;
}
else{
//  None
}

std::cout << COUNTER ;
std::cout << ": " ;
std::cout << ROW[1] ;
std::cout << " " ;
std::cout << ROW[2] ;
std::cout << "\n" ;
}

COUNTER = ZERO ;				//	Reset Counter
mysql_free_result( res_set ) ;	//	Frees Cursor Pointer
break ; 						//  Break from option r

//	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~
// Option X - Exit - Exit program
case 'x':
std::cout << "\n" ;
std::cout << "	~	Exiting Program		~	" ;
std::cout << "\n" ;
ESCAPE = true ;
break ; //  Break from option X

//	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~	~
// DEFAULT - Applied on bad user input
default:    //  Default option
std::cout << "\n" ;
std::cout << "ERROR: Incorrect Input - " ;
std::cout << "please choose from given options" ;
std::cout << "\n" ;

}   //  End of switch

}while( ESCAPE != true ) ;	//	End do while loop

}	//	End if connected

else{	//	Connection failed - print error report
std::cout << "\n" ;
std::cout << "ERROR: Connection failed" ;
std::cout << "\n" ;

}	//	End connection error

mysql_close( CONNECT ) ;	//	Close Connection
return ZERO ;				//	End Program
}	//	End main

//	~	~	~	~	~	~
//	~	END OF PROGRAM	~
//	~	~	~	~	~	~
