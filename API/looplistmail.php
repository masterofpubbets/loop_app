<?php

function sendloopmail($addresses, $subject, $body) {
    require '.././sndmail.php';
    $userName = 'tr-crisp@trprojectssolutions.com';
    $password = "57Wv=obrN!4'Vb2V";
    $from = 'tr-crisp@trprojectssolutions.com';
    $fromTitle = 'Loop Folders';
    $replayTo = 'ealy@trsa.es';
    $replayToName = 'Eslam';

    sendmail($userName, $password, $from, $fromTitle, $replayTo, $replayToName, $addresses, $subject, $body);
}


?>
