using System;
using System.Collections.Generic;
using System.Linq;

// Lớp cơ sở HocSinh
public class HocSinh
{
    public string HoTen { get; set; }
    public bool GioiTinh { get; set; } // true: Nam, false: Nữ
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public HocSinh()
    {
        HoTen = "";
        GioiTinh = true;
        DiemToan = 0;
        DiemLy = 0;
        DiemHoa = 0;
    }

    public HocSinh(string hoTen, bool gioiTinh, double toan, double ly, double hoa)
    {
        HoTen = hoTen;
        GioiTinh = gioiTinh;
        DiemToan = toan;
        DiemLy = ly;
        DiemHoa = hoa;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Giới tính: {(GioiTinh ? "Nam" : "Nữ")}");
        Console.WriteLine($"Điểm Toán: {DiemToan:F2}");
        Console.WriteLine($"Điểm Lý: {DiemLy:F2}");
        Console.WriteLine($"Điểm Hóa: {DiemHoa:F2}");
    }
}

// Lớp HocSinhNam (kế thừa từ HocSinh)
public class HocSinhNam : HocSinh
{
    public double DiemKyThuat { get; set; }

    public HocSinhNam() : base()
    {
        DiemKyThuat = 0;
    }

    public HocSinhNam(string hoTen, double toan, double ly, double hoa, double kyThuat)
        : base(hoTen, true, toan, ly, hoa)
    {
        DiemKyThuat = kyThuat;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Điểm Kỹ Thuật: {DiemKyThuat:F2}");
    }
}

// Lớp HocSinhNu (kế thừa từ HocSinh)
public class HocSinhNu : HocSinh
{
    public double DiemNuCong { get; set; }

    public HocSinhNu() : base()
    {
        DiemNuCong = 0;
    }

    public HocSinhNu(string hoTen, double toan, double ly, double hoa, double nuCong)
        : base(hoTen, false, toan, ly, hoa)
    {
        DiemNuCong = nuCong;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Điểm Nữ Công: {DiemNuCong:F2}");
    }
}

public class QuanLyHocSinh
{
    private List<HocSinh> danhSachHocSinh;

    public QuanLyHocSinh()
    {
        danhSachHocSinh = new List<HocSinh>();
    }

    // 1. Nhập họ tên, giới tính và điểm của n học sinh
    public void NhapDanhSach(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin học sinh thứ {i + 1} ---");
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Giới tính (Nam/Nữ): ");
            string gioiTinhInput = Console.ReadLine().ToLower();
            bool laNam = gioiTinhInput == "nam";

            Console.Write("Điểm Toán: ");
            if (!double.TryParse(Console.ReadLine(), out double toan) || toan < 0 || toan > 10) toan = 0;

            Console.Write("Điểm Lý: ");
            if (!double.TryParse(Console.ReadLine(), out double ly) || ly < 0 || ly > 10) ly = 0;

            Console.Write("Điểm Hóa: ");
            if (!double.TryParse(Console.ReadLine(), out double hoa) || hoa < 0 || hoa > 10) hoa = 0;

            if (laNam)
            {
                Console.Write("Điểm Kỹ Thuật: ");
                if (!double.TryParse(Console.ReadLine(), out double kyThuat) || kyThuat < 0 || kyThuat > 10) kyThuat = 0;
                danhSachHocSinh.Add(new HocSinhNam(hoTen, toan, ly, hoa, kyThuat));
            }
            else
            {
                Console.Write("Điểm Nữ Công: ");
                if (!double.TryParse(Console.ReadLine(), out double nuCong) || nuCong < 0 || nuCong > 10) nuCong = 0;
                danhSachHocSinh.Add(new HocSinhNu(hoTen, toan, ly, hoa, nuCong));
            }
        }
    }

    // 2. Hiển thị thông tin về những học sinh nam có điểm môn kĩ thuật không nhỏ hơn 8
    public void HienThiHocSinhNamKyThuatGioi()
    {
        Console.WriteLine("\n--- HỌC SINH NAM CÓ ĐIỂM KỸ THUẬT >= 8 ---");
        bool timThay = false;
        foreach (HocSinh hs in danhSachHocSinh)
        {
            if (hs is HocSinhNam hsNam && hsNam.DiemKyThuat >= 8)
            {
                hsNam.HienThiThongTin();
                Console.WriteLine("-------------------------");
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Không có học sinh nam nào có điểm kỹ thuật >= 8.");
        }
    }

    // 3. In số liệu về học sinh nam trước rồi đến các học sinh nữ
    public void InDanhSachTheoGioiTinh()
    {
        Console.WriteLine("\n--- DANH SÁCH HỌC SINH (NAM TRƯỚC, NỮ SAU) ---");
        Console.WriteLine("--- Học sinh Nam ---");
        foreach (HocSinh hs in danhSachHocSinh.Where(hs => hs.GioiTinh))
        {
            hs.HienThiThongTin();
            Console.WriteLine("-------------------------");
        }

        Console.WriteLine("\n--- Học sinh Nữ ---");
        foreach (HocSinh hs in danhSachHocSinh.Where(hs => !hs.GioiTinh))
        {
            hs.HienThiThongTin();
            Console.WriteLine("-------------------------");
        }
    }

    public static void Main(string[] args)
    {
        QuanLyHocSinh quanLy = new QuanLyHocSinh();
        int choice;

        do
        {
            Console.WriteLine("\n--- QUẢN LÝ THÔNG TIN HỌC SINH ---");
            Console.WriteLine("1. Nhập danh sách học sinh");
            Console.WriteLine("2. Hiển thị học sinh nam có điểm Kỹ Thuật >= 8");
            Console.WriteLine("3. In danh sách học sinh (Nam trước, Nữ sau)");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập lựa chọn: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhập số lượng học sinh N: ");
                        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                        {
                            quanLy.NhapDanhSach(n);
                        }
                        else
                        {
                            Console.WriteLine("Số lượng học sinh không hợp lệ.");
                        }
                        break;
                    case 2:
                        quanLy.HienThiHocSinhNamKyThuatGioi();
                        break;
                    case 3:
                        quanLy.InDanhSachTheoGioiTinh();
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