using System.Drawing;

namespace Bitmask
{
    internal class Program
    {
        static string[] acciones = { "Comida","Agua","Medicina","Abrigo","Tirar Dados" };
        static int posicionPunteroAcciones = 0;

        Program() {

            
        }
        static void Main(string[] args)
        {
            //En un solo entero guardaremos estados
            //==================================
            // 0000 Nada
            // 0001 Dormido
            // 0010 Hambre
            // 0011 Dormido y con hambre
            //==================================

            //ImprimirEnConsola(ConsoleColor.Green, "Aaaaaahhhhhhhhhhhhh..............                    Pulsa enter para continuar");

            //ImprimirEnConsola(ConsoleColor.Green, "!!Push¡¡");
            //ImprimirEnConsola(ConsoleColor.Green, "!!Bonk????");
            //ImprimirEnConsola(ConsoleColor.DarkCyan, "Despues de caer en un vasto precipicio, has llegado a lo que parece ser...");
            //ImprimirEnConsola(ConsoleColor.DarkCyan, "Un Largo y Oscuro Bosque");


            //==============================================================================================================================
            //==============================================================================================================================
            //==============================================================================================================================


            //Inicializar vista principal
            Console.Clear();
            VistaPrincipal();
            CMapa.InicializarMapa();
            CMapa.PintarMapa();
            CMapa.PintarDado(false);
            ObjetosInferiores();


            //Aquí ha empezado el juego
            //Hacer movimiento de selector

            while (true) 
            {

                ConsoleKeyInfo teclaPulsada = Console.ReadKey(intercept: true);


                if (teclaPulsada.Key == ConsoleKey.A)
                {
                    //Restaremos 1 a posicionPunteroAcciones
                    posicionPunteroAcciones =  ((posicionPunteroAcciones - 1 + acciones.Length) % acciones.Length);
                    ContinuarJuego(false);
                    continue;

                }
                else if(teclaPulsada.Key == ConsoleKey.D)
                {
                    //Sumaremos 1 a posicionPunteroAcciones

                    //Usar aritméticaModular

                    posicionPunteroAcciones = (posicionPunteroAcciones + 1) % acciones.Length;
                    ContinuarJuego(false);
                    continue;

                }

                else if(teclaPulsada.Key == ConsoleKey.Enter)
                {
                    //Significa que usó una accíon

                    switch (posicionPunteroAcciones)
                    {
                        case 0:
                           
                            if (Personaje.HasObject(0))
                            {
                                Console.WriteLine($"\nUsando {acciones[0]}");
                                Personaje.EliminateObject(0);
                            }

                            break;
                        case 1:

                            if (Personaje.HasObject(1))
                            {
                                Console.WriteLine($"\nUsando {acciones[1]}");
                                Personaje.EliminateObject(1);


                            }
                            break;
                        case 2:

                            if (Personaje.HasObject(2))
                            {
                                Console.WriteLine($"\nUsando {acciones[2]}");
                                Personaje.EliminateObject(2);


                            }
                            break;
                        case 3:

                            if (Personaje.HasObject(3))
                            {
                                Console.WriteLine($"\nUsando {acciones[3]}");
                                Personaje.EliminateObject(3);


                            }
                            break;

                        case 4:
                           

                            //Usó tirar dado
                            ContinuarJuego(true);

                            //Es todo lo que va a avanzar
                            CMapa.AvanzarEnElMapa(CMapa.TotalDado);


                            Console.WriteLine($"\n\n\nAvanzaste {CMapa.TotalDado}\nPulsa Cualquier tecla para continuar");
                            Console.ReadLine();
                            ContinuarJuego(false);



                            //LLamar a aletoriedad, usando los eventos para casos donde se completo la jugada, no por tiro

                            foreach(var a in Personaje.UltimosLogs)
                            {
                                Console.WriteLine("\n"+a);
                            }

                            Personaje.UltimosLogs.Clear();
                           

                            break;
                    }


                }


                



            }



            //Console.Clear();

            //VistaPrincipal();

            //CMapa.InicializarMapa();
            //CMapa.PintarMapa();
            //CMapa.PintarDado(true);

            //ObjetosInferiores();

        }




        static void ContinuarJuego(bool jugar)
        {
            Console.Clear();
            VistaPrincipal();
         
            CMapa.PintarMapa();
            CMapa.PintarDado(jugar);
            ObjetosInferiores();
        }




        static void VistaPrincipal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Vida:   {Personaje.Vida}% --------------");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-------------- Estados: {Personaje.ListarEstados()}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Sueño:  {Personaje.Sueno}%");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hambre: {Personaje.Hambre}%");
        }

        static void ObjetosInferiores()
        {
          
            Console.WriteLine("\nAcción: ");

            for (int a = 0; a < acciones.Length; a++) 
            {
                //Primero las pinta de blanco
                Console.ForegroundColor = ConsoleColor.White;

                //Si un objeto esta en el bitmask lo pintará de verde
                if (Personaje.HasObject(a))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }



                //Si el puntero esta sobre un objeto lo pintará
                if (a == posicionPunteroAcciones)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(acciones[a] + "      ");

                }
                else
                {
                    //Lo pinta como las reglas de arriba
                    Console.Write(acciones[a] + "      ");

                }
            }

        }

        static void ImprimirEnConsola(ConsoleColor color, string texto)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(texto);
            Console.ReadLine();

        }
    }
}
