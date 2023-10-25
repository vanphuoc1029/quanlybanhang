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
        public static bool kiemTraListTrong(string[] productsName)
        {
            foreach (string name in productsName)
            {
                if (name != null) { return false; }
            }
            return true;
        }


        public static void themMatHang(int[] id, string[] ten, ngayThang[] ngaySX, ngayThang[] hanSD, string[] congTySX, string[] loaiHang, string[] listLoaiHang)
        {
            if (XuLyLoaiHang.kiemTraListTrong(listLoaiHang))
                { Console.WriteLine("Hien tai danh sach loai hang dang trong. Vui long bo sung danh sach truoc khi them san pham."); }
            else
            {
                Console.Write("Nhap ID mat hang: ");
                XuLyArray.appendArray(id, int.Parse(Console.ReadLine()));
                Console.Write("Nhap ten mat hang: ");
                XuLyArray.appendArray(ten, Console.ReadLine());
                bool valid_input = false;
                while (!valid_input)
                {
                    Console.Write("Nhap ngay san suat (dinh dang dd/mm/yyyy): ");
                    string ngaysx_input = Console.ReadLine();
                    if (XuLyNgayThang.checkValidDay(ngaysx_input))
                    {
                        XuLyArray.appendArray(ngaySX, ngaysx_input);
                        valid_input = true;
                    }
                    else
                    {
                        Console.WriteLine("Ban nhap sai dinh dang ngay thang, vui long nhap lai");
                    }
                }
                valid_input = false;
                while (!valid_input)
                {
                    Console.Write("Nhap han su dung (dinh dang dd/mm/yyyy): ");
                    string hansd_input = Console.ReadLine();
                    if (XuLyNgayThang.checkValidDay(hansd_input))
                    {
                        XuLyArray.appendArray(hanSD, hansd_input);
                        valid_input = true;
                    }
                    else
                    {
                        Console.WriteLine("Ban nhap sai dinh dang ngay thang, vui long nhap lai");
                    }
                }
                Console.Write("Nhap cong ty san suat: ");
                XuLyArray.appendArray(congTySX, Console.ReadLine());
                Console.Write("Mat hang nay thuoc loai hang nao? ");
                XuLyLoaiHang.inList(listLoaiHang);
                string input = Console.ReadLine();
                valid_input=false;
                while (!valid_input)
                {
                    foreach(string cat in listLoaiHang)
                    { 
                        if (cat == input)
                            {   
                                valid_input = true;
                                XuLyArray.appendArray(loaiHang, input);
                                break; 
                            }
                    }
                    if (!valid_input)
                    { Console.WriteLine("Khong co loai hang nay trong danh sach, vui long nhap lai!"); }
                }
            }
        }
        public static void xoaMatHang(int[] id, string[] ten, ngayThang[] ngaySX, ngayThang[] hanSD, string[] congTySX, string[] loaiHang)
        {
            bool isNull = kiemTraListTrong(ten);
            if (!isNull)
            {
                Console.WriteLine("Lua chon so thu tu ban muon xoa.");
                for (int i = 0; i < ten.Length; i++)
                {
                    Console.WriteLine($"{i}. {ten[i]}");
                }
                int choice = int.Parse(Console.ReadLine());
                if ( choice > -1 && choice < ten.Length)
                {
                    XuLyArray.removeElement(id, choice);
                    XuLyArray.removeElement(ten, choice);
                    XuLyArray.removeElement(ngaySX, choice);
                    XuLyArray.removeElement(hanSD, choice);
                    XuLyArray.removeElement(congTySX, choice);
                    XuLyArray.removeElement(loaiHang, choice);

                }
            }
        }
    }
}