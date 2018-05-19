



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

Question 1
Add a new horse (Including the Sire and Dam)
************************************************/

//	Page header
include("Header.html");

//	Connect to database
include("Conn.php");

//	Output string
echo '<BR>';
echo '<CENTER>';
echo '<H3>';
echo 'Add a new Horse, Sire and Dam into database';
echo '</H3>';
echo '</CENTER>';
echo '<BR>';

//	Start text form
echo '<CENTER>';
echo '<form action="Question_1.php" method="post">';
echo 'Enter new names below';
echo '<BR>';
echo 'Horse:';
echo '<input type="text" name="name" id="name">';
echo '<BR>';
echo 'Sire: ';
echo '<input type="text" name="sire" id="sire">';
echo '<BR>';
echo 'Dam:  ';
echo '<input type="text" name="dam" id="dam">';
echo '<BR>';
echo '<BR>';
echo '<input type="submit" name="submit" value="Submit">';
echo '<BR>';
echo '</form>';
echo '</CENTER>';

/***********************************************/

//	POST to server
if($_SERVER['REQUEST_METHOD'] =='POST'){
$NAME = trim($_POST['name']);
$SIRE = trim($_POST['sire']);
$DAM  = trim($_POST['dam']);
	
//	SQL command
$SQL = "INSERT INTO z1771209.horse (name,sire,dam) VALUES ('$NAME','$SIRE','$DAM')";

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





