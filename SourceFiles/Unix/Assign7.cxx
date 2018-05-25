////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//	FILE INFO
//	NAME:		Tom Eisenbrandt
//	ZID:		Z1771209
//	CLASS:		CSCI 330
//	SECTION:	03
//	PROJECT:	07
//	DUE:		April 7th 5:00PM

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#include <iostream>
#include <fstream>
#include <cstdlib>
#include <cstdio>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
using namespace std ;



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int main ( int argc, char* argv[ ] ) {
// File Descriptor
int fd ;
// Records file name placement within command
int file ;
// Records string placement within command
int string ;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// If the program not called correctly
if ( argc < 3 || argc > 4 ) {
cerr << "\n" ;
cerr << "Invalid use of " << "\"" << argv[ 0 ] << "\"" ;
cerr << "\n" ;
cerr << "Example: " << argv[ 0 ] << " [-c] <FILE> <STRING>" ;
cerr << "\n" ;
cerr << "<STRING> will be appended to <FILE>" ;
cerr << "\n" ;
cerr << "The -c option will clear the file before appending the string." ;
cerr << "\n\n" ;
exit( EXIT_FAILURE ) ;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// 3 Part Command
if ( argc == 3 ) {
file = 1 ;
string = 2 ;
//int StringSize = sizeof( argv[ string ] ) ;




// If file has permissions
if( access( argv[ file ] , W_OK ) == 0 ) {
cerr << "\n" ;
cerr << argv[ file ] ;
cerr << " is not secure - Ignoring \n" ;
exit( EXIT_FAILURE ) ;
}




// If file lacks permission
if( access( argv[ file ] , W_OK ) == -1 ) {
// Give file write permission
chmod( argv[ file ] , 00200 ) ;
}



// Create and open file
fd = open( argv[ file ] , O_WRONLY | O_APPEND | O_CREAT , 00200 ) ;
// Error check
if ( fd == -1 ) {
perror( argv[ file ] ) ;
exit( EXIT_FAILURE ) ;
}



// Close standard output
close( 1 ) ;



// Duplicate fd into 1
if( dup( fd ) == -1 ) {
perror( "Duplicate dup" ) ;
exit( EXIT_FAILURE ) ;
}



// Close file
close( fd ) ;



// Write to file
//write( fd , argv[ string ] , StringSize ) ;
cout << argv[ string ] << "\n" ;



} // End of 3 part command function

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// 4 part command
if( argc == 4 ) {
file = 2 ;
string = 3 ;
//int StringSize = sizeof( argv[ string ] ) ;



// If file has permissions
if( access( argv[ file ] , W_OK ) == 0 ) {
cerr << "\n" ;
cerr << argv[ file ] ;
cerr << " is not secure - Ignoring \n" ;
exit( EXIT_FAILURE ) ;
}



// If file lacks permission
if( access( argv[ file ] , W_OK ) == -1 ) {
// Give file write permission
chmod( argv[ file ] , 00200 ) ;
}



// Create and open file
fd = open( argv[ file ] , O_WRONLY | O_APPEND | O_TRUNC | O_CREAT , 00200 ) ;
// Error check
if ( fd == -1 ) {
perror( argv[ file ] ) ;
exit( EXIT_FAILURE ) ;
}



// Close standard output
close( 1 ) ;



// Duplicate fd into 1
if( dup( fd ) == -1 ) {
perror( "Duplicate dup" ) ;
exit( EXIT_FAILURE ) ;
}



// Close file
close( fd ) ;



// Write to file
//write( fd , argv[ string ] , StringSize ) ;
cout << argv[ string ] << "\n" ;



} // End of 4 part command function

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Remove permissions from file
chmod( argv[ file ] , 00000 ) ;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

return 0 ;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
END OF FILE
*/
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
