using System;
using System.Collections.Generic;

// 1. Lớp HoiVien (thông tin chung)
public class HoiVien
{
    public string HoTen { get; set; }
    public string DiaChi { get; set; }

    public HoiVien()
    {
        HoTen = "";
        DiaChi = "";
    }

    public HoiVien(string hoTen, string diaChi)
    {
        HoTen = hoTen;
        DiaChi = diaChi;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}");
        Console.WriteLine($"Địa chỉ: {DiaChi}");
    }
}

// Lớp HoiVienDaKetHon (kế thừa từ HoiVien)
public class HoiVienDaKetHon : HoiVien
{
    public string HoTenVo { get; set; }
    public DateTime NgayCuoi { get; set; }

    public HoiVienDaKetHon() : base()
    {
        HoTenVo = "";
        NgayCuoi = DateTime.MinValue;
    }

    public HoiVienDaKetHon(string hoTen, string diaChi, string hoTenVo, DateTime ngayCuoi)
        : base(hoTen, diaChi)
    {
        HoTenVo = hoTenVo;
        NgayCuoi = ngayCuoi;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Họ tên vợ: {HoTenVo}");
        Console.WriteLine($"Ngày cưới: {NgayCuoi:dd.MM.yyyy}");
    }
}

// Lớp HoiVienCoNguoiYeu (kế thừa từ HoiVien)
public class HoiVienCoNguoiYeu : HoiVien
{
    public string HoTenNguoiYeu { get; set; }
    public string SoDienThoaiNguoiYeu { get; set; }

    public HoiVienCoNguoiYeu() : base()
    {
        HoTenNguoiYeu = "";
        SoDienThoaiNguoiYeu = "";
    }

    public HoiVienCoNguoiYeu(string hoTen, string diaChi, string hoTenNguoiYeu, string soDienThoaiNguoiYeu)
        : base(hoTen, diaChi)
    {
        HoTenNguoiYeu = hoTenNguoiYeu;
        SoDienThoaiNguoiYeu = soDienThoaiNguoiYeu;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Họ tên người yêu: {HoTenNguoiYeu}");
        Console.WriteLine($"Số điện thoại người yêu: {SoDienThoaiNguoiYeu}");
    }
}

public class QuanLyHoiVien
{
    private List<HoiVien> danhSachHoiVien;

    public QuanLyHoiVien()
    {
        danhSachHoiVien = new List<HoiVien>();
    }

    // 2. Nhập danh sách cho N hội viên
    public void NhapDanhSach(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin hội viên thứ {i + 1} ---");
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();
            Console.Write("Địa chỉ: ");
            string diaChi = Console.ReadLine();

            Console.Write("Đã có gia đình (y/n)? ");
            string daKetHonInput = Console.ReadLine().ToLower();

            if (daKetHonInput == "y")
            {
                Console.Write("Họ tên vợ: ");
                string hoTenVo = Console.ReadLine();
                Console.Write("Ngày cưới (dd.MM.yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngayCuoi))
                {
                    danhSachHoiVien.Add(new HoiVienDaKetHon(hoTen, diaChi, hoTenVo, ngayCuoi));
                }
                else
                {
                    Console.WriteLine("Ngày cưới không hợp lệ. Chỉ lưu thông tin cơ bản.");
                    danhSachHoiVien.Add(new HoiVien(hoTen, diaChi));
                }
                continue;
            }

            Console.Write("Đã có người yêu (y/n)? ");
            string coNguoiYeuInput = Console.ReadLine().ToLower();

            if (coNguoiYeuInput == "y")
            {
                Console.Write("Họ tên người yêu: ");
                string hoTenNguoiYeu = Console.ReadLine();
                Console.Write("Số điện thoại người yêu: ");
                string soDienThoaiNguoiYeu = Console.ReadLine();
                danhSachHoiVien.Add(new HoiVienCoNguoiYeu(hoTen, diaChi, hoTenNguoiYeu, soDienThoaiNguoiYeu));
                continue;
            }

            // Chưa có gia đình và chưa có người yêu
            danhSachHoiVien.Add(new HoiVien(hoTen, diaChi));
        }
    }

    // 3. Tìm kiếm thông tin của những hội viên có ngày cưới là: 11.11.2011
    public void TimKiemTheoNgayCuoi(DateTime ngayCanTim)
    {
        Console.WriteLine($"\n--- HỘI VIÊN CÓ NGÀY CƯỚI LÀ {ngayCanTim:dd.MM.yyyy} ---");
        bool timThay = false;
        foreach (HoiVien hoiVien in danhSachHoiVien)
        {
            if (hoiVien is HoiVienDaKetHon hoiVienKetHon && hoiVienKetHon.NgayCuoi.Date == ngayCanTim.Date)
            {
                hoiVienKetHon.HienThiThongTin();
                Console.WriteLine("-------------------------");
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine($"Không có hội viên nào có ngày cưới là {ngayCanTim:dd.MM.yyyy}.");
        }
    }

    // 4. Hiển thị thông tin cho những người đã có người yêu nhưng chưa lập gia đình
    public void HienThiNguoiYeuChuaKetHon()
    {
        Console.WriteLine("\n--- HỘI VIÊN CÓ NGƯỜI YÊU NHƯNG CHƯA KẾT HÔN ---");
        bool timThay = false;
        foreach (HoiVien hoiVien in danhSachHoiVien)
        {
            if (hoiVien is HoiVienCoNguoiYeu)
            {
                bool daKetHon = false;
                foreach (HoiVien hvKiemTra in danhSachHoiVien)
                {
                    if (hvKiemTra == hoiVien) continue; // Không so sánh với chính nó
                    if (hvKiemTra is HoiVienDaKetHon hvKetHon && hvKetHon.HoTen == hoiVien.HoTen)
                    {
                        daKetHon = true;
                        break;
                    }
                }
                if (!daKetHon)
                {
                    hoiVien.HienThiThongTin();
                    Console.WriteLine("-------------------------");
                    timThay = true;
                }
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Không có hội viên nào có người yêu nhưng chưa kết hôn.");
        }
    }

    public static void Main(string[] args)
    {
        QuanLyHoiVien quanLy = new QuanLyHoiVien();
        int choice;

        do
        {
            Console.WriteLine("\n--- QUẢN LÝ HỘI VIÊN ---");
            Console.WriteLine("1. Nhập danh sách hội viên");
            Console.WriteLine("2. Tìm kiếm hội viên theo ngày cưới (11.11.2011)");
            Console.WriteLine("3. Hiển thị người có người yêu nhưng chưa kết hôn");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập lựa chọn: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhập số lượng hội viên N: ");
                        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                        {
                            quanLy.NhapDanhSach(n);
                        }
                        else
                        {
                            Console.WriteLine("Số lượng hội viên không hợp lệ.");
                        }
                        break;
                    case 2:
                        quanLy.TimKiemTheoNgayCuoi(new DateTime(2011, 11, 11));
                        break;
                    case 3:
                        quanLy.HienThiNguoiYeuChuaKetHon();
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