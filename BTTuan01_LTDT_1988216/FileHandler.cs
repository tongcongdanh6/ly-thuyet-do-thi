using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01_LTDT_1988216
{
    class FileHandler
    {
        public bool readMatrixFromFile(string filename, ref int[,] a)
        {
            // Đọc ma trận từ file vào mảng a
            int n;
            if (!File.Exists(filename))
            {
                Console.WriteLine("File khong ton tai");
                return false;
            }
            
            // Đọc dòng đầu tiên lấy số lượng phần tử
            StreamReader file = new StreamReader(filename);
            string line;
            n = int.Parse(file.ReadLine());
            a = new int[n, n]; // Khởi tạo mạng 2 chiều
            int i = 0; // Biến đếm cho dòng
            while ((line = file.ReadLine()) != null) {
                string[] ch = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < n; j++)
                {
                   // Thêm phần tử vào các cột
                   a[i, j] = Int32.Parse(ch[j]);
                }
                i++;
            }

            file.Close();

            return true;
        }
    }
}
