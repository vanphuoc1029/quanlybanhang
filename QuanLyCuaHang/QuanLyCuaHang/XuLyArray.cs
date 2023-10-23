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
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    arr[i] = num;
                    return arr;
                }
            }
            int[] new_array = new int[arr.Length * 2];
            for (int i = 0; i < new_array.Length; i++)
            {
                new_array[i] = arr[i];
            }
            new_array[arr.Length] = num;
            return new_array;
        }
        public static string[] appendArray(string[] arr, string str)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    arr[i] = str;
                    return arr;
                }
            }
            string[] new_array = new string[arr.Length * 2];
            for (int i = 0; i < new_array.Length; i++)
            {
                new_array[i] = arr[i];
            }
            new_array[arr.Length] = str;
            return new_array;
        }

        public static ngayThang[] appendArray(ngayThang[] arr, string str)
        {
            ngayThang[] new_array = new ngayThang[arr.Length + 1];
            for (int i = 0; i < new_array.Length; i++)
            {
                new_array[i] = arr[i];
            }
            new_array[arr.Length].ngay = int.Parse(str.Substring(0, 2));
            new_array[arr.Length].thang = int.Parse(str.Substring(3, 2));
            new_array[arr.Length].nam = int.Parse(str.Substring(6, 4));
            return new_array;
        }

    }
}

