<?php

// Rudin Swagerman
// 2006
// BananAlbum.com

$file = '../'.$_GET['image'];
$filearray = explode("/",$file);
$ctype="image/jpg";
$arraylength = count($filearray);
$filename = $filearray[$arraylength-1];

           if (!file_exists($file)) {
               die("NO FILE HERE");
           }

           header("Pragma: public");
           header("Expires: 0");
           header("Cache-Control: must-revalidate, post-check=0, pre-check=0");
           header("Cache-Control: private",false);
           header("Content-Type: $ctype");
           header("Content-Disposition: attachment; filename=\"".basename($filename)."\";");
           header("Content-Transfer-Encoding: binary");
           header("Content-Length: ".@filesize($file));
           set_time_limit(0);
           @readfile("$file") or die("File not found.");

?>