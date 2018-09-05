using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace FordFulkerson_algorithm
{
    public partial class MainForm : Form
    {
        DrawGraph G;
        List<Node> V;
        List<Edge> E;
        FordFulkerson FFA;

        Node selectNode = null; //выбранная вершина, для соединения ребром
        int numColorEdges = 0, numPath = 0;
        float minC;
        bool stop = false;
        Pen lineColor = new Pen(Color.Green, 12);

        enum buttonOption { none, newVertex, newEdge, deleteButton, timer }
        buttonOption mouseNow;

        public MainForm()
        {
            InitializeComponent();
            G = new DrawGraph(drawSheet.Width, drawSheet.Height);
            V = new List<Node>();
            E = new List<Edge>();
            lineColor.EndCap = LineCap.ArrowAnchor;
            mouseNow = buttonOption.none;
            defaultGraph();
            G.drawALLGraph(V, E);
            drawSheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать вершину
        private void newVertexButton_Click(object sender, EventArgs e)
        {
            mouseNow = buttonOption.newVertex;
            Timer.Stop();
            G.drawALLGraph(V, E);
            drawSheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void newEdgeButton_Click(object sender, EventArgs e)
        {
            mouseNow = buttonOption.newEdge;
            Timer.Stop();
            G.drawALLGraph(V, E);
            drawSheet.Image = G.GetBitmap();
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            mouseNow = buttonOption.deleteButton;
            Timer.Stop();
            G.drawALLGraph(V, E);
            drawSheet.Image = G.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.drawALLGraph(V, E);
                drawSheet.Image = G.GetBitmap();
            }
            showAlgorithm.Enabled = false;
        }

        private void drawSheet_MouseClick(object sender, MouseEventArgs e)
        {
            bool somethingDelete = false;
            switch(mouseNow)
            {
                case buttonOption.none: //не нажата никакая кнопка
                    matrixBox.Clear();
                    G.drawALLGraph(V, E);
                    drawSheet.Image = G.GetBitmap();
                    break;

                case buttonOption.newVertex: //нажата кнопка "рисовать вершину"
                    V.Add(new Node(e.Location));
                    G.drawVertex(e.Location, V.Count.ToString());
                    drawSheet.Image = G.GetBitmap();
                    mouseNow = buttonOption.none;
                    break;

                case buttonOption.newEdge: //нажата кнопка "рисовать ребро"
                    if (e.Button == MouseButtons.Left)
                    {
                        for (int i = 0; i < V.Count; i++)
                        {
                            if (Math.Pow((V[i].position.X - e.X), 2) + Math.Pow((V[i].position.Y - e.Y), 2) <= G.R * G.R)
                            {
                                if (selectNode == null)
                                {
                                    selectNode = V[i];
                                    G.drawSelectedVertex(V[i].position);
                                    drawSheet.Image = G.GetBitmap();
                                    break;
                                }

                                if (selectNode == V[i])
                                {
                                    drawSheet.Image = G.GetBitmap();
                                    G.drawALLGraph(V, E);
                                    selectNode = null;
                                    mouseNow = buttonOption.none;
                                    return;
                                }

                                if (selectNode != V[i])
                                {
                                    G.drawSelectedVertex(V[i].position);

                                    inputEdgeThroughput throughput = new inputEdgeThroughput();
                                    throughput.ShowDialog();
                                    float c = throughput.val();
                                    throughput.Close();

                                    if (c != 0)
                                    {
                                        E.Add(new Edge(selectNode, V[i], c));
                                        G.drawEdge(selectNode, V[i], E.Last());
                                    }

                                    drawSheet.Image = G.GetBitmap();
                                    G.drawALLGraph(V, E);
                                    selectNode = null;
                                    mouseNow = buttonOption.none;
                                    break;
                                }
                            }
                        }
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        if (selectNode != null)
                        {
                            G.drawALLGraph(V, E);
                            drawSheet.Image = G.GetBitmap();
                            selectNode = null;
                        }
                    }
                    break;

                case buttonOption.deleteButton: //нажата кнопка "удалить элемент"
                    bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                    //если удалена вершина
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].position.X - e.X), 2) + Math.Pow((V[i].position.Y - e.Y), 2) <= G.R * G.R)
                        {
                            for (int j = 0; j < E.Count; j++)
                            {
                                if ((E[j].NodeFrom == V[i]) || (E[j].NodeTo == V[i]))
                                {
                                    E.RemoveAt(j);
                                    j--;
                                }
                            }
                            V.RemoveAt(i);
                            flag = true;
                            break;
                        }
                    }
                    //если удалено ребро
                    if (!flag)
                    {
                        for (int i = 0; i < E.Count; i++)
                        {
                            if (((e.X - E[i].NodeFrom.position.X) * (E[i].NodeTo.position.Y - E[i].NodeFrom.position.Y) / (E[i].NodeTo.position.X - E[i].NodeFrom.position.X) + E[i].NodeFrom.position.Y) <= (e.Y + 6) &&
                                ((e.X - E[i].NodeFrom.position.X) * (E[i].NodeTo.position.Y - E[i].NodeFrom.position.Y) / (E[i].NodeTo.position.X - E[i].NodeFrom.position.X) + E[i].NodeFrom.position.Y) >= (e.Y - 6))
                            {
                                if ((E[i].NodeFrom.position.X <= E[i].NodeTo.position.X && E[i].NodeFrom.position.X <= e.X && e.X <= E[i].NodeTo.position.X) ||
                                    (E[i].NodeFrom.position.X >= E[i].NodeTo.position.X && E[i].NodeFrom.position.X >= e.X && e.X >= E[i].NodeTo.position.X))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                    //если что-то было удалено, то обновляем граф на экране
                    if (flag)
                    {
                        somethingDelete = true;
                        G.drawALLGraph(V, E);
                        drawSheet.Image = G.GetBitmap();
                        mouseNow = buttonOption.none;
                    }
                    break;

                default:
                    break;
            }
            Timer.Stop();
            G.drawALLGraph(V, E);
            drawSheet.Image = G.GetBitmap();
            if (somethingDelete)
                showAlgorithm.Enabled = false;
        }

        private void FordFulkersonRunButton_Click(object sender, EventArgs e)
        {
            if (SourseSinkDefened())
            {
                foreach (var edge in E)
                    edge.Capacity = edge.maxCapacity;
                foreach (var node in V)
                    node.NodeEdges.Clear();
                FFA = new FordFulkerson(V, E);
                matrixBox.Clear();
                matrixBox.AppendText(FFA.Run());
                G.drawALLGraph(V, E);
                drawSheet.Image = G.GetBitmap();
            }
            else
            {
                var MBSave = MessageBox.Show("Обязательно должны быть только один источник и только один сток", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Timer.Stop();
            showAlgorithm.Enabled = true;
        }

        public bool SourseSinkDefened()
        {
            for (int i = 0; i < V.Count(); i++)
                for (int j = 0; j < E.Count(); j++)
                {
                    if (E[j].NodeFrom == V[i])
                        V[i].sink = false;

                    if (E[j].NodeTo == V[i])
                        V[i].source = false;
                }

            int sourseNum = 0, sinkNum = 0;
            for (int i = 0; i < V.Count(); i++)
            {
                if (V[i].source)
                    sourseNum++;
                if (V[i].sink)
                    sinkNum++;
            }

            if (sourseNum == 1 && sinkNum == 1)
                return true;
            else
                return false;
        }

        private void showAlgorithm_Click(object sender, EventArgs e)
        {
            mouseNow = buttonOption.timer;

            foreach (var edge in E)
                edge.Capacity = edge.maxCapacity;

            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(stop)
            {
                Timer.Stop();
                stop = false;
                G.drawALLGraph(V, E);
                drawSheet.Image = G.GetBitmap();
            }

            if (FFA != null)
            {
                if (numColorEdges == 0)
                {
                    minC = FFA.everyPath[numPath][0].Capacity;
                    foreach (var edge in FFA.everyPath[numPath])
                    {
                        if (edge.Capacity < minC)
                            minC = edge.Capacity;
                    }
                }
                else
                {
                    FFA.everyPath[numPath][FFA.everyPath[numPath].Count() - numColorEdges].Capacity -= minC;

                    for (int i = 0; i < FFA.everyPath.Count(); i++)
                        for (int j = 0; j < FFA.everyPath[i].Count(); j++)
                            if (FFA.everyPath[i][j].maxCapacity == 0 || FFA.everyPath[numPath][FFA.everyPath[numPath].Count() - numColorEdges].maxCapacity == 0)
                                if (FFA.everyPath[numPath][FFA.everyPath[numPath].Count() - numColorEdges].NodeFrom == FFA.everyPath[i][j].NodeTo && FFA.everyPath[numPath][FFA.everyPath[numPath].Count() - numColorEdges].NodeTo == FFA.everyPath[i][j].NodeFrom)
                                    FFA.everyPath[i][j].Capacity += minC;
                }

                G.drawALLGraph(V, E, FFA.everyPath[numPath], numColorEdges, lineColor);
                drawSheet.Image = G.GetBitmap();

                if (numColorEdges == FFA.everyPath[numPath].Count())
                {
                    numColorEdges = 0;
                    numPath++;
                }
                else
                    numColorEdges++;

                if (numPath == FFA.everyPath.Count())
                {
                    numPath = 0;
                    stop = true;
                }
            }
        }

        private void defaultGraph() //Заполнение графа по умолчанию 
        {
            PointF p = new PointF();
            p.X = 100;//1
            p.Y = 150;
            V.Add(new Node(p));
            p.X = 100;//2
            p.Y = 300;
            V.Add(new Node(p));
            p.X = 200;//3
            p.Y = 85;
            V.Add(new Node(p));
            p.X = 200;//4
            p.Y = 235;
            V.Add(new Node(p));
            p.X = 400;//5
            p.Y = 85;
            V.Add(new Node(p));
            p.X = 400;//6
            p.Y = 235;
            V.Add(new Node(p));
            p.X = 300;
            p.Y = 150;
            V.Add(new Node(p));
            p.X = 300;//8
            p.Y = 300;
            V.Add(new Node(p));
            E.Add(new Edge(V[0], V[1], 10));
            E.Add(new Edge(V[0], V[6], 10));
            E.Add(new Edge(V[0], V[2], 10));
            E.Add(new Edge(V[1], V[3], 5));
            E.Add(new Edge(V[1], V[7], 5));
            E.Add(new Edge(V[2], V[4], 5));
            E.Add(new Edge(V[2], V[3], 5));
            E.Add(new Edge(V[3], V[5], 10));
            E.Add(new Edge(V[4], V[5], 3));
            E.Add(new Edge(V[4], V[6], 2));
            E.Add(new Edge(V[5], V[7], 13));
            E.Add(new Edge(V[6], V[7], 12));
        }
    }
}
