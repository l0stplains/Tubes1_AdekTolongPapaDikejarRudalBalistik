<h1 align="center">Tugas Besar 1 IF2211 Strategi Algoritma</h1>
<h3 align="center">Pemanfaatan Algoritma Greedy dalam Pembuatan Bot Permainan Robocode Tank Royale</p>

## Daftar Isi

- [Overview](#overview)
    - [Author](#dibuat-oleh)
    - [Algoritma Greedy yang diimplementasikan](#penjelasan)
- [Requirement](#requirement)
- [Setup](#setup)

## Overview
Robocode adalah permainan pemrograman yang bertujuan untuk membuat kode bot dalam bentuk tank virtual untuk berkompetisi melawan bot lain di arena. Pertempuran Robocode berlangsung hingga bot-bot bertarung hanya tersisa satu seperti permainan Battle Royale, karena itulah permainan ini dinamakan Tank Royale. Nama Robocode adalah singkatan dari "Robot code," yang berasal dari versi asli/pertama permainan ini. Robocode Tank Royale adalah evolusi/versi berikutnya dari permainan ini, di mana bot dapat berpartisipasi melalui Internet/jaringan. Dalam permainan ini, pemain berperan sebagai programmer bot dan tidak memiliki kendali langsung atas permainan. Pemain hanya bertugas untuk membuat program yang menentukan logika atau "otak" bot. Program yang dibuat akan berisi instruksi tentang cara bot bergerak, mendeteksi bot lawan, menembakkan senjatanya, serta bagaimana bot bereaksi terhadap berbagai kejadian selama pertempuran.


Komponen-komponen dari permainan ini antara lain:

1. Rounds dan Turns
Pertempuran dapat terdiri dari beberapa rounds. Secara default, satu pertempuran berisi 10 rounds, di mana setiap rounds akan memiliki pemenang dan yang kalah.
Setiap round dibagi menjadi beberapa turns, yang merupakan unit waktu terkecil. Satu turn adalah satu ketukan waktu dan satu putaran permainan. Jumlah turn dalam satu round tergantung pada berapa lama waktu yang dibutuhkan hingga hanya tersisa bot terakhir yang bertahan.
Pada setiap turn, sebuah bot dapat:
Menggerakkan bot, memindai musuh, dan menembakkan senjata.
Bereaksi terhadap peristiwa seperti saat bot terkena peluru atau bertabrakan dengan bot lain atau dinding.
Perintah untuk bergerak, berputar, memindai, menembak, dan sebagainya dikirim ke server untuk setiap turn.
Perlu diperhatikan bahwa API (Application Programming Interface) bot resmi secara otomatis mengirimkan niat bot ke server di balik layar, sehingga Anda tidak perlu mengkhawatirkannya, kecuali jika Anda membuat API Bot sendiri. 
Pada setiap turn, bot akan secara otomatis menerima informasi terbaru tentang posisinya dan orientasinya di medan perang. Bot juga akan mendapatkan informasi tentang bot musuh ketika mereka terdeteksi oleh pemindai.
Perlu diketahui bahwa game engine yang akan digunakan pada tugas besar ini tidak mengikuti aturan default mengenai komponen Round & Turns.
2. Batas Waktu Giliran
Penting untuk dicatat bahwa setiap bot memiliki batas waktu untuk setiap turn yang disebut turn timeout, biasanya antara 30-50 ms (dapat diatur sebagai aturan pertempuran). Ini berarti bahwa bot tidak bisa mengambil waktu sebanyak yang mereka inginkan untuk bergerak dan menyelesaikan turn saat ini.
Setiap kali turn baru dimulai, penghitung waktu ulang diatur ulang dan mulai berjalan. Jika batas waktu tercapai dan bot tidak mengirimkan pergerakannya untuk turn tersebut, maka tidak ada perintah yang dikirim ke server. Akibatnya, bot akan melewatkan turn tersebut. Jika bot melewatkan turn, ia tidak akan bisa menyesuaikan gerakannya atau menembakkan senjatanya karena server tidak menerima perintah tepat waktu sebelum turn berikutnya dimulai.
3. Energi
Semua bot memulai permainan dengan jumlah energi awal sebanyak 100 poin energi.
Bot akan kehilangan energi jika ditembak atau ditabrak oleh bot musuh.
Bot juga akan kehilangan energi jika menembakkan meriamnya.
Bot akan mendapatkan energi jika peluru dari meriamnya mengenai musuh. Energi yang didapat akan lebih banyak 3 kali lipat dari energi yang digunakan untuk menembakkan peluru.
Bot dengan energi nol akan dinonaktifkan dan tidak bisa bergerak. Jika bot terkena serangan dalam keadaan ini, bot akan hancur.
4. Peluru
Semakin banyak energi (daya tembak) yang digunakan untuk menembakkan peluru, semakin berat peluru tersebut dan semakin lambat gerakannya. Namun, peluru yang lebih berat juga menghasilkan lebih banyak kerusakan dan memungkinkan bot mendapatkan lebih banyak energi saat mengenai bot musuh.
Seperti disebutkan sebelumnya, peluru yang lebih berat akan bergerak lebih lambat. Ini berarti akan membutuhkan waktu lebih lama untuk mencapai target, meningkatkan risiko peluru tidak mengenai sasaran. Sebaliknya, peluru yang lebih ringan bergerak lebih cepat, sehingga lebih mudah mengenai target, tetapi peluru ringan tidak memberikan banyak poin energi saat mengenai bot musuh.
5. Panas Meriam (Gun Heat)
Saat menembakkan peluru, meriam akan menjadi panas. Peluru yang lebih berat menghasilkan lebih banyak panas dibandingkan peluru yang lebih ringan. Ketika meriam terlalu panas, bot tidak dapat menembak hingga suhu meriam turun ke nol. Selain itu, meriam juga sudah dalam keadaan panas di awal round dan perlu waktu untuk mendingin sebelum bisa digunakan untuk pertama kalinya.
6. Tabrakan
Perlu diperhatikan bahwa bot akan menerima kerusakan jika menabrak dinding (batas arena), yang disebut wall damage. Hal yang sama juga terjadi jika bot bertabrakan dengan bot lain.
Jika bot menabrak bot musuh dengan bergerak maju, ini disebut ramming (menabrak dengan sengaja), yang akan memberikan sedikit skor tambahan bagi bot yang menyerang.
7. Bagian Tubuh Tank
Tubuh tank terdiri dari 3 bagian:

Body adalah bagian utama dari tank yang digunakan untuk menggerakkan tank.
Gun digunakan untuk menembakkan peluru dan dapat berputar bersama body atau independen dari body.
Radar digunakan untuk memindai posisi musuh dan dapat berputar bersama body atau independen dari body.
8. Pergerakan
Bot dapat bergerak maju dan mundur hingga kecepatan maksimum. Dibutuhkan beberapa giliran untuk mencapai kecepatan maksimum. Bot dapat mengalami percepatan maksimum sebesar 1 unit per giliran dan pengereman dengan perlambatan maksimum 2 unit per giliran. Percepatan dan perlambatan maksimum tidak bergantung pada kecepatan bot saat itu.
9. Berbelok
Seperti yang disebutkan sebelumnya, bagian tubuh, turret (meriam), dan radar dapat berputar secara independen satu sama lain. Jika turret atau radar tidak diputar, maka keduanya akan mengarah ke arah yang sama dengan tubuh bot.
Setiap bagian tubuh memiliki kecepatan putar yang berbeda. Radar adalah bagian tercepat dan dapat berputar hingga 45 derajat per giliran, yang berarti dapat berputar 360 derajat dalam 8 giliran. Turret dan meriam dapat berputar hingga 20 derajat per giliran.
Bagian paling lambat adalah tubuh tank, yang dalam kondisi terbaik dapat berputar hingga 10 derajat per giliran. Namun, ini bergantung pada kecepatan bot saat ini. Semakin cepat bot bergerak, semakin lambat kemampuannya untuk berbelok.
Perlu diperhatikan bahwa tidak ada energi yang dikonsumsi saat bot bergerak atau berbelok.
10. Pemindaian
Aspek penting dalam Robocode adalah memindai bot musuh menggunakan radar. Radar dapat mendeteksi bot dalam jangkauan hingga 1200 piksel. Musuh yang berada lebih dari 1200 piksel dari bot tidak dapat terdeteksi atau dipindai oleh radar.
Penting untuk diperhatikan bahwa sebuah bot hanya dapat memindai bot musuh yang berada dalam jangkauan sudut pemindaian (scan arc)-nya. Sudut pemindaian ini merupakan "sapuan radar" dari arah radar sebelumnya ke arah radar saat ini dalam satu giliran.  
Jika radar tidak bergerak dalam suatu giliran, artinya radar tetap mengarah ke arah yang sama seperti pada giliran sebelumnya, maka sudut pemindaian akan menjadi nol derajat, dan bot tidak akan dapat mendeteksi musuh.  
Oleh karena itu, sangat disarankan untuk selalu mengubah arah radar agar tetap dapat memindai musuh.
11. Skor
Pada akhir pertempuran, setiap bot akan diranking berdasarkan total skor yang diperoleh masing-masing bot selama keseluruhan pertempuran. Tentunya, tujuan utama pada tugas besar ini adalah membuat bot yang memberikan skor setinggi mungkin. Berikut adalah rincian komponen skor pada pertempuran:
Bullet Damage: Bot mendapatkan poin sebesar damage yang dibuat kepada bot musuh menggunakan peluru.
Bullet Damage Bonus: Apabila peluru berhasil membunuh bot musuh, bot mendapatkan poin sebesar 20% dari damage yang dibuat kepada musuh yang terbunuh.
Survival Score: Setiap ada bot yang mati, bot lainya yang masih bertahan pada ronde tersebut mendapatkan 50 poin.
Last Survival Bonus: Bot terakhir yang bertahan pada suatu ronde akan mendapatkan 10 poin dikali dengan banyaknya musuh.
Ram Damage: Bot mendapatkan poin sebesar 2 kalinya damage yang dibuat kepada bot musuh dengan cara menabrak.
Ram Damage Bonus: Apabila musuh terbunuh dengan cara ditabrak, bot mendapatkan poin sebesar 30% dari damage yang dibuat kepada musuh yang terbunuh.
Skor akhir bot adalah akumulasi dari 6 komponen diatas. Perlu diperhatikan bahwa game akan menampilkan berapa kali suatu bot meraih peringkat 1, 2, atau 3 pada setiap ronde. Namun, hal ini tidak dihitung sebagai komponen skor maupun untuk perangkingan akhir. Bot yang dianggap menang pertempuran adalah bot dengan akumulasi skor tertinggi.


### Dibuat Oleh
Program ini dibuat oleh Tim dengan Nama AdekTolongPapaDikejarRudalBalistik yang beranggotakan:
1. Refki Alfarizi / 13523002
2. Kenneth Ricardo Chandra / 13523022
3. Nadhif Radityo Nugroho / 13523045

### Penjelasan Algoritma Greedy yang Diimplementasikan

## Requirement
Untuk memainkan Robocode Tank Royale ini, dibutuhkan beberapa komponen yaitu
1. Versi Dotnet yang sesuai dengan bot yang dimiliki
2. Aplikasi Robocode

## Setup
Jika ingin memainkan Robocode Tank Royale dan menggunakan bot yang telah dibuat, maka langkah-langkah yang dapat dilakukan adalah :
1. Mengunduh starter pack ini dari link ini
   https://github.com/Ariel-HS/tubes1-if2211-starter-pack/releases/tag/v1.0

2. Jalankan file .jar aplikasi GUI :
   ```shell
   java -jar robocode-tankroyale-gui-0.30.0.jar
   ```
   
3. Klik tombol Config, lalu Bot Root Directories dan tambahkan direktori tempat bot berada:

4. Klik tombol Battle, lalu Start Battle untuk memunculkan panel konfigurasi permainan:
  
5. Bot yang berada di direktori yang telah ditambahkan akan muncul secara otomatis di kotak kiri atas:
  
6. Pilih bot yang diinginkan dan boot dengan menekan tombol Boot:

7. Tunggu hingga bot berhasil di boot dan join ke permainan, lalu klik tombol Add agar bot ditambahkan ke permainan:

8. Apabila semua bot sudah selesai ditambahkan, permainan dapat dimulai dengan menekan tombol Start Battle:

9. Untuk mengubah konfigurasi permainan, dapat dilakukan dengan menekan tombol Setup Rules di bagian atas:

10. Untuk melakukan build pada bot, dapat dilakukan dengan menuju direktori lokasi bot, lalu 
   

   Penjelasan singkat algoritma greedy yang diimplementasikan untuk setiap bot yang dibuat
Requirement program dan instalasi tertentu bila ada
Command atau langkah-langkah dalam meng-compile atau build program 
Author (identitas pembuat)
