using System;

namespace TemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHƯƠNG TRÌNH CHUYỂN ĐỔI NHIỆT ĐỘ TỪ ĐỘ C SANG ĐỘ F");
            Console.WriteLine("====================================================");

            // Nhập nhiệt độ C
            Console.Write("Nhập nhiệt độ (độ C): ");
            double celsius = Convert.ToDouble(Console.ReadLine());

            // Chuyển đổi từ độ C sang độ F theo công thức: F = (C * 9/5) + 32
            double fahrenheit = (celsius * 9 / 5) + 32;

            // Hiển thị kết quả
            Console.WriteLine($"{celsius}°C = {fahrenheit}°F");

            Console.WriteLine("====================================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}