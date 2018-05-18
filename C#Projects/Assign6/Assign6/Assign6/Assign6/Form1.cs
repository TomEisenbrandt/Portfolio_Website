/************************************************

NAME:       Tom Eisenbrandt
ZID:        Z1771209
CLASS:      CSCI 473
SECTION:    1
PROJECT:    6
DUE:        1st May 2018 11:59 PM

************************************************/
//
using System ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Data ;
using System.Drawing ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.Windows.Forms ;
//
namespace Assign6 {
//                    
    public partial class Form1: Form {
    //    
        public Form1( ) {
        //
        InitializeComponent( ) ;
        } // End of constructor
        //
/************************************************
Form Loader
    Load in material before the form starts
************************************************/
        private void Form1_Load( object sender , EventArgs e ) {
        //
        OutputBox.Items.Add( "Awaiting input..." ) ;  
        //
        } // End of Form Load
        //
/************************************************
Exit Button
    Ends the program
************************************************/
        private void ExitButton_Click( object sender , EventArgs e ) {
        //
        Application.Exit( ) ; // Exits the application
        } // End of Exit Button
        //
/************************************************
RREF Button
    Calculates the given matrix in reduced row echelon form
************************************************/
        private void RREFButton_Click( object sender , EventArgs e ) {
        //
        /*
        // 'More clear' way of indexing matrix, each variable is connected to its index value in terms of matrix
        int A11 = 0 ;
        int A12 = 1 ;
        int A13 = 2 ;
        int A21 = 3 ;
        int A22 = 4 ;
        int A23 = 5 ;
        int A31 = 6 ;
        int A32 = 7 ;
        int A33 = 8 ;
        */
        string TempString = "" ; // Temporary string (for formatting)
        double TempValue = 0.0 ; // Temporary value (for math)
        double PrintValue = 0.0 ; // For showing user calculation data
        bool Col1Null = false ; // Recycle column check
        bool Col2Null = false ; // Recycle column check
        OutputBox.Clear( ) ; // Reset value
        //
        string[ ] MatrixAInput = {
                            InputA11.Text , InputA12.Text , InputA13.Text , // Row 1 (0,1,2)
                            InputA21.Text , InputA22.Text , InputA23.Text , // Row 2 (3,4,5)
                            InputA31.Text , InputA32.Text , InputA33.Text   // Row 3 (6,7,8)
                            } ;
        //
        string[ ] MatrixBInput = {
                            InputB11.Text , InputB12.Text , InputB13.Text , // Row 1
                            InputB21.Text , InputB22.Text , InputB23.Text , // Row 2
                            InputB31.Text , InputB32.Text , InputB33.Text   // Row 3
                            } ;
        //
        double[ ] MatrixA = {
                            0.0 , 0.0 , 0.0 ,   // Row 1
                            0.0 , 0.0 , 0.0 ,   // Row 2
                            0.0 , 0.0 , 0.0     // Row 3
                            } ;
        //
        double[ ] MatrixB = {
                            0.0 , 0.0 , 0.0 ,   // Row 1
                            0.0 , 0.0 , 0.0 ,   // Row 2
                            0.0 , 0.0 , 0.0     // Row 3
                            } ;
        //
        double[ ] MatrixTempA = {
                            0.0 , 0.0 , 0.0 ,   // Row 1
                            0.0 , 0.0 , 0.0 ,   // Row 2
                            0.0 , 0.0 , 0.0     // Row 3
                            } ;
        //
        double[ ] MatrixTempB = {
                            0.0 , 0.0 , 0.0 ,   // Row 1
                            0.0 , 0.0 , 0.0 ,   // Row 2
                            0.0 , 0.0 , 0.0     // Row 3
                            } ;
        //
        // Test input for matrix A and convert valid values to double
        for( int i = 0 ; i < MatrixAInput.Length ; i++ ) { 
        //
            try{
            MatrixA[ i ] = Convert.ToDouble( MatrixAInput[ i ] ) ; // Convert string to type double
            } // End of try
            catch( FormatException ) { 
            MatrixAInput[ i ] = "0" ; // null input taken as 0
            } // End of catch
            //
        } // End of for-each
        //
        // Test input for matrix B and convert valid values to double
        for( int i = 0 ; i < MatrixBInput.Length ; i++ ) { 
        //
            try{
            MatrixB[ i ] = Convert.ToDouble( MatrixBInput[ i ] ) ; // Convert string to type double
            } // End of try
            catch( FormatException ) { 
           MatrixBInput[ i ] = "0" ; // null input taken as 0
            } // End of catch
            //
        } // End of for-each
        //
        ///////////////////////////////////////////////////////////////////////////////////////////
        //////////
        //////////  Work Column 1
        //////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 1 : Row 1
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Check the value of A11
        if( MatrixA[ 0 ] == 1 ) { // if A11 = 1
        //
        //  Pivot is set for next step
        OutputBox.Items.Add( "A11 = 1" ) ;
        //
        } // End of if
        else if( MatrixA[ 0 ] == 0 ) {  // If A11 = 0 , Row swap needed
        //
            //  Check other rows in column for potential swap
            if( MatrixA[ 3 ] != 0 ) { 
            //
                //  Swap Row 1 and Row 2
                for( int i = 0 ; i < MatrixA.Length ; i++ ) {
                MatrixTempA[ i ] = MatrixA[ i ] ; // Copy matrix A
                MatrixTempB[ i ] = MatrixB[ i ] ; // Copy matrix B
                } // End of for
            //
            // Matrix A Swapping
            MatrixA[ 0 ] = MatrixTempA[ 3 ] ;
            MatrixA[ 1 ] = MatrixTempA[ 4 ] ;
            MatrixA[ 2 ] = MatrixTempA[ 5 ] ;
            MatrixA[ 3 ] = MatrixTempA[ 0 ] ;
            MatrixA[ 4 ] = MatrixTempA[ 1 ] ;
            MatrixA[ 5 ] = MatrixTempA[ 2 ] ;
            //
            // Matrix B Swapping
            MatrixB[ 0 ] = MatrixTempB[ 3 ] ;
            MatrixB[ 1 ] = MatrixTempB[ 4 ] ;
            MatrixB[ 2 ] = MatrixTempB[ 5 ] ;
            MatrixB[ 3 ] = MatrixTempB[ 0 ] ;
            MatrixB[ 4 ] = MatrixTempB[ 1 ] ;
            MatrixB[ 5 ] = MatrixTempB[ 2 ] ;
            //
            OutputBox.Items.Add( "Swapped Rows 1 and 2" ) ;
            } // End of if
            else if( MatrixA[ 6 ] != 0 ) { 
            //  Swap Row 1 and Row 3
            //
                for( int i = 0 ; i < MatrixA.Length ; i++ ) {
                MatrixTempA[ i ] = MatrixA[ i ] ; // Copy matrix A
                MatrixTempB[ i ] = MatrixB[ i ] ; // Copy matrix B
                } // End of for
            //
            // Matrix A Swapping
            MatrixA[ 0 ] = MatrixTempA[ 6 ] ;
            MatrixA[ 1 ] = MatrixTempA[ 7 ] ;
            MatrixA[ 2 ] = MatrixTempA[ 8 ] ;
            MatrixA[ 6 ] = MatrixTempA[ 0 ] ;
            MatrixA[ 7 ] = MatrixTempA[ 1 ] ;
            MatrixA[ 8 ] = MatrixTempA[ 2 ] ;
            //
            // Matrix B Swapping
            MatrixB[ 0 ] = MatrixTempB[ 6 ] ;
            MatrixB[ 1 ] = MatrixTempB[ 7 ] ;
            MatrixB[ 2 ] = MatrixTempB[ 8 ] ;
            MatrixB[ 6 ] = MatrixTempB[ 0 ] ;
            MatrixB[ 7 ] = MatrixTempB[ 1 ] ;
            MatrixB[ 8 ] = MatrixTempB[ 2 ] ;
            //
            OutputBox.Items.Add( "Swapped Rows 1 and 3" ) ;
            } // End of else if
            else{
            //
            Col1Null = true ; // Column 1 may be 'recycled'
            OutputBox.Items.Add( "Column 1 inoperable, all zeros." ) ;
            goto COL2 ; // Skip ahead if all values in column 1 are zero
            //
            } // End of else
            //
        } // End of else-if
        //
            if( MatrixA[ 0 ] != 1 && MatrixA[ 0 ] != 0  ) { // A11 != 0 or 1 ,Reduce row to make value = 1
            //
            PrintValue = MatrixA[ 0 ] ;
            TempValue = 1/MatrixA[ 0 ] ; // x = 1/A11
            //
            //  Matrix A - Row 1 multipied by Tempvalue
            MatrixA[ 0 ] = MatrixA[ 0 ] * TempValue ; // A11 <- A11 * x
            MatrixA[ 1 ] = MatrixA[ 1 ] * TempValue ; // A12 <- A12 * x
            MatrixA[ 2 ] = MatrixA[ 2 ] * TempValue ; // A12 <- A13 * x 
            //  Matrix B - Row 1 multipied by Tempvalue
            MatrixB[ 0 ] = MatrixB[ 0 ] * TempValue ; // B11 <- B11 * x
            MatrixB[ 1 ] = MatrixB[ 1 ] * TempValue ; // B12 <- B12 * x
            MatrixB[ 2 ] = MatrixB[ 2 ] * TempValue ; // B13 <- B13 * x
            //
            TempString = String.Format( "Row 1 multiplied by ( 1 / {0} )" , PrintValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A11 = {0} " , MatrixA[ 0 ] ) ;
            OutputBox.Items.Add( TempString ) ;
            } // End of if
            //
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 1 : Row 2
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Reduce value of A21 so it equals 0
            if( MatrixA[ 3 ] > 0 ) { // If A21 is Positive
            //
            TempValue = -1 * MatrixA[ 3 ] ; // x = -1 * A21
            //  Matrix A
            MatrixA[ 3 ] = MatrixA[ 0 ] * TempValue + MatrixA[ 3 ] ; // A21 <- A21 + ( A11 * x )
            MatrixA[ 4 ] = MatrixA[ 1 ] * TempValue + MatrixA[ 4 ] ; // A22 <- A22 + ( A12 * x )
            MatrixA[ 5 ] = MatrixA[ 2 ] * TempValue + MatrixA[ 5 ] ; // A23 <- A23 + ( A13 * x )
            //  Matrix B
            MatrixB[ 3 ] = MatrixB[ 0 ] * TempValue + MatrixB[ 3 ] ; // B21 <- B21 + ( B11 * x )
            MatrixB[ 4 ] = MatrixB[ 1 ] * TempValue + MatrixB[ 4 ] ; // B22 <- B22 + ( B12 * x )
            MatrixB[ 5 ] = MatrixB[ 2 ] * TempValue + MatrixB[ 5 ] ; // B23 <- B23 + ( B13 * x )
            TempString = String.Format( "Row 2 = Row 2 + ( Row 1 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A21 = {0} " , MatrixA[ 3 ] ) ;
            OutputBox.Items.Add( TempString ) ;
            //
            } // End of if
            else if( MatrixA[ 3 ] < 0 ) { // If A21 Negative
            //        
            TempValue = Math.Abs( MatrixA[ 3 ] ) ; // (5) <- (-5)
            //  Matrix A
            MatrixA[ 3 ] = MatrixA[ 0 ] * TempValue + MatrixA[ 3 ] ; // A21 <- A21 + ( A11 * x )
            MatrixA[ 4 ] = MatrixA[ 1 ] * TempValue + MatrixA[ 4 ] ; // A22 <- A22 + ( A12 * x )
            MatrixA[ 5 ] = MatrixA[ 2 ] * TempValue + MatrixA[ 5 ] ; // A23 <- A23 + ( A13 * x )
            //  Matrix B
            MatrixB[ 3 ] = MatrixB[ 0 ] * TempValue + MatrixB[ 3 ] ; // B21 <- B21 + ( B11 * x )
            MatrixB[ 4 ] = MatrixB[ 1 ] * TempValue + MatrixB[ 4 ] ; // B22 <- B22 + ( B12 * x )
            MatrixB[ 5 ] = MatrixB[ 2 ] * TempValue + MatrixB[ 5 ] ; // B23 <- B23 + ( B13 * x )
            //
            TempString = String.Format( "Row 2 = Row 2 + ( Row 1 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A21 = {0} " , MatrixA[ 3 ] ) ;
            OutputBox.Items.Add( TempString ) ;
            } // End of if-else
            else{
            TempString = String.Format( "A21 = {0} " , MatrixA[ 3 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            } // End of else 
            //
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 1 : Row 3
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Reduce value of A31 so it equals 0
            if( MatrixA[ 6 ] > 0 ) { // If A31 is Positive
            //
            TempValue = -1 * MatrixA[ 6 ] ; // x = -1 * A21
            //  Matrix A
            MatrixA[ 6 ] = MatrixA[ 0 ] * TempValue + MatrixA[ 6 ] ; // A31 <- A31 + ( A11 * x )
            MatrixA[ 7 ] = MatrixA[ 1 ] * TempValue + MatrixA[ 7 ] ; // A32 <- A32 + ( A12 * x )
            MatrixA[ 8 ] = MatrixA[ 2 ] * TempValue + MatrixA[ 8 ] ; // A33 <- A33 + ( A13 * x )
            //  Matrix B
            MatrixB[ 6 ] = MatrixB[ 0 ] * TempValue + MatrixB[ 6 ] ; // B31 <- B31 + ( B11 * x )
            MatrixB[ 7 ] = MatrixB[ 1 ] * TempValue + MatrixB[ 7 ] ; // B32 <- B32 + ( B12 * x )
            MatrixB[ 8 ] = MatrixB[ 2 ] * TempValue + MatrixB[ 8 ] ; // B33 <- B33 + ( B13 * x )
            //
            TempString = String.Format( "Row 3 = Row 3 + ( Row 1 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A31 = {0} " , MatrixA[ 6 ] ) ;
            OutputBox.Items.Add( TempString ) ;
            } // End of if
            else if( MatrixA[ 6 ] < 0 ) { // If A31 Negative
            //            
            TempValue = Math.Abs( MatrixA[ 6 ] ) ; // (5) <- (-5)
            //  Matrix A
            MatrixA[ 6 ] = MatrixA[ 0 ] * TempValue + MatrixA[ 6 ] ; // A31 <- A31 + ( A11 * x )
            MatrixA[ 7 ] = MatrixA[ 1 ] * TempValue + MatrixA[ 7 ] ; // A32 <- A32 + ( A12 * x )
            MatrixA[ 8 ] = MatrixA[ 2 ] * TempValue + MatrixA[ 8 ] ; // A33 <- A33 + ( A13 * x )
            //  Matrix B
            MatrixB[ 6 ] = MatrixB[ 0 ] * TempValue + MatrixB[ 6 ] ; // B31 <- B31 + ( B11 * x )
            MatrixB[ 7 ] = MatrixB[ 1 ] * TempValue + MatrixB[ 7 ] ; // B32 <- B32 + ( B12 * x )
            MatrixB[ 8 ] = MatrixB[ 2 ] * TempValue + MatrixB[ 8 ] ; // B33 <- B33 + ( B13 * x )
            //
            TempString = String.Format( "Row 3 = Row 3 + ( Row 1 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A31 = {0} " , MatrixA[ 6 ] ) ;
            OutputBox.Items.Add( TempString ) ;
            //
            } // End of if-else
            //
            else{
            TempString = String.Format( "A31 = {0} " , MatrixA[ 6 ] ) ;
            OutputBox.Items.Add( TempString ) ;      
            } // End of else 
            //
        //
        COL2: // Skip to here if all values in column 1 are zero
        //
            OutputBox.Items.Add( "Current Matrix A" ) ;
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 0 ] , MatrixA[ 1 ] , MatrixA[ 2 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 3 ] , MatrixA[ 4 ] , MatrixA[ 5 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 6 ] , MatrixA[ 7 ] , MatrixA[ 8 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
        //
        OutputBox.Items.Add( " " ) ;
        OutputBox.Items.Add( "> > > Finished with column 1, moving to column 2" ) ;
        OutputBox.Items.Add( " " ) ;
        //
        ///////////////////////////////////////////////////////////////////////////////////////////
        //////////
        //////////  Work Column 2
        //////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 2 : Row 2
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Check the value of A22
        if( MatrixA[ 4 ] == 1 ) { // if A22 = 1
        //
        //  Pivot is set for next step
        OutputBox.Items.Add( "A22 = 1" ) ;
        //
        } // End of if
        else if( MatrixA[ 4 ] == 0 ) {  // If A22 = 0 , Row swap needed
        //
            //  Check other rows in column for potential swap
            if( MatrixA[ 1 ] != 0 && Col1Null == true ) { 
            //  Swap Row 1 and Row 2
            //
                for( int i = 0 ; i < MatrixA.Length ; i++ ) {
                MatrixTempA[ i ] = MatrixA[ i ] ; // Copy matrix A
                MatrixTempB[ i ] = MatrixB[ i ] ; // Copy matrix B
                } // End of for
                //
            // Matrix A Swapping
            MatrixA[ 0 ] = MatrixTempA[ 3 ] ;
            MatrixA[ 1 ] = MatrixTempA[ 4 ] ;
            MatrixA[ 2 ] = MatrixTempA[ 5 ] ;
            MatrixA[ 3 ] = MatrixTempA[ 0 ] ;
            MatrixA[ 4 ] = MatrixTempA[ 1 ] ;
            MatrixA[ 5 ] = MatrixTempA[ 2 ] ;
            //
            // Matrix B Swapping
            MatrixB[ 0 ] = MatrixTempB[ 3 ] ;
            MatrixB[ 1 ] = MatrixTempB[ 4 ] ;
            MatrixB[ 2 ] = MatrixTempB[ 5 ] ;
            MatrixB[ 3 ] = MatrixTempB[ 0 ] ;
            MatrixB[ 4 ] = MatrixTempB[ 1 ] ;
            MatrixB[ 5 ] = MatrixTempB[ 2 ] ;
            //
            Col1Null = false ;
            OutputBox.Items.Add( "Swapped Rows 1 and 2" ) ;
            } // End of if
            //  Check other rows in column for potential swap
            else if( MatrixA[ 7 ] != 0 ) { 
            //  Swap Row 2 and Row 3
            //
                for( int i = 0 ; i < MatrixA.Length ; i++ ) {
                MatrixTempA[ i ] = MatrixA[ i ] ; // Copy matrix A
                MatrixTempB[ i ] = MatrixB[ i ] ; // Copy matrix B
                } // End of for
                //
            // Matrix A Swapping
            MatrixA[ 3 ] = MatrixTempA[ 6 ] ;
            MatrixA[ 4 ] = MatrixTempA[ 7 ] ;
            MatrixA[ 5 ] = MatrixTempA[ 8 ] ;
            MatrixA[ 6 ] = MatrixTempA[ 3 ] ;
            MatrixA[ 7 ] = MatrixTempA[ 4 ] ;
            MatrixA[ 8 ] = MatrixTempA[ 5 ] ;
            //
            // Matrix B Swapping
            MatrixB[ 3 ] = MatrixTempB[ 6 ] ;
            MatrixB[ 4 ] = MatrixTempB[ 7 ] ;
            MatrixB[ 5 ] = MatrixTempB[ 8 ] ;
            MatrixB[ 6 ] = MatrixTempB[ 3 ] ;
            MatrixB[ 7 ] = MatrixTempB[ 4 ] ;
            MatrixB[ 8 ] = MatrixTempB[ 5 ] ;
            //
            OutputBox.Items.Add( "Swapped Rows 2 and 3" ) ;
            } // End of else-if
            else{
            //
            Col2Null = true ;
            OutputBox.Items.Add( "Column 2 inoperable" ) ;
            goto COL3 ; // Skip to column 3
            //
            } // End of else
            //
        } // End of else-if
        //    
            if( MatrixA[ 4 ] != 1 && MatrixA[ 4 ] != 0  ) { // A22 != 0 or 1 ,Reduce row to make value = 1
            //
            PrintValue = MatrixA[ 4 ] ;
            TempValue = 1/MatrixA[ 4 ] ; // x = 1/A22
            //
            //  Matrix A - Row 2 multipied by Tempvalue
            MatrixA[ 3 ] = MatrixA[ 3 ] * TempValue ; // A21 <- A21 * x
            MatrixA[ 4 ] = MatrixA[ 4 ] * TempValue ; // A22 <- A22 * x
            MatrixA[ 5 ] = MatrixA[ 5 ] * TempValue ; // A23 <- A23 * x 
            //  Matrix B - Row 2 multipied by Tempvalue
            MatrixB[ 3 ] = MatrixB[ 3 ] * TempValue ; // B21 <- B21 * x
            MatrixB[ 4 ] = MatrixB[ 4 ] * TempValue ; // B22 <- B22 * x
            MatrixB[ 5 ] = MatrixB[ 5 ] * TempValue ; // B23 <- B23 * x
            //
            TempString = String.Format( "Row 2 multiplied by ( 1 / {0} )" , PrintValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A22 = {0} " , MatrixA[ 4 ] ) ;
            OutputBox.Items.Add( TempString ) ;
            } // End of if
            //
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 2 : Row 1
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Reduce value of A12 so it equals 0
            if( MatrixA[ 1 ] > 0 ) { // If A12 is Positive
            //
            TempValue = -1 * MatrixA[ 1 ] ; // x = -1 * A21
            //  Matrix A
            MatrixA[ 0 ] = MatrixA[ 3 ] * TempValue + MatrixA[ 0 ] ; // A11 <- A11 + ( A21 * x )
            MatrixA[ 1 ] = MatrixA[ 4 ] * TempValue + MatrixA[ 1 ] ; // A12 <- A12 + ( A22 * x )
            MatrixA[ 2 ] = MatrixA[ 5 ] * TempValue + MatrixA[ 2 ] ; // A13 <- A13 + ( A23 * x )
            //  Matrix B
            MatrixB[ 0 ] = MatrixB[ 3 ] * TempValue + MatrixB[ 0 ] ; // B11 <- B11 + ( B21 * x )
            MatrixB[ 1 ] = MatrixB[ 4 ] * TempValue + MatrixB[ 1 ] ; // B12 <- B12 + ( B22 * x )
            MatrixB[ 2 ] = MatrixB[ 5 ] * TempValue + MatrixB[ 2 ] ; // B13 <- B13 + ( B23 * x )
            //
            TempString = String.Format( "Row 1 = Row 1 + ( Row 2 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;    
            TempString = String.Format( "A12 = {0} " , MatrixA[ 1 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            //
            } // End of if
            else if( MatrixA[ 1 ] < 0 ) { // If A12 is Negative
            //        
            TempValue = Math.Abs( MatrixA[ 1 ] ) ; // (5) <- (-5)
            //  Matrix A
            MatrixA[ 0 ] = MatrixA[ 3 ] * TempValue + MatrixA[ 0 ] ; // A11 <- A11 + ( A21 * x )
            MatrixA[ 1 ] = MatrixA[ 4 ] * TempValue + MatrixA[ 1 ] ; // A12 <- A12 + ( A22 * x )
            MatrixA[ 2 ] = MatrixA[ 5 ] * TempValue + MatrixA[ 2 ] ; // A13 <- A13 + ( A23 * x )
            //  Matrix B
            MatrixB[ 0 ] = MatrixB[ 3 ] * TempValue + MatrixB[ 0 ] ; // B11 <- B11 + ( B21 * x )
            MatrixB[ 1 ] = MatrixB[ 4 ] * TempValue + MatrixB[ 1 ] ; // B12 <- B12 + ( B22 * x )
            MatrixB[ 2 ] = MatrixB[ 5 ] * TempValue + MatrixB[ 2 ] ; // B13 <- B13 + ( B23 * x )
            //
            TempString = String.Format( "Row 1 = Row 1 + ( Row 2 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;    
            TempString = String.Format( "A12 = {0} " , MatrixA[ 1 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            } // End of if-else
            else{
            TempString = String.Format( "A12 = {0} " , MatrixA[ 1 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            } // End of else 
            //
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 2 : Row 3
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Reduce value of A32 so it equals 0
            if( MatrixA[ 7 ] > 0 ) { // If A32 is Positive
            //
            TempValue = -1 * MatrixA[ 7 ] ; // x = -1 * A32
            //  Matrix A
            MatrixA[ 6 ] = MatrixA[ 3 ] * TempValue + MatrixA[ 6 ] ; // A31 <- A31 + ( A21 * x )
            MatrixA[ 7 ] = MatrixA[ 4 ] * TempValue + MatrixA[ 7 ] ; // A32 <- A32 + ( A22 * x )
            MatrixA[ 8 ] = MatrixA[ 5 ] * TempValue + MatrixA[ 8 ] ; // A33 <- A33 + ( A23 * x )
            //  Matrix B
            MatrixB[ 6 ] = MatrixB[ 3 ] * TempValue + MatrixB[ 6 ] ; // B31 <- B31 + ( B21 * x )
            MatrixB[ 7 ] = MatrixB[ 4 ] * TempValue + MatrixB[ 7 ] ; // B32 <- B32 + ( B22 * x )
            MatrixB[ 8 ] = MatrixB[ 5 ] * TempValue + MatrixB[ 8 ] ; // B33 <- B33 + ( B23 * x )
            //
            TempString = String.Format( "Row 3 = Row 3 + ( Row 2 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;    
            TempString = String.Format( "A32 = {0} " , MatrixA[ 7 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            //
            } // End of if
            else if( MatrixA[ 7 ] < 0 ) { // If A32 is Negative
            //        
            TempValue = Math.Abs( MatrixA[ 7 ] ) ; // (5) <- (-5)
            //  Matrix A
            MatrixA[ 6 ] = MatrixA[ 3 ] * TempValue + MatrixA[ 6 ] ; // A31 <- A31 + ( A21 * x )
            MatrixA[ 7 ] = MatrixA[ 4 ] * TempValue + MatrixA[ 7 ] ; // A32 <- A32 + ( A22 * x )
            MatrixA[ 8 ] = MatrixA[ 5 ] * TempValue + MatrixA[ 8 ] ; // A33 <- A33 + ( A23 * x )
            //  Matrix B
            MatrixB[ 6 ] = MatrixB[ 3 ] * TempValue + MatrixB[ 6 ] ; // B31 <- B31 + ( B21 * x )
            MatrixB[ 7 ] = MatrixB[ 4 ] * TempValue + MatrixB[ 7 ] ; // B32 <- B32 + ( B22 * x )
            MatrixB[ 8 ] = MatrixB[ 5 ] * TempValue + MatrixB[ 8 ] ; // B33 <- B33 + ( B23 * x )
            //
            TempString = String.Format( "Row 3 = Row 3 + ( Row 2 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A32 = {0} " , MatrixA[ 7 ] ) ;
            OutputBox.Items.Add( TempString ) ;      
            //
            } // End of if-else
            else{
            TempString = String.Format( "A32 = {0} " , MatrixA[ 7 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            } // End of else 
            //
        //
        COL3: // Skip to here if all values in column 2 are zero
        //
            OutputBox.Items.Add( "Current Matrix A" ) ;
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 0 ] , MatrixA[ 1 ] , MatrixA[ 2 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 3 ] , MatrixA[ 4 ] , MatrixA[ 5 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 6 ] , MatrixA[ 7 ] , MatrixA[ 8 ] ) ;
            OutputBox.Items.Add( TempString ) ;  

        OutputBox.Items.Add( " " ) ;
        OutputBox.Items.Add( " > > > Finished with column 2, moving to column 3" ) ;
        OutputBox.Items.Add( " " ) ;
        //
        //
        ///////////////////////////////////////////////////////////////////////////////////////////
        //////////
        //////////  Work Column 3
        //////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 3 : Row 3
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Check the value of A33
        if( MatrixA[ 8 ] == 1 ) { // if A33 = 1
        //
        //  Pivot is set for next step
        OutputBox.Items.Add( "A33 = 1" ) ;
        //
        } // End of if
        else if( MatrixA[ 8 ] == 0 ) {  // If A11 = 0 , Row swap needed
        //
            //  Check other rows in column for potential swap
            //  Swap Row 1 and Row 3
            if( MatrixA[ 2 ] != 0 && Col1Null == true ) {
            //
                for( int i = 0 ; i < MatrixA.Length ; i++ ) {
                MatrixTempA[ i ] = MatrixA[ i ] ; // Copy matrix A
                MatrixTempB[ i ] = MatrixB[ i ] ; // Copy matrix B
                } // End of for
            //
            // Matrix A Swapping
            MatrixA[ 0 ] = MatrixTempA[ 6 ] ;
            MatrixA[ 1 ] = MatrixTempA[ 7 ] ;
            MatrixA[ 2 ] = MatrixTempA[ 8 ] ;
            MatrixA[ 6 ] = MatrixTempA[ 0 ] ;
            MatrixA[ 7 ] = MatrixTempA[ 1 ] ;
            MatrixA[ 8 ] = MatrixTempA[ 2 ] ;
            //
            // Matrix B Swapping
            MatrixB[ 0 ] = MatrixTempB[ 6 ] ;
            MatrixB[ 1 ] = MatrixTempB[ 7 ] ;
            MatrixB[ 2 ] = MatrixTempB[ 8 ] ;
            MatrixB[ 6 ] = MatrixTempB[ 0 ] ;
            MatrixB[ 7 ] = MatrixTempB[ 1 ] ;
            MatrixB[ 8 ] = MatrixTempB[ 2 ] ;
            //
            OutputBox.Items.Add( "Swapped Rows 1 and 3" ) ;
            } // End of if
            // Swap Row 2 and Row 3
            else if( MatrixA [ 5 ] != 0 && Col2Null == true ) {
            //
                for( int i = 0 ; i < MatrixA.Length ; i++ ) {
                MatrixTempA[ i ] = MatrixA[ i ] ; // Copy matrix A
                MatrixTempB[ i ] = MatrixB[ i ] ; // Copy matrix B
                } // End of for
                //
            // Matrix A Swapping
            MatrixA[ 3 ] = MatrixTempA[ 6 ] ;
            MatrixA[ 4 ] = MatrixTempA[ 7 ] ;
            MatrixA[ 5 ] = MatrixTempA[ 8 ] ;
            MatrixA[ 6 ] = MatrixTempA[ 3 ] ;
            MatrixA[ 7 ] = MatrixTempA[ 4 ] ;
            MatrixA[ 8 ] = MatrixTempA[ 5 ] ;
            //
            // Matrix B Swapping
            MatrixB[ 3 ] = MatrixTempB[ 6 ] ;
            MatrixB[ 4 ] = MatrixTempB[ 7 ] ;
            MatrixB[ 5 ] = MatrixTempB[ 8 ] ;
            MatrixB[ 6 ] = MatrixTempB[ 3 ] ;
            MatrixB[ 7 ] = MatrixTempB[ 4 ] ;
            MatrixB[ 8 ] = MatrixTempB[ 5 ] ;
            //
            OutputBox.Items.Add( "Swapped Rows 2 and 3" ) ;
            } // End of else if
            else{ 
            OutputBox.Items.Add( "Column 3 inoperable" ) ;
            goto MatrixPrint ; // Skip column 3 if all values are zero
            }
            //
        } // End of else-if
        //  
            if( MatrixA[ 8 ] != 1 && MatrixA[ 8 ] != 0  ) { // A33 != 0 or 1 ,Reduce row to make value = 1
            //
            PrintValue = MatrixA[ 8 ] ;
            TempValue = 1/MatrixA[ 8 ] ; // x = 1/A33
            //
            //  Matrix A - Row 3 multipied by Tempvalue
            MatrixA[ 6 ] = MatrixA[ 6 ] * TempValue ; // A31 <- A31 * x
            MatrixA[ 7 ] = MatrixA[ 7 ] * TempValue ; // A32 <- A32 * x
            MatrixA[ 8 ] = MatrixA[ 8 ] * TempValue ; // A33 <- A33 * x 
            //  Matrix B - Row 3 multipied by Tempvalue
            MatrixB[ 6 ] = MatrixB[ 6 ] * TempValue ; // B31 <- B31 * x
            MatrixB[ 7 ] = MatrixB[ 7 ] * TempValue ; // B32 <- B32 * x
            MatrixB[ 8 ] = MatrixB[ 8 ] * TempValue ; // B33 <- B33 * x
            //
            TempString = String.Format( "Row 3 multiplied by ( 1 / {0} )" , PrintValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A33 = {0} " , MatrixA[ 8 ] ) ;
            OutputBox.Items.Add( TempString ) ;
            } // End of if
            //
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 3 : Row 1
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Reduce value of A13 so it equals 0
            if( MatrixA[ 2 ] > 0 ) { // If A13 is Positive
            //
            TempValue = -1 * MatrixA[ 2 ] ; // x = -1 * A13
            //  Matrix A
            MatrixA[ 0 ] = MatrixA[ 6 ] * TempValue + MatrixA[ 0 ] ; // A11 <- A11 + ( A31 * x )
            MatrixA[ 1 ] = MatrixA[ 7 ] * TempValue + MatrixA[ 1 ] ; // A12 <- A12 + ( A32 * x )
            MatrixA[ 2 ] = MatrixA[ 8 ] * TempValue + MatrixA[ 2 ] ; // A13 <- A13 + ( A33 * x )
            //  Matrix B
            MatrixB[ 0 ] = MatrixB[ 6 ] * TempValue + MatrixB[ 0 ] ; // B11 <- B11 + ( B31 * x )
            MatrixB[ 1 ] = MatrixB[ 7 ] * TempValue + MatrixB[ 1 ] ; // B12 <- B12 + ( B32 * x )
            MatrixB[ 2 ] = MatrixB[ 8 ] * TempValue + MatrixB[ 2 ] ; // B13 <- B13 + ( B33 * x )
            //
            TempString = String.Format( "Row 1 = Row 1 + ( Row 3 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;    
            TempString = String.Format( "A13 = {0} " , MatrixA[ 2 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            //
            } // End of if
            else if( MatrixA[ 2 ] < 0 ) { // If A13 Negative
            //        
            TempValue = Math.Abs( MatrixA[ 2 ] ) ; // (5) <- (-5)
            //  Matrix A
            MatrixA[ 0 ] = MatrixA[ 6 ] * TempValue + MatrixA[ 0 ] ; // A11 <- A11 + ( A31 * x )
            MatrixA[ 1 ] = MatrixA[ 7 ] * TempValue + MatrixA[ 1 ] ; // A12 <- A12 + ( A32 * x )
            MatrixA[ 2 ] = MatrixA[ 8 ] * TempValue + MatrixA[ 2 ] ; // A13 <- A13 + ( A33 * x )
            //  Matrix B
            MatrixB[ 0 ] = MatrixB[ 6 ] * TempValue + MatrixB[ 0 ] ; // B11 <- B11 + ( B31 * x )
            MatrixB[ 1 ] = MatrixB[ 7 ] * TempValue + MatrixB[ 1 ] ; // B12 <- B12 + ( B32 * x )
            MatrixB[ 2 ] = MatrixB[ 8 ] * TempValue + MatrixB[ 2 ] ; // B13 <- B13 + ( B33 * x )
            //
            TempString = String.Format( "Row 1 = Row 1 + ( Row 3 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;   
            TempString = String.Format( "A13 = {0} " , MatrixA[ 2 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            //
            } // End of if-else
            else{
            TempString = String.Format( "A13 = {0} " , MatrixA[ 2 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            } // End of else 
            //
        //
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //  Column 3 : Row 2
        //  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
        //
        //  Reduce value of A23 so it equals 0
            if( MatrixA[ 5 ] > 0 ) { // If A23 is Positive
            //
            TempValue = -1 * MatrixA[ 5 ] ; // x = -1 * A23
            //  Matrix A
            MatrixA[ 3 ] = MatrixA[ 6 ] * TempValue + MatrixA[ 3 ] ; // A21 <- A21 + ( A31 * x )
            MatrixA[ 4 ] = MatrixA[ 7 ] * TempValue + MatrixA[ 4 ] ; // A22 <- A22 + ( A32 * x )
            MatrixA[ 5 ] = MatrixA[ 8 ] * TempValue + MatrixA[ 5 ] ; // A23 <- A23 + ( A33 * x )
            //  Matrix B
            MatrixB[ 3 ] = MatrixB[ 6 ] * TempValue + MatrixB[ 3 ] ; // B21 <- B21 + ( B31 * x )
            MatrixB[ 4 ] = MatrixB[ 7 ] * TempValue + MatrixB[ 4 ] ; // B22 <- B22 + ( B32 * x )
            MatrixB[ 5 ] = MatrixB[ 8 ] * TempValue + MatrixB[ 5 ] ; // B23 <- B23 + ( B33 * x )
            //
            TempString = String.Format( "Row 2 = Row 2 + ( Row 3 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;   
            TempString = String.Format( "A23 = {0} " , MatrixA[ 5 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            //
            } // End of if
            else if( MatrixA[ 5 ] < 0 ) { // If A23 is Negative
            //        
            TempValue = Math.Abs( MatrixA[ 5 ] ) ; // (5) <- (-5)
            //  Matrix A
            MatrixA[ 3 ] = MatrixA[ 6 ] * TempValue + MatrixA[ 3 ] ; // A21 <- A21 + ( A31 * x )
            MatrixA[ 4 ] = MatrixA[ 7 ] * TempValue + MatrixA[ 4 ] ; // A22 <- A22 + ( A32 * x )
            MatrixA[ 5 ] = MatrixA[ 8 ] * TempValue + MatrixA[ 5 ] ; // A23 <- A23 + ( A33 * x )
            //  Matrix B
            MatrixB[ 3 ] = MatrixB[ 6 ] * TempValue + MatrixB[ 3 ] ; // B21 <- B21 + ( B31 * x )
            MatrixB[ 4 ] = MatrixB[ 7 ] * TempValue + MatrixB[ 4 ] ; // B22 <- B22 + ( B32 * x )
            MatrixB[ 5 ] = MatrixB[ 8 ] * TempValue + MatrixB[ 5 ] ; // B23 <- B23 + ( B33 * x )
            //
            TempString = String.Format( "Row 2 = Row 2 + ( Row 3 * {0} )" , TempValue ) ;
            OutputBox.Items.Add( TempString ) ;
            TempString = String.Format( "A23 = {0} " , MatrixA[ 5 ] ) ;
            OutputBox.Items.Add( TempString ) ;    
            //
            } // End of if-else
            else{
            TempString = String.Format( "A23 = {0} " , MatrixA[ 5 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            } // End of else 
            //
        //
        ///////////////////////////////////////////////////////////////////////////////////////////
        //////////
        //////////  Printer
        //////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        //
        MatrixPrint: // Skip to here if all values in column 3 are zero
        //
            OutputBox.Items.Add( "Current Matrix A" ) ;   
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 0 ] , MatrixA[ 1 ] , MatrixA[ 2 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 3 ] , MatrixA[ 4 ] , MatrixA[ 5 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            TempString = String.Format( "|  {0}  {1}  {2}  |" , MatrixA[ 6 ] , MatrixA[ 7 ] , MatrixA[ 8 ] ) ;
            OutputBox.Items.Add( TempString ) ;  
            //
            // Round results ( xx.yyyyy -> xx.yy )
            for( int i = 0 ; i < MatrixA.Length ; i++ ) { 
            MatrixA[ i ] = Math.Round( MatrixA [ i ] , 2 ) ;
            MatrixB[ i ] = Math.Round( MatrixB [ i ] , 2 ) ;
            } // End of for
            //
            OutputBox.Items.Add( " " ) ;  
            OutputBox.Items.Add( "Displaying results to Matrix Output Group" ) ; 
            OutputBox.Items.Add( " " ) ;   
            //

            if( MatrixA[ 0 ] != 1 ) {
            OutputBox.Items.Add( "Column 1 is NOT in RREF form." ) ;  
            } // End of if 
            //
            if( MatrixA[ 4 ] != 1 ) {
            OutputBox.Items.Add( "Column 2 is NOT in RREF form." ) ;  
            } // End of if 
            //
            if( MatrixA[ 8 ] != 1 ) {
            OutputBox.Items.Add( "Column 3 is NOT in RREF form." ) ;  
            } // End of if 
            // 
        // Display Matrix A result
        OutputA11.Text = MatrixA[ 0 ].ToString( ) ;
        OutputA12.Text = MatrixA[ 1 ].ToString( ) ;
        OutputA13.Text = MatrixA[ 2 ].ToString( ) ;
        OutputA21.Text = MatrixA[ 3 ].ToString( ) ;
        OutputA22.Text = MatrixA[ 4 ].ToString( ) ;        
        OutputA23.Text = MatrixA[ 5 ].ToString( ) ;
        OutputA31.Text = MatrixA[ 6 ].ToString( ) ;
        OutputA32.Text = MatrixA[ 7 ].ToString( ) ;
        OutputA33.Text = MatrixA[ 8 ].ToString( ) ;
        //  Display Matrix B result
        OutputB11.Text = MatrixB[ 0 ].ToString( ) ;
        OutputB12.Text = MatrixB[ 1 ].ToString( ) ;
        OutputB13.Text = MatrixB[ 2 ].ToString( ) ;
        OutputB21.Text = MatrixB[ 3 ].ToString( ) ;
        OutputB22.Text = MatrixB[ 4 ].ToString( ) ;
        OutputB23.Text = MatrixB[ 5 ].ToString( ) ;
        OutputB31.Text = MatrixB[ 6 ].ToString( ) ;
        OutputB32.Text = MatrixB[ 7 ].ToString( ) ;
        OutputB33.Text = MatrixB[ 8 ].ToString( ) ;
        //
        } // End of RREF calculation Button
        //
/************************************************
Random Button00
    Assigns random values to matrices( -99 to 99 )
************************************************/
        private void RandomButton00_Click( object sender , EventArgs e ) {
        //
        Random RANDOM = new Random( ) ;
        //
        double[ ] RandomMatrix = {
                            0.0 , 0.0 , 0.0 ,   // Row 1
                            0.0 , 0.0 , 0.0 ,   // Row 2
                            0.0 , 0.0 , 0.0     // Row 3
                            } ;
        //
        for( int i = 0 ; i < RandomMatrix.Length ; i++ ) {  // Make random matrix
        RandomMatrix[ i ] = RANDOM.Next( -99 , 99 ) ;
        } // End of for
        // 
        //  Fill the input values for matrix A from the random matrix
        InputA11.Text = RandomMatrix[ 0 ].ToString( ) ;
        InputA12.Text = RandomMatrix[ 1 ].ToString( ) ;
        InputA13.Text = RandomMatrix[ 2 ].ToString( ) ;
        InputA21.Text = RandomMatrix[ 3 ].ToString( ) ;
        InputA22.Text = RandomMatrix[ 4 ].ToString( ) ;
        InputA23.Text = RandomMatrix[ 5 ].ToString( ) ;
        InputA31.Text = RandomMatrix[ 6 ].ToString( ) ;
        InputA32.Text = RandomMatrix[ 7 ].ToString( ) ;
        InputA33.Text = RandomMatrix[ 8 ].ToString( ) ;
        //
        //
        for( int i = 0 ; i < RandomMatrix.Length ; i++ ) { // Make another random matrix
        RandomMatrix[ i ] = RANDOM.Next( -99 , 99 ) ;
        } // End of for
        //
        //  Fill the input values for matrix B from the random matrix
        InputB11.Text = RandomMatrix[ 0 ].ToString( ) ;
        InputB12.Text = RandomMatrix[ 1 ].ToString( ) ;
        InputB13.Text = RandomMatrix[ 2 ].ToString( ) ;
        InputB21.Text = RandomMatrix[ 3 ].ToString( ) ;
        InputB22.Text = RandomMatrix[ 4 ].ToString( ) ;
        InputB23.Text = RandomMatrix[ 5 ].ToString( ) ;
        InputB31.Text = RandomMatrix[ 6 ].ToString( ) ;
        InputB32.Text = RandomMatrix[ 7 ].ToString( ) ;
        InputB33.Text = RandomMatrix[ 8 ].ToString( ) ;
        //
        } // End of random button00
        //
/************************************************
Random Button0
    Assigns random values to matrices( -9 to 9 )
************************************************/
        //
        private void RandomButton0_Click( object sender , EventArgs e ) {
        //
        Random RANDOM = new Random( ) ;
        //
        double[ ] RandomMatrix = {
                            0.0 , 0.0 , 0.0 ,   // Row 1
                            0.0 , 0.0 , 0.0 ,   // Row 2
                            0.0 , 0.0 , 0.0     // Row 3
                            } ;
        //
        for( int i = 0 ; i < RandomMatrix.Length ; i++ ) {  // Make random matrix
        RandomMatrix[ i ] = RANDOM.Next( -9 , 9 ) ;
        } // End of for
        // 
        //  Fill the input values for matrix A from the random matrix
        InputA11.Text = RandomMatrix[ 0 ].ToString( ) ;
        InputA12.Text = RandomMatrix[ 1 ].ToString( ) ;
        InputA13.Text = RandomMatrix[ 2 ].ToString( ) ;
        InputA21.Text = RandomMatrix[ 3 ].ToString( ) ;
        InputA22.Text = RandomMatrix[ 4 ].ToString( ) ;
        InputA23.Text = RandomMatrix[ 5 ].ToString( ) ;
        InputA31.Text = RandomMatrix[ 6 ].ToString( ) ;
        InputA32.Text = RandomMatrix[ 7 ].ToString( ) ;
        InputA33.Text = RandomMatrix[ 8 ].ToString( ) ;
        //
        //
        for( int i = 0 ; i < RandomMatrix.Length ; i++ ) { // Make another random matrix
        RandomMatrix[ i ] = RANDOM.Next( -9 , 9 ) ;
        } // End of for
        //
        //  Fill the input values for matrix B from the random matrix
        InputB11.Text = RandomMatrix[ 0 ].ToString( ) ;
        InputB12.Text = RandomMatrix[ 1 ].ToString( ) ;
        InputB13.Text = RandomMatrix[ 2 ].ToString( ) ;
        InputB21.Text = RandomMatrix[ 3 ].ToString( ) ;
        InputB22.Text = RandomMatrix[ 4 ].ToString( ) ;
        InputB23.Text = RandomMatrix[ 5 ].ToString( ) ;
        InputB31.Text = RandomMatrix[ 6 ].ToString( ) ;
        InputB32.Text = RandomMatrix[ 7 ].ToString( ) ;
        InputB33.Text = RandomMatrix[ 8 ].ToString( ) ;
        //
        } // End of Randombutton0
        //
/************************************************
Random Button1
    Assigns random values to matrices( -1 to 1 )
************************************************/
        private void RandomButton1_Click( object sender , EventArgs e ) {
        //
        Random RANDOM = new Random( ) ;
        //
        double[ ] RandomMatrix = {
                            0.0 , 0.0 , 0.0 ,   // Row 1
                            0.0 , 0.0 , 0.0 ,   // Row 2
                            0.0 , 0.0 , 0.0     // Row 3
                            } ;
        //
        for( int i = 0 ; i < RandomMatrix.Length ; i++ ) {  // Make random matrix
        RandomMatrix[ i ] = RANDOM.Next( -1 , 1 ) ;
        } // End of for
        // 
        //  Fill the input values for matrix A from the random matrix
        InputA11.Text = RandomMatrix[ 0 ].ToString( ) ;
        InputA12.Text = RandomMatrix[ 1 ].ToString( ) ;
        InputA13.Text = RandomMatrix[ 2 ].ToString( ) ;
        InputA21.Text = RandomMatrix[ 3 ].ToString( ) ;
        InputA22.Text = RandomMatrix[ 4 ].ToString( ) ;
        InputA23.Text = RandomMatrix[ 5 ].ToString( ) ;
        InputA31.Text = RandomMatrix[ 6 ].ToString( ) ;
        InputA32.Text = RandomMatrix[ 7 ].ToString( ) ;
        InputA33.Text = RandomMatrix[ 8 ].ToString( ) ;
        //
        //
        for( int i = 0 ; i < RandomMatrix.Length ; i++ ) { // Make another random matrix
        RandomMatrix[ i ] = RANDOM.Next( -1 , 1 ) ;
        } // End of for
        //
        //  Fill the input values for matrix B from the random matrix
        InputB11.Text = RandomMatrix[ 0 ].ToString( ) ;
        InputB12.Text = RandomMatrix[ 1 ].ToString( ) ;
        InputB13.Text = RandomMatrix[ 2 ].ToString( ) ;
        InputB21.Text = RandomMatrix[ 3 ].ToString( ) ;
        InputB22.Text = RandomMatrix[ 4 ].ToString( ) ;
        InputB23.Text = RandomMatrix[ 5 ].ToString( ) ;
        InputB31.Text = RandomMatrix[ 6 ].ToString( ) ;
        InputB32.Text = RandomMatrix[ 7 ].ToString( ) ;
        InputB33.Text = RandomMatrix[ 8 ].ToString( ) ;
        //
        } // End of RandomButton1
        //
/************************************************
Clear Button
    Resets all textbox and list values to null
************************************************/
        private void ClearButton_Click( object sender , EventArgs e ) {
        //
        OutputBox.Clear( ) ; // Reset List
        //
            //  Reset input
            foreach( Control c in MatrixInputGroup.Controls ) {
            //
                if( c is TextBox ) {
                //
                c.Text = "" ;
                } // End of if
                //
            } // End of foreach
            //
            //  Reset output
            foreach( Control c in MatrixOutputGroup.Controls ) {
            //
                if( c is TextBox ) {
                //
                c.Text = "" ;
                } // End of if
                //
            } // End of foreach
            //
        } //
        //
    } // End of public partial class
    //
} // End of namespace
//

//
//  END OF FILE
//



