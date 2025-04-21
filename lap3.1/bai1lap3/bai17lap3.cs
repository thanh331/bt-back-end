using System;
using System.Collections.Generic;
using System.Linq;

// 1. Lớp Diem (giữ nguyên từ bài 16)
public class Diem
{
    public double HoanhDo { get; set; }
    public double TungDo { get; set; }

    public Diem()
    {
        HoanhDo = 0;
        TungDo = 0;
    }

    public Diem(double x, double y)
    {
        HoanhDo = x;
        TungDo = y;
    }

    public void InDiem()
    {
        Console.WriteLine($"({HoanhDo}, {TungDo})");
    }

    public double TinhKhoangCach(Diem diemKhac)
    {
        double deltaX = HoanhDo - diemKhac.HoanhDo;
        double deltaY = TungDo - diemKhac.TungDo;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}

// 2. Lớp HinhTron
public class HinhTron
{
    public Diem Tam { get; set; }
    public float BanKinh { get; set; }

    // Toán tử tạo lập không đối số
    public HinhTron()
    {
        Tam = new Diem();
        BanKinh = 0;
    }

    // Toán tử tạo lập có đối số
    public HinhTron(Diem d, float bk)
    {
        Tam = d;
        BanKinh = bk;
    }

    // Phương thức nhập thông tin hình tròn
    public void NhapHinhTron()
    {
        Console.WriteLine("Nhập tọa độ tâm hình tròn:");
        Console.Write("Hoành độ: ");
        if (!double.TryParse(Console.ReadLine(), out double x)) x = 0;
        Console.Write("Tung độ: ");
        if (!double.TryParse(Console.ReadLine(), out double y)) y = 0;
        Tam = new Diem(x, y);

        Console.Write("Nhập bán kính hình tròn: ");
        if (!float.TryParse(Console.ReadLine(), out BanKinh) || BanKinh < 0)
        {
            Console.WriteLine("Bán kính không hợp lệ. Đặt bán kính là 0.");
            BanKinh = 0;
        }
    }

    // Phương thức hiển thị thông tin hình tròn
    public void HienThiHinhTron()
    {
        Console.Write("Tâm: ");
        Tam.InDiem();
        Console.WriteLine($"Bán kính: {BanKinh}");
        Console.WriteLine($"Chu vi: {TinhChuVi():F2}");
        Console.WriteLine($"Diện tích: {TinhDienTich():F2}");
    }

    // Tính chu vi hình tròn
    public double TinhChuVi()
    {
        return 2 * Math.PI * BanKinh;
    }

    // Tính diện tích hình tròn
    public double TinhDienTich()
    {
        return Math.PI * BanKinh * BanKinh;
    }

    // Kiểm tra xem hình tròn này có giao với hình tròn khác không
    public bool CoGiaoVoi(HinhTron hinhTronKhac)
    {
        double khoangCachTam = Tam.TinhKhoangCach(hinhTronKhac.Tam);
        return khoangCachTam <= (BanKinh + hinhTronKhac.BanKinh);
    }
}

// 3. Ứng dụng quản lý hình tròn
public class QuanLyHinhTron
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng hình tròn: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Số lượng hình tròn không hợp lệ.");
            return;
        }

        List<HinhTron> danhSachHinhTron = new List<HinhTron>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin hình tròn thứ {i + 1} ---");
            HinhTron hinhTron = new HinhTron();
            hinhTron.NhapHinhTron();
            danhSachHinhTron.Add(hinhTron);
        }

        if (danhSachHinhTron.Count == 0)
        {
            Console.WriteLine("Không có hình tròn nào để kiểm tra.");
            return;
        }

        int maxGiaoDiem = 0;
        HinhTron hinhTronGiaoNhieuNhat = null;

        for (int i = 0; i < danhSachHinhTron.Count; i++)
        {
            int soGiaoDiem = 0;
            for (int j = 0; j < danhSachHinhTron.Count; j++)
            {
                if (i != j && danhSachHinhTron[i].CoGiaoVoi(danhSachHinhTron[j]))
                {
                    soGiaoDiem++;
                }
            }

            if (soGiaoDiem > maxGiaoDiem)
            {
                maxGiaoDiem = soGiaoDiem;
                hinhTronGiaoNhieuNhat = danhSachHinhTron[i];
            }
        }

        Console.WriteLine("\n--- Hình tròn giao với nhiều hình tròn khác nhất ---");
        if (hinhTronGiaoNhieuNhat != null)
        {
            hinhTronGiaoNhieuNhat.HienThiHinhTron();
            Console.WriteLine($"Số hình tròn giao: {maxGiaoDiem}");
        }
        else
        {
            Console.WriteLine("Không có hình tròn nào giao với hình tròn khác trong danh sách.");
        }

        Console.ReadKey();
    }
}