



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

Server Connection

PDO Paramters
HOST		=	'courses'
DATABASE	=	'z1771209'
USER		=	'z1771209'
PASSWORD	=	'1994Aug20'
************************************************/

//	PDO Parameters
//$dsn	=	'mysql:host=localhost;dbname=z1771209'; 
$HOST		=	'courses';
$DATABASE	=	'z1771209';
$USER		=	'z1771209';
$PASS		=	'1994Aug20';

//	Make new PDO
$CONN = new PDO("mysql:host=$HOST;dbname=$DB", $USER, $PASS);

//	Error check
try{
$CONN->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}

//	Output for errors
catch(PDOException $E){
echo '<BR>';
echo 'ERROR: ' . $E->getMessage();
echo '<BR>';
}

?>





