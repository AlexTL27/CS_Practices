namespace PaintBasico
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
            Lienzo = new Panel();
            InformacionLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // Lienzo
            // 
            Lienzo.BorderStyle = BorderStyle.FixedSingle;
            Lienzo.Cursor = Cursors.Cross;
            Lienzo.Location = new Point(25, 64);
            Lienzo.Name = "Lienzo";
            Lienzo.Size = new Size(711, 332);
            Lienzo.TabIndex = 0;
            Lienzo.Paint += Lienzo_Paint;
            Lienzo.MouseDown += Lienzo_MouseDown;
            Lienzo.MouseMove += Lienzo_MouseMove;
            Lienzo.MouseUp += Lienzo_MouseUp;
            // 
            // InformacionLabel
            // 
            InformacionLabel.AutoSize = true;
            InformacionLabel.Location = new Point(25, 22);
            InformacionLabel.Name = "InformacionLabel";
            InformacionLabel.Size = new Size(28, 15);
            InformacionLabel.TabIndex = 0;
            InformacionLabel.Text = "Info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 22);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 445);
            Controls.Add(label1);
            Controls.Add(InformacionLabel);
            Controls.Add(Lienzo);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel Lienzo;
        private Label InformacionLabel;
        private Label label1;
    }
}
