using System;
using System.Collections.Generic;

// Lớp cơ sở Phương Tiện Giao Thông (PTGT)
public class PTGT
{
    public string HangSanXuat { get; set; }
    public int NamSanXuat { get; set; }
    public double GiaBan { get; set; }
    public string Mau { get; set; }

    // Hàm tạo không đối số
    public PTGT()
    {
    }

    // Hàm tạo có đối số
    public PTGT(string hangSanXuat, int namSanXuat, double giaBan, string mau)
    {
        HangSanXuat = hangSanXuat;
        NamSanXuat = namSanXuat;
        GiaBan = giaBan;
        Mau = mau;
    }

    // Phương thức hiển thị thông tin chung
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Hãng sản xuất: {HangSanXuat}");
        Console.WriteLine($"Năm sản xuất: {NamSanXuat}");
        Console.WriteLine($"Giá bán: {GiaBan:N0} VNĐ");
        Console.WriteLine($"Màu: {Mau}");
    }
}

// Lớp Ô tô kế thừa từ PTGT
public class OTo : PTGT
{
    public int SoChoNgoi { get; set; }
    public string KieuDongCo { get; set; }

    // Hàm tạo không đối số
    public OTo() : base()
    {
    }

    // Hàm tạo có đối số
    public OTo(string hangSanXuat, int namSanXuat, double giaBan, string mau, int soChoNgoi, string kieuDongCo)
        : base(hangSanXuat, namSanXuat, giaBan, mau)
    {
        SoChoNgoi = soChoNgoi;
        KieuDongCo = kieuDongCo;
    }

    // Override phương thức hiển thị thông tin
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Số chỗ ngồi: {SoChoNgoi}");
        Console.WriteLine($"Kiểu động cơ: {KieuDongCo}");
    }
}

// Lớp Xe máy kế thừa từ PTGT
public class XeMay : PTGT
{
    public string CongSuat { get; set; }

    // Hàm tạo không đối số
    public XeMay() : base()
    {
    }

    // Hàm tạo có đối số
    public XeMay(string hangSanXuat, int namSanXuat, double giaBan, string mau, string congSuat)
        : base(hangSanXuat, namSanXuat, giaBan, mau)
    {
        CongSuat = congSuat;
    }

    // Override phương thức hiển thị thông tin
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Công suất: {CongSuat}");
    }
}

// Lớp Xe tải kế thừa từ PTGT
public class XeTai : PTGT
{
    public double TrongTai { get; set; }

    // Hàm tạo không đối số
    public XeTai() : base()
    {
    }

    // Hàm tạo có đối số
    public XeTai(string hangSanXuat, int namSanXuat, double giaBan, string mau, double trongTai)
        : base(hangSanXuat, namSanXuat, giaBan, mau)
    {
        TrongTai = trongTai;
    }

    // Override phương thức hiển thị thông tin
    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Trọng tải: {TrongTai} tấn");
    }
}

// Lớp Quản lý Phương Tiện Giao Thông (QLPTGT)
public class QLPTGT
{
    private List<PTGT> danhSachPTGT;

    public QLPTGT()
    {
        danhSachPTGT = new List<PTGT>();
    }

    // Phương thức nhập đăng ký phương tiện
    public void NhapPTGT()
    {
        Console.WriteLine("\n--- NHẬP THÔNG TIN PHƯƠNG TIỆN ---");
        Console.WriteLine("Chọn loại phương tiện:");
        Console.WriteLine("1. Ô tô");
        Console.WriteLine("2. Xe máy");
        Console.WriteLine("3. Xe tải");
        Console.Write("Nhập lựa chọn: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.Write("Hãng sản xuất: ");
            string hangSanXuat = Console.ReadLine();
            Console.Write("Năm sản xuất: ");
            if (!int.TryParse(Console.ReadLine(), out int namSanXuat)) namSanXuat = 0;
            Console.Write("Giá bán: ");
            if (!double.TryParse(Console.ReadLine(), out double giaBan)) giaBan = 0;
            Console.Write("Màu: ");
            string mau = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Số chỗ ngồi: ");
                    if (int.TryParse(Console.ReadLine(), out int soChoNgoi))
                    {
                        Console.Write("Kiểu động cơ: ");
                        string kieuDongCo = Console.ReadLine();
                        OTo oTo = new OTo(hangSanXuat, namSanXuat, giaBan, mau, soChoNgoi, kieuDongCo);
                        danhSachPTGT.Add(oTo);
                        Console.WriteLine("Đăng ký ô tô thành công!");
                    }
                    else
                    {
                        Console.WriteLine("Số chỗ ngồi không hợp lệ.");
                    }
                    break;
                case 2:
                    Console.Write("Công suất: ");
                    string congSuat = Console.ReadLine();
                    XeMay xeMay = new XeMay(hangSanXuat, namSanXuat, giaBan, mau, congSuat);
                    danhSachPTGT.Add(xeMay);
                    Console.WriteLine("Đăng ký xe máy thành công!");
                    break;
                case 3:
                    Console.Write("Trọng tải (tấn): ");
                    if (double.TryParse(Console.ReadLine(), out double trongTai))
                    {
                        XeTai xeTai = new XeTai(hangSanXuat, namSanXuat, giaBan, mau, trongTai);
                        danhSachPTGT.Add(xeTai);
                        Console.WriteLine("Đăng ký xe tải thành công!");
                    }
                    else
                    {
                        Console.WriteLine("Trọng tải không hợp lệ.");
                    }
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Lựa chọn không hợp lệ.");
        }
    }

    // Phương thức tìm phương tiện theo màu
    public void TimPTGTTheoMau(string mauTim)
    {
        Console.WriteLine($"\n--- KẾT QUẢ TÌM THEO MÀU '{mauTim}' ---");
        bool timThay = false;
        foreach (PTGT ptgt in danhSachPTGT)
        {
            if (ptgt.Mau.ToLower() == mauTim.ToLower())
            {
                ptgt.HienThiThongTin();
                Console.WriteLine("-------------------------");
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy phương tiện nào có màu này.");
        }
    }

    // Phương thức tìm phương tiện theo năm sản xuất
    public void TimPTGTTheoNamSanXuat(int namTim)
    {
        Console.WriteLine($"\n--- KẾT QUẢ TÌM THEO NĂM SẢN XUẤT '{namTim}' ---");
        bool timThay = false;
        foreach (PTGT ptgt in danhSachPTGT)
        {
            if (ptgt.NamSanXuat == namTim)
            {
                ptgt.HienThiThongTin();
                Console.WriteLine("-------------------------");
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine($"Không tìm thấy phương tiện nào sản xuất năm {namTim}.");
        }
    }

    public static void Main(string[] args)
    {
        QLPTGT quanLyPTGT = new QLPTGT();
        int choice;

        do
        {
            Console.WriteLine("\n--- QUẢN LÝ PHƯƠNG TIỆN GIAO THÔNG ---");
            Console.WriteLine("1. Nhập đăng ký phương tiện");
            Console.WriteLine("2. Tìm phương tiện theo màu");
            Console.WriteLine("3. Tìm phương tiện theo năm sản xuất");
            Console.WriteLine("0. Kết thúc chương trình");
            Console.Write("Nhập lựa chọn: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        quanLyPTGT.NhapPTGT();
                        break;
                    case 2:
                        Console.Write("Nhập màu cần tìm: ");
                        string mauTim = Console.ReadLine();
                        quanLyPTGT.TimPTGTTheoMau(mauTim);
                        break;
                    case 3:
                        Console.Write("Nhập năm sản xuất cần tìm: ");
                        if (int.TryParse(Console.ReadLine(), out int namTim))
                        {
                            quanLyPTGT.TimPTGTTheoNamSanXuat(namTim);
                        }
                        else
                        {
                            Console.WriteLine("Năm sản xuất không hợp lệ.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Chương trình kết thúc. Cảm ơn bạn đã sử dụng!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Vui lòng nhập một số từ menu.");
            }
        } while (choice != 0);
    }
}