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
        string status = _isAvailable ? "Tersedia" : "Tidak tersedia";
        Console.WriteLine($"{_namaKendaraan} | {_nomorPolisi} | Rp {_hargaSewa} / hari | {status} ");
    }

    public void UbahStatus()
    {
        _isAvailable = false;
    }

    public virtual double HitungTotal (int hari)
    {
        return _hargaSewa * hari;
    }
}