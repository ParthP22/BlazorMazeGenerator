using System;
using System.Collections.Generic;
//using System.Random;
namespace BlazorMazeGenerator.MazeGen{

    public class MazeGenerator
    {
        private int[,] _grid;
        private int[,] _edges;
        private List<int[]> _EdgeList;
        private List<int[]> _WallEdges;
        private List<int[]> _MST;
        private Dictionary<int, List<int[]>> _AdjList;
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

            this._grid = new int[GridHeight, GridWidth];
            this._edges = new int[2 * GridHeight * (GridWidth - 1), 5];
            this._EdgeList = new List<int[]>();
            this._MST = new List<int[]>();
            this._WallEdges = new List<int[]>();
            this._AdjList = new Dictionary<int, List<int[]>>();

            for (int i = 0, k = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    _grid[i,j] = k;
                    _AdjList.Add(i, new List<int[]>());
                    k++;
                }
            }

            for (int i = 0, k = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    if (j + 1 < GridWidth)
                    {
                        this._edges[k,0] = _grid[i,j];
                        this._edges[k,1] = _grid[i,j + 1];
                        this._edges[k,2] = 0;
                        k++;
                    
                    }
                    if (i + 1 < GridHeight)
                    {
                        this._edges[k,0] = _grid[i,j];
                        this._edges[k,1] = _grid[i + 1,j];
                        this._edges[k,2] = 1;
                        k++;
                    
                    }
                    
                }
            }


            Random rand = new Random();

            int min = 1;
            int max = Int32.MaxValue;


            for (int i = 0; i < _edges.GetLength(0); i++)
            {
                this._edges[i,3] = rand.Next(min, max);
                this._edges[i,4] = 1;
            }

            for (int i = 0; i < _edges.GetLength(0); i++)
            {
                this._EdgeList.Add(new int[] { _edges[i, 0], _edges[i, 1], _edges[i, 2], _edges[i, 3], _edges[i,4] });
                this._WallEdges.Add(new int[] { _edges[i, 0], _edges[i, 1], _edges[i, 2], _edges[i, 3], _edges[i,4] });
            }

            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                
                this._AdjList[_grid[i,0]].Add(new int[] { _grid[i, 1], _grid[i,2], _grid[i,3], _grid[i,4] });
                this._AdjList[_grid[i,1]].Add(new int[] { _grid[i, 0], _grid[i, 2], _grid[i, 3], _grid[i, 4] });

                
            }

        }

        public List<int[]> Kruskals()
        {
            Console.WriteLine("Performing Kruskal's algorithm");

            _WallEdges.Sort((a,b) => a[3] - b[3]);



            // edgelist_to_string(edge_list);

            DisjointSet Forest = new DisjointSet(GridHeight * GridWidth);
            int size = this._WallEdges.Count;
            // printf("Print: %d", size);

           
            // int* tmp = edgelist_get(edge_list,0);
            // printf("Print %d, ", tmp[0]);

            for (int i = 0; i < size; i++)
            {
                int[] node = _WallEdges[i];
            
                //printf("\nIndex: %d", i);
                int InitialNode = Forest.FindRepresentative(node[0]);
                int TerminalNode = Forest.FindRepresentative(node[1]);

                if (InitialNode != TerminalNode)
                {
                    int[] tmp = _WallEdges[i];

                    _MST.Add(tmp);

                    _WallEdges[i][4] = 0;
                    

                    Forest.Union(InitialNode, TerminalNode);
                }
            }


            //for (int i = 0; i < _WallEdges.Count;)
            //{
            //    if (_WallEdges[i][0] == -1)
            //    {
            //        _WallEdges.RemoveAt(i);
            //    }
            //    else
            //    {
            //        i++;
            //    }
            //}

            return _MST;
        }

        public List<int[]> Prims()
        {
            PriorityQueue<int,int> pq = new PriorityQueue<int,int>();

            pq.Enqueue(0,0);

            for (int i = 1; i < grid.GetLength(0); i++)
            {
                pq.Enqueue(i,int.MaxValue);
            }

            while (pq.Count >= 0)
            {
                int node = pq.Dequeue();
                List<int[]> list = this._AdjList.GetValueOrDefault(node,new List<int[]>);
                foreach(int[] num in list)
                {

                }
            }


            return MST;
        }

        public int[,] grid
        {
            get { return this._grid; }
            set { this._grid = value; }
        }

        public int[,] edges
        {
            get { return this._edges; }
            set { this._edges = value; }
        }

        public List<int[]> EdgeList
        {
            get { return this._EdgeList; }
            set { this._EdgeList = value; }
        }

        public List<int[]> WallEdges
        {
            get { return this._WallEdges; }
            set { this._WallEdges = value; }
        }

        public List<int[]> MST
        {
            get { return this._MST; }
            set { this._MST = value; }
        }


        public void NodesToString()
        {
            Console.Write("\nNodes: [");
            for (int i = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    Console.Write(this._grid[i,j] + ", ");
                }
            }
            Console.Write("]");
        }

        public void EdgesToString()
        {

            Console.Write("\nEdges: [");
            for (int i = 0; i < this._EdgeList.Count; i++)
            {
                Console.Write("[" + _EdgeList[i][0] + ", " + EdgeList[i][1] + ", " + EdgeList[i][2] + ", " + EdgeList[i][3] + "]");
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
