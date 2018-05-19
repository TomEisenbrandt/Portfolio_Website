



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

Question 3
Delete an existing race
************************************************/

//	Page header
include("Header.html");

//	Connect to database
require("Conn.php");

//	Output string
echo '<BR>';
echo '<CENTER>';
echo '<H3>';
echo 'Delete a race';
echo '</H3>';
echo '</CENTER>';
echo '<BR>';

//	SQL command for race info
$SQL = "SELECT * FROM z1771209.race";

//	Start text form
echo '<CENTER>';
echo '<form action="Question_3.php" method="post">';
echo 'Choose a race to delete: ';
echo '<BR>';
echo '<TABLE>';
echo '<TR>';
echo '<TD>';
echo '<select name="name" distance="distance">';

foreach($CONN->query($SQL) as $ROW){
echo "<option value='";
echo $ROW['race_id'] ;
echo "'>";
echo $ROW['name'];
echo ' ' ;
echo $ROW['distance'];
echo "</option>";	
}
echo '</select';
echo '</TD>';
echo '<TD>';
echo '<input type="submit" value="Delete">';
echo '</TD>';
echo '</TR>';
echo '</TABLE>';
echo '<BR>';
echo '</form>';
echo '</CENTER>';

/***********************************************/

//	POST to server
if($_SERVER['REQUEST_METHOD'] =='POST'){
$RACE_ID = trim($_POST['race_id']);
$NAME = trim($_POST['name']);
$DISTANCE = trim($_POST['distance']);
	
//	SQL delete from race
$SQL_DELETE = "DELETE FROM z1771209.race (race_id,name,distance) VALUES ('$RACE_ID','$NAME','$DISTANCE')";

//	SQL delete runsin via foriegn key race_id(rid)
//$SQL_DELETE_TWO = "DELETE FROM z1771209.runsin WHERE rid=:RACE_ID"

/*
NOTE
Keep getting errors here, don't know what to do.
*/

//	Check
if($CONN->query($SQL_DELETE)==TRUE){
echo '<CENTER>';
echo 'Data deleted';
echo '</CENTER>';
echo '<BR>';

//	Output for ERROR	
}else{
echo '<CENTER>';
echo 'ERROR: ';
echo $SQL_DELETE ; 
echo '<BR>' ; 
echo $CONN->error;
echo '</CENTER>';
echo '<BR>';
echo '<BR>';
}

/*
try{
//	Delete primary race
$PUPPY = $CONN->prepare($SQL_DELETE);
$DOGGO = $PUPPY->execute(array($RACE_ID,$NAME,$DISTANCE));


//	Handle foriegn keys
$SALAD = $CONN->prepare($SQL_DELETE_TWO);
$SLIME = $SALAD->execute(array(':RACE_ID' => $RACE_ID));
}
*/

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








