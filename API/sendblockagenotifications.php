<?php

require './sendblockages.php';

$sql = "SELECT distinct issuedToMail, issuedTo, issuedByMail, issuedBy FROM u502625302_loops.tblBlockages WHERE hasSended = 0;";
$conf = parse_ini_file("./etc/con_config.ini");
$conn = mysqli_connect($conf["url"], $conf["username"], $conf["pass"], $conf["db"]);


if (!$conn) {
  die("connection failed: " . $conn->connect_error);
  print "error";
}



$result = mysqli_query($conn, $sql);
if (mysqli_num_rows($result) > 0) {

  for ($x = 0; $x < mysqli_num_rows($result); $x++) {
    $row = mysqli_fetch_assoc($result);


    sendBlockageMail($row['issuedToMail'], $row['issuedTo'], $row['issuedByMail'], $row['issuedBy'], $_GET['mailcc']);
  }
}

mysqli_close($conn);
