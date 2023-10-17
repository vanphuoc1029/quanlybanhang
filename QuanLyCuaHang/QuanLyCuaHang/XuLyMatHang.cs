using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class XuLyMatHang
    {
        public void checkValidInput<T>(T input)
        {
            if (input == null)
            {
                Console.WriteLine("Ban khong duoc bo trong, vui long nhap lai");
            }

        }

        public static bool kiemTraListTrong(List<item> listMatHang)
        {
            if (listMatHang.Count == 0)
            {
                Console.WriteLine("Hien danh sach mat hang dang trong");
                return true;
            }
            return false;
        }


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
        public static void xoaMatHang(List<item> listMatHang)
        {
            bool isNull = kiemTraListTrong(listMatHang);
            if (!isNull)
            {
                Console.WriteLine("Lua chon id ban muon xoa.");
                foreach (item i in listMatHang)
                {
                    Console.WriteLine($"ID: {i.id}, Ten mat hang: {i.ten}");
                }
                int choice = int.Parse(Console.ReadLine());
                foreach (item i in listMatHang)
                {
                    if (choice == i.id)
                    {
                        Console.WriteLine("Xoa mat hang thanh cong");
                        listMatHang.Remove(i);
                    }
                    else
                    {
                        Console.WriteLine("Khong ton tai ID mat hang nay");
                    }
                }
            }
        }
    }
}