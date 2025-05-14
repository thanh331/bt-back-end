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

        public static void DemAmDuong(int[] a, int n, out int demAm, out int demDuong)
        {
            demAm = 0;
            demDuong = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < 0)
                {
                    demAm++;
                }
                else if (a[i] > 0)
                {
                    demDuong++;
                }
                // Trường hợp a[i] == 0 không cần xử lý, không tăng biến đếm nào
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
            //Khai báo biến đếm số âm và số dương
            int demAm, demDuong;
            //Gọi hàm đếm số âm và số dương
            DemAmDuong(a, n, out demAm, out demDuong);
            //Hiển thị kết quả
            Console.WriteLine($"Số lượng số âm là: {demAm}");
            Console.WriteLine($"Số lượng số dương là: {demDuong}");
        }
    }
}
