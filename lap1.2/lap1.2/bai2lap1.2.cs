using System;
namespace LAB2
{
    class Program
    {
        // Hàm kiểm tra xem một số có phải là số nguyên tố hay không
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;
            for (int i = 5; i * i <= number; i = i + 6)
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            return true;
        }

        public static void NhapMang(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}]: ");
                a[i] = int.Parse(Console.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Khai báo biến n
            int n;
            //Nhập giá trị cho biến n
            Console.Write("Nhập n: ");
            n = int.Parse(Console.ReadLine());
            //Khai báo và khởi tạo mảng số nguyên có n phần tử
            int[] a = new int[n];
            //Gọi hàm nhập mảng
            NhapMang(a, n);
            // Hiển thị các số nguyên tố trong mảng
            Console.WriteLine("Các số nguyên tố trong mảng là:");
            for (int i = 0; i < n; i++)
            {
                if (IsPrime(a[i]))
                {
                    Console.WriteLine($"Chỉ số: {i}, Giá trị: {a[i]}");
                }
            }
        }
    }
}
