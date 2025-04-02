using System;

namespace PrimeNumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHƯƠNG TRÌNH KIỂM TRA SỐ NGUYÊN TỐ");
            Console.WriteLine("====================================");

            try
            {
                // Nhập số cần kiểm tra
                Console.Write("Nhập một số nguyên dương: ");
                int number = Convert.ToInt32(Console.ReadLine());

                // Kiểm tra số hợp lệ
                if (number < 1)
                {
                    Console.WriteLine("Vui lòng nhập số nguyên dương lớn hơn hoặc bằng 1.");
                    return;
                }

                // Kiểm tra số nguyên tố
                bool isPrime = IsPrime(number);

                // Hiển thị kết quả
                if (isPrime)
                {
                    Console.WriteLine($"{number} là số nguyên tố.");
                }
                else
                {
                    Console.WriteLine($"{number} không phải là số nguyên tố.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }

            Console.WriteLine("====================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        // Phương thức kiểm tra số nguyên tố
        static bool IsPrime(int number)
        {
            // Theo định nghĩa, 1 không phải là số nguyên tố
            if (number <= 1)
                return false;

            // 2 và 3 là số nguyên tố
            if (number <= 3)
                return true;

            // Kiểm tra nhanh: nếu số chia hết cho 2 hoặc 3 thì không phải số nguyên tố
            if (number % 2 == 0 || number % 3 == 0)
                return false;

            // Kiểm tra các số từ 5 đến căn bậc hai của number
            // Chỉ cần kiểm tra các số có dạng 6k ± 1
            int i = 5;
            while (i * i <= number)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
                i += 6;
            }

            return true;
        }
    }
}