using Microsoft.Msagl.Core.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSLR
{
    public partial class Graph : Form
    {
        public Graph(List<List<(string, List<string>, int)>> estados, List<List<(string, string)>> caminos)
        {
            InitializeComponent();
            //create a form 
            //System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Location = new Point(0,0);
            viewer.Height = this.Height - 30;
            viewer.Width = 700;
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 

            for (int est = 0; est < caminos.Count; est++)
            {
                for (int edg = 0; edg < caminos[est].Count; edg++)
                {
                    if (!caminos[est][edg].Item2.Contains("acc"))
                    {
                        if (caminos[est][edg].Item2.Contains("s"))
                        {
                            graph.AddEdge("I" + est, caminos[est][edg].Item1, "I" + caminos[est][edg].Item2.Substring(1));
                        }
                        else if (!caminos[est][edg].Item2.Contains("r"))
                        {
                            graph.AddEdge("I" + est, caminos[est][edg].Item1, "I" + caminos[est][edg].Item2);
                        }
                    }



                }
            }
            string gr = "Grafo:\n";
            for (int est = 0; est < estados.Count; est++)
            {
                string e = "I" + est + "\n{";
                string p = "";
                for (int pr = 0; pr < estados[est].Count; pr++)
                {
                    p = p + "\n   " + estados[est][pr].Item1 + $" => {string.Join(" ",estados[est][pr].Item2)}" + $" [{estados[est][pr].Item3}]";
                }
                gr = gr + e + p + "\n}\n";
            }
            Console.WriteLine(gr);
            rtxt_grafo.ReadOnly = true;
            rtxt_grafo.Text = gr;

            
            viewer.Graph = graph;
            ////associate the viewer with the form 
            this.SuspendLayout();
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
            //show the form 
        }

        private void Graph_Load(object sender, EventArgs e)
        {

        }
    }
}
