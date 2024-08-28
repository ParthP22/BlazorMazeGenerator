using System;
using System.Collections.Generic;
//using System.Random;
namespace BlazorMazeGenerator.MazeGen{

    public class MazeGenerator
    {
        private int[,] grid;
        private int[,] edges;
        private List<int[]> EdgeList;
        private List<int[]> MST;
        private int WindowHeight;
        private int WindowWidth;
        private int GridHeight;
        private int GridWidth;
        private int UnitSize;

        public MazeGenerator(int WindowHeight, int WindowWidth, int UnitSize)
        {
            
            this.WindowWidth = WindowWidth;
            this.WindowHeight = WindowHeight;
            this.UnitSize = UnitSize;
            this.GridWidth = WindowWidth / UnitSize;
            this.GridHeight = WindowHeight / UnitSize;

            this.grid = new int[GridHeight, GridWidth];
            this.edges = new int[2 * GridHeight * (GridWidth - 1), 4];
            this.EdgeList = new List<int[]>();
            this.MST = new List<int[]>();

            for (int i = 0, k = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    grid[i,j] = k;
                    k++;
                }
            }

            for (int i = 0, k = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    this.EdgeList.Add(new int[] { });
                    if (j + 1 < GridWidth)
                    {
                        this.edges[k,0] = grid[i,j];
                        this.edges[k,1] = grid[i,j + 1];
                        this.edges[k,2] = 0;
                        k++;
                    
                    }
                    if (i + 1 < GridHeight)
                    {
                        this.edges[k,0] = grid[i,j];
                        this.edges[k,1] = grid[i + 1,j];
                        this.edges[k,2] = 1;
                        k++;
                    
                    }
                }
            }


            Random rand = new Random();

            int min = 1;
            int max = Int32.MaxValue;


            for (int i = 0; i < edges.GetLength(0); i++)
            {
                this.edges[i,3] = rand.Next(min, max);
            }

        }

        public List<int[]> Kruskals()
        {

            EdgeList.Sort((a,b) => a[3] - b[3]);



            // edgelist_to_string(edge_list);

            DisjointSet Forest = new DisjointSet(GridHeight * GridWidth);
            int size = this.EdgeList.Count;
            // printf("Print: %d", size);

           
            // int* tmp = edgelist_get(edge_list,0);
            // printf("Print %d, ", tmp[0]);

            for (int i = 0; i < size; i++)
            {
                int[] node = EdgeList[i];
            
                //printf("\nIndex: %d", i);
                int InitialNode = Forest.FindRepresentative(node[0]);
                int TerminalNode = Forest.FindRepresentative(node[1]);

                if (InitialNode != TerminalNode)
                {
                    int[] tmp = EdgeList[i];

                    MST.Add(tmp);

                    Forest.Union(InitialNode, TerminalNode);
                }
            }

            return MST;
        }

        public void NodesToString()
        {
            Console.Write("\nNodes: [");
            for (int i = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    Console.Write(this.grid[i,j] + ", ");
                }
            }
            Console.Write("]");
        }

        public void EdgesToString()
        {

            Console.Write("\nEdges: [");
            for (int i = 0; i < this.EdgeList.Count; i++)
            {
                Console.Write("[" + EdgeList[i][0] + ", " + EdgeList[i][1] + ", " + EdgeList[i][2] + ", " + EdgeList[i][3] + "]");
            }
            Console.Write("]");
        }

        //public static void Main(string[] args)
        //{
        //    MazeGenerator mg = new MazeGenerator(75,75,25);
        //    mg.Kruskals();
        //    mg.EdgesToString();
        //}
    }
}
