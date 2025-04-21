using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyKhachSan
{
    // 1. Lớp Nguoi – Thông tin cá nhân
    class Nguoi
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public string CMND { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhập số CMND: ");
            CMND = Console.ReadLine();
        }

        public void HienThi()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, CMND: {CMND}");
        }
    }

    // 2. Lớp KhachThue – Thông tin khách trọ
    class KhachThue
    {
        public Nguoi ThongTinCaNhan { get; set; } = new Nguoi();
        public int SoNgayTro { get; set; }
        public string LoaiPhong { get; set; }
        public double GiaPhong { get; set; }

        public void Nhap()
        {
            Console.WriteLine("Nhập thông tin cá nhân:");
            ThongTinCaNhan.Nhap();
            Console.Write("Nhập số ngày trọ: ");
            SoNgayTro = int.Parse(Console.ReadLine());
            Console.Write("Nhập loại phòng (A/B/C...): ");
            LoaiPhong = Console.ReadLine();
            Console.Write("Nhập giá phòng/ngày: ");
            GiaPhong = double.Parse(Console.ReadLine());
        }

        public void HienThi()
        {
            ThongTinCaNhan.HienThi();
            Console.WriteLine($"Loại phòng: {LoaiPhong}, Số ngày trọ: {SoNgayTro}, Giá phòng/ngày: {GiaPhong} VND");
        }

        public double TinhTien()
        {
            return SoNgayTro * GiaPhong;
        }
    }

    // 3. Lớp KhachSan – Quản lý danh sách khách trọ
    class KhachSan
    {
        private List<KhachThue> danhSachKhach = new List<KhachThue>();

        public void NhapDanhSach()
        {
            Console.Write("Nhập số lượng khách thuê phòng: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin cho khách thứ {i + 1}:");
                KhachThue khach = new KhachThue();
                khach.Nhap();
                danhSachKhach.Add(khach);
            }
        }

        public void HienThiTatCa()
        {
            Console.WriteLine("\n=== Danh sách khách thuê phòng ===");
            foreach (var khach in danhSachKhach)
            {
                khach.HienThi();
                Console.WriteLine("--------------------------------");
            }
        }

        public void TimKiemTheoTen()
        {
            Console.Write("Nhập họ tên khách cần tìm: ");
            string ten = Console.ReadLine();
            var ketQua = danhSachKhach.Where(k => k.ThongTinCaNhan.HoTen.Equals(ten, StringComparison.OrdinalIgnoreCase)).ToList();

            if (ketQua.Count > 0)
            {
                foreach (var khach in ketQua)
                {
                    khach.HienThi();
                    Console.WriteLine("--------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy khách nào trùng tên.");
            }
        }

        public void TinhTienThanhToan()
        {
            Console.Write("Nhập CMND khách cần tính tiền: ");
            string cmnd = Console.ReadLine();

            var khach = danhSachKhach.FirstOrDefault(k => k.ThongTinCaNhan.CMND == cmnd);

            if (khach != null)
            {
                double tien = khach.TinhTien();
                Console.WriteLine($"Khách hàng: {khach.ThongTinCaNhan.HoTen} phải thanh toán: {tien} VND");
            }
            else
            {
                Console.WriteLine("Không tìm thấy khách với CMND đã nhập.");
            }
        }
    }

    // 4. Chương trình chính
    class Program
    {
        static void Main(string[] args)
        {
            KhachSan ks = new KhachSan();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ KHÁCH SẠN =====");
                Console.WriteLine("1. Nhập danh sách khách thuê");
                Console.WriteLine("2. Hiển thị thông tin khách thuê");
                Console.WriteLine("3. Tìm kiếm khách theo họ tên");
                Console.WriteLine("4. Tính tiền thanh toán");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");

                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        ks.NhapDanhSach();
                        break;
                    case "2":
                        ks.HienThiTatCa();
                        break;
                    case "3":
                        ks.TimKiemTheoTen();
                        break;
                    case "4":
                        ks.TinhTienThanhToan();
                        break;
                    case "5":
                        tiepTuc = false;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }
    }
}
