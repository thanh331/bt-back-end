using System;
using System.Collections.Generic;
using System.Linq;

// 1. Lớp Nguoi
public class Nguoi
{
    public string HoTen { get; set; }
    public bool GioiTinh { get; set; } // true: Nam, false: Nữ
    public int Tuoi { get; set; }

    // Toán tử tạo lập không đối số
    public Nguoi()
    {
        HoTen = "";
        GioiTinh = true;
        Tuoi = 0;
    }

    // Toán tử tạo lập có đối số
    public Nguoi(string hoTen, bool gioiTinh, int tuoi)
    {
        HoTen = hoTen;
        GioiTinh = gioiTinh;
        Tuoi = tuoi;
    }

    // Phương thức in thông tin về một cá nhân
    public virtual void In()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Giới tính: {(GioiTinh ? "Nam" : "Nữ")}");
        Console.WriteLine($"Tuổi: {Tuoi}");
    }
}

// 2. Lớp CoQuan kế thừa từ lớp Nguoi
public class CoQuan : Nguoi
{
    public string DonViCongTac { get; set; }
    public double HeSoLuong { get; set; }
    private const double LuongCoBan = 1050000;

    // Toán tử tạo lập không đối số
    public CoQuan() : base()
    {
        DonViCongTac = "";
        HeSoLuong = 1.0;
    }

    // Toán tử tạo lập có đối số
    public CoQuan(string hoTen, bool gioiTinh, int tuoi, string donViCongTac, double heSoLuong)
        : base(hoTen, gioiTinh, tuoi)
    {
        DonViCongTac = donViCongTac;
        HeSoLuong = heSoLuong;
    }

    // Viết đè phương thức in() ở lớp Nguoi để in thông tin về một cá nhân trong CoQuan
    public override void In()
    {
        base.In();
        Console.WriteLine($"Đơn vị công tác: {DonViCongTac}");
        Console.WriteLine($"Hệ số lương: {HeSoLuong}");
        Console.WriteLine($"Lương: {TinhLuong():N0} VNĐ");
    }

    // Phương thức tinhLuong() để tính lương cho mỗi cá nhân trong cơ quan
    public double TinhLuong()
    {
        return HeSoLuong * LuongCoBan;
    }
}

// 3. Ứng dụng quản lý cá nhân trong cơ quan
public class QuanLyCoQuan
{
    private List<CoQuan> danhSachCanBo;

    public QuanLyCoQuan()
    {
        danhSachCanBo = new List<CoQuan>();
    }

    // Phương thức nhập thông tin cán bộ
    public void NhapCanBo()
    {
        Console.WriteLine("\n--- NHẬP THÔNG TIN CÁN BỘ ---");
        Console.Write("Họ tên: ");
        string hoTen = Console.ReadLine();

        Console.Write("Giới tính (Nam/Nữ): ");
        bool gioiTinh = Console.ReadLine().ToLower() == "nam";

        Console.Write("Tuổi: ");
        if (!int.TryParse(Console.ReadLine(), out int tuoi) || tuoi <= 0) tuoi = 0;

        Console.Write("Đơn vị công tác: ");
        string donViCongTac = Console.ReadLine();

        Console.Write("Hệ số lương: ");
        if (!double.TryParse(Console.ReadLine(), out double heSoLuong) || heSoLuong < 0) heSoLuong = 1.0;

        CoQuan canBo = new CoQuan(hoTen, gioiTinh, tuoi, donViCongTac, heSoLuong);
        danhSachCanBo.Add(canBo);
        Console.WriteLine("Nhập thông tin cán bộ thành công!");
    }

    // Hiển thị thông tin cho cá nhân có đơn vị là Phòng tài chính
    public void HienThiPhongTaiChinh()
    {
        Console.WriteLine("\n--- THÔNG TIN CÁN BỘ PHÒNG TÀI CHÍNH ---");
        bool timThay = false;
        foreach (CoQuan canBo in danhSachCanBo)
        {
            if (canBo.DonViCongTac.ToLower() == "phòng tài chính")
            {
                canBo.In();
                Console.WriteLine("-------------------------");
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Không có cán bộ nào thuộc Phòng tài chính.");
        }
    }

    // Tìm kiếm thông tin theo họ tên
    public void TimKiemTheoHoTen(string tenTimKiem)
    {
        Console.WriteLine($"\n--- KẾT QUẢ TÌM KIẾM THEO HỌ TÊN '{tenTimKiem}' ---");
        bool timThay = false;
        foreach (CoQuan canBo in danhSachCanBo)
        {
            if (canBo.HoTen.ToLower().Contains(tenTimKiem.ToLower()))
            {
                canBo.In();
                Console.WriteLine("-------------------------");
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine($"Không tìm thấy cán bộ nào có họ tên chứa '{tenTimKiem}'.");
        }
    }

    public static void Main(string[] args)
    {
        QuanLyCoQuan quanLy = new QuanLyCoQuan();
        int choice;

        do
        {
            Console.WriteLine("\n--- QUẢN LÝ CÁN BỘ CƠ QUAN ---");
            Console.WriteLine("1. Nhập thông tin cán bộ");
            Console.WriteLine("2. Hiển thị cán bộ Phòng tài chính");
            Console.WriteLine("3. Tìm kiếm cán bộ theo họ tên");
            Console.WriteLine("0. Thoát khỏi chương trình");
            Console.Write("Nhập lựa chọn: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        quanLy.NhapCanBo();
                        break;
                    case 2:
                        quanLy.HienThiPhongTaiChinh();
                        break;
                    case 3:
                        Console.Write("Nhập họ tên cần tìm kiếm: ");
                        string tenTimKiem = Console.ReadLine();
                        quanLy.TimKiemTheoHoTen(tenTimKiem);
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