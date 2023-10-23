using System.Xml.Serialization;
namespace QuanLyCuaHang;
public struct item
{
    public int id, namsx;
    public string ten, congtysx, loaihang, hansd;
}

public struct ngayThang
{
    public int ngay, thang, nam;
}
internal class program
{
    static void Main(string[] args)
    {
        List<item> listMatHang = new List<item>();
        List<string> listLoaiHang = new List<string>();
        bool end = false;
        while (!end)
        {
            Console.WriteLine("Moi ban chon tinh nang: \n1. Quan ly loai hang\n2. Quan ly mat hang" +
            "\n3. Thoat chuong trinh\n");
            int choice = int.Parse(Console.ReadLine());
            {
                if (choice == 3)
                {
                    Console.WriteLine("Chao tam biet va hen gap lai!!");
                    end = true;
                }
                else if (choice == 1)
                {
                    bool quanLyLoaiHan = true;
                    while (quanLyLoaiHan)
                    {
                        Console.WriteLine("Moi ban chon tinh nang quan ly loai hang:\n1. Them" +
                            "\n2. Xoa\n3. Sua\n4. Tim kiem\n5. Quay lai\n  ");
                        int categoryChoice = int.Parse(Console.ReadLine());
                        switch (categoryChoice)
                        {
                            case 1:
                                XuLyLoaiHang.themLoaiHang(listLoaiHang);
                                break;
                            case 2:
                                XuLyLoaiHang.xoaLoaiHang(listLoaiHang);
                                break;
                            case 3:
                                XuLyLoaiHang.suaLoaiHang(listLoaiHang);
                                break;
                            case 4:
                                XuLyLoaiHang.timKiemMatHang(listLoaiHang, listMatHang);
                                break;
                            case 5:
                                quanLyLoaiHan = false;
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
                        Console.WriteLine("Moi ban chon tinh nang quan ly loai hang:\n1. Them" +
                            "\n2. Xoa\n3. Sua\n4. Tim kiem\n5. Quay lai\n  ");
                        int productChoice = int.Parse(Console.ReadLine());
                        switch (productChoice) 
                        { 
                            case 1:
                                XuLyMatHang.themMatHang(listMatHang);
                                break;
                            case 2:
                                XuLyMatHang.xoaMatHang(listMatHang);
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