using System;

namespace LAB2
{
    class Program
    {
        // Hàm hoán vị hai số nguyên
        public static void HoanVi(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Khai báo biến
            int a, b;
            // Nhập giá trị cho a và b
            Console.Write("Nhập số nguyên a: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Nhập số nguyên b: ");
            b = int.Parse(Console.ReadLine());
            // In giá trị trước khi hoán vị
            Console.WriteLine($"Trước khi hoán vị: a = {a}, b = {b}");
            // Gọi hàm hoán vị
            HoanVi(ref a, ref b);
            // In giá trị sau khi hoán vị
            Console.WriteLine($"Sau khi hoán vị: a = {a}, b = {b}");
        }
    }
}
