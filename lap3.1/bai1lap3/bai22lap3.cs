using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class HocSinh : IComparable<HocSinh>
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public double TongDiem { get; set; }

    public HocSinh(string hoTen, int namSinh, double tongDiem)
    {
        HoTen = hoTen;
        NamSinh = namSinh;
        TongDiem = tongDiem;
    }

    // Phương thức chuyển chữ cái đầu của mỗi từ trong họ tên thành chữ hoa
    public string HoTenVietHoaChuDau()
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(HoTen.ToLower());
    }

    // Implement interface IComparable để thực hiện so sánh
    public int CompareTo(HocSinh other)
    {
        // Sắp xếp giảm dần theo tổng điểm
        int compareDiem = other.TongDiem.CompareTo(TongDiem);
        if (compareDiem != 0)
        {
            return compareDiem;
        }

        // Nếu tổng điểm bằng nhau, sắp xếp tăng dần theo năm sinh (năm sinh nhỏ hơn đứng trước)
        return NamSinh.CompareTo(other.NamSinh);
    }
}

public class QuanLyHocSinh
{
    private List<HocSinh> danhSachHocSinh;

    public QuanLyHocSinh()
    {
        danhSachHocSinh = new List<HocSinh>();
    }

    public void NhapDanhSach(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin học sinh thứ {i + 1} ---");
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Năm sinh: ");
            if (!int.TryParse(Console.ReadLine(), out int namSinh) || namSinh <= 0) namSinh = DateTime.Now.Year;

            Console.Write("Tổng điểm: ");
            if (!double.TryParse(Console.ReadLine(), out double tongDiem) || tongDiem < 0 || tongDiem > 30) tongDiem = 0;

            danhSachHocSinh.Add(new HocSinh(hoTen, namSinh, tongDiem));
        }
    }

    public void InDanhSachDaSapXep()
    {
        danhSachHocSinh.Sort(); // Sử dụng phương thức Sort của List, nó sẽ gọi CompareTo của HocSinh

        Console.WriteLine("\n--- DANH SÁCH HỌC SINH ĐÃ SẮP XẾP ---");
        foreach (HocSinh hs in danhSachHocSinh)
        {
            Console.WriteLine($"Họ tên: {hs.HoTenVietHoaChuDau()}, Năm sinh: {hs.NamSinh}, Tổng điểm: {hs.TongDiem:F2}");
        }
    }

    public static void Main(string[] args)
    {
        QuanLyHocSinh quanLy = new QuanLyHocSinh();

        Console.Write("Nhập số lượng học sinh N: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            quanLy.NhapDanhSach(n);
            quanLy.InDanhSachDaSapXep();
        }
        else
        {
            Console.WriteLine("Số lượng học sinh không hợp lệ.");
        }

        Console.ReadKey();
    }
}