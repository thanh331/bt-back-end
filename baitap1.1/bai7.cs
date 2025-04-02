using System;

namespace LeapYearChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHƯƠNG TRÌNH KIỂM TRA NĂM NHUẬN");
            Console.WriteLine("=================================");

            try
            {
                // Nhập năm cần kiểm tra
                Console.Write("Nhập năm cần kiểm tra: ");
                int year = Convert.ToInt32(Console.ReadLine());

                // Kiểm tra năm nhuận
                bool isLeapYear = false;

                // Năm nhuận là năm chia hết cho 4
                // Trừ các năm chia hết cho 100 nhưng không chia hết cho 400
                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                {
                    isLeapYear = true;
                }

                // Hiển thị kết quả
                if (isLeapYear)
                {
                    Console.WriteLine($"{year} là năm nhuận.");
                }
                else
                {
                    Console.WriteLine($"{year} không phải là năm nhuận.");
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

            Console.WriteLine("=================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}