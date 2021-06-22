
namespace ProjectSLR
{
    partial class Arbol
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
            this.rtxt_arbol = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxt_arbol
            // 
            this.rtxt_arbol.Location = new System.Drawing.Point(706, 35);
            this.rtxt_arbol.Name = "rtxt_arbol";
            this.rtxt_arbol.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtxt_arbol.Size = new System.Drawing.Size(268, 445);
            this.rtxt_arbol.TabIndex = 3;
            this.rtxt_arbol.Text = "";
            // 
            // Arbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 515);
            this.Controls.Add(this.rtxt_arbol);
            this.Name = "Arbol";
            this.Text = "Arbol";
            this.Load += new System.EventHandler(this.Arbol_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxt_arbol;
    }
}