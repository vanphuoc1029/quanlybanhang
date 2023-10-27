using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuanLyCuaHang
{
    internal class XuLyMatHang
    {

        public static int checkValidNumberInput()
        {

            bool isValidNumber = false, check = true;
            int validNumber = -1;
            while (check)
            {
                string input = Console.ReadLine();
                isValidNumber = int.TryParse(input, out validNumber);
                if (!isValidNumber || string.IsNullOrEmpty(input)) 
                { 
                    Console.WriteLine("Du lieu ban nhap vao khong hop le, vui long nhap lai (du lieu so)!");
                }
                else { check = false; }
            }
            return validNumber;
        }

        public static string checkValidStringInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Ban khong duoc de trong truong nay, vui long nhap lai!");
                input = Console.ReadLine();
            }
            return input;
        }
        public static void themMatHang(ref products[] productsArray, string[] listLoaiHang)
        {
            if (XuLyLoaiHang.kiemTraListTrong(listLoaiHang))
                { Console.WriteLine("Vui long bo sung danh sach truoc khi them san pham.");
                Console.WriteLine("--------------------------------------------------------");
            }
            else
            {
                products newProduct = new products(); 
                Console.Write("Nhap ID mat hang: ");
                newProduct.ID = checkValidNumberInput();
                Console.Write("Nhap ten mat hang: ");
                newProduct.name = checkValidStringInput();
                bool valid_input = false;
                while (!valid_input)
                {
                    Console.Write("Nhap ngay san suat (dinh dang dd/mm/yyyy): ");
                    string ngaysx_input = checkValidStringInput();
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
                    string hansd_input = checkValidStringInput();
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
                newProduct.factory = checkValidStringInput();
                valid_input=false;
                while (!valid_input)
                {
                    Console.WriteLine("Mat hang nay thuoc loai hang nao? (nhap ten cua mat hang)");
                    XuLyLoaiHang.inList(listLoaiHang);
                    string input = checkValidStringInput();
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
                Console.WriteLine("--------------------------------------------------------");
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
                int choice = checkValidNumberInput();
                if (choice > -1 && choice < productsArray.Length)
                {
                    productsArray = XuLyArray.removeElement(productsArray, choice);
                }
                else
                {
                    Console.WriteLine("Lua chon khong phu hop.");
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
            else
            { 
                Console.WriteLine("Khong co mat hang nao de xoa!");
                Console.WriteLine("--------------------------------------------------------");
            }    
        }

        public static void timKiemMatHang(products[] productsArray)
        {
            if (!XuLyArray.checkEmptyArray(productsArray))
            {
                Console.Write("Nhap tu khoa ban muon tim kiem: ");
                string search = checkValidStringInput();
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
                    Console.WriteLine("--------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Tu khoa cua ban phu hop voi nhung san pham sau");
                    foreach (products product in searchResult) 
                    {
                        Console.WriteLine($"ID: {product.ID}, Ten SP: {product.name}");
                    }
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
        }

        public static void SuaMatHang(ref products[] productArray, string[] categories)
        {
            Console.Write("Nhap ID mat hang ban muon sua: ");
            int choice = checkValidNumberInput();
            bool found = false;
            for (int i = 0; i < productArray.Length; i++) 
            { 
                if (choice == productArray[i].ID)
                {
                    found = true;
                    Console.WriteLine("Ban muon sua thong tin nao cua san pham (chon so thu tu):\n1. ID san pham.\n2. Ten san pham.\n3. Ngay san xuat." +
                        "\n4. Han su dung.\n5. Cong ty san xuat.\n6. Loai hang.");
                    choice = checkValidNumberInput();
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Nhap ID moi: ");
                            productArray[i].ID = checkValidNumberInput();
                            Console.WriteLine("Thay the ID thanh cong!");
                            Console.WriteLine("--------------------------------------------------------");
                            break;
                        case 2:
                            Console.Write("Nhap ten san phan moi: ");
                            productArray[i].name = checkValidStringInput();
                            Console.WriteLine("Thay the ten san pham thanh cong!");
                            Console.WriteLine("--------------------------------------------------------");
                            break;
                        case 3:
                            Console.Write("Nhap ngay san xuat moi (dd/mm/yyyy): ");
                            string input = checkValidStringInput();
                            if (XuLyNgayThang.checkValidDay(input))
                            {
                                productArray[i].manufactoringDate.date = int.Parse(input.Substring(0, 2));
                                productArray[i].manufactoringDate.month = int.Parse(input.Substring(3, 2));
                                productArray[i].manufactoringDate.year = int.Parse(input.Substring(6, 2));
                                Console.WriteLine("Thay the ngay san xuat thanh cong!");
                                Console.WriteLine("--------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Ban da nhap sai dinh dang ngay thang");
                                Console.WriteLine("--------------------------------------------------------");
                            }
                            break;
                        case 4:
                            Console.Write("Nhap han su dung moi (dd/mm/yyyy): ");
                            input = checkValidStringInput();
                            if (XuLyNgayThang.checkValidDay(input))
                            {
                                productArray[i].expiredDate.date = int.Parse(input.Substring(0, 2));
                                productArray[i].expiredDate.month = int.Parse(input.Substring(3, 2));
                                productArray[i].expiredDate.year = int.Parse(input.Substring(6, 2));
                                Console.WriteLine("Thay the han su dung thanh cong!");
                                Console.WriteLine("--------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Ban da nhap sai dinh dang ngay thang");
                                Console.WriteLine("--------------------------------------------------------");
                            }
                            break;
                        case 5:
                            Console.Write("Nhap ten cong ty san xuat moi: ");
                            productArray[i].name = checkValidStringInput();
                            Console.WriteLine("Thay the ten cong ty san xuat thanh cong!");
                            Console.WriteLine("--------------------------------------------------------");
                            break;
                        case 6:
                            Console.WriteLine("Mat hang cua ban thuoc loai hang nao: ");
                            foreach (string category in categories)
                            { Console.WriteLine(category); }
                            input = checkValidStringInput();
                            bool validInput = false;
                            while (!validInput)
                            {
                                foreach (string category in categories)
                                {
                                    if (category == input)
                                    { validInput = true; break; }
                                }
                                Console.WriteLine("Loai hang ban nhap hien khong co, vui long nhap lai.");
                                Console.WriteLine("--------------------------------------------------------");
                            }
                            productArray[i].name = checkValidStringInput();
                            Console.WriteLine("Thay the ten cong ty san xuat thanh cong!");
                            Console.WriteLine("--------------------------------------------------------");
                            break;
                        default:
                            Console.WriteLine("Lua chon cua ban khong nam trong danh sach.");
                            Console.WriteLine("--------------------------------------------------------");
                            break;
                    }
                    break;
                }    
            }
            if (!found)
            { Console.WriteLine("Khong tim thay ID ban vua nhap!"); Console.WriteLine("--------------------------------------------------------"); }
            }
    }
}