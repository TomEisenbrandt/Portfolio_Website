/*
FILE INFO
NAME:       Tom Eisenbrnadt
ZID:        Z1771209
CLASS:      CSCI 330
SECTION:    03
PROJECT:    09
DUE:        Thursday May 4th 2017 11:59PM
FILENAME:   z1771209.cxx
*/

#include <iostream>
#include <fstream>
#include <cstdlib>
#include <cstdio>
#include <cstring>
#include <ctime>
#include <string>
#include <unistd.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dirent.h>

using namespace std ;

void Search(		int		,	char * 	,	string	)	;
void RootDisplay(	int		,	char * 	,	string	)	;
void Options(		int		, 	char* 	)	;
void CheckInput(	char*	, 	int 	,	char*	)	;
DIR *DirectoryPoint ;
struct dirent *DirectoryOpen;
struct sockaddr_in SERVER 	;
struct sockaddr_in CLIENT	;

int main( int argc , char* argv[ ] ) {
	
//	Improper Usage Check
	if( argc < 3 || argc > 3 ) {
	cerr << "\n" ;
	cerr << "Incorrect usage of " ;
	cerr << argv[ 0 ] ;
	cerr << "\n" ;
	cerr << "Correct usage is as follows: " ;
	cerr << "\n" ;
	cerr << argv[ 0 ] ;
	cerr << " >Port Number<" ;
	cerr << " >Directory<" ;
	cerr << "\n" ;
	exit( EXIT_FAILURE ) ;
	}
	
int SocketPrime ;
int SockFullOfSadness ;
socklen_t Server_Size ;
socklen_t Client_Size ;

//	Socket
	if( ( SocketPrime = socket( AF_INET , SOCK_STREAM , 0 ) ) < 0 ) {
	perror( "SOCKET : Code 1" ) ;
	exit( EXIT_FAILURE ) ;
	}

memset( &SERVER, 0 , sizeof( SERVER ) ) ;

SERVER.sin_family = AF_INET ;
SERVER.sin_addr.s_addr = INADDR_ANY ;
SERVER.sin_port = htons( atoi( argv[ 1 ] ) ) ;

Server_Size = sizeof( SERVER ) ;

	if( bind( SocketPrime , ( struct sockaddr* ) &SERVER , Server_Size ) < 0 ) {
	perror( "SOCKET : Code 2" ) ;
	exit( EXIT_FAILURE ) ;
	}

//	Buffer Size
	if( listen( SocketPrime , 1026 ) < 0 ) {
	perror( "LISTEN : Code 3" ) ;
	exit( EXIT_FAILURE ) ;
	}

cout << "\n Enter Command: \t" ;

//	Loop program until told otherwise
while( ( true ) ) {

SockFullOfSadness = accept( SocketPrime , ( struct sockaddr* ) &CLIENT , &Client_Size ) ;

	if( SockFullOfSadness < 0 ) {
	perror( "SOCKET : Code 3" ) ;
	exit( EXIT_FAILURE ) ;
	}

	if( fork( ) ) {
//	Parent
	close( SockFullOfSadness ) ;
	}
//	Child
	else{
	Options( SockFullOfSadness , argv[ 2 ] ) ;
	}

}

close( SocketPrime ) ;

return 0 ;

}

//	//	//	//	//

//	Opens Root Directory via argv[ 2 ] and searches for file by given name.

void RootDisplay( int Socker_Ball , char *Dog_Directory , string FILE ) {

string INPUT ;
string FILE_STRING ;
struct stat DirectoryBuffer ;
int DIRECT ;


//	Open desired directory
DirectoryPoint = opendir( Dog_Directory ) ;

Dups( Socker_Ball , 2 ) ;

	if( DirectoryPoint == 0 ) {
	perror( Dog_Directory ) ;
	exit( EXIT_FAILURE ) ;
	}

FILE_STRING = FILE + "index.html" ;
DIRECT = stat( FILE_STRING.c_str( ) , &DirectoryBuffer ) ;

	if( DIRECT != 0 ) {


		while( ( DirectoryOpen = readdir( DirectoryPoint ) ) != NULL ) {
		cerr << DirectoryOpen->d_name << endl ;
		}


	}
	else{


		if( S_ISREG ( DirectoryBuffer.st_mode ) ) {
		ifstream infile( FILE_STRING.c_str( ) ) ;
		infile.is_open( ) ;


			while( getline( infile , INPUT ) ) {
			cerr << INPUT << endl ;
			}


		}

	}

closedir( DirectoryPoint ) ;

}

//	//	//	//	//

//	Directory Searcher
//	Checks if input is a valid directory.

void Search( int SockPupper , char *RootDir , string File_Location ) {

struct stat DirectBuffing ;
int Certified_Directory ;
string String_Input ;

Certified_Directory = stat( File_Location.c_str( ) , &DirectBuffing ) ;

	if( ( Certified_Directory != 0 ) ) {

		if( Dups( SockPupper , 2 ) < 0 ) {
		perror( "SOCKET : Code 12" ) ;
		exit( EXIT_FAILURE ) ;
		}

	}
	else{
		if( S_ISREG( DirectBuffing.st_mode ) ) {
		ifstream infile( File_Location.c_str( ) ) ;
		infile.is_open( ) ;

			if( Dups( SockPupper , 2 ) < 0 ) {
			perror( "SOCKET : Code 47" ) ;
			exit( EXIT_FAILURE ) ;
			}

			while( getline( infile , String_Input ) ) {
			cerr << String_Input << endl;
			}

		}

	if( S_ISDIR( DirectBuffing.st_mode ) ) {

	DirectoryPoint = opendir( File_Location.c_str( ) ) ;

		if( Dups( SockPupper , 2 ) < 0 ) {
		perror( "SOCKET : Code 67" ) ;
		exit( EXIT_FAILURE ) ;
		}

	File_Location = File_Location + "/index.html" ;
	Certified_Directory = stat( File_Location.c_str( ) , &DirectBuffing ) ;

	if( S_ISREG( DirectBuffing.st_mode ) ) {
	ifstream infile( File_Location.c_str( ) ) ;
	infile.is_open( ) ;

		if( Dups( SockPupper , 2 ) < 0 ) {
		perror( "SOCKET : Code 23" ) ;
		exit( EXIT_FAILURE ) ;
		}

	while( ( DirectoryOpen = readdir( DirectoryPoint ) ) != NULL ) {
	cerr << DirectoryOpen->d_name ;
	cerr << "\n" ;
	}

	}

	}

	}

}

//	//	//	//	//

//	INFO	:	Display Time
//	QUIT	:	Exit Program
//	GET		:	Arguments get processed

void Options( int Socket_Opt , char* Directory_ROOT ) {

int PizzaGoon ;
bool FrootLoop = true ;
char InputBuffer[ 1026 ] ;

cout << "\n" ;
cout << "Display Time :	INFO" ;
cout << "\n" ;
cout << "Command :  GET" ;
cout << "\n" ;
cout << "Return to Terminal : QUIT" ;
cout << "\n" ;

while( ( FrootLoop = true ) ) {

//Read message from the client
	if( ( PizzaGoon = read( Socket_Opt , InputBuffer , 256 ) ) < 0 ) {
	perror( "INPUT" ) ;
	exit( EXIT_FAILURE ) ;
	}

//  Flush the buff
InputBuffer[ PizzaGoon ] = '\0' ;

	if( ( !strncmp( InputBuffer , "QUIT" , 4 ) ) ) {
	cout << "\n\t" ;
	cout << "GOODBYE" ;
	cout << "\n" ;
	break ;
	}

////////////////////	EXTRA CREDIT	/////////////////////////////////////
//  Clock
	if( ( !strncmp( InputBuffer , "INFO" , 4 ) ) ) {
	const time_t TIME = time( 0 ) ;
	char *Time_Alt ;
	Time_Alt = asctime( localtime( &TIME ) ) ;
	Dups( Socket_Opt , 2 ) ;
	cerr << Time_Alt ;
	}
////////////////////	EXTRA CREDIT	////////////////////////////////////
	else{
	CheckInput( InputBuffer , Socket_Opt , Directory_ROOT ) ;
	}

}
cout << "\n" ;
close( Socket_Opt ) ;
exit( EXIT_SUCCESS ) ;
}

//	//	//	//	//

//	Function checks user's arguments

void CheckInput( char* User_Input , int Socketeer , char* ROOT_DIR ) {

string PathFinder ;
string File_Grabber ;
string File_Location ;
int Counter = 0 ;

char* argv[ ] = { ( char* )0 , ( char* )0 , ( char* )0 , ( char* )0 , ( char* )0 } ;

//	Give strings proper format
for( char* p = strtok( User_Input , " " ) ; p ; p = strtok( NULL , " " ) ) {
argv[ Counter++ ] = p ;
}

//	GET and Path
if( Counter == 2 ) {
File_Grabber = argv[ 0 ] ;
PathFinder = argv[ 1 ] ;
}

//	Only GET
else{
File_Grabber = argv[ 0 ] ;
}

if( File_Grabber == "GET" and PathFinder[ 0 ] == '/' ) {
File_Location = ROOT_DIR + PathFinder ;
}

//	Checks for proper spelling of GET
if( ( File_Grabber != "GET" ) ) {
cout << "SEVER : Code 32" ;
exit( EXIT_FAILURE ) ;
}

//	Checks if path starts with a "/"
if( ( PathFinder[ 0 ] != '/' ) ) {
Dups( Socketeer , 2 ) ;
cerr << "\n" ;
cerr << "INPUT : Code 38" ;
cerr << "\n" ;
}

else{
Search( Socketeer , ROOT_DIR , File_Location ) ;
}

if( ( PathFinder[ 1 ] == '.' ) && ( PathFinder[ 2 ] == '.' ) ) {
Dups( Socketeer , 2 ) ;
cerr << "\n" ;
cerr << "INPUT : Code 25" ;
cerr << "\n" ;
}

if( ( PathFinder[ 1 ] == '\0' ) ) {
RootDisplay( Socketeer , ROOT_DIR , File_Location ) ;
}

}



//	END OF FILE



