using System;

namespace LAB2
{
    class Program
    {
        // Hàm nhập mảng số thực
        public static void NhapMang(float[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}]: ");
                a[i] = float.Parse(Console.ReadLine());
            }
        }

        // Hàm sắp xếp mảng số thực theo chiều tăng dần
        public static void SapXepTangDan(float[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i] > a[j])
                    {
                        // Hoán vị a[i] và a[j]
                        float temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        // Hàm hiển thị mảng số thực
        public static void HienThiMang(float[] a, int n)
        {
            Console.Write("Mảng sau khi sắp xếp: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Khai báo biến n
            int n;
            // Nhập giá trị cho biến n
            Console.Write("Nhập n: ");
            n = int.Parse(Console.ReadLine());
            // Khai báo và khởi tạo mảng số thực có n phần tử
            float[] a = new float[n];
            // Gọi hàm nhập mảng
            NhapMang(a, n);
            // Gọi hàm sắp xếp mảng
            SapXepTangDan(a, n);
            // Gọi hàm hiển thị mảng
            HienThiMang(a, n);
        }
    }
}
