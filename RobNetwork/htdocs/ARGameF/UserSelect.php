<?php  
include('Connection.php');

$sql = "SELECT * FROM Quests";
$result = mysqli_query($connect, $sql);

if( $result )
{
	// success! check results
	while( $row = mysqli_fetch_assoc( $result ) ){
		echo "ID:".$row['ID'].",";
		echo "Quest:".$row['Quest'].";";
		}
}
else
{
		echo "Failed To Load DB Data";
}
	
?>