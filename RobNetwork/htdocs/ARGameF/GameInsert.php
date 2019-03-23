<?php  
include('Connection.php');

//$PlayerName = $_GET['PlayerName'];
//$GameID = $_GET['GameID'];
//$UsedTime = $_GET['addUsedTime']

//Initializing variable
$PlayerName = ""; 	//Initialization value; Examples
$GameID = ""; 		//"" When you want to append stuff later
            		//0  When you want to add numbers later

$PlayerName = isset($_GET['PlayerName']) ? $_GET['PlayerName'] : 'No PlayerName';

$GameID = !empty($_GET['GameID']) ? $_GET['GameID'] : 'No GameID';


$sql = "INSERT INTO players(name, game) VALUES ('".$PlayerName."', '".$GameID."')";


$result = mysqli_query($connect, $sql)

?>