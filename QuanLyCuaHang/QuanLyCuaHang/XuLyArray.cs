

namespace QuanLyCuaHang
{
    internal class XuLyArray
    {
        public static bool checkEmptyArray(products[] product)
        {
            if (product.Length == 0) 
            {
                Console.WriteLine("Danh sach hien tai dang trong.");
                return true; 
            }
            return false;
        }
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

        public static products[] appendArray(products[] arr, products str)
        {
            products[] new_array = new products[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                new_array[i] = arr[i];
            }
            new_array[arr.Length] = str;
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

        public static products[] removeElement(products[] arr, int index)
        {
            products[] new_arr = new products[arr.Length - 1];
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

