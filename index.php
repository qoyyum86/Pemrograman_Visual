<?php
include 'config.php';

// Ambil data jadwal sholat dari database
$sql = "SELECT * FROM jadwal_sholat";
$result = $conn->query($sql);

// Simpan dalam array
$jadwal = [];
while ($row = $result->fetch_assoc()) {
    $jadwal[$row['sholat']] = $row['waktu'];
}

// Ambil waktu sekarang
date_default_timezone_set("Asia/Jakarta");
$waktu_sekarang = date("H:i:s");
?>

<!DOCTYPE html>
<html lang="id">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Jadwal Sholat</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #7AC142;
            text-align: center;
            color: white;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 80%;
            margin: auto;
            padding: 20px;
        }
        .header {
            font-size: 24px;
            font-weight: bold;
            color: yellow;
        }
        .quote {
            font-size: 16px;
            margin-top: 10px;
        }
        .jadwal {
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
            margin-top: 20px;
        }
        .waktu-box {
            background: black;
            padding: 15px;
            margin: 5px;
            border-radius: 5px;
            text-align: center;
            width: 120px;
        }
        .highlight {
            background: yellow;
            color: black;
            font-weight: bold;
        }
        .time-now {
            font-size: 18px;
            margin-top: 20px;
            font-weight: bold;
        }
    </style>
</head>
<body>

<div class="container">
    <div class="header">Amal Itu Tergantung Niat</div>
    <div class="quote">"Amal itu tergantung niatnya, dan seseorang mendapatkan (balasan) sesuai niatnya." <br>(HR. Bukhari No.1 & Muslim No.3530)</div>
    
    <div class="jadwal">
        <?php foreach ($jadwal as $sholat => $waktu): ?>
            <div class="waktu-box <?php echo ($sholat == "Dzuhur") ? 'highlight' : ''; ?>">
                <div><?php echo $sholat; ?></div>
                <div><?php echo substr($waktu, 0, 5); ?></div>
            </div>
        <?php endforeach; ?>
    </div>

    <div class="time-now">Waktu Sekarang: <span id="waktuSekarang"><?php echo $waktu_sekarang; ?></span></div>
</div>

<script>
    function updateTime() {
        let now = new Date();
        let hours = now.getHours().toString().padStart(2, '0');
        let minutes = now.getMinutes().toString().padStart(2, '0');
        let seconds = now.getSeconds().toString().padStart(2, '0');
        document.getElementById("waktuSekarang").innerText = hours + ":" + minutes + ":" + seconds;
    }
    setInterval(updateTime, 1000);
</script>
<script>
    function hitungMundur() {
        let jadwal = {
            "Shubuh": "<?php echo $jadwal['Shubuh']; ?>",
            "Dzuhur": "<?php echo $jadwal['Dzuhur']; ?>",
            "Ashar": "<?php echo $jadwal['Ashar']; ?>",
            "Maghrib": "<?php echo $jadwal['Maghrib']; ?>",
            "Isya": "<?php echo $jadwal['Isya']; ?>"
        };

        let now = new Date();
        let waktuSekarang = now.getHours() * 3600 + now.getMinutes() * 60 + now.getSeconds();
        let selisihTerkecil = Infinity;
        let sholatBerikutnya = "";

        for (let sholat in jadwal) {
            let [jam, menit] = jadwal[sholat].split(":").map(Number);
            let waktuSholat = jam * 3600 + menit * 60;

            if (waktuSholat > waktuSekarang && (waktuSholat - waktuSekarang) < selisihTerkecil) {
                selisihTerkecil = waktuSholat - waktuSekarang;
                sholatBerikutnya = sholat;
            }
        }

        if (selisihTerkecil === Infinity) {
            document.getElementById("countdown").innerText = "Waktu sholat sudah selesai untuk hari ini.";
            return;
        }

        let jam = Math.floor(selisihTerkecil / 3600);
        let menit = Math.floor((selisihTerkecil % 3600) / 60);
        let detik = selisihTerkecil % 60;

        document.getElementById("countdown").innerText = "Menuju " + sholatBerikutnya + ": " + jam + "j " + menit + "m " + detik + "d";
        setTimeout(hitungMundur, 1000);
    }

    hitungMundur();
</script>

<p id="countdown" style="font-size: 18px; font-weight: bold;"></p>


</body>
</html>
