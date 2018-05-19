



<?PHP

/************************************************
NAME:		TOM EISENBRANDT
ZID:		Z1771209
CLASS:		CSCI 466
SECTION:	2
PROJECT:	11
INSTRUCTOR:	Georgia Brown
TA:			Priyanka Kondapuram
DUE DATE:	NOVEMBER 27 2017 11:59 PM

Question 2
Add a new race
************************************************/

//	Page header
include("Header.html");

//	Connect to database
require("Conn.php");

//	Output string
echo '<BR>';
echo '<CENTER>';
echo '<H3>';
echo 'Add a new race';
echo '</H3>';
echo '</CENTER>';
echo '<BR>';

//	Start text form
echo '<CENTER>';
echo '<form action="Question_2.php" method="post">';
echo 'Enter new horse name:';
echo '<BR>';
echo 'Name:    ';
echo '<input type="text" name="name" id="name">';
echo '<BR>';
echo 'Distance:';
echo '<input type="text" name="distance" id="distance">';
echo '<BR>';
echo '<input type="submit" name="submit" value="Submit">';
echo '<BR>';
echo '</form>';
echo '</CENTER>';

//	POST to server
if($_SERVER['REQUEST_METHOD'] =='POST'){
$NAME     = trim($_POST['name']);
$DISTANCE = trim($_POST['distance']);

//	SQL command
$SQL = "INSERT INTO z1771209.race (name,distance) VALUES( 'NAME' , '$DISTANCE' )";

//	Check
if($CONN->query($SQL)==TRUE){
echo '<CENTER>';
echo 'New Data Imported';
echo '</CENTER>';
echo '<BR>';

//	Output for ERROR	
}else{
echo '<CENTER>';
echo 'ERROR: ';
echo $SQL ; 
echo '<BR>' ; 
echo $CONN->error;
echo '</CENTER>';
echo '<BR>';
echo '<BR>';
}

}	

//	Link to entire database view
echo '<CENTER>';
echo '<A href="Data.php">';
echo ' ~ View Data ~ ';
echo '</A>'; 
echo '</CENTER>';

//	Page footer
include("Footer.html");

?>





