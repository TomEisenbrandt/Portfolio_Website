/*
FILE INFO
NAME:       Tom Eisenbrandt
ZID:        Z1771209
CLASS:      CSCI 330
SECTION:    03
PROJECT:    08
DUE:        April 25th 2017 11:59 PM
*/

#include <unistd.h>     //	unlink / fork / exec
#include <cstdio>
#include <cstdlib>
#include <iostream>     //  input/output stream
#include <fstream>      //  filestrem
#include <string>       //	strings
#include <string.h>     //  more strings
#include <sstream>
#include <iomanip>      //  input/output manipulation
#include <cstdlib>
#include <sys/types.h>
#include <fcntl.h>
#include <sys/wait.h>
#include <vector>		//	Vectors
#include <iterator>     //  Vector iterator

using namespace std ;

int main( void ) {

//	Variable list
string Command = "" ;
int pid ;
int status ;
bool LoopProgram = true ;
unsigned int Count = 0 ;

//	Loop program
while( LoopProgram == true ) {

//  Prompt user
cout << "\n" ;
cout << "Enter command: " ;

//  Input
getline( cin , Command ) ;

// Store the input as an object
istringstream stream_cmmd( Command ) ;

//  Store input object into a dynamic vector array
vector< string > AltCom ;

copy( istream_iterator< string >( stream_cmmd ) , istream_iterator< string >( ) , back_inserter< vector< string > >( AltCom ) ) ;

const char **CommandOne = new const char* [ AltCom.size( )+1 ] ;

//  Copy the vector to a pointer so it has the proper use type
for( Count = 0 ; Count < AltCom.size( ) ; Count++ )
CommandOne[ Count ] = AltCom[ Count ].c_str( ) ;

//	If user enters "exit" then program will end
if( Command == "exit" ) {

exit( EXIT_SUCCESS ) ;
}

//	fork starts child and parent process
pid = fork( ) ;
if( pid == -1 ) {
perror( "fork" ) ;
exit( EXIT_FAILURE ) ;
}

//	Child process
if( pid == 0 ) {


pid = execvp( CommandOne[0] , (char**)CommandOne ) ;

if( pid == -1 ) {
perror( "exec" ) ;
exit( EXIT_FAILURE ) ;
}
}

//	Parent process
else{
wait( NULL ) ;
wait( &status ) ;
}


}

return 0 ;

}

/*****/

//  END OF FILE

/*****/

