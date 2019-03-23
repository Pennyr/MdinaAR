<?php  
include('Connection.php');

$NumofPlayers = $_POST['addNumofPlayers']
$QuestsSolved = $_POST['addQuestsSolved']
$UsedTime = $_POST['addUsedTime']


$sql = "INSERT INTO Scores(NumofPlayers, QuestsSolved, UsedTime) VALUES (
'".$NumofPlayers."', '".$QuestsSolved."','".$UsedTime."')";


$result = mysqli_query($connect, $sql)

}

?>