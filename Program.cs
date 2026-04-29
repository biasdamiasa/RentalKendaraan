List<Kendaraan> datakendaraan = new List<Kendaraan>()
{
    new Kendaraan("Vario", "N 1234 Z", 125000),
    new Kendaraan("Beat", "N 5678 B", 110000),
    new Mobil("Civic", "N 1111 C", 500000),
    new Mobil("Avanza", "N 2222 D", 400000),
    new MiniBus("Elf", "N 3333 E", 1000000),
    new MiniBus("HiAce", "N 4444 F", 1500000)
}; 

while (true)
{
    Console.WriteLine("--- Rental Kendaraan MOKLET ---");
    Console.WriteLine("1. Sewa\n2. Kembali");
    Console.Write("Pilihan: ");
    string pilihan = Console.ReadLine();

    if (pilihan == "1")
    {
        Console.WriteLine("\nDaftar Kendaraan");
        foreach (var kendaraan in datakendaraan)
        {
            kendaraan.TampilInfo();
        }

        Console.Write("Nama kendaraan yang disewa: ");
        string kendaraan_sewa = Console.ReadLine();

        foreach (var kendaraan in datakendaraan)
        {
            if (kendaraan_sewa.ToUpper() == kendaraan.NamaKendaraan.ToUpper())
            {
                if (kendaraan.IsAvailable)
                {
                    Console.Write("Masukkan jumlah hari: ");
                    int hari = int.Parse(Console.ReadLine());

                    double total = kendaraan.HitungTotal(hari);

                    Console.WriteLine($"Total sewa: Rp {total}");

                    kendaraan.UbahStatus();
                }
                else
                {
                    Console.WriteLine("Kendaraan tidak tersedia");
                }
            }
        }


    }
}

class Kendaraan
{
    protected string _namaKendaraan;
    protected string _nomorPolisi;
    protected double _hargaSewa;
    protected bool _isAvailable;

    public Kendaraan(string nama_kendaraan, string nomor_polisi, double harga_sewa)
    {
        _namaKendaraan = nama_kendaraan;
        _nomorPolisi = nomor_polisi;
        _hargaSewa = harga_sewa;
        _isAvailable = true;
    }

    public string NamaKendaraan
    {
        get {return _namaKendaraan; }
        set { _namaKendaraan = value; }
    }

    public string NomorPolisi
    {
        get {return _nomorPolisi; }
    }

    public double HargaSewa
    {
        get { return _hargaSewa; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Harga sewa tidak boleh negatif!");
            }
            else
            {
                _hargaSewa = value;
            }
        }
    }

    public bool IsAvailable
    {
        get { return _isAvailable; }
    }

    public void TampilInfo()
    {
        Console.WriteLine($"{_namaKendaraan} | {_nomorPolisi} | Rp {_hargaSewa} / hari | {(_isAvailable ? "Tersedia" : "Tidak tersedia")} ");
    }

    public void UbahStatus()
    {
        _isAvailable = !_isAvailable;
    }

    public virtual double HitungTotal (int hari)
    {
        return _hargaSewa * hari;
    }
}

class Mobil : Kendaraan
{
    private double _biayaAsuransi;
    public Mobil (string nama_kendaraan, string nomor_polisi, double harga_sewa) : base (nama_kendaraan, nomor_polisi, harga_sewa)
    {
        _biayaAsuransi = 50000;
    }

    public override double HitungTotal(int hari)
    {
        return base.HitungTotal(hari) + _biayaAsuransi;
    }
}

class MiniBus : Kendaraan
{
    private double _biayaSopir;
    public MiniBus (string nama_kendaraan, string nomor_polisi, double harga_sewa) : base (nama_kendaraan, nomor_polisi, harga_sewa)
    {
        _biayaSopir = 100000;
    }

    public override double HitungTotal(int hari)
    {
        return base.HitungTotal(hari) + _biayaSopir * hari;
    }
}