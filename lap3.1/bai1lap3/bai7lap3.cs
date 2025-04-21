using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyCBGV
{
    // 1. Lớp Nguoi – Thông tin cá nhân
    class Nguoi
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public string QueQuan { get; set; }
        public string CMND { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhập quê quán: ");
            QueQuan = Console.ReadLine();
            Console.Write("Nhập số CMND: ");
            CMND = Console.ReadLine();
        }

        public void HienThi()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Quê quán: {QueQuan}, CMND: {CMND}");
        }
    }

    // 2. Lớp CBGV – Thông tin cán bộ giáo viên
    class CBGV
    {
        public Nguoi ThongTinCaNhan { get; set; } = new Nguoi();
        public double LuongCung { get; set; }
        public double Thuong { get; set; }
        public double Phat { get; set; }
        public double LuongThucLinh => LuongCung + Thuong - Phat;

        public void Nhap()
        {
            ThongTinCaNhan.Nhap();
            Console.Write("Nhập lương cứng: ");
            LuongCung = double.Parse(Console.ReadLine());
            Console.Write("Nhập thưởng: ");
            Thuong = double.Parse(Console.ReadLine());
            Console.Write("Nhập phạt: ");
            Phat = double.Parse(Console.ReadLine());
        }

        public void HienThi()
        {
            ThongTinCaNhan.HienThi();
            Console.WriteLine($"Lương cứng: {LuongCung:#,##0} | Thưởng: {Thuong:#,##0} | Phạt: {Phat:#,##0} | Lương thực lĩnh: {LuongThucLinh:#,##0}");
        }
    }

    // 3. Lớp quản lý danh sách cán bộ giáo viên
    class QuanLyCBGV
    {
        private List<CBGV> danhSach = new List<CBGV>();

        public void NhapDanhSach()
        {
            Console.Write("Nhập số lượng cán bộ giáo viên: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin cán bộ giáo viên thứ {i + 1} ---");
                CBGV cb = new CBGV();
                cb.Nhap();
                danhSach.Add(cb);
            }
        }

        public void HienThiTatCa()
        {
            Console.WriteLine("\n=== DANH SÁCH CÁN BỘ GIÁO VIÊN ===");
            foreach (var cb in danhSach)
            {
                cb.HienThi();
                Console.WriteLine("----------------------------------");
            }
        }

        public void TimKiemTheoQueQuan()
        {
            Console.Write("\nNhập quê quán cần tìm: ");
            string que = Console.ReadLine();

            var ketQua = danhSach.Where(cb => cb.ThongTinCaNhan.QueQuan.Equals(que, StringComparison.OrdinalIgnoreCase)).ToList();

            if (ketQua.Count > 0)
            {
                Console.WriteLine($"\n=== Cán bộ quê ở {que} ===");
                foreach (var cb in ketQua)
                {
                    cb.HienThi();
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy cán bộ nào ở quê quán này.");
            }
        }

        public void HienThiLuongTren5Trieu()
        {
            var ketQua = danhSach.Where(cb => cb.LuongThucLinh > 5000000).ToList();

            Console.WriteLine("\n=== Cán bộ giáo viên có lương thực lĩnh > 5 triệu ===");
            if (ketQua.Count > 0)
            {
                foreach (var cb in ketQua)
                {
                    cb.HienThi();
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không có cán bộ nào có lương thực lĩnh trên 5 triệu.");
            }
        }
    }

    // 4. Chương trình chính
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyCBGV ql = new QuanLyCBGV();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ CÁN BỘ GIÁO VIÊN =====");
                Console.WriteLine("1. Nhập danh sách cán bộ giáo viên");
                Console.WriteLine("2. Hiển thị toàn bộ cán bộ giáo viên");
                Console.WriteLine("3. Tìm kiếm theo quê quán");
                Console.WriteLine("4. Hiển thị cán bộ có lương thực lĩnh > 5 triệu");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");

                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        ql.NhapDanhSach();
                        break;
                    case "2":
                        ql.HienThiTatCa();
                        break;
                    case "3":
                        ql.TimKiemTheoQueQuan();
                        break;
                    case "4":
                        ql.HienThiLuongTren5Trieu();
                        break;
                    case "5":
                        tiepTuc = false;
                        Console.WriteLine("Đã thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Mời chọn lại.");
                        break;
                }
            }
        }
    }
}
