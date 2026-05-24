<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <title>Névnap kereső</title>
</head>
<body>

<h2>Névnap kereső</h2>

<h3>Dátum alapján</h3>
<input type="date" id="datum">
<button onclick="keres('datum')">Keresés</button>

<h3>Név alapján</h3>
<input type="text" id="nev" placeholder="Név...">
<button onclick="keres('nev')">Keresés</button>

<p id="eredmeny"></p>

<script>
function keres(tipus) {

    let url = "index.php?";

    if (tipus === "datum") {
        let d = document.getElementById("datum").value;
        if (!d) return kiir("Válassz dátumot!");
        let [ev, ho, nap] = d.split("-");
        url += "nap=" + ho + "-" + nap;
    }

    if (tipus === "nev") {
        let n = document.getElementById("nev").value.trim();
        if (!n) return kiir("Írj be egy nevet!");
        url += "nev=" + n;
    }

    fetch(url)
        .then(r => r.json())
        .then(adat => {
            if (adat.hiba) kiir(adat.hiba);
            else kiir(JSON.stringify(adat, null, 2));
        });
}

function kiir(szoveg) {
    document.getElementById("eredmeny").innerText = szoveg;
}
</script>

</body>
</html>
