using System.Text.RegularExpressions;
namespace QuanLyCuaHang;
// Xu ly input ""
public struct ngayThang
{
    public int date, month, year;
}

public struct products
{
    public string name, factory, category;
    public int ID;
    public ngayThang manufactoringDate, expiredDate;
}
internal class program
{
    static void Main(string[] args)
    {
        products[] productsArray = new products[0];
        string[] category = new string[0];
        bool end = false;
        while (!end)
        {
            Console.WriteLine("Moi ban chon tinh nang: \n1. Quan ly loai hang\n2. Quan ly mat hang" +
            "\n3. Load test set\n4. Thoat chuong trinh\n");
            string choice_ = Console.ReadLine();
            if (String.IsNullOrEmpty(choice_) ||Regex.IsMatch(choice_,@"\D") || int.Parse(choice_) > 4 || int.Parse(choice_) < 0)
            {
                Console.WriteLine("Du lieu nhap vao khong hop le!");
                Console.WriteLine("--------------------------------------------------------");
            }
            else
            { 
                int choice = int.Parse(choice_);
              
                if (choice == 4)
                {
                    Console.WriteLine("Chao tam biet va hen gap lai!!");
                    end = true;
                }
                else if (choice == 3)
                {
                    category = LoadTestData.testCategory(ref category);
                    productsArray = LoadTestData.testProducts(ref productsArray);
                    Console.WriteLine("Data da duoc load thanh cong!!");
                    Console.WriteLine("--------------------------------------------------------");
                }
                else if (choice == 1)
                {
                    bool quanLyLoaiHang = true;
                    while (quanLyLoaiHang)
                    {
                        Console.WriteLine("Moi ban chon tinh nang quan ly loai hang:\n1. Them" +
                            "\n2. Xoa\n3. Sua\n4. Tim kiem\n5. Quay lai\n  ");
                        int categoryChoice;
                        string input = XuLyMatHang.checkValidStringInput();
                        bool validInput = int.TryParse(input, out categoryChoice);
                        if (validInput && !String.IsNullOrEmpty(input))
                        {
                            switch (categoryChoice)
                            {
                                case 1:
                                    XuLyLoaiHang.themLoaiHang(ref category);
                                    break;
                                case 2:
                                    XuLyLoaiHang.xoaLoaiHang(ref category, productsArray);
                                    break;
                                case 3:
                                    XuLyLoaiHang.suaLoaiHang(ref category);
                                    break;
                                case 4:
                                    XuLyLoaiHang.timKiemMatHang(category);
                                    break;
                                case 5:
                                    quanLyLoaiHang = false;
                                    break;
                                default:
                                    Console.WriteLine("Lua chon khong hop le, moi ban chon lai.");
                                    Console.WriteLine("--------------------------------------------------------");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lua chon khong hop le, moi ban chon lai.");
                            Console.WriteLine("--------------------------------------------------------");
                        }
                    }
                }
                else if (choice == 2)
                {
                    bool quanLyMatHang = true;
                    while (quanLyMatHang)
                    {
                        Console.WriteLine("Moi ban chon tinh nang quan ly mat hang:\n1. Them" +
                            "\n2. Xoa\n3. Sua\n4. Tim kiem\n5. Quay lai\n  ");
                        string input = XuLyMatHang.checkValidStringInput();
                        int productChoice;
                        bool validInput = int.TryParse(input, out productChoice);
                        if (validInput && !String.IsNullOrEmpty(input))
                        {
                            switch (productChoice)
                            {
                                case 1:
                                    XuLyMatHang.themMatHang(ref productsArray, category);
                                    break;
                                case 2:
                                    XuLyMatHang.xoaMatHang(ref productsArray);
                                    break;
                                case 3:
                                    XuLyMatHang.SuaMatHang(ref productsArray, category);
                                    break;
                                case 4:
                                    XuLyMatHang.timKiemMatHang(productsArray);
                                    break;
                                case 5:
                                    quanLyMatHang = false;
                                    break;
                                default:
                                    Console.WriteLine("Du lieu ban nhap vao khong hop le");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lua chon khong hop le, moi ban chon lai.");
                            Console.WriteLine("--------------------------------------------------------");
                        }
                    }
                }
            }
        }
    }
}