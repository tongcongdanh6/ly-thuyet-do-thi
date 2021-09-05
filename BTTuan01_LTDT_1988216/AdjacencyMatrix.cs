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
            // @ Chức năng: có phải là đồ thị vô hướng hay không?

            // Kiểm tra tính đối xứng qua đường chéo chính
            bool isSymmetric = true;
            for(int i = 0; i < this.n - 1; i++)
            {
                for(int j = i + 1; j < this.n; j++)
                {
                    if(this.Matrix[i,j] != this.Matrix[j,i])
                    {
                        isSymmetric = false;
                        break;
                    }
                }
            }
            return isSymmetric;
        }

        public int CountVertex()
        {
            // @ Chức năng: tính số lượng đỉnh trong đồ thị
            // Số đỉnh là số dòng
            return this.n;
        }

        public int GetNumOfEdge()
        {
            // @ Chức năng: tính số lượng cạnh trong đồ thị

            int sumOfDegree = 0;
            // Áp dụng định lý handshaking
            if(isUndirectedGraph())
            {
                // Nếu đồ thị là vô hướng
                int[] degrees = GetDegreesOfUndirectedGraph();
                for(int i = 0; i < degrees.Length; i++)
                {
                    sumOfDegree += degrees[i];
                }
            }
            else
            {
                // Đồ thị có hướng
                int[,] degrees = GetDegressOfDirectedGraph();
                for (int i = 0; i < degrees.GetLength(0); i++)
                {
                    sumOfDegree += degrees[i,0];
                    sumOfDegree += degrees[i,1];
                }
            }
            return sumOfDegree / 2;
        }

        public int GetNumOfLoopEdge()
        {
            // @ Trả về: tính số lượng cạnh khuyên
            int numOfLoopEdge = 0;
            // Đếm cạnh khuyên;
            for(int i = 0; i < n; i++)
            {
                numOfLoopEdge += Matrix[i, i];
            }

            return numOfLoopEdge;
        }

        public int GetNumOfCoupleOfVertexHaveMultipleEdge()
        {
            // @ Chức năng: tính số lượng cặp đỉnh có cạnh bội
            int numOfVertex = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if(isUndirectedGraph())
                    {
                        if (Matrix[i, j] > 1) numOfVertex++;
                    }
                    else
                    {
                        if (Matrix[i, j] == 1 && Matrix[j, i] == 1) numOfVertex++;
                    }
                    
                }
            }
            return numOfVertex;
        }

        public int GetIsolatedVertex()
        {
            // @ Chức năng: tính số đỉnh cô lập
            int numOfIsolatedVertex = 0;
            if(isUndirectedGraph())
            {
                int[] degrees = GetDegreesOfUndirectedGraph();
                for(int i = 0; i < degrees.Length; i++)
                {
                    if (degrees[i] == 0) numOfIsolatedVertex++;
                }
            }
            else
            {
                int[,] degrees = GetDegressOfDirectedGraph();
                for (int i = 0; i < degrees.GetLength(0); i++)
                {
                    if (degrees[i,0] == 0 && degrees[i,1] == 0) numOfIsolatedVertex++;
                }
            }
            return numOfIsolatedVertex;
        }

        public int GetPendantVertex()
        {
            // @ Chức năng: tính số đỉnh treo
            int numOfPendantVertex = 0;
            if (isUndirectedGraph())
            {
                int[] degrees = GetDegreesOfUndirectedGraph();
                for (int i = 0; i < degrees.Length; i++)
                {
                    if (degrees[i] == 1) numOfPendantVertex++;
                }
            }
            else
            {
                int[,] degrees = GetDegressOfDirectedGraph();
                for (int i = 0; i < degrees.GetLength(0); i++)
                {
                    if ((degrees[i, 0] == 1 && degrees[i, 1] == 0)
                        || (degrees[i, 0] == 0 && degrees[i, 1] == 1)
                        ) numOfPendantVertex++;
                }
            }
            return numOfPendantVertex;
        }

        public int[] GetDegreesOfUndirectedGraph()
        {
            // @Return: Mảng các số nguyên chứa bậc của các đỉnh trong đồ thị vô hướng
            int[] degrees = new int[n];
            for (int i = 0; i < n; i++)
            {
                int count = 0; // Biến đếm bậc 1 đỉnh
                for (int j = 0; j < n; j++)
                {
                    if (Matrix[i, j] != 0)
                    {
                        count += Matrix[i, j];
                        // Nếu có cạnh khuyên
                        if(i == j)
                        {
                            count += Matrix[i, i];
                        }
                    }

                }
                // Hiệu chỉnh giá trị bậc của đỉnh trong mảng degrees
                degrees[i] = count;
            }
            return degrees;
        }

        public int[,] GetDegressOfDirectedGraph()
        {
            int[,] degrees = new int[n, 2];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Matrix[i,j] != 0)
                    {
                        // Bậc ra degrees[*,0]; Bậc vào degrees[*,1];
                        // Nếu có cạnh khuyên thì chỉ tính bậc ra và vào cho đỉnh đó
                        if (i == j)
                        {
                            degrees[i, 1] += Matrix[i, i]; // Vào
                            degrees[i, 0] += Matrix[i, i]; // Ra
                        }
                        else
                        {
                            degrees[i, 0] += Matrix[i, j]; // Cộng dồn bậc ra của đỉnh i đến j
                            degrees[j, 1] += Matrix[i, j]; // Cộng dồn bậc vào của đỉnh j do i đến j
                        }
                    }
                    
                }
            }

            return degrees;
        }

        public string GetTypeOfGraph()
        {
            string resStr = "";
            if(isUndirectedGraph())
            {
                if (GetNumOfLoopEdge() == 0 && GetNumOfCoupleOfVertexHaveMultipleEdge() == 0)
                    resStr = "Don do thi";
                else if(GetNumOfLoopEdge() == 0 && GetNumOfCoupleOfVertexHaveMultipleEdge() > 0)
                    resStr = "Da do thi";
                else if(GetNumOfLoopEdge() > 0)
                    resStr = "Gia do thi";
            }
            else
            {
                if(GetNumOfCoupleOfVertexHaveMultipleEdge() == 0)
                {
                    resStr = "Do thi co huong";
                }
                else if(GetNumOfCoupleOfVertexHaveMultipleEdge() > 0)
                {
                    resStr = "Da do thi co huong";
                }
            }
            return resStr;
        }
    }
}
