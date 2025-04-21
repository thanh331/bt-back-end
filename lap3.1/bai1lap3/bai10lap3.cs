using System;
using System.Text.RegularExpressions;

public class VanBan
{
    private string noiDung;

    // 1. Hàm tạo không có đối số
    public VanBan()
    {
        noiDung = "";
    }

    // 1. Hàm tạo có đối số
    public VanBan(string st)
    {
        noiDung = st;
    }

    // 2. Phương thức đếm số từ của một xâu
    public int DemSoTu()
    {
        if (string.IsNullOrWhiteSpace(noiDung))
        {
            return 0;
        }
        string[] cacTu = noiDung.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return cacTu.Length;
    }

    // 3. Phương thức đếm số ký tự H (không phân biệt chữ thường, chữ hoa) của xâu
    public int DemKyTuH()
    {
        int count = 0;
        foreach (char c in noiDung)
        {
            if (char.ToUpper(c) == 'H')
            {
                count++;
            }
        }
        return count;
    }

    // 4. Chuẩn hoá một xâu theo tiêu chuẩn
    public string ChuanHoa()
    {
        // Loại bỏ khoảng trắng ở đầu và cuối xâu
        string chuanHoa = noiDung.Trim();

        // Loại bỏ khoảng trắng thừa ở giữa xâu
        chuanHoa = Regex.Replace(chuanHoa, @"\s+", " ");

        return chuanHoa;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- CHƯƠNG TRÌNH XỬ LÝ VĂN BẢN ---");
        Console.Write("Nhập vào một đoạn văn bản: ");
        string input = Console.ReadLine();

        VanBan vanBan = new VanBan(input);

        int choice;
        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Đếm số từ");
            Console.WriteLine("2. Đếm số ký tự 'H'");
            Console.WriteLine("3. Chuẩn hóa xâu");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn công việc bạn muốn thực hiện: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Số từ trong văn bản là: {vanBan.DemSoTu()}");
                        break;
                    case 2:
                        Console.WriteLine($"Số ký tự 'H' (không phân biệt hoa thường) trong văn bản là: {vanBan.DemKyTuH()}");
                        break;
                    case 3:
                        Console.WriteLine($"Xâu sau khi chuẩn hóa là: \"{vanBan.ChuanHoa()}\"");
                        break;
                    case 0:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Vui lòng nhập một số hợp lệ từ menu.");
            }
        } while (choice != 0);

        Console.ReadKey();
    }
}