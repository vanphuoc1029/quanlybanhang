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
            string new_item = XuLyMatHang.checkValidStringInput();
            listLoaiHang = XuLyArray.appendArray(listLoaiHang, new_item);
            Console.WriteLine("Them thanh cong!!");
            Console.WriteLine("-----------------------------------");

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
                Console.WriteLine("Du lieu ban nhap vao khong hop le!");
                Console.WriteLine("-----------------------------------");
                return false;
            }
            return true;
        }
        public static void xoaLoaiHang(ref string[] listLoaiHang, products[] productsArray)
        {
            bool nullList = kiemTraListTrong(listLoaiHang);

            if (!nullList)
            {
                Console.WriteLine("Chon so thu tu loai hang ban muon xoa");
                inList(listLoaiHang);
                int choice = XuLyMatHang.checkValidNumberInput();
                bool validChoice = checkValidChoice(choice, listLoaiHang);
                if (validChoice)
                {
                    bool productsRemain = false;
                    foreach (products product in productsArray)
                    {
                        if (product.category == listLoaiHang[choice])
                        {
                            productsRemain = true;
                            break;
                        }
                    }
                    if (productsRemain)
                    {
                        Console.WriteLine("Hien tai van con mat hang thuoc loai hang nay trong danh sach. Vui long xoa het mat hang thuoc loai hang nay truoc khi xoa loai hang nay !");
                        Console.WriteLine("-----------------------------------");
                    }
                    else
                    {
                        listLoaiHang = XuLyArray.removeElement(listLoaiHang, choice);
                        Console.WriteLine("Xoa thanh cong!!");
                        Console.WriteLine("-----------------------------------");
                    }
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
                int choice = XuLyMatHang.checkValidNumberInput();
                bool validChoice = checkValidChoice(choice, listLoaiHang);
                if (validChoice)
                {
                    Console.Write("Nhap ten loai hang moi: ");
                    listLoaiHang[choice] = XuLyMatHang.checkValidStringInput();
                    Console.WriteLine("Thay the thanh cong!!");
                    Console.WriteLine("-----------------------------------");
                }
            }
        }

        public static void timKiemMatHang(string[] listLoaiHang)
        {
            bool nullList = kiemTraListTrong(listLoaiHang);
            if (!nullList)
            {
                Console.WriteLine("Nhap thong tin loai hang ban muon tim: ");
                string search = XuLyMatHang.checkValidStringInput();
                string[] resultArray = new string[0]; 
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
                if (resultArray.Length == 0) { Console.WriteLine("Hien tai khong co mat hang nao phu hop voi tu khoa"); Console.WriteLine("-----------------------------------"); }
                else
                {
                    Console.WriteLine("Cac loai hang sau phu hop voi tu khoa cua ban: ");
                    foreach (string product in resultArray) { Console.WriteLine(product); }
                    Console.WriteLine("-----------------------------------");
                }
            }
        }

    }
}
