

namespace QuanLyCuaHang
{
    internal class LoadTestData
    {
        public static string[] testCategory(ref string[] category)
        {
            category = XuLyArray.appendArray(category, "Thoi trang");
            category = XuLyArray.appendArray(category, "My pham");
            category = XuLyArray.appendArray(category, "Dien tu");
            category = XuLyArray.appendArray(category, "Gia dung");
            return category;
        }
        public static products[] testProducts(ref products[] productsArray)
        {
            string[] testName = { "Ao LV", "Kem chong nang Sunplay", "Sua rua mat OXY", "Iphone 15"
                                  , "Bep dien SunHouse", "Laptop Asus", "Ao Adidas", "Iphone 14", "Iphone 15 proMax"},
                    testFactory = { "LV", "SP", "OXY", "Apple", "Sun", "ASUS", "Adidas", "Apple", "Apple" },
                    testCategory = {"Thoi trang", "My pham", "My pham", "Dien tu", "Gia dung", "Dien tu", "Thoi trang",
                                   "Dien tu","Dien tu",};
            int[] testDate = { 12, 21, 15, 01, 06, 04, 09, 16, 12 },
                    testMonth = { 01, 02, 03, 04, 05, 06, 07, 08, 09 },
                    testYear = { 2020, 2020, 2021, 2021, 2022, 2022, 2023, 2023, 2023 };
            for (int i = 0; i < testName.Length; i++ )
            {
                products new_Product = new products();
                new_Product.ID = i;
                new_Product.name = testName[i];
                new_Product.factory = testFactory[i];
                new_Product.category = testCategory[i];
                new_Product.manufactoringDate.date = testDate[i];
                new_Product.manufactoringDate.month = testMonth[i];
                new_Product.manufactoringDate.year = testYear[i];
                new_Product.expiredDate.date = testDate[i];
                new_Product.expiredDate.month = testMonth[i];
                new_Product.expiredDate.year = testYear[i];
                productsArray = XuLyArray.appendArray(productsArray, new_Product);
            }
            return productsArray;
        }
    }
}
