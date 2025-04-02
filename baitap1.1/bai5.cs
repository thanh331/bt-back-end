using System;

namespace SumProductCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHƯƠNG TRÌNH TÍNH TỔNG VÀ TÍCH CỦA HAI SỐ");
            Console.WriteLine("==========================================");

            try
            {
                // Nhập số thứ nhất
                Console.Write("Nhập số thứ nhất: ");
                double firstNumber = Convert.ToDouble(Console.ReadLine());

                // Nhập số thứ hai
                Console.Write("Nhập số thứ hai: ");
                double secondNumber = Convert.ToDouble(Console.ReadLine());

                // Tính tổng
                double sum = firstNumber + secondNumber;

                // Tính tích
                double product = firstNumber * secondNumber;

                // Hiển thị kết quả
                Console.WriteLine("==========================================");
                Console.WriteLine($"Tổng của {firstNumber} và {secondNumber} là: {sum}");
                Console.WriteLine($"Tích của {firstNumber} và {secondNumber} là: {product}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Lỗi: Vui lòng nhập số hợp lệ.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }

            Console.WriteLine("==========================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}