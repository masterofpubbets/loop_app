<?php

$conf = parse_ini_file("./etc/con_config.ini");
        $conn = mysqli_connect($conf["url"], $conf["username"], $conf["pass"], $conf["db"]);
        if (!$conn) {
            die("connection failed: " . $conn->connect_error);
            echo 'problem in connection';
            print "error";
        }

        /*Update Loops Data */
        $sql = "call clearLoop (?)";
        $stmt = mysqli_stmt_init($conn);
        if (!mysqli_stmt_prepare($stmt, $sql)) {
            echo 'problem in params';
            exit();
        }

        mysqli_stmt_bind_param($stmt, "s", $_GET['prouuid']);
        mysqli_stmt_execute($stmt);

        mysqli_stmt_close($stmt);
        mysqli_close($conn);
        echo 'done';
        

        exit();