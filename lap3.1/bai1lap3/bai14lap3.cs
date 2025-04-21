using System;

public class PhanSo
{
    private int tuSo;
    private int mauSo;

    // 1. Toán tử tạo lập không đối số
    public PhanSo()
    {
        tuSo = 0;
        mauSo = 1; // Mẫu số mặc định là 1
    }

    // 1. Toán tử tạo lập có đối số
    public PhanSo(int tu, int mau)
    {
        tuSo = tu;
        if (mau == 0)
        {
            Console.WriteLine("Lỗi: Mẫu số không thể bằng 0. Mẫu số được đặt là 1.");
            mauSo = 1;
        }
        else
        {
            mauSo = mau;
        }
    }

    // 2. Phương thức nhập vào một phân số
    public void NhapPhanSo()
    {
        Console.Write("Nhập tử số: ");
        if (!int.TryParse(Console.ReadLine(), out tuSo))
        {
            Console.WriteLine("Giá trị không hợp lệ. Tử số được đặt là 0.");
            tuSo = 0;
        }

        Console.Write("Nhập mẫu số: ");
        if (!int.TryParse(Console.ReadLine(), out mauSo))
        {
            Console.WriteLine("Giá trị không hợp lệ. Mẫu số được đặt là 1.");
            mauSo = 1;
        }
        else if (mauSo == 0)
        {
            Console.WriteLine("Lỗi: Mẫu số không thể bằng 0. Mẫu số được đặt là 1.");
            mauSo = 1;
        }
    }

    // 2. Phương thức hiển thị một phân số
    public void HienThiPhanSo()
    {
        Console.WriteLine($"{tuSo}/{mauSo}");
    }

    // Phương thức tìm ước chung lớn nhất (UCLN)
    private int UCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // 2. Phương thức rút gọn một phân số
    public void RutGonPhanSo()
    {
        int ucln = UCLN(tuSo, mauSo);
        tuSo /= ucln;
        mauSo /= ucln;

        // Đảm bảo mẫu số luôn dương
        if (mauSo < 0)
        {
            tuSo = -tuSo;
            mauSo = -mauSo;
        }
    }

    // 2. Phương thức cộng hai phân số
    public PhanSo Cong(PhanSo ps)
    {
        int tuSoMoi = (tuSo * ps.mauSo) + (ps.tuSo * mauSo);
        int mauSoMoi = mauSo * ps.mauSo;
        PhanSo ketQua = new PhanSo(tuSoMoi, mauSoMoi);
        ketQua.RutGonPhanSo();
        return ketQua;
    }

    // 2. Phương thức trừ hai phân số
    public PhanSo Tru(PhanSo ps)
    {
        int tuSoMoi = (tuSo * ps.mauSo) - (ps.tuSo * mauSo);
        int mauSoMoi = mauSo * ps.mauSo;
        PhanSo ketQua = new PhanSo(tuSoMoi, mauSoMoi);
        ketQua.RutGonPhanSo();
        return ketQua;
    }

    // 2. Phương thức nhân hai phân số
    public PhanSo Nhan(PhanSo ps)
    {
        int tuSoMoi = tuSo * ps.tuSo;
        int mauSoMoi = mauSo * ps.mauSo;
        PhanSo ketQua = new PhanSo(tuSoMoi, mauSoMoi);
        ketQua.RutGonPhanSo();
        return ketQua;
    }

    // 2. Phương thức chia hai phân số
    public PhanSo Chia(PhanSo ps)
    {
        if (ps.tuSo == 0)
        {
            Console.WriteLine("Lỗi: Không thể chia cho phân số có tử số bằng 0.");
            return null;
        }
        int tuSoMoi = tuSo * ps.mauSo;
        int mauSoMoi = mauSo * ps.tuSo;
        PhanSo ketQua = new PhanSo(tuSoMoi, mauSoMoi);
        ketQua.RutGonPhanSo();
        return ketQua;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- CHƯƠNG TRÌNH TÍNH TOÁN PHÂN SỐ ---");

        PhanSo phanSoA = new PhanSo();
        Console.WriteLine("\nNhập phân số A:");
        phanSoA.NhapPhanSo();
        phanSoA.RutGonPhanSo();
        Console.Write("Phân số A sau khi rút gọn: ");
        phanSoA.HienThiPhanSo();

        PhanSo phanSoB = new PhanSo();
        Console.WriteLine("\nNhập phân số B:");
        phanSoB.NhapPhanSo();
        phanSoB.RutGonPhanSo();
        Console.Write("Phân số B sau khi rút gọn: ");
        phanSoB.HienThiPhanSo();

        int choice;
        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Cộng hai phân số");
            Console.WriteLine("2. Trừ hai phân số (A - B)");
            Console.WriteLine("3. Nhân hai phân số");
            Console.WriteLine("4. Chia hai phân số (A / B)");
            Console.WriteLine("5. Hiển thị phân số A");
            Console.WriteLine("6. Hiển thị phân số B");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn phép toán bạn muốn thực hiện: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        PhanSo tong = phanSoA.Cong(phanSoB);
                        Console.Write("Tổng hai phân số: ");
                        tong.HienThiPhanSo();
                        break;
                    case 2:
                        PhanSo hieu = phanSoA.Tru(phanSoB);
                        Console.Write("Hiệu hai phân số (A - B): ");
                        hieu.HienThiPhanSo();
                        break;
                    case 3:
                        PhanSo tich = phanSoA.Nhan(phanSoB);
                        Console.Write("Tích hai phân số: ");
                        tich.HienThiPhanSo();
                        break;
                    case 4:
                        PhanSo thuong = phanSoA.Chia(phanSoB);
                        if (thuong != null)
                        {
                            Console.Write("Thương hai phân số (A / B): ");
                            thuong.HienThiPhanSo();
                        }
                        break;
                    case 5:
                        Console.Write("Phân số A: ");
                        phanSoA.HienThiPhanSo();
                        break;
                    case 6:
                        Console.Write("Phân số B: ");
                        phanSoB.HienThiPhanSo();
                        break;
                    case 0:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Vui lòng nhập một số hợp lệ từ menu.");
            }
        } while (choice != 0);

        Console.ReadKey();
    }
}