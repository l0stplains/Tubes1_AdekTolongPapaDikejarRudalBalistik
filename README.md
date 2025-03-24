> Tugas Besar 1 - IF2211 Strategi Algoritma 2025
<p align="center">
    <br />
    <img width="150px" src="https://github.com/user-attachments/assets/e45fc60d-20c4-44c3-8fa4-a5ad20108fbc">
</p>
    <h3 align="center">Robocode Tank Royale Bot</h3>
<p align="center">
   Pemanfaatan Algoritma Greedy dalam Pembuatan Bot Permainan Robocode Tank Royale.
    <br />
    <br />
    <a href="https://github.com/l0stplains/Tubes1_AdekTolongPapaDikejarRudalBalistik/releases/">Rilis</a>
    ·
    <a href="https://github.com/l0stplains/Tubes1_AdekTolongPapaDikejarRudalBalistik/tree/main/doc/AdekTolongPapaDikejarRudalBalistik.pdf">Laporan</a>
</p>

## Overview

<p align="justify"><a href="https://github.com/robocode-dev/tank-royale">Robocode Tank Royale</a> adalah permainan pemrograman yang bertujuan untuk membuat kode bot dalam bentuk tank virtual untuk berkompetisi melawan bot lain di arena. Pertempuran Robocode berlangsung hingga bot-bot bertarung hanya tersisa satu seperti permainan Battle Royale, karena itulah permainan ini dinamakan Tank Royale. Nama Robocode adalah singkatan dari "Robot code," yang berasal dari versi asli/pertama permainan ini. Robocode Tank Royale adalah evolusi/versi berikutnya dari permainan ini, di mana bot dapat berpartisipasi melalui Internet/jaringan. Dalam permainan ini, pemain berperan sebagai programmer bot dan tidak memiliki kendali langsung atas permainan. Pemain hanya bertugas untuk membuat program yang menentukan logika atau "otak" bot. Program yang dibuat akan berisi instruksi tentang cara bot bergerak, mendeteksi bot lawan, menembakkan senjatanya, serta bagaimana bot bereaksi terhadap berbagai kejadian selama pertempuran.</p>

<p align="center">
    <img width="450px" src="https://github.com/user-attachments/assets/2d9aca86-2ee9-42f0-9d14-f0e7a014e481">
</p>
<p align="center"><i>Tampilan permainan Robocode Tank Royale</i></p>


## Algoritma Greedy yang Diimplementasikan
### CIV-1L Mauler (Bot Utama)
<p align="justify">CIV-1L Mauler adalah bot dengan pendekatan greedy yang adaptif dengan jumlah musuh pada arena sehingga bot ini memiliki dua mode, yaitu mode targetting dan mode roaming. Pemisahan mode tersebut dikarenakan meningkatnya gangguan atau kejadian yang sulit bahkan mustahil untuk diperhitungkan seiring meningkatnya jumlah pemain.
</p>
<p align="justify">
Mode <i>targetting</i> aktif ketika jumlah lawan pada arena kurang dari 5. Pada mode ini, bot akan menarget salah satu lawan dan melakukan gerakan osilasi melingkari lawan. Strategi ini dilakukan untuk<b> mengurangi kemungkinan terkena tembakan dan meningkatkan kemungkinan tembakan mengenai lawan. </b>
</p>

<p align="justify">
Mode <i>roaming</i> aktif ketika jumlah lawan pada arena lebih dari 4. Pada mode ini bot akan berputar-putar sepanjang mode ini aktif dan melakukan targetting pada salah satu lawan. Algoritma targetting pada mode ini sama dengan mode targetting, yaitu dengan menggunakan Guess Factor. Mode ini juga sangat adaptif terhadap gangguan/serangan yang dilakukan oleh musuh yang sangat mungkin terjadi saat bot di arena relatif banyak. Oleh karena itu, strategi ini <b> mengurangi kemungkinan terkena serangan (tembakan maupun ramming) dan meningkatkan kemungkinan tembakan mengenai lawan </b>
</p>

### Hecate
<p align="justify">Hecate adalah bot yang menggunakan pendekatan greedy sesuai dengan konsumsi energi yang digunakan serta persediaan energi yang tersisa pada bot. Apabila bot memiliki energi yang masih banyak atau diatas 70, maka bot berada dalam mode agresif atau menggunakan energi yang lebih banyak untuk menembak peluru sehingga damage yang dikeluarkan lebih besar. Saat bot memiliki energi sedang atau di antara 70 dan 30, Saat bot memiliki energi yang rendah atau dibawah 30, maka bot akan mengeluarkan peluru dengan energi yang lebih sedikit. Selain itu, saat bot memiliki energi dibawah 30, maka bot akan otomatis mencari lokasi yang aman dengan pergi ke suatu ujung atau corner dari arena. Apabila energi masih diatas 30, maka bot akan terus bertarung hingga energinya dibawah 30. Strategi ini<b> mengoptimalkan penggunaan energi agar dapat mendapatkan poin yang paling banyak. </b>
</p>

### DantolBot
<p align="justify">Bot ini dikembangkan menggunakan algoritma greedy untuk pengambilan keputusan secara<b>optimal berdasarkan informasi historis dan analisis crowd</b> dari pergerakan serta interaksi bot lain dalam arena. Bot mengumpulkan data dari berbagai events dalam permainan untuk membangun strategi <b> serangan yang adaptif dan prediktif</b>.
</p>

### Freedom
<p align="justify">Freedom adalah bot yang mengimplementasikan pendekatan greedy dengan strategi adalah bergerak berputar di ujung arena sehingga objektif utama bot ini adalah<b>memaksimalkan peluang bertahan dari serangan peluru lawan.</b>
</p>

## Requirement
Untuk memainkan Robocode Tank Royale ini, dibutuhkan beberapa komponen yaitu
1. Versi Dotnet versi 8.0
2. Aplikasi Robocode Tank Royale

## Setup
Jika ingin memainkan Robocode Tank Royale dan menggunakan bot yang telah dibuat, maka langkah-langkah yang dapat dilakukan adalah :
1. Mengunduh starter pack ini dari link ini
   https://github.com/Ariel-HS/tubes1-if2211-starter-pack/releases/tag/v1.0

2. Jalankan file .jar aplikasi GUI (atau <i>double click</i> pada aplikasi GUI) :
   ```shell
   java -jar robocode-tankroyale-gui-0.30.0.jar
   ```
3. Klik tombol Config, lalu Bot Root Directories dan tambahkan direktori tempat bot berada

4. Klik tombol Battle, lalu Start Battle untuk memunculkan panel konfigurasi permainan

5. Bot yang berada di direktori yang telah ditambahkan akan muncul secara otomatis di kotak kiri atas

6. Pilih bot yang diinginkan dan boot dengan menekan tombol Boot

7. Tunggu hingga bot berhasil di boot dan join ke permainan, lalu klik tombol Add agar bot ditambahkan ke permainan

8. Apabila semua bot sudah selesai ditambahkan, permainan dapat dimulai dengan menekan tombol Start Battle

9. Untuk melakukan build pada masing-masing, jalankan command berikut pada terminal :
   ```shell
   cd Bot
    ./Bot.bat
   ```

## Author
 Anggota Kelompok AdekTolongPapaDikejarRudalBalistik
| **Nama**                     | **NIM** |
|-------------------------------|----------------|
| Refki Alfarizi | 13523002       |
| Kenneth Ricardo Chandra | 13523022      |
| Nadhif Radityo Nugroho | 13523045       |

---
