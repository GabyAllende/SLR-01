using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace ProjectSLR
{
    public partial class Form1 : Form
    {
        private int numProducciones;
        public static (string, string[][])[] gramatica1 { get; set; }
        
        public Form1()
        {
            InitializeComponent();
            dgv_gramatica.Enabled = false;
            btn_ingresarGram.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv_gramatica.Enabled = true;
            string num = txt_numProd.Text;
            if (!string.IsNullOrEmpty(num) && !string.IsNullOrWhiteSpace(num) && Metodos.isNumber(num))
            {
                numProducciones = Int32.Parse(num);
                dgv_gramatica.ColumnCount = 3;
                dgv_gramatica.Columns[0].Name = "Produccion";
                dgv_gramatica.Columns[2].Name = "Valor";
                dgv_gramatica.Columns[0].HeaderText = "Produccion";
                dgv_gramatica.Columns[2].HeaderText = "Valor";
                dgv_gramatica.Columns[1].ReadOnly = true;

                for (int i = 0; i<numProducciones; i++) 
                {
                    int row = dgv_gramatica.Rows.Add();
                    dgv_gramatica.Rows[row].Cells[1].Value= "=>";
                    
                }
                btn_ingresar.Enabled = false;
                txt_numProd.Enabled = false;
                btn_ingresarGram.Enabled = true;

                

            }
            else 
            {
                MessageBox.Show("La informacion ingresada es incorrecta, por favor ingrese un numero.","ERROR",MessageBoxButtons.OK);
            }

            
        }




        private void fillGram1() 
        {
            bool salto = false;
            gramatica1 = new (string, string[][])[numProducciones];

            Console.WriteLine("dgv_gramatica.Rows.Count: " + dgv_gramatica.Rows.Count);

            for (int i = 0; i < dgv_gramatica.Rows.Count; i++)
            {
                if (salto)
                {
                    break;
                }
                for (int j = 0; j < dgv_gramatica.Columns.Count; j++)
                {
                    if (dgv_gramatica.Rows[i].Cells[j].Value == null || string.IsNullOrEmpty(dgv_gramatica.Rows[i].Cells[j].Value.ToString()) || string.IsNullOrWhiteSpace(dgv_gramatica.Rows[i].Cells[j].Value.ToString()))
                    {
                        MessageBox.Show("Debe llenar todas las casillas designadas.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        salto = true;
                        break;
                    }


                    if (j == 0)
                    {
                        gramatica1[i].Item1 = dgv_gramatica.Rows[i].Cells[j].Value.ToString();
                    }
                    if (j == 2)
                    {
                        string[] ors = dgv_gramatica.Rows[i].Cells[j].Value.ToString().Split('|');


                        gramatica1[i].Item2 = new string[ors.Length][];

                        for (int o = 0; o < ors.Length; o++)
                        {

                            string[] atoms = ors[o].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (atoms.ToList().Contains("lambda")) 
                            {
                                for (int y =0; y < atoms.Length; y ++) 
                                {
                                    if (atoms[y] == "lambda") 
                                    {
                                        atoms[y] = "";
                                    }
                                }
                            }

                            gramatica1[i].Item2[o] = atoms;


                        }
                    }


                }
            }

            if (salto)
            {
                gramatica1 = null;
            }

            printGram1();

        }

        private void fillGram2() { }

        private void fillPrimerosSiguientes() 
        {
            List<string> primeros = new List<string>();
            List<string> siguientes = new List<string>();

            foreach (var a in gramatica1)
            {
                primeros.Add($"\n   Primeros({a.Item1}) : " + "{ " + String.Join(" , ", Metodos.primeros(a.Item1)) + " }");
                siguientes.Add($"\n   Siguientes({a.Item1}) : " + "{ " + String.Join(" , ", Metodos.siguientes(a.Item1)) + " }");
            }

            rtxt_primeros.Text = "PRIMEROS:\n{" + string.Join(" , ", primeros) + "\n}\n";
            rtxt_siguientes.Text = "SIGUIENTES:\n{" + string.Join(" , ", siguientes) + "\n}\n";

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            fillGram1();
            fillPrimerosSiguientes();
        }


        private void printGram1() 
        {
            if (gramatica1 != null)
            {
                Console.WriteLine("=================GRAMATICA1:=================");
                foreach (var prod in gramatica1) 
                {
                    
                    string miprod = $"{prod.Item1}:\n";
                    List<string> theors = new List<string>();

                    foreach (string[] or in prod.Item2) 
                    {
                        string mior= "\n  { "+string.Join(" , ",or)+" }";
                        theors.Add(mior);
                    }

                    Console.WriteLine(miprod+"{"+string.Join(" , ",theors)+ "\n}\n");
                }

                Console.WriteLine("============================================");
            }
            else 
            {
                Console.WriteLine("LA GRAMATICA1 ES NULL!!!");
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            


            Graph a = new Graph();

            //create a form 
            //System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            a.SuspendLayout();
            a.Dock = System.Windows.Forms.DockStyle.Fill;
            a.Controls.Add(viewer);
            a.ResumeLayout();
            //show the form 
            a.ShowDialog();

            //a.Show();
        }
    }
}
