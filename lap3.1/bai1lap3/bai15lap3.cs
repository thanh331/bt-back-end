using System;
using System.Collections.Generic;
using System.Linq;

// 1. Lớp DaGiac
public class DaGiac
{
    public int SoCanh { get; protected set; }
    public int[] KichThuocCanh { get; protected set; }

    // Hàm tạo không đối số
    public DaGiac()
    {
        SoCanh = 0;
        KichThuocCanh = null;
    }

    // Hàm tạo có đối số
    public DaGiac(int soCanh)
    {
        if (soCanh < 3)
        {
            Console.WriteLine("Một đa giác phải có ít nhất 3 cạnh. Số cạnh được đặt là 0.");
            SoCanh = 0;
            KichThuocCanh = null;
        }
        else
        {
            SoCanh = soCanh;
            KichThuocCanh = new int[soCanh];
        }
    }

    // Phương thức nhập kích thước các cạnh
    public virtual void NhapKichThuocCanh()
    {
        if (SoCanh > 0)
        {
            Console.WriteLine($"Nhập kích thước cho {SoCanh} cạnh:");
            for (int i = 0; i < SoCanh; i++)
            {
                Console.Write($"Cạnh thứ {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out KichThuocCanh[i]) || KichThuocCanh[i] <= 0)
                {
                    Console.WriteLine("Kích thước cạnh không hợp lệ. Đặt giá trị là 1.");
                    KichThuocCanh[i] = 1;
                }
            }
        }
        else
        {
            Console.WriteLine("Không thể nhập kích thước cho đa giác chưa được khởi tạo số cạnh.");
        }
    }

    // Phương thức tính chu vi
    public virtual int TinhChuVi()
    {
        if (KichThuocCanh != null)
        {
            return KichThuocCanh.Sum();
        }
        return 0;
    }

    // Phương thức in giá trị các cạnh của đa giác
    public virtual void InGiaTriCacCanh()
    {
        if (KichThuocCanh != null && SoCanh > 0)
        {
            Console.Write("Các cạnh của đa giác: ");
            for (int i = 0; i < SoCanh; i++)
            {
                Console.Write($"{KichThuocCanh[i]} ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Đa giác chưa được khởi tạo hoặc không có cạnh.");
        }
    }
}

// 2. Lớp TamGiac kế thừa từ DaGiac
public class TamGiac : DaGiac
{
    // Hàm tạo không đối số
    public TamGiac() : base(3)
    {
    }

    // Hàm tạo có đối số
    public TamGiac(int a, int b, int c) : base(3)
    {
        KichThuocCanh = new int[] { a, b, c };
        // Kiểm tra tính hợp lệ của ba cạnh tam giác (tổng hai cạnh bất kỳ phải lớn hơn cạnh còn lại)
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            Console.WriteLine("Ba cạnh không tạo thành một tam giác hợp lệ. Các cạnh được đặt là 1, 1, 1.");
            KichThuocCanh = new int[] { 1, 1, 1 };
        }
    }

    // Override phương thức nhập kích thước các cạnh
    public override void NhapKichThuocCanh()
    {
        Console.WriteLine("Nhập kích thước cho 3 cạnh của tam giác:");
        KichThuocCanh = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Cạnh thứ {i + 1}: ");
            if (!int.TryParse(Console.ReadLine(), out KichThuocCanh[i]) || KichThuocCanh[i] <= 0)
            {
                Console.WriteLine("Kích thước cạnh không hợp lệ. Đặt giá trị là 1.");
                KichThuocCanh[i] = 1;
            }
        }
        // Kiểm tra lại tính hợp lệ sau khi nhập
        if (KichThuocCanh[0] + KichThuocCanh[1] <= KichThuocCanh[2] ||
            KichThuocCanh[0] + KichThuocCanh[2] <= KichThuocCanh[1] ||
            KichThuocCanh[1] + KichThuocCanh[2] <= KichThuocCanh[0])
        {
            Console.WriteLine("Ba cạnh không tạo thành một tam giác hợp lệ. Các cạnh được đặt là 1, 1, 1.");
            KichThuocCanh = new int[] { 1, 1, 1 };
        }
    }

    // Override hàm tính chu vi
    public override int TinhChuVi()
    {
        return KichThuocCanh.Sum();
    }

    // Phương thức tính diện tích tam giác (theo công thức Heron)
    public double TinhDienTich()
    {
        double p = (double)TinhChuVi() / 2; // Nửa chu vi
        return Math.Sqrt(p * (p - KichThuocCanh[0]) * (p - KichThuocCanh[1]) * (p - KichThuocCanh[2]));
    }
}

// 3. Ứng dụng quản lý tam giác
public class QuanLyTamGiac
{
    public static void Main(string[] args)
    {
        Console.Write("Nhập số lượng tam giác cần kiểm tra: ");
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
            tamGiac.NhapKichThuocCanh();
            danhSachTamGiac.Add(tamGiac);
        }

        Console.WriteLine("\n--- Các tam giác thỏa mãn định lý Pitago ---");
        bool timThay = false;
        foreach (TamGiac tg in danhSachTamGiac)
        {
            int[] canh = tg.KichThuocCanh.OrderBy(x => x).ToArray(); // Sắp xếp cạnh để dễ kiểm tra
            if (canh[0] * canh[0] + canh[1] * canh[1] == canh[2] * canh[2])
            {
                Console.Write("Tam giác có các cạnh: ");
                tg.InGiaTriCacCanh();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không có tam giác nào thỏa mãn định lý Pitago.");
        }

        Console.ReadKey();
    }
}