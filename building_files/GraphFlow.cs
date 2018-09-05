using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
//using static System.Math;

namespace FordFulkerson_algorithm
{
    public class FordFulkerson
    {
        static Dictionary<int, Node> Nodes;
        static Dictionary<string, Edge> Edges;
        private const float MaxValue = float.MaxValue;
        public static string runRes;
        bool rightGraph;
        public List<List<Edge>> everyPath;

        public FordFulkerson(List<Node> V, List<Edge> E)
        {
            everyPath = new List<List<Edge>>();
            rightGraph = true;
            Nodes = new Dictionary<int, Node>(V.Count());
            int IdNum = 2;
            for (int i = 0; i < V.Count(); i++)
            {
                if (V[i].source)
                {
                    if (!Nodes.ContainsKey(1))
                    {
                        V[i].Name = "s";
                        V[i].Id = 1;
                        Nodes.Add(V[i].Id, V[i]);
                    }
                    else
                        rightGraph = false;
                }
                else if (V[i].sink)
                {
                    if (!Nodes.ContainsKey(V.Count()))
                    {
                        V[i].Name = "t";
                        V[i].Id = V.Count;
                        Nodes.Add(V[i].Id, V[i]);
                    }
                    else
                        rightGraph = false;
                }
                else
                {
                    V[i].Id = IdNum;
                    V[i].Name = (IdNum).ToString();
                    Nodes.Add(V[i].Id, V[i]);
                    IdNum++;
                }
            }

            Edges = new Dictionary<string, Edge>(2*E.Count());
            for (int i = 0; i < E.Count(); i++)
                AddAtEdges(E[i]);
        }

        public string Run()
        {
            if (rightGraph)
            {
                runRes = "";
                PrintNodes();
                FordFulkersonAlgo(Nodes[1], Nodes[Nodes.Count()]);
                return runRes;
            }
            else
                return runRes = "The graph is not correct";
        }

        void FordFulkersonAlgo(Node nodeSource, Node nodeTerminal)
        {
            PrintLn("\n** FordFulkerson");
            var flow = 0f;

            var path = Bfs(nodeSource, nodeTerminal);

            while (path != null && path.Count > 0)
            {
                var minCapacity = MaxValue;
                foreach (var edge in path)
                {
                    if (edge.Capacity < minCapacity)
                        minCapacity = edge.Capacity;
                }

                if (minCapacity == MaxValue || minCapacity < 0)
                    throw new Exception("minCapacity " + minCapacity);

                AugmentPath(path, minCapacity);
                flow += minCapacity;
                PrintLn("\nminCapacity = " + minCapacity);

                Print(path);
                everyPath.Add(path);

                path = Bfs(nodeSource, nodeTerminal);
            }
            PrintLn("\n** Max flow = " + flow);

            // min cut
            PrintLn("\n** Min cut");
            FindMinCut(nodeSource);
}

        static void AugmentPath(List<Edge> path, float minCapacity)
        {
            foreach (var edge in path)
            {
                var keyResidual = GetKey(edge.NodeTo, edge.NodeFrom);
                var edgeResidual = Edges[keyResidual];

                edge.Capacity -= minCapacity;
                edgeResidual.Capacity += minCapacity;
            }
        }

        List<Edge> Bfs(Node root, Node target)
        {
            root.TraverseParent = null;
            target.TraverseParent = null;

            var queue = new Queue<Node>();
            var discovered = new HashSet<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                discovered.Add(current);

                if (current.Id == target.Id)
                    return GetPath(current);

                var nodeEdges = current.NodeEdges;
                foreach (var edge in nodeEdges)
                {
                    var next = edge.NodeTo;
                    var c = GetCapacity(current, next);
                    if (c > 0 && !discovered.Contains(next))
                    {
                        next.TraverseParent = current;
                        queue.Enqueue(next);
                    }
                }
            }
            return null;
        }

        static void Print(List<Edge> path)
        {
            foreach (var edge in path)
                PrintLn(edge.Info());
        }

        static List<Edge> GetPath(Node node)
        {
            var path = new List<Edge>();
            var current = node;
            while (current.TraverseParent != null)
            {
                var key = GetKey(current.TraverseParent, current);
                var edge = Edges[key];
                path.Add(edge);
                current = current.TraverseParent;
            }
            return path;
        }

        public static string GetKey(Node node1, Node node2)
        {
            return node1.Id + "|" + node2.Id;
        }

        public float GetCapacity(Node node1, Node node2)
        {
            var edge = Edges[GetKey(node1, node2)];
            return edge.Capacity;
        }

        public void AddAtEdges(Edge E)
        {
            E.Name = GetKey(E.NodeFrom, E.NodeTo);
            Edges.Add(E.Name, E);
            E.NodeFrom.NodeEdges.Add(E);

            Edge edge = new Edge(E.NodeTo, E.NodeFrom, 0f);
            //edge.Capacity = 0f;
            edge.Name = GetKey(E.NodeTo, E.NodeFrom);
            Edges.Add(edge.Name, edge);
            E.NodeTo.NodeEdges.Add(edge);
        }

        static void PrintNodes()
        {
            for (int i = 1; i < Nodes.Count + 1; i++)
            {
                var node = Nodes[i];
                PrintLn(node.ToString() + " outnodes=" + node.GetInfo());
            }
        }

        void FindMinCut(Node root)
        {
            var queue = new Queue<Node>();
            var discovered = new HashSet<Node>();
            var minCutNodes = new List<Node>();
            var minCutArcs = new List<Edge>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (discovered.Contains(current))
                    continue;

                minCutNodes.Add(current);
                discovered.Add(current);

                var arcs = current.NodeEdges;
                foreach (var arc in arcs)
                {
                    var next = arc.NodeTo;
                    if (arc.Capacity <= 0 || discovered.Contains(next))
                        continue;
                    queue.Enqueue(next);
                    minCutArcs.Add(arc);
                }
            }

            // bottleneck as a list of arcs
            var minCutResult = new List<Edge>();
            List<int> nodeIds = minCutNodes.Select(node => node.Id).ToList();

            var nodeKeys = new HashSet<int>();
            foreach (var node in minCutNodes)
                nodeKeys.Add(node.Id);

            var arcKeys = new HashSet<string>();
            foreach (var arc in minCutArcs)
                arcKeys.Add(arc.Name);


            //ParseData(V, E); // reset the graph

            // finding by comparing residual and original graph

            foreach (var id in nodeIds)
            {
                var node = Nodes[id];
                var arcs = node.NodeEdges;
                foreach (var arc in arcs)
                {
                    if (nodeKeys.Contains(arc.NodeTo.Id))
                        continue;

                    if (arc.Capacity > 0 && !arcKeys.Contains(arc.Name))
                        minCutResult.Add(arc);
                }
            }

            float maxflow = 0;
            foreach (var arc in minCutResult)
            {
                maxflow += arc.Capacity;
                PrintLn(arc.Info());
            }
            PrintLn("min-cut total maxflow = " + maxflow);
        }

        public static void PrintLn(object o) { runRes = string.Format(runRes + o + "\n"); }
        public static void PrintLn() { runRes = string.Format(runRes + "\n"); }
        public static void Print(object o) { runRes = string.Format(runRes + o); }
    }
}