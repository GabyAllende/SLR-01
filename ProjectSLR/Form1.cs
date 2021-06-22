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
        public static List<(string, List<string>)> gramatica2 { get; set; }

        List<List<(string, List<string>, int)>> estados { get; set; }

        List<List<(string, string)>> caminos { get; set; }

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
            gramatica2 = new List<(string, List<string>)>();

            Console.WriteLine("dgv_gramatica.Rows.Count: " + dgv_gramatica.Rows.Count);
            List<string> terminales = new List<string>();
            List<string> noterminales = new List<string>();


            for (int i = 0; i < dgv_gramatica.Rows.Count; i++)
            {
                if (salto)
                {
                    break;
                }
                (string, List<string>) aux = ("",new List<string>()); 
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
                        aux.Item1 = dgv_gramatica.Rows[i].Cells[j].Value.ToString();
                        if (!noterminales.Contains(aux.Item1)) { noterminales.Add(aux.Item1); }

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


                            //Al procesar cadena se especifica el lambda ya sea como espacio o como otra cadena 

                            //List<string> atoms2 = new List<string>();

                            //foreach(var mu in atoms)
                            //{
                            //    if (mu == "")
                            //    {
                            //        atoms2.Add("lmb");
                            //    }
                            //    else
                            //    {
                            //        atoms2.Add(mu);
                            //    }
                            //}    

                            
                            
                            
                            aux.Item2 = atoms.ToList();
                            gramatica2.Add(aux);
                        }
                    }


                }
            }

            //adding terminales
            foreach (var segmento in gramatica2)
            {
                foreach (string s in segmento.Item2)
                {
                    if (!noterminales.Contains(s) && !terminales.Contains(s)) { terminales.Add(s); }

                }

            }


            if (salto)
            {
                gramatica1 = null;
            }

            printGram1();
            //Metodos.printGramatica2(gramatica2);
            (caminos, estados) = Metodos.automataSLR(terminales, noterminales, gramatica2);
            
            Console.WriteLine("IMPRIMIENTO LOS CAMINOS");
            foreach (var camino in caminos)
            {
                Console.WriteLine("[" + String.Join(",", camino) + "]");

            }


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
            



            Graph a = new Graph(estados, caminos);

           
            a.ShowDialog();

            //a.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            (bool, List < (int, string) >, List<(int, string)>) m = Metodos.procesarCadena(txtProCadena.Text, caminos, gramatica2);
            if(m.Item1 == true)
            {
                MessageBox.Show("Cadena Aceptada", "Procesar Cadena",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Cadena Denegada", "Procesar Cadena", MessageBoxButtons.OK);
            }


            Console.WriteLine("Grafo para graficar");
            foreach(var milo in m.Item2)
            {
                Console.Write(milo.Item1 + ",");
                Console.WriteLine(milo.Item2);
            }

            Console.WriteLine("----------------------------------------");
            foreach (var mile in m.Item3)
            {
                Console.Write(mile.Item1 + ",");
                Console.WriteLine(mile.Item2);
            }


        }
    }
}
