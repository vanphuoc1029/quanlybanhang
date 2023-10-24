using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class XuLyNgayThang
    {
        public static bool checkValidDay(string day)
        {
            if (day.Length != 10) {  return false; }
            if (day[2] != '/' && day[5] != '/') { return false; }
            string date = day.Substring(0, 2), month = day.Substring(3,2), year = day.Substring(7,4);
            if (int.Parse(date) > 31) { return false; };
            if (int.Parse(month) > 12) { return false; };
            return true;
        }
    }
}
