<?php

require './looplistmail.php';

    $sql = "SELECT distinct area,loopName,description FROM u502625302_loops.tblLoops WHERE loopStatus ='" . $_GET["loopstatus"] . "'  AND proUUID = '" . $_GET["prouuid"] . "' AND hasSended = 0;";
    $conf = parse_ini_file("./etc/con_config.ini");
    $conn = mysqli_connect($conf["url"],$conf["username"],$conf["pass"],$conf["db"]);
    $tocc = $_GET["tocc"];


    $message = '<html><head>
<style>
#table {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#table td, #table th {
  border: 1px solid #ddd;
  padding: 8px;
}

#table tr:nth-child(even){background-color: #f2f2f2;}

#table tr:hover {background-color: #ddd;}

#table th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #4CAF50;
  color: white;
}
</style>
</head><body>';

            
    $message .= '<h4 style="color:#f40;">Dear All<br>Loop Folders status have been changed!</h4>';
    
    
    if(!$conn)
    {
        die("connection failed: " .$conn -> connect_error);
        print "error";
    }
    
   
    
    $result = mysqli_query($conn,$sql);
    if (mysqli_num_rows($result) > 0){

      $table .= '<table id="table">
                <tr>
                  <th>Area</th>
                  <th>Loop</th>
                  <th>Description</th>
                </tr>';

      $tableBody = '';
      $loopCount = mysqli_num_rows($result);

        for($x = 0 ; $x < mysqli_num_rows($result) ; $x++){
            $row = mysqli_fetch_assoc($result);

            /*Update Loops Send = 1 */
            $sql = "call setLoopSent (?,?)";
            $stmt = mysqli_stmt_init($conn);
            if (!mysqli_stmt_prepare($stmt, $sql)) {
                echo 'problem in params';
            exit();
            }
            mysqli_stmt_bind_param($stmt, "ss", $_GET['prouuid'], $row['loopName']);
            mysqli_stmt_execute($stmt);
            /*Update Loops Send = 1 */

                $tableBody .= '<tr>';
                $tableBody .= '<td>' . $row['area'] . '</td>';
                $tableBody .= '<td>' . $row['loopName'] . '</td>';
                $tableBody .= '<td>' . $row['description'] . '</td>';
                $tableBody .= '</tr>';

            }

            $table .= $tableBody;
            $table .= '</table>';

            ini_set( 'display_errors', 1 );
            error_reporting( E_ALL );
            $from = "tr-crisp@trprojectssolutions.com";
            $to = $_GET["toc"];

            $subject = "Loop Folder Status Updated";

            
            $message .= '<h3 style="color:#006d77;">Status: ' . $_GET["loopstatus"] . '</h3>';
            $message .= $table;
            $message .= '<h3 style="color:#006d77;">Total:' . $loopCount . '</h3>';


            sendloopmail($to . ',' . $tocc, $subject, $message);
            // mail body ends

       
    }

    mysqli_close($conn);
