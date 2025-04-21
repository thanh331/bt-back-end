using System;
using System.Collections.Generic;

namespace BienLaiTienDien
{
    // 1. Lớp KhachHang
    class KhachHang
    {
        public string HoTen { get; set; }
        public string SoNha { get; set; }
        public string MaCongTo { get; set; }

        public void Nhap()
        {
            Console.Write("Nhập họ tên chủ hộ: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập số nhà: ");
            SoNha = Console.ReadLine();
            Console.Write("Nhập mã số công tơ: ");
            MaCongTo = Console.ReadLine();
        }

        public void HienThi()
        {
            Console.WriteLine($"Chủ hộ: {HoTen}, Số nhà: {SoNha}, Mã công tơ: {MaCongTo}");
        }
    }

    // 2. Lớp BienLai
    class BienLai
    {
        public KhachHang ChuHo { get; set; } = new KhachHang();
        public int ChiSoCu { get; set; }
        public int ChiSoMoi { get; set; }
        public double SoTienPhaiTra { get; private set; }

        public void Nhap()
        {
            Console.WriteLine("\n--- Nhập thông tin khách hàng ---");
            ChuHo.Nhap();
            Console.Write("Nhập chỉ số cũ: ");
            ChiSoCu = int.Parse(Console.ReadLine());
            Console.Write("Nhập chỉ số mới: ");
            ChiSoMoi = int.Parse(Console.ReadLine());
            TinhTien();
        }

        public void HienThi()
        {
            ChuHo.HienThi();
            Console.WriteLine($"Chỉ số cũ: {ChiSoCu}, Chỉ số mới: {ChiSoMoi}, Số tiền phải trả: {SoTienPhaiTra:N0} VNĐ");
        }

        private void TinhTien()
        {
            int soDien = ChiSoMoi - ChiSoCu;
            if (soDien <= 50)
                SoTienPhaiTra = soDien * 1250;
            else if (soDien < 100)
                SoTienPhaiTra = 50 * 1250 + (soDien - 50) * 1500;
            else
                SoTienPhaiTra = 50 * 1250 + 50 * 1500 + (soDien - 100) * 2000;
        }
    }

    // 3. Chương trình chính
    class Program
    {
        static void Main(string[] args)
        {
            List<BienLai> danhSachBienLai = new List<BienLai>();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ BIÊN LAI TIỀN ĐIỆN =====");
                Console.WriteLine("1. Nhập biên lai cho các hộ dân");
                Console.WriteLine("2. Hiển thị thông tin các biên lai");
                Console.WriteLine("3. Thoát chương trình");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        Console.Write("Nhập số hộ dân: ");
                        int n = int.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"\n-- Nhập hộ dân thứ {i + 1} --");
                            BienLai bl = new BienLai();
                            bl.Nhap();
                            danhSachBienLai.Add(bl);
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n=== THÔNG TIN CÁC BIÊN LAI ===");
                        foreach (var bl in danhSachBienLai)
                        {
                            bl.HienThi();
                            Console.WriteLine("-----------------------------------");
                        }
                        break;

                    case "3":
                        tiepTuc = false;
                        Console.WriteLine("Đã thoát chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }
            }
        }
    }
}
