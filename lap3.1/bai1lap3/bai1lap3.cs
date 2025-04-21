using System;
using System.Collections.Generic;

namespace QLCBApp
{
    class CanBo
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhập giới tính: ");
            GioiTinh = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            DiaChi = Console.ReadLine();
        }

        public virtual void HienThi()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Giới tính: {GioiTinh}, Địa chỉ: {DiaChi}");
        }
    }

    class CongNhan : CanBo
    {
        public string Bac { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập bậc (VD: 3/7): ");
            Bac = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Bậc: {Bac}");
        }
    }

    class KySu : CanBo
    {
        public string NganhDaoTao { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập ngành đào tạo: ");
            NganhDaoTao = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Ngành đào tạo: {NganhDaoTao}");
        }
    }

    class NhanVien : CanBo
    {
        public string CongViec { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập công việc: ");
            CongViec = Console.ReadLine();
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Công việc: {CongViec}");
        }
    }

    class QLCB
    {
        private List<CanBo> danhSachCanBo = new List<CanBo>();

        public void NhapCanBoMoi()
        {
            Console.WriteLine("Nhập loại cán bộ (1 - Công nhân, 2 - Kỹ sư, 3 - Nhân viên): ");
            string luaChon = Console.ReadLine();
            CanBo cb;

            switch (luaChon)
            {
                case "1":
                    cb = new CongNhan();
                    break;
                case "2":
                    cb = new KySu();
                    break;
                case "3":
                    cb = new NhanVien();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            cb.Nhap();
            danhSachCanBo.Add(cb);
        }

        public void HienThiDanhSach()
        {
            if (danhSachCanBo.Count == 0)
            {
                Console.WriteLine("Danh sách cán bộ trống.");
                return;
            }

            Console.WriteLine("Danh sách cán bộ:");
            foreach (var cb in danhSachCanBo)
            {
                cb.HienThi();
                Console.WriteLine("----------------------");
            }
        }

        public void TimKiemTheoHoTen()
        {
            Console.Write("Nhập họ tên cần tìm: ");
            string tenCanTim = Console.ReadLine();
            bool timThay = false;

            foreach (var cb in danhSachCanBo)
            {
                if (cb.HoTen.Contains(tenCanTim, StringComparison.OrdinalIgnoreCase))
                {
                    cb.HienThi();
                    Console.WriteLine("----------------------");
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy cán bộ nào.");
            }
        }
    }

    class bai1lap3
    {
        static void Main(string[] args)
        {
            QLCB qlcb = new QLCB();
            bool chay = true;

            while (chay)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Nhập cán bộ mới");
                Console.WriteLine("2. Tìm kiếm theo họ tên");
                Console.WriteLine("3. Hiển thị danh sách cán bộ");
                Console.WriteLine("4. Thoát");
                Console.Write("Chọn chức năng: ");

                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        qlcb.NhapCanBoMoi();
                        break;
                    case "2":
                        qlcb.TimKiemTheoHoTen();
                        break;
                    case "3":
                        qlcb.HienThiDanhSach();
                        break;
                    case "4":
                        chay = false;
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
