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
    public partial class Arbol : Form
    {
        public Arbol(List<(int,string)> grafo, List<(int, string)> registrado)
        {
            InitializeComponent();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Location = new Point(0, 0);
            viewer.Height = this.Height - 30;
            viewer.Width = 700;
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 


            foreach(var graf in grafo)
            {

                graph.AddEdge(graf.Item1.ToString(), graf.Item2);
                
            }

            List<string> aux = new List<string>();
            
             foreach(var reg in registrado)
            {
                string perro = "(" + reg.Item1 + "," + reg.Item2 + ")";
                aux.Add(perro);
            }


            string x = string.Join("\n", aux);
            rtxt_arbol.Text = x;

            viewer.Graph = graph;
            ////associate the viewer with the form 
            this.SuspendLayout();
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();

        }

        private void Arbol_Load(object sender, EventArgs e)
        {

        }
    }
}
