using System.Xml.Serialization;
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
            if (choice_ == string.Empty || int.Parse(choice_) < 0 || int.Parse(choice_) > 4)
            {
                Console.WriteLine("Du lieu nhap vao khong hop le!");
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
                        int categoryChoice = int.Parse(Console.ReadLine());
                        switch (categoryChoice)
                        {
                            case 1:
                                XuLyLoaiHang.themLoaiHang(ref category);
                                break;
                            case 2:
                                XuLyLoaiHang.xoaLoaiHang(ref category);
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
                                break;
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
                        int productChoice = int.Parse(Console.ReadLine());
                        switch (productChoice)
                        {
                            case 1:
                                XuLyMatHang.themMatHang(ref productsArray, category);
                                break;
                            case 2:
                                XuLyMatHang.xoaMatHang(ref productsArray);
                                break;
                            case 4:
                                XuLyMatHang.timKiemMatHang(productsArray);
                                break;
                            case 5:
                                quanLyMatHang = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}