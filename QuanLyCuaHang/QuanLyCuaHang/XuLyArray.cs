using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class XuLyArray
    {
        public static int[] appendArray(int[] arr, int num)
        {   
            int[] new_array = new int[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                new_array[i] = arr[i];
            }
            new_array[arr.Length] = num;
            return new_array;
        }
        public static string[] appendArray(string[] arr, string str)
        {
            string[] new_array = new string[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                new_array[i] = arr[i];
            }
            new_array[arr.Length] = str;
            return new_array;
        }

        public static ngayThang[] appendArray(ngayThang[] arr, string str)
        {
            ngayThang[] new_array = new ngayThang[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                new_array[i] = arr[i];
            }      
                new_array[arr.Length].ngay = int.Parse(str.Substring(0, 2));
                new_array[arr.Length].thang = int.Parse(str.Substring(3, 2));
                new_array[arr.Length].nam = int.Parse(str.Substring(6, 4));
                return new_array;
        }
        public static int[] removeElement(int[] arr, int index)
        {
            int[] new_arr = new int[arr.Length - 1];
            int i = 0;
            while (i < new_arr.Length)
            {
                if (i < index)
                {
                    new_arr[i] = arr[i];
                }
                else
                {
                    new_arr[i] = arr[i + 1];
                }
                i++;
            }
            return new_arr;
        }
        public static string[] removeElement(string[] arr, int index)
        {
            string[] new_arr = new string[arr.Length - 1];
            int i = 0;
            while (i < new_arr.Length)
            {
                if (i < index)
                {
                    new_arr[i] = arr[i];
                }
                else
                {
                    new_arr[i] = arr[i + 1];
                }
                i++;
            }
            return new_arr;
        }
        public static ngayThang[] removeElement(ngayThang[] arr, int index)
        {
            ngayThang[] new_arr = new ngayThang[arr.Length - 1];
            int i = 0;
            while (i < new_arr.Length)
            {
                if (i < index)
                {
                    new_arr[i] = arr[i];
                }
                else
                {
                    new_arr[i] = arr[i + 1];
                }
                i++;
            }
            return new_arr;
        }
    }
}

