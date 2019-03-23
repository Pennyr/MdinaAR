<?php
$server = "localhost";
$username = "root";
$password = "";
$db = "ARGame";

$connect = new mysqli($server, $username, $password, $db);

//check  that connection happened
	if(mysqli_connect_errno())
	{
		echo "1: Connection Failed"; // error code #1 = connection failed
		exit();
	}
?>