using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01_LTDT_1988216
{
    class AdjacencyMatrix
    {
        public int[,] Matrix { set; get; }
        public int n { set; get; }


        public AdjacencyMatrix(int[,] arr)
        {
            this.Matrix = arr;
            this.n = arr.GetLength(0);
        }

        public void printMatrix()
        {
            Console.WriteLine(n);
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    Console.Write(Matrix[i, j]+ " ");
                }
                Console.WriteLine("");
            }
        }

        public bool isUndirectedGraph()
        {
            // Kiểm tra tính đối xứng
            bool isSymmetric = true;
            for(int i = 0; i < this.n; i++)
            {
                for(int j = i + 1; j < this.n; j++)
                {
                    if(this.Matrix[i,j] != this.Matrix[j,i])
                    {
                        isSymmetric = false;
                    }
                }
            }
            return isSymmetric;
        }

        public int countVertex()
        {
            return this.n;
        }

        public int iCountLoopEdge()
        {
            int iNumOfLoopEdge = 0;
            // Đếm cạnh khuyên;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(Matrix[i,j] == 1 && i == j)
                    {
                        iNumOfLoopEdge++;
                    }
                }
            }

            return iNumOfLoopEdge;
        }

        public int iGetMultipleEdge()
        {
            int iNumOfMultipleEdge = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Matrix[i, j] > 1 && i != j)
                    {
                        iNumOfMultipleEdge += Matrix[i,j];
                    }
                }
            }
            if(isUndirectedGraph())
            {
                iNumOfMultipleEdge /= 2;
            }
            return iNumOfMultipleEdge;
        }

        public int iGetTotalEdge()
        {
            // Số lượng cạnh khuyên
            int iLoopEdge = iCountLoopEdge();
            // Số lượng cạnh bội
            int iNumOfMultipleEdge = iGetMultipleEdge();
            // Số lượng cạnh đơn
            int iNumOfEdge = 0;
            // Tổng số cạnh
            int iTotalEdge = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Matrix[i, j] == 1 && i != j)
                    {
                        iNumOfEdge++;
                    }
                }
            }

            if (isUndirectedGraph())
            {
                // Nếu là đồ thị vô hướng
                iNumOfEdge = iNumOfEdge / 2;
            }

            iTotalEdge = iNumOfEdge + iLoopEdge + iNumOfMultipleEdge;
            return iTotalEdge;
        }

        public int iGetCoupleOfVertexHaveMultipleEdge()
        {

        }
    }
}
