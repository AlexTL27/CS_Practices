namespace GraficadorFuncionesBasicas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelGrafico = new Panel();
            label1 = new Label();
            SuspendLayout();
            // 
            // panelGrafico
            // 
            panelGrafico.BorderStyle = BorderStyle.FixedSingle;
            panelGrafico.Location = new Point(166, 64);
            panelGrafico.Name = "panelGrafico";
            panelGrafico.Size = new Size(423, 239);
            panelGrafico.TabIndex = 0;
            panelGrafico.Paint += panelGrafico_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 49);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(panelGrafico);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelGrafico;
        private Label label1;
    }
}
