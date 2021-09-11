using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01_LTDT_1988216
{
    class Cau2
    {
        protected int[,] matrix;

        public void Run()
        {
            // Câu 2
            string path1 = @"../../Cau2_testcase3.txt";

            FileHandler fileHandleInstance = new FileHandler();

            fileHandleInstance.readMatrixFromFile(path1, ref matrix);

            AdjacencyMatrix MatrixCau2 = new AdjacencyMatrix(matrix);

            // Cau 2a:
            if(MatrixCau2.IsCompleteGraph())
            {
                Console.WriteLine("Day la do thi day du K{0}",MatrixCau2.CountVertex());
            }
            else
            {
                Console.WriteLine("Day khong phai la do thi day du");
            }

            // Cau 2b: 
            if (MatrixCau2.IsRegularGraph())
            {
                Console.WriteLine("Day la do thi {0} - chinh quy", MatrixCau2.GetDegreesOfUndirectedGraph()[0]);
            }
            else
            {
                Console.WriteLine("Day khong phai la do thi chinh quy");
            }

            // Cau 2c: 
            if (MatrixCau2.IsCircleGraph())
            {
                Console.WriteLine("Day la do thi vong C{0}", MatrixCau2.CountVertex());
            }
            else
            {
                Console.WriteLine("Day khong phai la do thi vong");
            }
        }

    }

}
