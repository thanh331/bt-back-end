using System;

namespace EvenNumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHƯƠNG TRÌNH KIỂM TRA SỐ CHẴN");
            Console.WriteLine("===============================");

            // Nhập số nguyên
            Console.Write("Nhập một số nguyên: ");
            int number;

            // Kiểm tra đầu vào hợp lệ
            if (int.TryParse(Console.ReadLine(), out number))
            {
                // Kiểm tra số chẵn
                if (number % 2 == 0)
                {
                    Console.WriteLine($"{number} là số chẵn.");
                }
                else
                {
                    Console.WriteLine($"{number} là số lẻ.");
                }
            }
            else
            {
                Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập một số nguyên.");
            }

            Console.WriteLine("===============================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}