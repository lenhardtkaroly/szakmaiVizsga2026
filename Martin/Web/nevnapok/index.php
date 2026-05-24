<?php 

    header("Content-Type: application/json; charset=UTF-8");


    $host = "localhost";
    $username = "root";
    $password = "";
    $database = "nevnapok";

    $conn = new mysqli($host, $username, $password, $database);
    $conn->set_charset("utf8mb4");


    $nap = $_GET['nap'] ?? null;
    $nev = $_GET['nev'] ?? null;

    if ($nap === null && $nev === null) {
        echo json_encode(["minta1" => "/?nap=12-31",
        "minta2" => "/?nev=Szilveszter"], JSON_UNESCAPED_UNICODE);

    }

    if ($nap !== null) {

        [$honap, $napszam] = explode("-", $nap);

        $honap   = (int)$honap;  
        $napszam = (int)$napszam;

        $sql = "SELECT nev1, nev2 FROM nevnap WHERE ho = $honap AND nap = $napszam";

        $result = $conn->query($sql);

        $sor = $result->fetch_assoc();

        if ($sor) {
            echo json_encode(["nev1" => $sor["nev1"], "nev2" => $sor["nev2"]], JSON_UNESCAPED_UNICODE);
        } else {
            echo json_encode(["hiba" => "Hibás bemeneti dátumformátum!"], JSON_UNESCAPED_UNICODE);
        }


    }

    if ($nev !== null) {

        $honapok = ["január", "február", "március", "április", "május", "június", "július", "augusztus", "szeptember", "október", "november", "december"];

        $sql = "SELECT nev1, nev2, ho, nap FROM nevnap WHERE nev1 = '$nev' OR nev2 = '$nev'";

        $result = $conn->query($sql);

        $sor = $result->fetch_assoc();

        if ($sor) {
            $honapNev = $honapok[$sor["ho"] - 1];
            echo json_encode(["datum" => $honapNev . " " . $sor["nap"] . ".", "nevnap1" => $sor["nev1"], "nevnap2" => $sor["nev2"]], JSON_UNESCAPED_UNICODE);
        } else {
            echo json_encode(["hiba" => "Név nem található!"], JSON_UNESCAPED_UNICODE);
        }

    }


    


?>