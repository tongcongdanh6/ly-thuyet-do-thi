using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01_LTDT_1988216
{
    class Cau1
    {
        protected int[,] matrix1;

        public void Run()
        {
            // Câu 1
            string path1 = @"../../Cau1_testcase2.txt";

            FileHandler fileHandleInstance = new FileHandler();

            fileHandleInstance.readMatrixFromFile(path1, ref matrix1);

            AdjacencyMatrix MatrixCau1 = new AdjacencyMatrix(matrix1);

            // Cau 1a
            MatrixCau1.printMatrix();

            // Cau 1b
            if(MatrixCau1.isUndirectedGraph())
            {
                Console.WriteLine("Do thi vo huong");
            }
            else
            {
                Console.WriteLine("Do thi co huong");
            }

            // Cau 1c: Số đỉnh
            Console.WriteLine("So dinh cua do thi: {0}", MatrixCau1.countVertex());

            // Cau 1d: Số cạnh
            Console.WriteLine("So canh cua do thi: {0}", MatrixCau1.iGetTotalEdge());

            // Cau 1e: Số cặp đỉnh xuất hiện cạnh bội
            Console.WriteLine("So cap dinh xuat hien canh boi: {0}", MatrixCau1.iGetCoupleOfVertexHaveMultipleEdge());

            // Cau 1g: Xác định bậc của đồ thị
            if(MatrixCau1.isUndirectedGraph())
            {
                Console.WriteLine("Bac cua tung dinh: ");
                int[] degrees = MatrixCau1.GetDegreesOfUndirectedGraph();
                // Mảng kết quả là 1 chiều: Đồ thị vô hướng
                for (int i = 0; i < degrees.GetLength(0); i++)
                {
                    Console.Write("{0}({1}) ",i,degrees[i]);
                }
            }
            else
            {
                Console.WriteLine("(Bac vao - Bac ra) cua tung dinh:");
                int[,] degrees = MatrixCau1.GetDegressOfDirectedGraph();
                for(int i = 0; i < degrees.GetLength(0); i++)
                {
                    Console.Write("{0}({1}-{2}) ", i, degrees[i,1], degrees[i,0]);
                }
            }
        }
    }
}
