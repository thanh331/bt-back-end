using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyKhuPho
{
    // 1. Lớp Nguoi (cá nhân)
    class Nguoi
    {
        public string CMND { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public int NamSinh { get; set; }
        public string NgheNghiep { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập số CMND: ");
            CMND = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhập nghề nghiệp: ");
            NgheNghiep = Console.ReadLine();
        }

        public void HienThi()
        {
            Console.WriteLine($"CMND: {CMND}, Họ tên: {HoTen}, Tuổi: {Tuoi}, Năm sinh: {NamSinh}, Nghề: {NgheNghiep}");
        }
    }

    // 2. Lớp HoDan (1 hộ dân)
    class HoDan
    {
        public int SoNha { get; set; }
        public int SoThanhVien { get; set; }
        public List<Nguoi> ThanhVien { get; set; } = new List<Nguoi>();

        public void Nhap()
        {
            Console.Write("Nhập số nhà: ");
            SoNha = int.Parse(Console.ReadLine());
            Console.Write("Nhập số thành viên trong hộ: ");
            SoThanhVien = int.Parse(Console.ReadLine());

            for (int i = 0; i < SoThanhVien; i++)
            {
                Console.WriteLine($"Nhập thông tin thành viên thứ {i + 1}:");
                Nguoi nguoi = new Nguoi();
                nguoi.Nhap();
                ThanhVien.Add(nguoi);
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"Số nhà: {SoNha}, Số thành viên: {SoThanhVien}");
            foreach (var nguoi in ThanhVien)
            {
                nguoi.HienThi();
            }
        }

        public bool CoNguoiTen(string ten)
        {
            return ThanhVien.Any(n => n.HoTen.Equals(ten, StringComparison.OrdinalIgnoreCase));
        }
    }

    // 3. Lớp KhuPho (quản lý các hộ dân)
    class KhuPho
    {
        private List<HoDan> danhSachHoDan = new List<HoDan>();

        public void NhapDanhSachHoDan()
        {
            Console.Write("Nhập số lượng hộ dân: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin cho hộ dân thứ {i + 1}:");
                HoDan ho = new HoDan();
                ho.Nhap();
                danhSachHoDan.Add(ho);
            }
        }

        public void HienThiTatCa()
        {
            Console.WriteLine("\n=== Danh sách toàn bộ hộ dân trong khu phố ===");
            foreach (var ho in danhSachHoDan)
            {
                ho.HienThi();
                Console.WriteLine("--------------------------------");
            }
        }

        public void TimTheoTen()
        {
            Console.Write("Nhập họ tên cần tìm: ");
            string ten = Console.ReadLine();
            bool timThay = false;

            foreach (var ho in danhSachHoDan)
            {
                if (ho.CoNguoiTen(ten))
                {
                    ho.HienThi();
                    Console.WriteLine("--------------------------------");
                    timThay = true;
                }
            }

            if (!timThay)
                Console.WriteLine("Không tìm thấy hộ dân có người tên này.");
        }

        public void TimTheoSoNha()
        {
            Console.Write("Nhập số nhà cần tìm: ");
            int soNha = int.Parse(Console.ReadLine());
            var hoTim = danhSachHoDan.FirstOrDefault(h => h.SoNha == soNha);

            if (hoTim != null)
            {
                hoTim.HienThi();
            }
            else
            {
                Console.WriteLine("Không tìm thấy hộ dân có số nhà này.");
            }
        }
    }

    // 4. Chương trình chính
    class Program
    {
        static void Main(string[] args)
        {
            KhuPho khuPho = new KhuPho();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ KHU PHỐ =====");
                Console.WriteLine("1. Nhập thông tin các hộ dân");
                Console.WriteLine("2. Tìm hộ dân theo họ tên");
                Console.WriteLine("3. Tìm hộ dân theo số nhà");
                Console.WriteLine("4. Hiển thị toàn bộ hộ dân");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");

                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        khuPho.NhapDanhSachHoDan();
                        break;
                    case "2":
                        khuPho.TimTheoTen();
                        break;
                    case "3":
                        khuPho.TimTheoSoNha();
                        break;
                    case "4":
                        khuPho.HienThiTatCa();
                        break;
                    case "5":
                        tiepTuc = false;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}
