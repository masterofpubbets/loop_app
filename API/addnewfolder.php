<?php

$conf = parse_ini_file("./etc/con_config.ini");
        $conn = mysqli_connect($conf["url"], $conf["username"], $conf["pass"], $conf["db"]);
        if (!$conn) {
            die("connection failed: " . $conn->connect_error);
            echo 'problem in connection';
            print "error";
        }

        /*Update Loops Data */
        $sql = "call addLoop (?,?,?,?,?)";
        $stmt = mysqli_stmt_init($conn);
        if (!mysqli_stmt_prepare($stmt, $sql)) {
            echo 'problem in params';
            exit();
        }

        mysqli_stmt_bind_param($stmt, "sssss", $_GET['loopname'], $_GET['loopstatus'],$_GET['prouuid'],$_GET['area'],$_GET['description']);
        mysqli_stmt_execute($stmt);

        mysqli_stmt_close($stmt);
        mysqli_close($conn);
        echo 'done';
        

        exit();