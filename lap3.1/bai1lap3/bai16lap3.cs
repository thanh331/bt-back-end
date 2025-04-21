using System;
using System.Collections.Generic;

// 1. Lớp Diem
public class Diem
{
    public double HoanhDo { get; set; }
    public double TungDo { get; set; }

    // Toán tử tạo lập không đối số
    public Diem()
    {
        HoanhDo = 0;
        TungDo = 0;
    }

    // Toán tử tạo lập có đối số
    public Diem(double x, double y)
    {
        HoanhDo = x;
        TungDo = y;
    }

    // Phương thức in một đối tượng Diem
    public void InDiem()
    {
        Console.WriteLine($"({HoanhDo}, {TungDo})");
    }

    // Tính khoảng cách giữa hai điểm
    public double TinhKhoangCach(Diem diemKhac)
    {
        double deltaX = HoanhDo - diemKhac.HoanhDo;
        double deltaY = TungDo - diemKhac.TungDo;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}

// 2. Lớp TamGiac
public class TamGiac
{
    private Diem diem1;
    private Diem diem2;
    private Diem diem3;

    // Toán tử tạo lập không đối số
    public TamGiac()
    {
        diem1 = new Diem();
        diem2 = new Diem();
        diem3 = new Diem();
    }

    // Toán tử tạo lập có đối số
    public TamGiac(Diem d1, Diem d2, Diem d3)
    {
        diem1 = d1;
        diem2 = d2;
        diem3 = d3;
    }

    // Phương thức nhập tọa độ ba đỉnh tam giác
    public void NhapTamGiac()
    {
        Console.WriteLine("Nhập tọa độ đỉnh thứ nhất:");
        Console.Write("Hoành độ: ");
        if (!double.TryParse(Console.ReadLine(), out double x1)) x1 = 0;
        Console.Write("Tung độ: ");
        if (!double.TryParse(Console.ReadLine(), out double y1)) y1 = 0;
        diem1 = new Diem(x1, y1);

        Console.WriteLine("Nhập tọa độ đỉnh thứ hai:");
        Console.Write("Hoành độ: ");
        if (!double.TryParse(Console.ReadLine(), out double x2)) x2 = 0;
        Console.Write("Tung độ: ");
        if (!double.TryParse(Console.ReadLine(), out double y2)) y2 = 0;
        diem2 = new Diem(x2, y2);

        Console.WriteLine("Nhập tọa độ đỉnh thứ ba:");
        Console.Write("Hoành độ: ");
        if (!double.TryParse(Console.ReadLine(), out double x3)) x3 = 0;
        Console.Write("Tung độ: ");
        if (!double.TryParse(Console.ReadLine(), out double y3)) y3 = 0;
        diem3 = new Diem(x3, y3);
    }

    // Phương thức in tọa độ ba đỉnh tam giác
    public void InTamGiac()
    {
        Console.Write("Đỉnh 1: ");
        diem1.InDiem();
        Console.Write("Đỉnh 2: ");
        diem2.InDiem();
        Console.Write("Đỉnh 3: ");
        diem3.InDiem();
    }

    // Tính diện tích tam giác (sử dụng công thức Heron)
    public double TinhDienTich()
    {
        double a = diem1.TinhKhoangCach(diem2);
        double b = diem2.TinhKhoangCach(diem3);
        double c = diem3.TinhKhoangCach(diem1);
        double p = (a + b + c) / 2; // Nửa chu vi
        if (p * (p - a) * (p - b) * (p - c) < 0)
        {
            Console.WriteLine("Lỗi: Ba điểm không tạo thành tam giác hợp lệ (hoặc thẳng hàng). Diện tích trả về 0.");
            return 0;
        }
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Tính chu vi của tam giác
    public double TinhChuVi()
    {
        double a = diem1.TinhKhoangCach(diem2);
        double b = diem2.TinhKhoangCach(diem3);
        double c = diem3.TinhKhoangCach(diem1);
        return a + b + c;
    }
}

// 3. Ứng dụng quản lý tam giác
public class QuanLyTamGiac
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng tam giác cần tính toán: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Số lượng tam giác không hợp lệ.");
            return;
        }

        List<TamGiac> danhSachTamGiac = new List<TamGiac>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin tam giác thứ {i + 1} ---");
            TamGiac tamGiac = new TamGiac();
            tamGiac.NhapTamGiac();
            danhSachTamGiac.Add(tamGiac);
        }

        double tongChuVi = 0;
        double tongDienTich = 0;

        Console.WriteLine("\n--- Thông tin và kết quả tính toán ---");
        for (int i = 0; i < danhSachTamGiac.Count; i++)
        {
            Console.WriteLine($"\nTam giác thứ {i + 1}:");
            danhSachTamGiac[i].InTamGiac();
            double chuVi = danhSachTamGiac[i].TinhChuVi();
            double dienTich = danhSachTamGiac[i].TinhDienTich();
            Console.WriteLine($"Chu vi: {chuVi:F2}");
            Console.WriteLine($"Diện tích: {dienTich:F2}");
            tongChuVi += chuVi;
            tongDienTich += dienTich;
        }

        Console.WriteLine($"\n--- Tổng kết ---");
        Console.WriteLine($"Tổng chu vi của {n} tam giác: {tongChuVi:F2}");
        Console.WriteLine($"Tổng diện tích của {n} tam giác: {tongDienTich:F2}");

        Console.ReadKey();
    }
}