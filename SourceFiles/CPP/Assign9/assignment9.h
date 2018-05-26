/*
FILE INFO
NAME:       Tom Eisenbrandt
ZID:        Z1771209
CLASS:      CSCI 340
SECTION:	03
PROJECT:    09
DUE:        May 4th 2017 11:59PM
FILENAME:   assignment9.h
*/



#ifndef ASSIGNMENT9_H
#define ASSIGNMENT9_H
#include <vector>
#include <list>

class graph {
    private:
        int size;
        std::vector< std::list<int> > adj_list;
        std::vector< char > labels;
        void depth_first( int );
    public:
        graph( const char* filename );
        ~graph();
        int get_size() const;
        void traverse( ) ;
        void print ( ) const;
};

#endif 



/*

	END OF FILE

*/

