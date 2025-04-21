using System;
using System.Collections.Generic;
using System.Linq;

// 1. Cấu trúc HoTen
public struct HoTen
{
    public string Ho;
    public string TenDem;
    public string Ten;

    public override string ToString()
    {
        return $"{Ho} {TenDem} {Ten}".Trim();
    }
}

// 1. Cấu trúc QueQuan
public struct QueQuan
{
    public string Xa;
    public string Huyen;
    public string Tinh;

    public override string ToString()
    {
        return $"{Xa}, {Huyen}, {Tinh}";
    }
}

// 1. Cấu trúc DiemThi
public struct DiemThi
{
    public double Toan;
    public double Ly;
    public double Hoa;

    public override string ToString()
    {
        return $"Toán: {Toan}, Lý: {Ly}, Hóa: {Hoa}";
    }
}

// 1. Lớp THISINH
public class THISINH
{
    public HoTen HoTen { get; set; }
    public QueQuan QueQuan { get; set; }
    public string Truong { get; set; }
    public int Tuoi { get; set; }
    public string SoBaoDanh { get; set; }
    public DiemThi DiemThi { get; set; }

    // Phương thức tính tổng điểm
    public double TinhTongDiem()
    {
        return DiemThi.Toan + DiemThi.Ly + DiemThi.Hoa;
    }

    // Phương thức in thông tin thí sinh (dạng bảng)
    public void InThongTinBang()
    {
        Console.WriteLine($"{HoTen,-30} {QueQuan,-30} {SoBaoDanh,-15} {DiemThi.Toan,-10:F2} {DiemThi.Ly,-10:F2} {DiemThi.Hoa,-10:F2}");
    }
}

public class QuanLyThiSinh
{
    private List<THISINH> danhSachThiSinh;

    public QuanLyThiSinh()
    {
        danhSachThiSinh = new List<THISINH>();
    }

    // 2. Đọc số liệu từ một phiếu điểm cụ thể và lưu trữ
    public void DocPhieuDiem()
    {
        Console.WriteLine("\n--- NHẬP THÔNG TIN THÍ SINH ---");

        HoTen hoTen;
        Console.Write("Họ: ");
        hoTen.Ho = Console.ReadLine();
        Console.Write("Tên đệm: ");
        hoTen.TenDem = Console.ReadLine();
        Console.Write("Tên: ");
        hoTen.Ten = Console.ReadLine();
        HoTen = hoTen;

        QueQuan queQuan;
        Console.Write("Xã: ");
        queQuan.Xa = Console.ReadLine();
        Console.Write("Huyện: ");
        queQuan.Huyen = Console.ReadLine();
        Console.Write("Tỉnh: ");
        queQuan.Tinh = Console.ReadLine();
        QueQuan = queQuan;

        Console.Write("Trường: ");
        string truong = Console.ReadLine();

        Console.Write("Tuổi: ");
        if (!int.TryParse(Console.ReadLine(), out int tuoi) || tuoi <= 0) tuoi = 0;
        Tuoi = tuoi;

        Console.Write("Số báo danh: ");
        string soBaoDanh = Console.ReadLine();
        SoBaoDanh = soBaoDanh;

        DiemThi diemThi;
        Console.Write("Điểm Toán: ");
        if (!double.TryParse(Console.ReadLine(), out double toan) || toan < 0 || toan > 10) toan = 0;
        diemThi.Toan = Math.Round(toan * 4) / 4.0; // Làm tròn đến 1/4

        Console.Write("Điểm Lý: ");
        if (!double.TryParse(Console.ReadLine(), out double ly) || ly < 0 || ly > 10) ly = 0;
        diemThi.Ly = Math.Round(ly * 4) / 4.0; // Làm tròn đến 1/4

        Console.Write("Điểm Hóa: ");
        if (!double.TryParse(Console.ReadLine(), out double hoa) || hoa < 0 || hoa > 10) hoa = 0;
        diemThi.Hoa = Math.Round(hoa * 4) / 4.0; // Làm tròn đến 1/4
        DiemThi = diemThi;

        THISINH thiSinh = new THISINH
        {
            HoTen = HoTen,
            QueQuan = QueQuan,
            Truong = truong,
            Tuoi = Tuoi,
            SoBaoDanh = SoBaoDanh,
            DiemThi = DiemThi
        };
        danhSachThiSinh.Add(thiSinh);
        Console.WriteLine("Đã thêm thông tin thí sinh.");
    }

    // 2. In ra màn hình thông tin thí sinh vừa nhập
    public void InThongTinThiSinh(THISINH thiSinh)
    {
        Console.WriteLine("\n--- THÔNG TIN THÍ SINH ---");
        Console.WriteLine($"Họ tên: {thiSinh.HoTen}");
        Console.WriteLine($"Quê quán: {thiSinh.QueQuan}");
        Console.WriteLine($"Trường: {thiSinh.Truong}");
        Console.WriteLine($"Tuổi: {thiSinh.Tuoi}");
        Console.WriteLine($"Số báo danh: {thiSinh.SoBaoDanh}");
        Console.WriteLine($"Điểm thi: {thiSinh.DiemThi}");
        Console.WriteLine($"Tổng điểm: {thiSinh.TinhTongDiem():F2}");
    }

    // 4. Nhập số liệu từ N phiếu điểm
    public void NhapDanhSachThiSinh(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin thí sinh thứ {i + 1} ---");
            DocPhieuDiem();
        }
    }

    // 5. Tìm kiếm và in ra các thí sinh có tổng điểm ba môn lớn hơn 15
    public void TimKiemThiSinhDiemCao()
    {
        Console.WriteLine("\n--- THÍ SINH CÓ TỔNG ĐIỂM LỚN HƠN 15 ---");
        bool timThay = false;
        Console.WriteLine($"{"Họ tên",-30} {"Quê quán",-30} {"SBD",-15} {"Toán",-10} {"Lý",-10} {"Hóa",-10}");
        Console.WriteLine(new string('-', 105));
        foreach (THISINH thiSinh in danhSachThiSinh)
        {
            if (thiSinh.TinhTongDiem() > 15)
            {
                thiSinh.InThongTinBang();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Không có thí sinh nào có tổng điểm lớn hơn 15.");
        }
    }

    // 6. Sắp xếp danh sách theo tổng điểm giảm dần và in ra
    public void SapXepVaInDanhSach()
    {
        danhSachThiSinh = danhSachThiSinh.OrderByDescending(ts => ts.TinhTongDiem()).ToList();
        Console.WriteLine("\n--- DANH SÁCH THÍ SINH THEO TỔNG ĐIỂM GIẢM DẦN ---");
        Console.WriteLine($"{"Họ tên",-30} {"Quê quán",-30} {"SBD",-15} {"Toán",-10} {"Lý",-10} {"Hóa",-10}");
        Console.WriteLine(new string('-', 105));
        foreach (THISINH thiSinh in danhSachThiSinh)
        {
            thiSinh.InThongTinBang();
        }
    }

    public static void Main(string[] args)
    {
        QuanLyThiSinh quanLy = new QuanLyThiSinh();
        int choice;

        do
        {
            Console.WriteLine("\n--- QUẢN LÝ THÔNG TIN THÍ SINH ---");
            Console.WriteLine("1. Nhập thông tin một thí sinh");
            Console.WriteLine("2. Nhập danh sách N thí sinh");
            Console.WriteLine("3. Tìm kiếm thí sinh có tổng điểm > 15");
            Console.WriteLine("4. Sắp xếp và in danh sách theo tổng điểm giảm dần");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập lựa chọn: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        quanLy.DocPhieuDiem();
                        if (quanLy.danhSachThiSinh.Count > 0)
                        {
                            quanLy.InThongTinThiSinh(quanLy.danhSachThiSinh.Last());
                        }
                        break;
                    case 2:
                        Console.Write("Nhập số lượng thí sinh N: ");
                        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                        {
                            quanLy.NhapDanhSachThiSinh(n);
                        }
                        else
                        {
                            Console.WriteLine("Số lượng thí sinh không hợp lệ.");
                        }
                        break;
                    case 3:
                        quanLy.TimKiemThiSinhDiemCao();
                        break;
                    case 4:
                        quanLy.SapXepVaInDanhSach();
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