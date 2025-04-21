using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QuanLyMuonSach
{
    // 1. Lớp SinhVien
    class SinhVien
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public string Lop { get; set; }
        public string MaSV { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhập lớp: ");
            Lop = Console.ReadLine();
            Console.Write("Nhập mã số sinh viên: ");
            MaSV = Console.ReadLine();
        }

        public void HienThi()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Lớp: {Lop}, Mã SV: {MaSV}");
        }
    }

    // 2. Lớp TheMuon
    class TheMuon
    {
        public string SoPhieuMuon { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public string SoHieuSach { get; set; }
        public SinhVien SinhVien { get; set; } = new SinhVien();

        public void Nhap()
        {
            Console.WriteLine("\n-- Nhập thông tin sinh viên --");
            SinhVien.Nhap();

            Console.WriteLine("-- Nhập thông tin mượn sách --");
            Console.Write("Nhập số phiếu mượn: ");
            SoPhieuMuon = Console.ReadLine();
            Console.Write("Nhập số hiệu sách: ");
            SoHieuSach = Console.ReadLine();
            Console.Write("Nhập ngày mượn (dd/MM/yyyy): ");
            NgayMuon = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Nhập hạn trả (dd/MM/yyyy): ");
            HanTra = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public void HienThi()
        {
            SinhVien.HienThi();
            Console.WriteLine($"Số phiếu mượn: {SoPhieuMuon}, Số hiệu sách: {SoHieuSach}, Ngày mượn: {NgayMuon:dd/MM/yyyy}, Hạn trả: {HanTra:dd/MM/yyyy}");
        }
    }

    // 3. Lớp quản lý mượn sách
    class QuanLyMuonSach
    {
        private List<TheMuon> danhSach = new List<TheMuon>();

        public void NhapDanhSach()
        {
            Console.Write("Nhập số sinh viên mượn sách: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Sinh viên thứ {i + 1} ---");
                TheMuon tm = new TheMuon();
                tm.Nhap();
                danhSach.Add(tm);
            }
        }

        public void HienThiTatCa()
        {
            Console.WriteLine("\n=== DANH SÁCH THẺ MƯỢN ===");
            foreach (var tm in danhSach)
            {
                tm.HienThi();
                Console.WriteLine("----------------------------------");
            }
        }

        public void TimKiemTheoMaSV()
        {
            Console.Write("\nNhập mã số sinh viên cần tìm: ");
            string ma = Console.ReadLine();

            var ketQua = danhSach.Where(t => t.SinhVien.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase)).ToList();

            if (ketQua.Count > 0)
            {
                Console.WriteLine($"\n== Kết quả tìm kiếm mã SV {ma} ==");
                foreach (var tm in ketQua)
                {
                    tm.HienThi();
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã số này.");
            }
        }

        public void HienThiDenHanTra()
        {
            Console.WriteLine($"\n== Danh sách sinh viên đến hạn trả sách (hôm nay: {DateTime.Now:dd/MM/yyyy}) ==");

            var ketQua = danhSach.Where(t => t.HanTra <= DateTime.Now).ToList();

            if (ketQua.Count > 0)
            {
                foreach (var tm in ketQua)
                {
                    tm.HienThi();
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Chưa có sinh viên nào đến hạn trả sách.");
            }
        }
    }

    // 4. Chương trình chính
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyMuonSach ql = new QuanLyMuonSach();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ MƯỢN SÁCH =====");
                Console.WriteLine("1. Nhập danh sách thẻ mượn");
                Console.WriteLine("2. Hiển thị toàn bộ thẻ mượn");
                Console.WriteLine("3. Tìm kiếm theo mã số sinh viên");
                Console.WriteLine("4. Hiển thị sinh viên đến hạn trả sách");
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
                        ql.TimKiemTheoMaSV();
                        break;
                    case "4":
                        ql.HienThiDenHanTra();
                        break;
                    case "5":
                        tiepTuc = false;
                        Console.WriteLine("Đã thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }
    }
}
