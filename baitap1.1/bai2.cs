using System;

namespace RectangleAreaCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHƯƠNG TRÌNH TÍNH DIỆN TÍCH HÌNH CHỮ NHẬT");
            Console.WriteLine("=========================================");

            // Nhập chiều dài
            Console.Write("Nhập chiều dài: ");
            double length = Convert.ToDouble(Console.ReadLine());

            // Nhập chiều rộng
            Console.Write("Nhập chiều rộng: ");
            double width = Convert.ToDouble(Console.ReadLine());

            // Tính diện tích
            double area = length * width;

            // Hiển thị kết quả
            Console.WriteLine("Diện tích hình chữ nhật là: " + area);

            Console.WriteLine("=========================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}