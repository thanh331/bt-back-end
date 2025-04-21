using System;
using System.Collections.Generic;

namespace QuanLyThuVien
{
    // Lớp cơ sở: Tài liệu
    class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenNhaXuatBan { get; set; }
        public int SoBanPhatHanh { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhập mã tài liệu: ");
            MaTaiLieu = Console.ReadLine();
            Console.Write("Nhập tên nhà xuất bản: ");
            TenNhaXuatBan = Console.ReadLine();
            Console.Write("Nhập số bản phát hành: ");
            SoBanPhatHanh = int.Parse(Console.ReadLine());
        }

        public virtual void HienThi()
        {
            Console.WriteLine($"Mã TL: {MaTaiLieu}, NXB: {TenNhaXuatBan}, Số bản: {SoBanPhatHanh}");
        }

        public virtual string LoaiTaiLieu()
        {
            return "Tài liệu";
        }
    }

    class Sach : TaiLieu
    {
        public string TenTacGia { get; set; }
        public int SoTrang { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập tên tác giả: ");
            TenTacGia = Console.ReadLine();
            Console.Write("Nhập số trang: ");
            SoTrang = int.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Tác giả: {TenTacGia}, Số trang: {SoTrang}");
        }

        public override string LoaiTaiLieu()
        {
            return "Sách";
        }
    }

    class TapChi : TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập số phát hành: ");
            SoPhatHanh = int.Parse(Console.ReadLine());
            Console.Write("Nhập tháng phát hành: ");
            ThangPhatHanh = int.Parse(Console.ReadLine());
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Số phát hành: {SoPhatHanh}, Tháng phát hành: {ThangPhatHanh}");
        }

        public override string LoaiTaiLieu()
        {
            return "Tạp chí";
        }
    }

    class Bao : TaiLieu
    {
        public string NgayPhatHanh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập ngày phát hành (dd/mm/yyyy): ");
            NgayPhatHanh = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Ngày phát hành: {NgayPhatHanh}");
        }

        public override string LoaiTaiLieu()
        {
            return "Báo";
        }
    }

    class QuanLyTaiLieu
    {
        private List<TaiLieu> danhSachTaiLieu = new List<TaiLieu>();

        public void NhapTaiLieuMoi()
        {
            Console.WriteLine("Chọn loại tài liệu cần nhập:");
            Console.WriteLine("1. Sách");
            Console.WriteLine("2. Tạp chí");
            Console.WriteLine("3. Báo");
            Console.Write("Lựa chọn: ");
            string luaChon = Console.ReadLine();

            TaiLieu tl;

            switch (luaChon)
            {
                case "1":
                    tl = new Sach();
                    break;
                case "2":
                    tl = new TapChi();
                    break;
                case "3":
                    tl = new Bao();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            tl.Nhap();
            danhSachTaiLieu.Add(tl);
        }

        public void HienThiTatCaTaiLieu()
        {
            if (danhSachTaiLieu.Count == 0)
            {
                Console.WriteLine("Chưa có tài liệu nào.");
                return;
            }

            Console.WriteLine("=== Danh sách tài liệu ===");
            foreach (var tl in danhSachTaiLieu)
            {
                Console.WriteLine($"[Loại: {tl.LoaiTaiLieu()}]");
                tl.HienThi();
                Console.WriteLine("---------------------------");
            }
        }

        public void TimKiemTheoLoai()
        {
            Console.Write("Nhập loại tài liệu cần tìm (Sách / Tạp chí / Báo): ");
            string loai = Console.ReadLine().ToLower();

            bool timThay = false;
            foreach (var tl in danhSachTaiLieu)
            {
                if (tl.LoaiTaiLieu().ToLower() == loai)
                {
                    tl.HienThi();
                    Console.WriteLine("---------------------------");
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy tài liệu thuộc loại này.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            QuanLyTaiLieu qltl = new QuanLyTaiLieu();
            bool tiepTuc = true;

            while (tiepTuc)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Nhập tài liệu mới");
                Console.WriteLine("2. Hiển thị tất cả tài liệu");
                Console.WriteLine("3. Tìm kiếm theo loại tài liệu");
                Console.WriteLine("4. Thoát");
                Console.Write("Chọn chức năng: ");

                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        qltl.NhapTaiLieuMoi();
                        break;
                    case "2":
                        qltl.HienThiTatCaTaiLieu();
                        break;
                    case "3":
                        qltl.TimKiemTheoLoai();
                        break;
                    case "4":
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
