namespace ProjectSLR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_gramatica = new System.Windows.Forms.DataGridView();
            this.txt_numProd = new System.Windows.Forms.TextBox();
            this.btn_ingresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ingresarGram = new System.Windows.Forms.Button();
            this.rtxt_primeros = new System.Windows.Forms.RichTextBox();
            this.rtxt_siguientes = new System.Windows.Forms.RichTextBox();
            this.btn_grafo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gramatica)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_gramatica
            // 
            this.dgv_gramatica.AllowUserToAddRows = false;
            this.dgv_gramatica.AllowUserToDeleteRows = false;
            this.dgv_gramatica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_gramatica.Location = new System.Drawing.Point(16, 92);
            this.dgv_gramatica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_gramatica.Name = "dgv_gramatica";
            this.dgv_gramatica.RowHeadersWidth = 51;
            this.dgv_gramatica.Size = new System.Drawing.Size(441, 423);
            this.dgv_gramatica.TabIndex = 0;
            this.dgv_gramatica.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txt_numProd
            // 
            this.txt_numProd.Location = new System.Drawing.Point(228, 32);
            this.txt_numProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_numProd.Name = "txt_numProd";
            this.txt_numProd.Size = new System.Drawing.Size(132, 22);
            this.txt_numProd.TabIndex = 1;
            this.txt_numProd.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_ingresar
            // 
            this.btn_ingresar.Location = new System.Drawing.Point(385, 26);
            this.btn_ingresar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ingresar.Name = "btn_ingresar";
            this.btn_ingresar.Size = new System.Drawing.Size(100, 28);
            this.btn_ingresar.TabIndex = 2;
            this.btn_ingresar.Text = "Ingresar";
            this.btn_ingresar.UseVisualStyleBackColor = true;
            this.btn_ingresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numero de Producciones:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_ingresarGram
            // 
            this.btn_ingresarGram.Location = new System.Drawing.Point(16, 523);
            this.btn_ingresarGram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ingresarGram.Name = "btn_ingresarGram";
            this.btn_ingresarGram.Size = new System.Drawing.Size(100, 28);
            this.btn_ingresarGram.TabIndex = 4;
            this.btn_ingresarGram.Text = "Ingresar";
            this.btn_ingresarGram.UseVisualStyleBackColor = true;
            this.btn_ingresarGram.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rtxt_primeros
            // 
            this.rtxt_primeros.Location = new System.Drawing.Point(511, 92);
            this.rtxt_primeros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtxt_primeros.Name = "rtxt_primeros";
            this.rtxt_primeros.Size = new System.Drawing.Size(472, 194);
            this.rtxt_primeros.TabIndex = 5;
            this.rtxt_primeros.Text = "";
            // 
            // rtxt_siguientes
            // 
            this.rtxt_siguientes.Location = new System.Drawing.Point(511, 308);
            this.rtxt_siguientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtxt_siguientes.Name = "rtxt_siguientes";
            this.rtxt_siguientes.Size = new System.Drawing.Size(472, 194);
            this.rtxt_siguientes.TabIndex = 6;
            this.rtxt_siguientes.Text = "";
            // 
            // btn_grafo
            // 
            this.btn_grafo.Location = new System.Drawing.Point(768, 36);
            this.btn_grafo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_grafo.Name = "btn_grafo";
            this.btn_grafo.Size = new System.Drawing.Size(100, 28);
            this.btn_grafo.TabIndex = 7;
            this.btn_grafo.Text = "Grafo";
            this.btn_grafo.UseVisualStyleBackColor = true;
            this.btn_grafo.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btn_grafo);
            this.Controls.Add(this.rtxt_siguientes);
            this.Controls.Add(this.rtxt_primeros);
            this.Controls.Add(this.btn_ingresarGram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ingresar);
            this.Controls.Add(this.txt_numProd);
            this.Controls.Add(this.dgv_gramatica);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gramatica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_gramatica;
        private System.Windows.Forms.TextBox txt_numProd;
        private System.Windows.Forms.Button btn_ingresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ingresarGram;
        private System.Windows.Forms.RichTextBox rtxt_primeros;
        private System.Windows.Forms.RichTextBox rtxt_siguientes;
        private System.Windows.Forms.Button btn_grafo;
    }
}

