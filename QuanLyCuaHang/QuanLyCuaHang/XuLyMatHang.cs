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
        public static void themMatHang(ref products[] productsArray, string[] listLoaiHang)
        {
            if (XuLyLoaiHang.kiemTraListTrong(listLoaiHang))
                { Console.WriteLine("Vui long bo sung danh sach truoc khi them san pham."); }
            else
            {
                products newProduct = new products(); 
                Console.Write("Nhap ID mat hang: ");
                newProduct.ID = int.Parse(Console.ReadLine());
                Console.Write("Nhap ten mat hang: ");
                newProduct.name = Console.ReadLine();
                bool valid_input = false;
                while (!valid_input)
                {
                    Console.Write("Nhap ngay san suat (dinh dang dd/mm/yyyy): ");
                    string ngaysx_input = Console.ReadLine();
                    if (XuLyNgayThang.checkValidDay(ngaysx_input))
                    {
                        newProduct.manufactoringDate.date = int.Parse(ngaysx_input.Substring(0,2)) ;
                        newProduct.manufactoringDate.month = int.Parse(ngaysx_input.Substring(3, 2));
                        newProduct.manufactoringDate.year = int.Parse(ngaysx_input.Substring(6, 4));
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
                        newProduct.expiredDate.date = int.Parse(hansd_input.Substring(0, 2));
                        newProduct.expiredDate.month = int.Parse(hansd_input.Substring(3, 2));
                        newProduct.expiredDate.year = int.Parse(hansd_input.Substring(6, 4));
                        valid_input = true;
                    }
                    else
                    {
                        Console.WriteLine("Ban nhap sai dinh dang ngay thang, vui long nhap lai");
                    }
                }
                Console.Write("Nhap cong ty san suat: ");
                newProduct.factory = Console.ReadLine();
                valid_input=false;
                while (!valid_input)
                {
                    Console.WriteLine("Mat hang nay thuoc loai hang nao? (nhap ten cua mat hang)");
                    XuLyLoaiHang.inList(listLoaiHang);
                    string input = Console.ReadLine();
                    foreach (string cat in listLoaiHang)
                    { 
                        if (cat.ToLower() == input.ToLower())
                            {   
                                valid_input = true;
                                newProduct.category = input;
                                break; 
                            }
                    }
                    if (!valid_input)
                    { Console.WriteLine("Khong co loai hang nay trong danh sach, vui long nhap lai!"); }
                }
                Console.WriteLine("Them mat hang thanh cong!");
                productsArray = XuLyArray.appendArray(productsArray, newProduct);
            }
        }
        public static void xoaMatHang(ref products[] productsArray)
        {
            if (!XuLyArray.checkEmptyArray(productsArray))
            {
                Console.WriteLine("Lua chon so thu tu ban muon xoa.");
                for (int i = 0; i < productsArray.Length; i++)
                {
                    Console.WriteLine($"{i}. ID:{productsArray[i].ID}, san pham: {productsArray[i].name}");
                }
                int choice = int.Parse(Console.ReadLine());
                if (choice > -1 && choice < productsArray.Length)
                {
                    productsArray = XuLyArray.removeElement(productsArray, choice);
                }
                else
                {
                    Console.WriteLine("Lua chon khong phu hop.");
                }
            }
            else
            { Console.WriteLine("Khong co mat hang nao de xoa!"); }    
        }

        public static void timKiemMatHang(products[] productsArray)
        {
            if (!XuLyArray.checkEmptyArray(productsArray))
            {
                Console.Write("Nhap tu khoa ban muon tim kiem: ");
                string search = Console.ReadLine();
                products[] searchResult = new products[0];           
                foreach(products product in productsArray)
                {
                    for (int index = 0; index <= product.name.Length - search.Length; index++)
                    {
                        if (Char.ToLower(product.name[index]) == Char.ToLower(search[0]))
                        {
                            if (product.name.Substring(index, search.Length).ToLower() == search.ToLower())
                            {
                                searchResult = XuLyArray.appendArray(searchResult, product);
                            }
                        }
                        else if (product.ID.ToString().Length >= search.Length && index < product.ID.ToString().Length)
                        {
                            if (product.ID.ToString()[index] == search[0])
                            {
                                if (product.ID.ToString().Substring(index, search.Length) == search)
                                {
                                    searchResult = XuLyArray.appendArray(searchResult, product);
                                }
                            }
                        }
                    }
                }
                if (searchResult.Length == 0)
                {
                    Console.WriteLine("Khong co san pham nao phu hop voi tu khoa cua ban!");
                }
                else
                {
                    Console.WriteLine("Tu khoa cua ban phu hop voi nhung san pham sau");
                    foreach (products product in searchResult) 
                    {
                        Console.WriteLine($"ID: {product.ID}, Ten SP: {product.name}");
                    }
                }
            }
        }
    }
}