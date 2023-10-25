using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class XuLyNgayThang
    {
        public static bool kiemTraNamNhuan(int year)
        {
            if (year % 4  == 0)
            {
                if (year % 100 != 0)
                {
                    return true;
                }    
            }
            return false;
        }
        public static bool checkValidDay(string day)
        {
            if (day.Length != 10) {  return false; }
            if (day[2] != '/' && day[5] != '/') { return false; }
            int[] _31days = { 1, 3, 5, 7, 8, 10, 12 }, _30days = { 4, 6, 9, 11 };
            int date = int.Parse(day.Substring(0, 2)), month = int.Parse(day.Substring(3,2)), year = int.Parse(day.Substring(7,4));
            if (month > 12 || month < 0) { return false; }

            else
            {
                if (_31days.Contains(month))
                {
                    if (date < 0 || date > 31)
                    {
                        return false;
                    }
                }
                else if (_30days.Contains(month))
                {
                    if (date < 0 || date > 30)
                    {
                        return false;
                    }
                }
                else
                {
                    if (kiemTraNamNhuan(year)) { if (date > 29) { return false;} }
                    else { if (date > 28) { return false;} } 
                }
            }
            return true;
        }
    }
}
