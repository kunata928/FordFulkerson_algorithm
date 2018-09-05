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
    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 17; //радиус окружности вершины

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            gr.Clear(Color.White);
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(Color.DarkGoldenrod, 8);
            darkGoldPen.EndCap = LineCap.ArrowAnchor;
            fo = new Font("Arial", 14);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void drawVertex(PointF p, string name)
        {
            gr.FillEllipse(Brushes.White, (p.X - R), (p.Y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (p.X - R), (p.Y - R), 2 * R, 2 * R);
            point = new PointF(p.X - 9, p.Y - 9);
            gr.DrawString(name, fo, br, point);
        }

        public void drawSelectedVertex(PointF p)
        {
            gr.DrawEllipse(redPen, (p.X - R), (p.Y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Node V1, Node V2, Edge E, Pen lineColor = null)
        {
            float Rcos = (float)(R * (V2.position.X - V1.position.X) / Math.Sqrt(Math.Pow(V2.position.X - V1.position.X, 2) + Math.Pow(V2.position.Y - V1.position.Y, 2)));
            float Rsin = (float)(R * (V2.position.Y - V1.position.Y) / Math.Sqrt(Math.Pow(V2.position.X - V1.position.X, 2) + Math.Pow(V2.position.Y - V1.position.Y, 2)));
            float x1 = V1.position.X + Rcos, x2 = V1.position.Y + Rsin, y1 = V2.position.X - Rcos, y2 = V2.position.Y - Rsin;
            if (lineColor == null)
                lineColor = darkGoldPen;
            gr.DrawLine(lineColor, x1, x2, y1, y2);
            if (E.maxCapacity != 0)
            {
                point = new PointF((V1.position.X + V2.position.X) / 2, (V1.position.Y + V2.position.Y) / 2);
                gr.DrawString((E.maxCapacity - E.Capacity).ToString() + "/" + (E.maxCapacity).ToString(), fo, br, point);
            }
        }

        public void drawALLGraph(List<Node> V, List<Edge> E, Pen lineColor = null)
        {
            gr.Clear(Color.White);
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
                drawEdge(E[i].NodeFrom, E[i].NodeTo, E[i], lineColor);

            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
                drawVertex(V[i].position, (i + 1).ToString());
        }

        public void drawALLGraph(List<Node> V, List<Edge> E, List<Edge> path, int numColorEdge, Pen lineColor)
        {
            gr.Clear(Color.White);
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
                drawEdge(E[i].NodeFrom, E[i].NodeTo, E[i], null);

            for (int i = path.Count()-1; i >= path.Count() - numColorEdge; i--)
                drawEdge(path[i].NodeFrom, path[i].NodeTo, path[i], lineColor);

            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
                drawVertex(V[i].position, (i + 1).ToString());
        }
    }
}
