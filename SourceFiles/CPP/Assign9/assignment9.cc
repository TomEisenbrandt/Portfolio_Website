/*
FILE INFO
NAME:       Tom Eisenbrandt
ZID:        Z1771209
CLASS:      CSCI 340
SECTION:	03
PROJECT:    09
DUE:        May 4th 2017 11:59PM
FILENAME:   assignment9.cc
*/

/*
>	>	>	>	>	>   >   >   >	>	~	Includes	~	<	<	<   <   <	<	<	<	<	<
*/

#include <iostream>
#include <fstream>
#include <vector>
#include <list>
#include <utility>
#include <string>
#include <algorithm>
#include <iterator>
#include "assignment9.h"

using namespace std ;

/*
>	>	>	>	>	>   >   >   >	>	~	Global Scope Variables	~	<	<	<   <   <	<	<	<	<	<
*/

int COUNTER = 0 ;							//	Counter

vector< int > traversalOrder ;				//	Order of traversal

vector< pair< int , int > > lastPaired ;	//	Save the two ints visited

vector< int >::iterator it ;				//  Iterator for vector

list< int >::iterator adjIt ;				//  Iterator for list

list< int > AltList ;						//  Stores input

/*
>	>	>	>	>	>   >   >   >	>	~	Constructor	~	<	<	<   <   <	<	<	<	<	<
*/

/*
FUNCTION:   void graph::graph( const char* input )
PARAMETERS: const char* input
RETURN:     Void
USE:        Constructor
*/
graph::graph( const char* input ) {

int Temporary_Holder = 0 ;
unsigned int Number_of_Verticies = 0 ;
char Line_Being_Read ;

ifstream File_Stream_Input( input , ios::in ) ;
File_Stream_Input >> Line_Being_Read ;
Number_of_Verticies = Line_Being_Read - '0' ;
size = Number_of_Verticies ;

	for( unsigned int Boop = 0 ; Boop < Number_of_Verticies ; Boop++ ) {
	File_Stream_Input >> Line_Being_Read ;
	labels.push_back( Line_Being_Read ) ;
	}

	for( unsigned int Hot_Dog = 0 ; Hot_Dog < Number_of_Verticies ; Hot_Dog++ ) {
	File_Stream_Input >> Line_Being_Read ;

		for( unsigned int Bagel = 0 ; Bagel < Number_of_Verticies ; Bagel++ ) {
		File_Stream_Input >> Temporary_Holder ;
		AltList.push_back( Temporary_Holder ) ;
		}

//  Reset values
	adj_list.push_back( AltList ) ;
	AltList.erase( AltList.begin( ) , AltList.end( ) ) ;
	}

File_Stream_Input.close( ) ;

}



/*
>	>	>	>	>	>   >   >   >	>	~	Deconstructor	~	<	<	<   <   <	<	<	<	<	<
*/

/*
FUNCTION:   graph::~graph( )
PARAMETERS: Void
RETURN:     Void
USE:        Deconstructor
*/
graph::~graph( ) {

// Deconstructor

}



/*
>	>	>	>	>	>   >   >   >	>	~	Depth_First	~	<	<	<   <   <	<	<	<	<	<
*/

/*
FUNCTION:   void graph::depth_first( int v ) const
PARAMETERS: int v
RETURN:     Void
USE:        Depth first traversal of graph
*/
void graph::depth_first( int v ) {
	
int Distance = 0 ;

COUNTER++ ;
traversalOrder[ v ] = COUNTER ;
AltList = adj_list[ v ] ;

	for( adjIt = AltList.begin( ) ; adjIt != AltList.end( ) ; adjIt++ ) {
	AltList = adj_list[ v ] ;
	Distance = distance( AltList.begin( ) , adjIt ) ;

		if( *adjIt == 1 && traversalOrder[ Distance ] == 0 ) {
		lastPaired.push_back( make_pair( v , Distance ) ) ;
		depth_first( Distance ) ;
		}
		
	}

}

/*
>	>	>	>	>	>   >   >   >	>	~	Traverse	~	<	<	<   <   <	<	<	<	<	<
*/

/*
FUNCTION:   void graph::traverse( ) const {
PARAMETERS: Void
RETURN:     Void
USE:        Traverse the graph
*/
void graph::traverse( ) {

traversalOrder.resize( size ) ;
it = find( traversalOrder.begin( ) , traversalOrder.end( ) , 0 ) ;

	while( it != traversalOrder.end( ) ) {
	depth_first( it - traversalOrder.begin( ) ) ;
	it = find( traversalOrder.begin( ) , traversalOrder.end( ) , 0 ) ;
	}

cout << "------- traverse of graph ------" ;
cout << "\n" ;

unsigned int SIZE = size ;

	for( unsigned int Traversal_Index = 1 ; Traversal_Index <= SIZE ; Traversal_Index++ ) {
	it = find( traversalOrder.begin( ) , traversalOrder.end( ) , Traversal_Index ) ;
	cout << labels[ it - traversalOrder.begin( ) ] ;
	cout << " " ;
	}

cout << "\n" ;

	for( unsigned int Pair_Index = 0 ; Pair_Index < lastPaired.size( ) ; Pair_Index++ ) {
	cout << "(" ;
	cout << labels[ lastPaired[ Pair_Index ].first ] ;
	cout << ", " ;
	cout << labels[ lastPaired[ Pair_Index ].second ] ;
	cout << ") " ;
	}

cout << "\n" ;
cout << "--------- end of traverse -------" ;
cout << "\n\n" ;

}

/*
>	>	>	>	>	>   >   >   >	>	~	Print	~	<	<	<   <   <	<	<	<	<	<
*/

/*
FUNCTION:   void graph::print( ) const
PARAMETERS: Void
RETURN:     Void
USE:        Prints adjacency list of graph
*/
void graph::print( ) const {

int Label_Counter = 0 ;
int Edge_Count = 0 ;

cout << "\n" ;
cout << "Number of vertices in the graph: " ;
cout << size ;
cout << "\n\n" ;
cout << "-------- graph -------" ;
cout << "\n" ;

	for( vector< list< int > >::const_iterator it = adj_list.begin( ) ; it != adj_list.end( ) ; it++ ) {
	cout << labels[ Label_Counter ] ;
	cout << ": " ;
	list< int > li = *it ;

		for( list< int >::iterator print_it = li.begin( ) ; print_it != li.end( ) ; print_it++ ) {

			if( *print_it == 1 ) {
			cout << labels[ Edge_Count ] ;
			cout << ", " ;
			}

		Edge_Count++ ;
		}

	cout << "\n" ;
	Label_Counter++ ;
	Edge_Count = 0 ;
	}

cout << "------- end of graph ------" ;
cout << "\n\n" ;

}

/*
>	>	>	>	>	>   >   >   >	>	~	Main	~	<	<	<   <   <	<	<	<	<	<
*/

#define ASSIGNMENT9_TEST
#ifdef 	ASSIGNMENT9_TEST

int main(int argc, char** argv) {
    if ( argc < 2 ) {
        cerr << "args: input-file-name\n";
        return 1;
    }
    
    graph g(argv[1]);

    g.print();
    
    g.traverse();

    return 0;
}

#endif

/*

	END OF FILE

*/

