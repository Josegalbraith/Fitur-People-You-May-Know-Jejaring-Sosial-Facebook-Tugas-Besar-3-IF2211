## Penjelasan Singkat Algoritma

Algoritma DFS:\
Tetapkan simpul yang akan dicek menjadi simpul awal\
Cari simpul-simpul hidupnya dan simpan simpul-simpul tersebut pada bagian awal daftar simpul hidup\
Simpan jumlah simpul hidup pada simpul yang sedang dicek pada daftar yang menyatakan jumlah simpul hidup per simpul yang dikunjungi.\
Simpan nilai pada simpul yang sedang dicek pada daftar simpul-simpul yang sudah dikunjungi\
Ubah nilai simpul yang akan dicek menjadi simpul pertama pada daftar simpul hidup dan hilangkan simpul tersebut dari daftar simpul hidup.\
Ulangi langkah pertama hingga simpul yang sedang dicek adalah simpul tujuan atau daftar simpul hidup menjadi kosong (yang menandakan tidak ada jalur DFS) dan kurangi jumlah simpul hidup pada daftar yang menyimpannya sejumlah 1 pada setiap iterasi dimulai dari simpul sebelum ditemukannya simpul yang tidak memiliki simpul hidup dihitung mundur hingga simpul yang jika jumlah simpul hidupnya lebih dari 1 jika dikurangi 1 jika ditemukan simpul yang tidak memiliki simpul hidup
Simpul-simpul yang memiliki jumlah lebih dari 0 akan membentuk jalur pencarian DFS jika simpul-simpul tersebut diurut berdasarkan urutan pencarian yang lebih dulu.\

Algoritma BFS: \
Tetapkan simpul awal pencarian\
“Kunjungi” simpul awal. Kunjungi berarti: 1) menambahkan simpul ke antrian, dan 2) mencatat jalur menuju simpul. Simpul yang sudah dikunjungi tidak boleh dikunjungi lagi.
Keluarkan simpul awal dari antrian.\
Kunjungi (tambah ke antrian + catat jalur) satu per satu simpul yang bertetangga dengan simpul awal. Kunjungan dilakukan sesuai aturan tertentu (biasanya urutan abjad nama simpul).\
Keluarkan simpul pertama yang dimasukkan ke antrian.\
Kunjungi (tambah ke antrian + catat jalur) satu per satu simpul yang bertetangga dengan simpul yang telah dikeluarkan.\
Ulangi langkah 5 dan 6 hingga antrian kembali kosong.\
Telah diperoleh jalur dari simpul awal ke semua simpul lainnya secara BFS.\


## Instalasi tertentu
Sudah menginstall Visual Studio

## Cara menggunakan program
Dengan menggunakan Visual Stud

## Author / identitas pembuat

Jose Galbraith Hasintongan (13519022)\
Feralezer Leonard Gorga Tampubolon (13519062)\
Moses Ananta (13519076)


