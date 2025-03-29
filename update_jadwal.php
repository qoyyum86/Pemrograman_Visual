<?php
include 'config.php';

$kota = "Jakarta";
$negara = "ID";
$method = 2; // Metode perhitungan (2 untuk Islamic Society of North America)

$url = "http://api.aladhan.com/v1/timingsByCity?city=$kota&country=$negara&method=$method";
$response = file_get_contents($url);
$data = json_decode($response, true);

if ($data && isset($data['data']['timings'])) {
    $jadwal_api = $data['data']['timings'];

    // Update jadwal di database
    $mapping = ["Fajr" => "Shubuh", "Sunrise" => "Syuruq", "Dhuhr" => "Dzuhur", "Asr" => "Ashar", "Maghrib" => "Maghrib", "Isha" => "Isya"];
    foreach ($mapping as $api_name => $db_name) {
        $waktu = $jadwal_api[$api_name];
        $sql = "UPDATE jadwal_sholat SET waktu='$waktu' WHERE sholat='$db_name'";
        $conn->query($sql);
    }
    echo "Jadwal sholat berhasil diperbarui!";
} else {
    echo "Gagal mengambil data dari API!";
}
?>
