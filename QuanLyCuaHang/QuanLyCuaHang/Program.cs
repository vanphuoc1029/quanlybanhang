public struct item
{
    public int id, namsx;
    public string ten, congtysx, loaihang, hansd;
}
internal class program
{
 

    public static item themSanPham() 
    {
        item new_item;
        Console.Write("Nhap ID san pham: ");
        new_item.id = int.Parse(Console.ReadLine());
        Console.Write("Nhap ten san pham: ");
        new_item.ten = Console.ReadLine();
        Console.Write("Nhap nam san suat: ");
        new_item.namsx = int.Parse(Console.ReadLine());
        Console.Write("Nhap han su dung: ");
        new_item.hansd = Console.ReadLine();
        Console.Write("Nhap cong ty san suat: ");
        new_item.congtysx = Console.ReadLine();
        Console.Write("Nhap loai hang: ");
        new_item.loaihang = Console.ReadLine();
        return new_item;

    }

    static void Main (string[] args)
    {
        item sanphama = themSanPham();
    }
}