using System;

public class MaTran
{
    private int soDong;
    private int soCot;
    private double[,] phanTu;

    // 1. Hàm tạo không có đối số
    public MaTran()
    {
        soDong = 0;
        soCot = 0;
        phanTu = null;
    }

    // 1. Hàm tạo có đối số
    public MaTran(int n, int m)
    {
        if (n <= 0 || m <= 0)
        {
            Console.WriteLine("Số dòng và số cột phải lớn hơn 0.");
            soDong = 0;
            soCot = 0;
            phanTu = null;
        }
        else
        {
            soDong = n;
            soCot = m;
            phanTu = new double[n, m];
        }
    }

    // 2. Phương thức nhập vào một ma trận
    public void NhapMaTran()
    {
        if (soDong <= 0 || soCot <= 0)
        {
            Console.WriteLine("Không thể nhập ma trận chưa được khởi tạo kích thước.");
            return;
        }

        Console.WriteLine($"Nhập các phần tử cho ma trận {soDong}x{soCot}:");
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                Console.Write($"Phần tử [{i},{j}]: ");
                if (!double.TryParse(Console.ReadLine(), out phanTu[i, j]))
                {
                    Console.WriteLine("Giá trị không hợp lệ. Phần tử được đặt là 0.");
                    phanTu[i, j] = 0;
                }
            }
        }
    }

    // 2. Phương thức hiển thị một ma trận
    public void HienThiMaTran()
    {
        if (soDong <= 0 || soCot <= 0 || phanTu == null)
        {
            Console.WriteLine("Ma trận chưa được khởi tạo hoặc rỗng.");
            return;
        }

        Console.WriteLine("Ma trận:");
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                Console.Write($"{phanTu[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    // 3. Phương thức tính tổng hai ma trận
    public MaTran Cong(MaTran mt)
    {
        if (soDong != mt.soDong || soCot != mt.soCot)
        {
            Console.WriteLine("Lỗi: Hai ma trận không cùng cấp, không thể cộng.");
            return null;
        }

        MaTran ketQua = new MaTran(soDong, soCot);
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                ketQua.phanTu[i, j] = phanTu[i, j] + mt.phanTu[i, j];
            }
        }
        return ketQua;
    }

    // 3. Phương thức tính hiệu hai ma trận
    public MaTran Tru(MaTran mt)
    {
        if (soDong != mt.soDong || soCot != mt.soCot)
        {
            Console.WriteLine("Lỗi: Hai ma trận không cùng cấp, không thể trừ.");
            return null;
        }

        MaTran ketQua = new MaTran(soDong, soCot);
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                ketQua.phanTu[i, j] = phanTu[i, j] - mt.phanTu[i, j];
            }
        }
        return ketQua;
    }

    // 3. Phương thức tính tích hai ma trận
    public MaTran Nhan(MaTran mt)
    {
        if (soCot != mt.soDong)
        {
            Console.WriteLine($"Lỗi: Số cột của ma trận thứ nhất ({soCot}) phải bằng số dòng của ma trận thứ hai ({mt.soDong}) để thực hiện phép nhân.");
            return null;
        }

        MaTran ketQua = new MaTran(soDong, mt.soCot);
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < mt.soCot; j++)
            {
                ketQua.phanTu[i, j] = 0;
                for (int k = 0; k < soCot; k++)
                {
                    ketQua.phanTu[i, j] += phanTu[i, k] * mt.phanTu[k, j];
                }
            }
        }
        return ketQua;
    }

    // 3. Phương thức tính thương hai ma trận (chỉ định nghĩa khi ma trận thứ hai là ma trận vuông khả nghịch)
    // Để đơn giản, chúng ta sẽ không triển khai phép chia ma trận ở đây.
    // Phép chia ma trận thực chất là nhân với ma trận nghịch đảo, một khái niệm phức tạp hơn.
    public MaTran Chia(MaTran mt)
    {
        Console.WriteLine("Lưu ý: Phép chia ma trận không được định nghĩa trực tiếp. Bạn có thể nhân với ma trận nghịch đảo (nếu có).");
        return null;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- CHƯƠNG TRÌNH TÍNH TOÁN MA TRẬN ---");

        Console.Write("Nhập số dòng cho ma trận A: ");
        if (!int.TryParse(Console.ReadLine(), out int rowsA) || rowsA <= 0)
        {
            Console.WriteLine("Số dòng không hợp lệ.");
            return;
        }
        Console.Write("Nhập số cột cho ma trận A: ");
        if (!int.TryParse(Console.ReadLine(), out int colsA) || colsA <= 0)
        {
            Console.WriteLine("Số cột không hợp lệ.");
            return;
        }
        MaTran maTranA = new MaTran(rowsA, colsA);
        Console.WriteLine("\nNhập ma trận A:");
        maTranA.NhapMaTran();

        Console.Write("\nNhập số dòng cho ma trận B: ");
        if (!int.TryParse(Console.ReadLine(), out int rowsB) || rowsB <= 0)
        {
            Console.WriteLine("Số dòng không hợp lệ.");
            return;
        }
        Console.Write("Nhập số cột cho ma trận B: ");
        if (!int.TryParse(Console.ReadLine(), out int colsB) || colsB <= 0)
        {
            Console.WriteLine("Số cột không hợp lệ.");
            return;
        }
        MaTran maTranB = new MaTran(rowsB, colsB);
        Console.WriteLine("\nNhập ma trận B:");
        maTranB.NhapMaTran();

        if (maTranA.soDong != maTranB.soDong || maTranA.soCot != maTranB.soCot)
        {
            Console.WriteLine("\nLưu ý: Chỉ có thể thực hiện phép cộng và trừ trên hai ma trận cùng cấp.");
        }
        if (maTranA.soCot != maTranB.soDong)
        {
            Console.WriteLine("\nLưu ý: Chỉ có thể thực hiện phép nhân khi số cột của ma trận A bằng số dòng của ma trận B.");
        }

        int choice;
        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Tính tổng hai ma trận");
            Console.WriteLine("2. Tính tích hai ma trận");
            Console.WriteLine("3. Tính hiệu hai ma trận");
            Console.WriteLine("4. Tính thương hai ma trận");
            Console.WriteLine("5. Hiển thị ma trận A");
            Console.WriteLine("6. Hiển thị ma trận B");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn tác vụ bạn muốn thực hiện: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        if (maTranA.soDong == maTranB.soDong && maTranA.soCot == maTranB.soCot)
                        {
                            MaTran tong = maTranA.Cong(maTranB);
                            Console.WriteLine("\nTổng hai ma trận:");
                            tong?.HienThiMaTran();
                        }
                        else
                        {
                            Console.WriteLine("Không thể tính tổng vì hai ma trận không cùng cấp.");
                        }
                        break;
                    case 2:
                        if (maTranA.soCot == maTranB.soDong)
                        {
                            MaTran tich = maTranA.Nhan(maTranB);
                            Console.WriteLine("\nTích hai ma trận:");
                            tich?.HienThiMaTran();
                        }
                        else
                        {
                            Console.WriteLine("Không thể tính tích vì số cột của ma trận A không bằng số dòng của ma trận B.");
                        }
                        break;
                    case 3:
                        if (maTranA.soDong == maTranB.soDong && maTranA.soCot == maTranB.soCot)
                        {
                            MaTran hieu = maTranA.Tru(maTranB);
                            Console.WriteLine("\nHiệu hai ma trận (A - B):");
                            hieu?.HienThiMaTran();
                        }
                        else
                        {
                            Console.WriteLine("Không thể tính hiệu vì hai ma trận không cùng cấp.");
                        }
                        break;
                    case 4:
                        MaTran thuong = maTranA.Chia(maTranB);
                        break;
                    case 5:
                        Console.WriteLine("\nMa trận A:");
                        maTranA.HienThiMaTran();
                        break;
                    case 6:
                        Console.WriteLine("\nMa trận B:");
                        maTranB.HienThiMaTran();
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