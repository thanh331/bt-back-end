using System;
using System.Collections.Generic;

namespace QuanLyThiSinh
{
    // Lớp cơ sở
    class ThiSinh
    {
        public string SoBaoDanh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string UuTien { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhập số báo danh: ");
            SoBaoDanh = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            DiaChi = Console.ReadLine();
            Console.Write("Nhập diện ưu tiên: ");
            UuTien = Console.ReadLine();
        }

        public virtual void HienThi()
        {
            Console.WriteLine($"SBD: {SoBaoDanh}, Họ tên: {HoTen}, Địa chỉ: {DiaChi}, Ưu tiên: {UuTien}");
        }

        public virtual double TongDiem()
        {
            return 0;
        }

        public virtual string KhoiThi()
        {
            return "Không xác định";
        }

        public virtual bool DaTrungTuyen()
        {
            return false;
        }
    }

    class ThiSinhKhoiA : ThiSinh
    {
        public double Toan, Ly, Hoa;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập điểm Toán: ");
            Toan = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Lý: ");
            Ly = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Hóa: ");
            Hoa = double.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Khối A - Toán: {Toan}, Lý: {Ly}, Hóa: {Hoa}, Tổng: {TongDiem()}");
        }

        public override double TongDiem() => Toan + Ly + Hoa;

        public override string KhoiThi() => "A";

        public override bool DaTrungTuyen() => TongDiem() >= 15;
    }

    class ThiSinhKhoiB : ThiSinh
    {
        public double Toan, Hoa, Sinh;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập điểm Toán: ");
            Toan = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Hóa: ");
            Hoa = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Sinh: ");
            Sinh = double.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Khối B - Toán: {Toan}, Hóa: {Hoa}, Sinh: {Sinh}, Tổng: {TongDiem()}");
        }

        public override double TongDiem() => Toan + Hoa + Sinh;

        public override string KhoiThi() => "B";

        public override bool DaTrungTuyen() => TongDiem() >= 16;
    }

    class ThiSinhKhoiC : ThiSinh
    {
        public double Van, Su, Dia;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập điểm Văn: ");
            Van = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Sử: ");
            Su = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Địa: ");
            Dia = double.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Khối C - Văn: {Van}, Sử: {Su}, Địa: {Dia}, Tổng: {TongDiem()}");
        }

        public override double TongDiem() => Van + Su + Dia;

        public override string KhoiThi() => "C";

        public override bool DaTrungTuyen() => TongDiem() >= 13.5;
    }

    class TuyenSinh
    {
        private List<ThiSinh> danhSachThiSinh = new List<ThiSinh>();

        public void NhapThiSinhMoi()
        {
            Console.WriteLine("Chọn khối thi:");
            Console.WriteLine("1. Khối A");
            Console.WriteLine("2. Khối B");
            Console.WriteLine("3. Khối C");
            Console.Write("Lựa chọn: ");
            string chon = Console.ReadLine();

            ThiSinh ts;

            switch (chon)
            {
                case "1":
                    ts = new ThiSinhKhoiA();
                    break;
                case "2":
                    ts = new ThiSinhKhoiB();
                    break;
                case "3":
                    ts = new ThiSinhKhoiC();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            ts.Nhap();
            danhSachThiSinh.Add(ts);
        }

        public void HienThiTatCaThiSinh()
        {
            if (danhSachThiSinh.Count == 0)
            {
                Console.WriteLine("Chưa có thí sinh nào.");
                return;
            }

            Console.WriteLine("=== Danh sách thí sinh ===");
            foreach (var ts in danhSachThiSinh)
            {
                ts.HienThi();
                Console.WriteLine("------------------------");
            }
        }

        public void HienThiThiSinhTrungTuyen()
        {
            Console.WriteLine("=== Danh sách thí sinh trúng tuyển ===");
            bool coNguoiTrungTuyen = false;
            foreach (var ts in danhSachThiSinh)
            {
                if (ts.DaTrungTuyen())
                {
                    ts.HienThi();
                    Console.WriteLine("------------------------");
                    coNguoiTrungTuyen = true;
                }
            }

            if (!coNguoiTrungTuyen)
                Console.WriteLine("Không có thí sinh nào trúng tuyển.");
        }

        public void TimKiemTheoSBD()
        {
            Console.Write("Nhập số báo danh cần tìm: ");
            string sbd = Console.ReadLine();
            bool timThay = false;

            foreach (var ts in danhSachThiSinh)
            {
                if (ts.SoBaoDanh.Equals(sbd, StringComparison.OrdinalIgnoreCase))
                {
                    ts.HienThi();
                    timThay = true;
                    break;
                }
            }

            if (!timThay)
                Console.WriteLine("Không tìm thấy thí sinh.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TuyenSinh ts = new TuyenSinh();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Nhập thí sinh mới");
                Console.WriteLine("2. Hiển thị tất cả thí sinh");
                Console.WriteLine("3. Hiển thị thí sinh trúng tuyển");
                Console.WriteLine("4. Tìm kiếm theo số báo danh");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng: ");

                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        ts.NhapThiSinhMoi();
                        break;
                    case "2":
                        ts.HienThiTatCaThiSinh();
                        break;
                    case "3":
                        ts.HienThiThiSinhTrungTuyen();
                        break;
                    case "4":
                        ts.TimKiemTheoSBD();
                        break;
                    case "5":
                        tiepTuc = false;
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ.");
                        break;
                }
            }
        }
    }
}
