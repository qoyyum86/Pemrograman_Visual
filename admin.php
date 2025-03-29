<?php
include 'config.php';

// Jika ada data yang dikirim dari form
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    foreach ($_POST['jadwal'] as $id => $waktu) {
        $sql = "UPDATE jadwal_sholat SET waktu='$waktu' WHERE id=$id";
        $conn->query($sql);
    }
    header("Location: admin.php?success=1");
    exit();
}

// Ambil data jadwal sholat
$sql = "SELECT * FROM jadwal_sholat";
$result = $conn->query($sql);
?>

<!DOCTYPE html>
<html lang="id">
<head>
    <meta charset="UTF-8">
    <title>Admin - Edit Jadwal Sholat</title>
</head>
<body>
    <h2>Edit Jadwal Sholat</h2>

    <?php if (isset($_GET['success'])): ?>
        <p style="color: green;">Jadwal berhasil diperbarui!</p>
    <?php endif; ?>

    <form method="POST">
        <table border="1" cellpadding="10">
            <tr>
                <th>Sholat</th>
                <th>Waktu</th>
            </tr>
            <?php while ($row = $result->fetch_assoc()): ?>
            <tr>
                <td><?php echo $row['sholat']; ?></td>
                <td>
                    <input type="time" name="jadwal[<?php echo $row['id']; ?>]" value="<?php echo substr($row['waktu'], 0, 5); ?>">
                </td>
            </tr>
            <?php endwhile; ?>
        </table>
        <br>
        <button type="submit">Simpan Perubahan</button>
    </form>

    <br>
    <a href="index.php">Kembali ke Jadwal</a>
</body>
</html>
