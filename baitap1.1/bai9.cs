using System;
using System.Numerics;

namespace FactorialCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHƯƠNG TRÌNH TÍNH GIAI THỪA");
            Console.WriteLine("===========================");

            try
            {
                // Nhập số nguyên dương n
                Console.Write("Nhập một số nguyên dương n: ");
                int n = Convert.ToInt32(Console.ReadLine());

                // Kiểm tra số nguyên dương
                if (n < 0)
                {
                    Console.WriteLine("Lỗi: Vui lòng nhập số nguyên dương.");
                    return;
                }

                // Tính giai thừa
                BigInteger factorial = CalculateFactorial(n);

                // Hiển thị kết quả
                Console.WriteLine($"{n}! = {factorial}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Lỗi: Số quá lớn, không thể xử lý.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }

            Console.WriteLine("===========================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        // Phương thức tính giai thừa
        static BigInteger CalculateFactorial(int n)
        {
            // Giai thừa của 0 và 1 đều bằng 1
            if (n == 0 || n == 1)
                return 1;

            // Tính giai thừa cho số lớn hơn 1
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}