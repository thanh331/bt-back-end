
            
// Yêu cầu người dùng nhập tên
            Console.Write("Vui lòng nhập tên của bạn: ");
            string ten = Console.ReadLine();

            // Yêu cầu người dùng nhập tuổi
            Console.Write("Vui lòng nhập tuổi của bạn: ");
            int tuoi = Convert.ToInt32(Console.ReadLine());

            // In ra thông báo
            Console.WriteLine("Xin chào " + ten + ", bạn " + tuoi + " tuổi!");

            // Chờ người dùng nhấn phím bất kỳ trước khi đóng cửa sổ console
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        