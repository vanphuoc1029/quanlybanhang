using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class XuLyLoaiHang
    {
        public static void themLoaiHang(ref string[] listLoaiHang)
        {
            Console.WriteLine("Nhap ten loai hang: ");
            string new_item = Console.ReadLine();
            listLoaiHang = XuLyArray.appendArray(listLoaiHang, new_item);
        }

        public static bool kiemTraListTrong(string[] listLoaiHang)
        {
            if (listLoaiHang.Length == 0)
            {
                Console.WriteLine("Hien danh sach loai hang dang trong");
                return true;
            }
            return false;
        }

        public static void inList(string[] listLoaiHang)
        {   
            int i = 0;
            foreach (string item in listLoaiHang)
            {
                if (item != "")
                {
                    Console.WriteLine($"{i}. {item}");

                    i++;
                }
            }
            Console.WriteLine("\n");
        }

        public static bool checkValidChoice(int choice, string[] listLoaiHang)
        {
            if (choice < 0 || choice > (listLoaiHang.Length - 1)) 
            {
                Console.WriteLine("So thu tu khong hop le");
                return false;
            }
            return true;
        }
        public static void xoaLoaiHang(ref string[] listLoaiHang)
        {
            bool nullList = kiemTraListTrong(listLoaiHang);

            if (!nullList)
            {
                Console.WriteLine("Chon so thu tu loai hang ban muon xoa");
                inList(listLoaiHang);
                int choice = int.Parse(Console.ReadLine());
                bool validChoice = checkValidChoice(choice, listLoaiHang);
                if (validChoice)
                {
                    listLoaiHang = XuLyArray.removeElement(listLoaiHang, choice);
                }
                
            }
        }

        public static void suaLoaiHang( ref string[] listLoaiHang)
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

        public static void timKiemMatHang(string[] listLoaiHang)
        {
            bool nullList = kiemTraListTrong(listLoaiHang);
            if (!nullList)
            {
                Console.WriteLine("Nhap thong tin loai hang ban muon tim: ");
                string search = Console.ReadLine();
                string[] resultArray = new string[1]; 
                foreach (string loaiHang in listLoaiHang)
                {
                    if (search.Length > loaiHang.Length) { continue; }
                    for (int index = 0; index <= loaiHang.Length - search.Length; index++)
                    {
                        if (loaiHang[index] == search[0])
                        {
                            if (loaiHang.Substring(index, search.Length) == search)
                            {
                                resultArray = XuLyArray.appendArray(resultArray, loaiHang); 
                            }
                        }
                    }
                }
                if (resultArray.Length < 0) { Console.WriteLine("Hien tai khong co mat hang nao phu hop voi tu khoa"); }
                else
                {
                    Console.WriteLine("Cac mat hang sau phu hop voi tu khoa cua ban: ");
                    foreach (string product in resultArray) { Console.WriteLine(product); }
                }
            }
        }

    }
}
