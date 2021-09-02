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
                Console.WriteLine("This file does not exist.");
                return false;
            }
            char[] sp = new char[] { ' ' }; // chuỗi ký tự phân cách phần tử
            string[] lines = File.ReadAllLines(filename);
            n = Int32.Parse(lines[0]);  // convert chuỗi số sang số nguyên
            a = new int[n, n];          // Khởi tạo mạng 2 chiều
            for (int i = 0; i < n; ++i)
            {
                string[] ArrayNumbers = lines[i + 1].Split(sp, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; ++j)
                    a[i, j] = Int32.Parse(ArrayNumbers[j]);
            }
            return true;
        }
    }
}
