using System.Xml.Serialization;
namespace QuanLyCuaHang;
public struct item
{
    public int id, namsx;
    public string ten, congtysx, loaihang, hansd;
}
internal class program
{


    public static item themMatHang(List<item> listMatHang)
    {

        item new_item;
        Console.Write("Nhap ID mat hang: ");
        new_item.id = int.Parse(Console.ReadLine());
        Console.Write("Nhap ten mat hang: ");
        new_item.ten = Console.ReadLine();
        Console.Write("Nhap nam san suat: ");
        new_item.namsx = int.Parse(Console.ReadLine());
        Console.Write("Nhap han su dung: ");
        new_item.hansd = Console.ReadLine();
        Console.Write("Nhap cong ty san suat: ");
        new_item.congtysx = Console.ReadLine();
        Console.Write("Nhap loai hang: ");
        new_item.loaihang = Console.ReadLine();
        listMatHang.Add(new item());
        return new_item;

    }

 
    static void Main(string[] args)
    {
        List<item> listMatHang = new List<item>();
        List<string> listLoaiHang = new List<string>();
        while (true)
        {
            Console.WriteLine("Moi ban chon tinh nang: \n1. Quan ly loai hang\n2. Quan ly mat hang" +
            "\n3. Thoat chuong trinh\n");
            string choice = Console.ReadLine();
            {
                if (choice == "1")
                {
                    bool quanLyLoaiHan = true;
                    while (quanLyLoaiHan)
                    {
                        Console.WriteLine("Moi ban chon tinh nang quan ly loai hang:\n1. Them" +
                            "\n2. Xoa loai hang\n3. Sua\n4. Tim kiem\n5. Quay lai\n  ");
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

                        }

                    }

                }
            }
        }
    }
}