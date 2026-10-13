namespace GraficadorFuncionesBasicas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void panelGrafico_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Obtener el dentro
            float centroX = panelGrafico.Width / 2;
            float centroY = panelGrafico.Height / 2;

            label1.Text = $"Centro x: {centroX} \n Centro Y: {centroY}";


            //Pintar en el centro
            g.DrawLine(Pens.Blue, 0, centroY, centroX * 2, centroY);
            g.DrawLine(Pens.Red, centroX, 0, centroX, centroY * 2);


            g.DrawLine(Pens.BlueViolet, centroX - 30, centroY + 8 , centroX, centroY-40);




        }
    }
}
