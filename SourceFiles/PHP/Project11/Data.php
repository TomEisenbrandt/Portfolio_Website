



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

Database
Show all current data
************************************************/

//	Page header
include("Header.html");

//	Connect to database
require("Conn.php");

/************************************************
Table horse
************************************************/
echo '<BR>';
echo '<CENTER>';
echo '<H3>';
echo 'Table: Horse [horse]';
echo '</H3>';
echo '</CENTER>';
echo '<BR>';
echo '<HR>';
echo '<BR>';

$SQL_ONE = 'SELECT * from z1771209.horse';
$SQL = $CONN->query($SQL_ONE);

echo '<CENTER>';
echo ' ~ NAME - SIRE - DAM ~ ';
echo '</CENTER>';

while($ROW=$SQL->fetch(PDO::FETCH_ASSOC)){
echo '<CENTER>';
echo ' ~ ';
echo $ROW['name'];
echo ' - ';
echo $ROW['sire'];
echo ' - ';
echo $ROW['dam'];
echo ' ~ ';
echo '</CENTER>';
echo '<BR>';
}



/************************************************
Table race
************************************************/
echo '<HR>';
echo '<BR>';
echo '<CENTER>';
echo '<H3>';
echo 'Table: Race [race]';
echo '</H3>';
echo '</CENTER>';
echo '<BR>';
echo '<HR>';
echo '<BR>';

$SQL_TWO = 'SELECT * FROM z1771209.race';
$SQL = $CONN->query($SQL_TWO);

echo '<CENTER>';
echo ' ~ Name - Distance ~ ';
echo '</CENTER>';

while($ROW=$SQL->fetch(PDO::FETCH_ASSOC)){
echo '<CENTER>';
echo ' ~ ';
echo $ROW['name'];
echo ' - ';
echo $ROW['distance'];
echo ' ~ ';
echo '</CENTER>';
echo '<BR>';
}



/************************************************
Table runsin
************************************************/

echo '<HR>';
echo '<BR>';
echo '<CENTER>';
echo '<H3>';
echo 'Table: Runs_In [runsin]';
echo '</H3>';
echo '</CENTER>';
echo '<BR>';
echo '<HR>';

$SQL_THREE = 'SELECT * FROM z1771209.runsin';
$SQL = $CONN->query($SQL_THREE);

echo '<CENTER>';
echo ' ~ HID - RID - DT - TM - FINISH ~ ';
echo '</CENTER>';

while($ROW=$SQL->fetch(PDO::FETCH_ASSOC)){
echo '<CENTER>';
echo ' ~ ';
echo $ROW['hid'];
echo ' - ';
echo $ROW['rid'];
echo ' - ';
echo $ROW['dt'];
echo ' - ';
echo $ROW['tm'];
echo ' - ';
echo $ROW['finish'];
echo ' ~ ';
echo '</CENTER>';
echo '<BR>';
}


//	Page footer
include("Footer.html");

?>



