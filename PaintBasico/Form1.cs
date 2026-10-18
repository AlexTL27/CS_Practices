namespace PaintBasico
{
    public partial class Form1 : Form
    {
        //la posicion del mouse
        int posX = 0;
        int posY = 0;


        List<List<Trazo>> FullTrazos = new List<List<Trazo>>();

        List<Trazo> Trazos = new List<Trazo> ();
        public struct Trazo
        {
           
            public (int X, int Y) Coordenada { get; set; }
            public Trazo(int x, int y)
            {
                Coordenada = (x, y);
            }
        }



        bool pintar = false;

 

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        private void Lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            posX = e.X;
            posY = e.Y;
     

            if (pintar)
            {
                InformacionLabel.Text = $"X={e.X} Y={e.Y}";

                Trazos.Add(new Trazo(posX, posY));
                Lienzo.Invalidate();

            }

        }

        private void Lienzo_MouseDown(object sender, MouseEventArgs e)
        {

            pintar = true;
            Trazos.Add(new Trazo(posX, posY));



        }



        private void Lienzo_MouseUp(object sender, MouseEventArgs e)
        {
            //Guardar Trazos y resetearlo
            FullTrazos.Add(new List<Trazo>(Trazos));
            Trazos.Clear();
            pintar = false;
        }


        private void Lienzo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;



            
            foreach (var trazoCompleto in FullTrazos) {

                for(int i = 1; i < trazoCompleto.Count; i++)
                {
                    Trazo puntoAnterior = trazoCompleto[i - 1];
                    Trazo puntoActual = trazoCompleto[i];

                    g.FillEllipse(Brushes.Black,puntoAnterior.Coordenada.X, puntoAnterior.Coordenada.Y, 2, 2);


                    //Pintar una linea entre cada punto
                    g.DrawLine(Pens.Black, puntoAnterior.Coordenada.X, puntoAnterior.Coordenada.Y, puntoActual.Coordenada.X, puntoActual.Coordenada.Y);

                  
                }
            }

            for (int i = 1; i < Trazos.Count; i++)
            {
                var puntoAnterior = Trazos[i - 1];
                var puntoActual = Trazos[i];

                g.DrawLine(Pens.Black,
                           puntoAnterior.Coordenada.X, puntoAnterior.Coordenada.Y,
                           puntoActual.Coordenada.X, puntoActual.Coordenada.Y);
            }
        }

     
    }
}
