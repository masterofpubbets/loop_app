<?php
function sendBlockageMail($issuedToMail, $issuedToName, $issuedByMail, $issuedByName, $mailCC) {
    require './looplistmail.php';

    $sql = "SELECT distinct loopName, area,description, blockage, folderStatus FROM u502625302_loops.tblBlockages WHERE hasSended = 0 AND issuedToMail = '" . $issuedToMail . "'AND issuedByMail = '" . $issuedByMail . "';";
    $conf = parse_ini_file("./etc/con_config.ini");
    $conn = mysqli_connect($conf["url"],$conf["username"],$conf["pass"],$conf["db"]);

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
    
                
        $message .= '<h4 style="color:#f40;">Hi '. $issuedToName . '<br>We would like to inform you that:! ' . $issuedByName . ' has assigned  blockage(s) to be resolved by you</h4>';

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
                  <th>Folder Status</th>
                  <th>Blockage</th>
                </tr>';

      $tableBody = '';
      $loopCount = mysqli_num_rows($result);

        for($x = 0 ; $x < mysqli_num_rows($result) ; $x++){
            $row = mysqli_fetch_assoc($result);


            /*Update Blockage Send = 1 */
            $sql = "call setBlockSent (?,?,?)";
            $stmt = mysqli_stmt_init($conn);
            if (!mysqli_stmt_prepare($stmt, $sql)) {
                echo 'problem in params';
            exit();
            }
            mysqli_stmt_bind_param($stmt, "sss", $row['loopName'], $issuedToMail, $issuedByMail);
            mysqli_stmt_execute($stmt);
            /*Update Loops Send = 1 */

                $tableBody .= '<tr>';
                $tableBody .= '<td>' . $row['area'] . '</td>';
                $tableBody .= '<td>' . $row['loopName'] . '</td>';
                $tableBody .= '<td>' . $row['description'] . '</td>';
                $tableBody .= '<td>' . $row['folderStatus'] . '</td>';
                $tableBody .= '<td>' . $row['blockage'] . '</td>';
                $tableBody .= '</tr>';

            }

            $table .= $tableBody;


            $table .= '</table>';

            ini_set( 'display_errors', 1 );
            error_reporting( E_ALL );
            $from = "tr-crisp@trprojectssolutions.com";
            $to = $issuedToMail;
            $tocc = $mailCC;

            $subject = "New Blockage Assignment";

            
            $message .= '<h3 style="color:#006d77;">Blockage Details: </h3>';
            $message .= $table;
            $message .= '<h3 style="color:#006d77;">Total:' . $loopCount . '</h3>';


            sendloopmail($to . ',' . $tocc, $subject, $message);
            echo 'The email message was sent.';
            // mail body ends

        }

}
