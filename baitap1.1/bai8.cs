using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BẢNG CỬU CHƯƠNG TỪ 1 ĐẾN 10");
            Console.WriteLine("============================");

            // In bảng cửu chương từ 1 đến 10
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"\nBẢNG CỬU CHƯƠNG {i}:");
                Console.WriteLine("--------------------");

                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} x {j} = {i * j}");
                }
            }

            Console.WriteLine("\n============================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}