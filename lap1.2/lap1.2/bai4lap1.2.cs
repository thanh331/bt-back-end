using System;

namespace LAB2
{
    class Program
    {
        public static void NhapMang(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}]: ");
                a[i] = int.Parse(Console.ReadLine());
            }
        }

        public static int TimSoLonThuHai(int[] a, int n)
        {
            if (n < 2)
            {
                Console.WriteLine("Mảng không đủ phần tử.");
                return int.MinValue; // Trả về giá trị nhỏ nhất có thể của int
            }

            int lonNhat = int.MinValue;
            int lonThuHai = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (a[i] > lonNhat)
                {
                    lonThuHai = lonNhat;
                    lonNhat = a[i];
                }
                else if (a[i] > lonThuHai && a[i] != lonNhat)
                {
                    lonThuHai = a[i];
                }
            }

            if (lonThuHai == int.MinValue)
            {
                Console.WriteLine("Không có số lớn thứ hai phân biệt.");
                return int.MinValue;
            }

            return lonThuHai;
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
            //Tìm số lớn thứ hai
            int soLonThuHai = TimSoLonThuHai(a, n);
            //Hiển thị kết quả
            if (soLonThuHai != int.MinValue)
            {
                Console.WriteLine($"Số lớn thứ hai trong mảng là: {soLonThuHai}");
            }
        }
    }
}
