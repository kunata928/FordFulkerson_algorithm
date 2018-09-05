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

namespace FordFulkerson_algorithm
{
    public class Node
    {
        public PointF position;
        public bool source, sink;

        public int Id;
        public string Name;
        public List<Edge> NodeEdges;
        public Node TraverseParent;

        public Node(PointF pos)
        {
            position = pos;
            source = true;
            sink = true;
            NodeEdges = new List<Edge>();
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            foreach (var edge in NodeEdges)
            {
                var node = edge.NodeTo;
                if (edge.Capacity > 0)
                    sb.Append(node.Name + "C" + edge.Capacity + " ");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return string.Format("Id={0}, Name={1}", Id, Name);
        }
    }

    public class Edge
    {
        public Node NodeFrom;
        public Node NodeTo;
        public float Capacity;
        public readonly float maxCapacity;
        public string Name;

        public Edge(Node v1, Node v2, float c)
        {
            NodeFrom = v1;
            NodeTo = v2;
            Capacity = c;
            maxCapacity = c;
        }

        public override string ToString()
        {
            return string.Format("NodeFrom={0}, NodeTo={1}, C={2}", NodeFrom.Name, NodeTo.Name, Capacity);
        }

        public string Info()
        {
            return string.Format("NodeFrom=({0}), NodeTo=({1}), C={2}", NodeFrom, NodeTo, Capacity);
        }
    }
}