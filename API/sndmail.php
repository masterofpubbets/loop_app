<?php
use PHPMailer\PHPMailer\PHPMailer;
function sendmail($userName, $password, $from, $fromTitle, $replayTo, $replayToName, $addresses, $subject, $body) {
    require 'vendor/autoload.php';
    echo 'sndmail file';
    $mail = new PHPMailer;
    $mail->isSMTP();
    $mail->SMTPDebug = 2;
    $mail->Host = 'smtp.hostinger.com';
    $mail->Port = 587;
    $mail->SMTPAuth = true;
    $mail->Username = $userName;
    $mail->Password = $password;
    $mail->setFrom($from, $fromTitle);
    $mail->addReplyTo($replayTo, $replayToName);
    $addArray = explode(',', $addresses);
    foreach ($addArray as $address) {
        if ($address !== '') {
            $mail->addAddress($address);
        }        
    }
    echo 'after foreach';
    echo $addresses;
    $mail->Subject = $subject;
    $mail->msgHTML(file_get_contents('message.html'), __DIR__);
    $mail->Body = $body;
    //$mail->addAttachment('test.txt');
    if (!$mail->send()) {
        echo 'Mailer Error: ' . $mail->ErrorInfo;
    } else {
        echo 'The email message was sent.';
    }

}
?>