using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.CodeDom.Compiler;
using System.Data;
using System.Security.Cryptography.X509Certificates;

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
            float SizeUnidad = 10;



            //Pintar en el centro
            g.DrawLine(Pens.Blue, 0, centroY, centroX * 2, centroY);
            g.DrawLine(Pens.Red, centroX, 0, centroX, centroY * 2);



            int a = 0;
            while (true)
            {
                //pintar a la derecha
                if (a < (centroX / SizeUnidad))
                {
                    PintarLineasPlano(a, 0, true);
                    PintarLineasPlano(-a, 0, true);
                    PintarLineasPlano(0, -a, false);
                    PintarLineasPlano(0, a, false);
                    a++;
                    continue;
                }
                break;
            }






            void PintarLineasPlano(float posicionX, float posicionY, bool pintarVertical)
            {


                float largo = 5;
                //NOrmalizar la distancia a moverse
                posicionX *= SizeUnidad;
                posicionY *= SizeUnidad;

                if (pintarVertical)
                {
                    g.DrawLine(Pens.DarkBlue, (centroX + posicionX), centroY + largo, (centroX + posicionX), centroY - largo);
                }
                else
                {
                    g.DrawLine(Pens.DarkBlue, centroX - largo, centroY - posicionY, centroX + largo, centroY - posicionY);
                }

            }





            void PintarElipse(float x, float y)
            {
                float radio = 2;
                //Establecer un tamaño para cada pixel
                x *= SizeUnidad;
                y *= SizeUnidad;

                g.DrawEllipse(Pens.DarkGreen, (centroX + x) - radio, (centroY - y) - radio, radio * 2, radio * 2);
            }
            float.TryParse(textBox1.Text, out float x);
            float.TryParse(textBox2.Text, out float y);
            
            if(! (textBox1.Text == "" || textBox2.Text == "" ))  PintarElipse(x, y);







            void PintarEcuacion()
            {

                label2.BackColor = Color.White;
                //y=  2x+3   //-21 =  2 * 3 +3
                string expresion = EcuacionText.Text;

                if (EcuacionText.Text == "") return;


                for (float x = -21; x <= 21; x += 0.5f)
                {

                    for (float y = -12; y <= 12; y += 0.5f)
                    {
                        var dataTable = new DataTable();
                        try
                        {
                            string temp = expresion;

                            //Metemos el valor de X a la expresion
                            temp = temp.Replace("x", x.ToString());
                            var resultado = dataTable.Compute(temp, null);

                            float resultadoFinal = Convert.ToSingle(resultado);
                            if (y == resultadoFinal)
                            {
                                PintarElipse(x, y);
                            }


                            label2.Text = "Ecuación";

                            
                        }
                        catch
                        {
                            label2.Text = "Error";
                            label2.BackColor = Color.Red;
                            break;
                        }

                    }
                }
            }

            PintarEcuacion();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Forzar al panel a repintarse inmediatamente
            panelGrafico.Invalidate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Forzar al panel a repintarse inmediatamente
            panelGrafico.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void EcuacionText_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificamos si la tecla presionada es Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Esto evita el molesto sonido de "beep" que hace Windows al presionar Enter en un TextBox
                e.SuppressKeyPress = true;
                panelGrafico.Invalidate();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
