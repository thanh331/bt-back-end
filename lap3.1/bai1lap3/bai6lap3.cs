using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyHocSinhTHPT
{
    // 1. Lớp Nguoi – Thông tin cá nhân
    class Nguoi
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public int NamSinh { get; set; }
        public string QueQuan { get; set; }
        public string GioiTinh { get; set; } // "Nam" hoặc "Nữ"

        public void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhập quê quán: ");
            QueQuan = Console.ReadLine();
            Console.Write("Nhập giới tính (Nam/Nữ): ");
            GioiTinh = Console.ReadLine();
        }

        public void HienThi()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Tuổi: {Tuoi}, Năm sinh: {NamSinh}, Quê quán: {QueQuan}, Giới tính: {GioiTinh}");
        }
    }

    // 2. Lớp HSHocSinh – Hồ sơ học sinh
    class HSHocSinh
    {
        public Nguoi ThongTinCaNhan { get; set; } = new Nguoi();
        public string Lop { get; set; }
        public string KhoaHoc { get; set; }
        public string KyHoc { get; set; }

        public void Nhap()
        {
            ThongTinCaNhan.Nhap();
            Console.Write("Nhập lớp: ");
            Lop = Console.ReadLine();
            Console.Write("Nhập khóa học: ");
            KhoaHoc = Console.ReadLine();
            Console.Write("Nhập kỳ học: ");
            KyHoc = Console.ReadLine();
        }

        public void HienThi()
        {
            ThongTinCaNhan.HienThi();
            Console.WriteLine($"Lớp: {Lop}, Khóa học: {KhoaHoc}, Kỳ học: {KyHoc}");
        }

        public bool LaNuSinhNam1985()
        {
            return ThongTinCaNhan.GioiTinh.ToLower() == "nữ" && ThongTinCaNhan.NamSinh == 1985;
        }
    }

    // 3. Lớp QuanLyHocSinh
    class QuanLyHocSinh
    {
        private List<HSHocSinh> danhSachHS = new List<HSHocSinh>();

        public void NhapDanhSach()
        {
            Console.Write("Nhập số lượng học sinh: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin học sinh thứ {i + 1}:");
                HSHocSinh hs = new HSHocSinh();
                hs.Nhap();
                danhSachHS.Add(hs);
            }
        }

        public void HienThiTatCa()
        {
            Console.WriteLine("\n=== Danh sách học sinh ===");
            foreach (var hs in danhSachHS)
            {
                hs.HienThi();
                Console.WriteLine("--------------------------------");
            }
        }

        public void HienThiNuSinh1985()
        {
            Console.WriteLine("\n=== Học sinh nữ sinh năm 1985 ===");
            var ketQua = danhSachHS.Where(hs => hs.LaNuSinhNam1985()).ToList();

            if (ketQua.Count > 0)
            {
                foreach (var hs in ketQua)
                {
                    hs.HienThi();
                    Console.WriteLine("--------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không có học sinh nữ nào sinh năm 1985.");
            }
        }

        public void TimKiemTheoQueQuan()
        {
            Console.Write("Nhập quê quán cần tìm: ");
            string que = Console.ReadLine();

            var ketQua = danhSachHS.Where(hs => hs.ThongTinCaNhan.QueQuan.Equals(que, StringComparison.OrdinalIgnoreCase)).ToList();

            if (ketQua.Count > 0)
            {
                Console.WriteLine($"\n=== Danh sách học sinh quê ở {que} ===");
                foreach (var hs in ketQua)
                {
                    hs.HienThi();
                    Console.WriteLine("--------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy học sinh nào ở quê quán này.");
            }
        }
    }

    // 4. Chương trình chính
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyHocSinh qlhs = new QuanLyHocSinh();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ HỌC SINH =====");
                Console.WriteLine("1. Nhập danh sách học sinh");
                Console.WriteLine("2. Hiển thị tất cả học sinh nữ sinh năm 1985");
                Console.WriteLine("3. Tìm học sinh theo quê quán");
                Console.WriteLine("4. Hiển thị tất cả học sinh");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");

                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        qlhs.NhapDanhSach();
                        break;
                    case "2":
                        qlhs.HienThiNuSinh1985();
                        break;
                    case "3":
                        qlhs.TimKiemTheoQueQuan();
                        break;
                    case "4":
                        qlhs.HienThiTatCa();
                        break;
                    case "5":
                        tiepTuc = false;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
