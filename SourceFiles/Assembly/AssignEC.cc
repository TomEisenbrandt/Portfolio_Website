



/*
NAME:				TOM EISENBRANDT
ZID:				Z1771209
CLASS:				CSCI 360
SECTION:			1
PROJECT:			EXTRA CREDIT
DATE DUE:			DECEMBER 8TH 2017 11:59PM
*/

#include <iostream>

#define ZERO 0
#define ONE 1
#define FIVER 5000

int main( ){

int COUNT = ZERO ;
int SUM = ZERO ;

while( COUNT != FIVER ){
COUNT = COUNT + ONE ;
SUM = SUM + COUNT ;	
}

std::cout << "\n" << "THE SUM OF THE NUMBERS 1 TO 5000: " << SUM ;

return ZERO;
}

/*
END OF PROGRAM
*/


