using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class XuLyLoaiHang
    {
        public static void themLoaiHang(List<string> listLoaiHang)
        {
            Console.WriteLine("Nhap ten loai hang: ");
            listLoaiHang.Add(Console.ReadLine());

        }

        public static bool kiemTraListTrong(List<string> listLoaiHang)
        {
            if (listLoaiHang.Count == 0)
            {
                Console.WriteLine("Hien danh sach loai hang dang trong");
                return true;
            }
            return false;
        }

        public static void inList(List<string> listLoaiHang)
        {   
            int i = 0;
            foreach (string item in listLoaiHang)
            {
                Console.WriteLine($"{i}. {item}");
                
                i++;
            }
            Console.WriteLine("\n");
        }

        public static bool checkValidChoice(int choice, List<string> listLoaiHang)
        {
            if (choice < 0 || choice > (listLoaiHang.Count - 1)) 
            {
                Console.WriteLine("So thu tu khong hop le");
                return false;
            }
            return true;
        }
        public static void xoaLoaiHang(List<string> listLoaiHang)
        {
            bool nullList = kiemTraListTrong(listLoaiHang);

            if (!nullList)
            {
                Console.WriteLine("Chon so thu tu loai hang ban muon xoa");
                int i = 1;
                inList(listLoaiHang);
                int choice = int.Parse(Console.ReadLine());
                bool validChoice = checkValidChoice(choice, listLoaiHang);
                if (validChoice)
                {
                    listLoaiHang.RemoveAt(choice);
                }
                
            }
        }

        public static void suaLoaiHang(List<string> listLoaiHang)
        {
            bool nullList = kiemTraListTrong(listLoaiHang);
            if (!nullList)
            {
                Console.WriteLine("Moi ban chon so thu tu muon sua: ");
                int i = 1;
                inList(listLoaiHang);
                int choice = int.Parse(Console.ReadLine());
                bool validChoice = checkValidChoice(choice, listLoaiHang);
                if (validChoice)
                {
                    Console.Write("Nhap noi dung thay the: ");
                    listLoaiHang[choice] = Console.ReadLine();
                }

            }
        }

        public static void timKiemMatHang(List<string> listLoaiHang, List<item> listMatHang)
        {
            bool nullList = kiemTraListTrong(listLoaiHang);
            if (!nullList)
            {
                Console.WriteLine("Ban muon tim kiem loai hang nao?");
                inList(listLoaiHang);
                string tenMatHang = Console.ReadLine();
                bool checkMatHang = false;
                foreach(item item in listMatHang) 
                {
                    if (item.loaihang == tenMatHang) 
                    {   
                        checkMatHang = true;
                        Console.WriteLine("Loai hang nay bao gom cac mat hang sau: ");
                        Console.WriteLine(item.ten);
                    }
                    if (!checkMatHang)
                    {
                        Console.WriteLine("Hien khong co mat hang nay thuoc loai hang nay!");
                    }
                }
            }
        }

    }
}
