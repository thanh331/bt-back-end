using System;

public class SoPhuc
{
    private double phanThuc;
    private double phanAo;

    // 1. Hàm tạo không có đối số
    public SoPhuc()
    {
        phanThuc = 0;
        phanAo = 0;
    }

    // 1. Hàm tạo có đối số
    public SoPhuc(double a, double b)
    {
        phanThuc = a;
        phanAo = b;
    }

    // 2. Phương thức nhập vào một số phức
    public void NhapSoPhuc()
    {
        Console.Write("Nhập phần thực: ");
        if (double.TryParse(Console.ReadLine(), out double thuc))
        {
            phanThuc = thuc;
        }
        else
        {
            Console.WriteLine("Giá trị không hợp lệ. Phần thực được đặt là 0.");
            phanThuc = 0;
        }

        Console.Write("Nhập phần ảo: ");
        if (double.TryParse(Console.ReadLine(), out double ao))
        {
            phanAo = ao;
        }
        else
        {
            Console.WriteLine("Giá trị không hợp lệ. Phần ảo được đặt là 0.");
            phanAo = 0;
        }
    }

    // 2. Phương thức hiển thị một số phức
    public void HienThiSoPhuc()
    {
        if (phanAo >= 0)
        {
            Console.WriteLine($"{phanThuc} + {phanAo}i");
        }
        else
        {
            Console.WriteLine($"{phanThuc} - {Math.Abs(phanAo)}i");
        }
    }

    // 2. Phương thức cộng hai số phức
    public SoPhuc Cong(SoPhuc sp)
    {
        double phanThucMoi = phanThuc + sp.phanThuc;
        double phanAoMoi = phanAo + sp.phanAo;
        return new SoPhuc(phanThucMoi, phanAoMoi);
    }

    // 2. Phương thức trừ hai số phức
    public SoPhuc Tru(SoPhuc sp)
    {
        double phanThucMoi = phanThuc - sp.phanThuc;
        double phanAoMoi = phanAo - sp.phanAo;
        return new SoPhuc(phanThucMoi, phanAoMoi);
    }

    // 2. Phương thức nhân hai số phức
    public SoPhuc Nhan(SoPhuc sp)
    {
        double phanThucMoi = (phanThuc * sp.phanThuc) - (phanAo * sp.phanAo);
        double phanAoMoi = (phanThuc * sp.phanAo) + (phanAo * sp.phanThuc);
        return new SoPhuc(phanThucMoi, phanAoMoi);
    }

    // 2. Phương thức chia hai số phức
    public SoPhuc Chia(SoPhuc sp)
    {
        double mauSo = (sp.phanThuc * sp.phanThuc) + (sp.phanAo * sp.phanAo);
        if (mauSo == 0)
        {
            Console.WriteLine("Lỗi: Không thể chia cho số phức 0.");
            return null;
        }
        double phanThucMoi = ((phanThuc * sp.phanThuc) + (phanAo * sp.phanAo)) / mauSo;
        double phanAoMoi = ((sp.phanThuc * phanAo) - (phanThuc * sp.phanAo)) / mauSo;
        return new SoPhuc(phanThucMoi, phanAoMoi);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- CHƯƠNG TRÌNH TÍNH TOÁN SỐ PHỨC ---");

        SoPhuc soPhucA = new SoPhuc();
        Console.WriteLine("\nNhập số phức A:");
        soPhucA.NhapSoPhuc();

        SoPhuc soPhucB = new SoPhuc();
        Console.WriteLine("\nNhập số phức B:");
        soPhucB.NhapSoPhuc();

        int choice;
        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("a) Tính tổng hai số phức");
            Console.WriteLine("b) Tính hiệu hai số phức");
            Console.WriteLine("c) Tính tích hai số phức");
            Console.WriteLine("d) Tính thương hai số phức");
            Console.WriteLine("e) Hiển thị số phức A");
            Console.WriteLine("f) Hiển thị số phức B");
            Console.WriteLine("0) Thoát");
            Console.Write("Chọn tác vụ bạn muốn thực hiện: ");

            string input = Console.ReadLine();
            if (input != null && input.Length == 1)
            {
                choice = -1; // Giá trị mặc định nếu không phải là số để vào switch
                switch (input.ToLower())
                {
                    case "a":
                        SoPhuc tong = soPhucA.Cong(soPhucB);
                        Console.Write("Tổng hai số phức: ");
                        tong.HienThiSoPhuc();
                        break;
                    case "b":
                        SoPhuc hieu = soPhucA.Tru(soPhucB);
                        Console.Write("Hiệu hai số phức (A - B): ");
                        hieu.HienThiSoPhuc();
                        break;
                    case "c":
                        SoPhuc tich = soPhucA.Nhan(soPhucB);
                        Console.Write("Tích hai số phức: ");
                        tich.HienThiSoPhuc();
                        break;
                    case "d":
                        SoPhuc thuong = soPhucA.Chia(soPhucB);
                        if (thuong != null)
                        {
                            Console.Write("Thương hai số phức (A / B): ");
                            thuong.HienThiSoPhuc();
                        }
                        break;
                    case "e":
                        Console.Write("Số phức A: ");
                        soPhucA.HienThiSoPhuc();
                        break;
                    case "f":
                        Console.Write("Số phức B: ");
                        soPhucB.HienThiSoPhuc();
                        break;
                    case "0":
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
            else if (input == "0")
            {
                choice = 0;
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập một ký tự từ menu.");
                continue; // Tiếp tục vòng lặp nếu đầu vào không hợp lệ
            }
        } while (choice != 0);

        Console.ReadKey();
    }
}