using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JuegoArrays
{
    internal class CPlayer
    {
        private int posicionX;
        private int posicionY;
        private Random random = new Random();

        public CPlayer()
        {
            posicionX = random.Next(0, 5);
            posicionY = random.Next(0, 50);
        }


        public int[] InvocarPlayer()
        {
            int[] valor = { posicionX, posicionY };
            return valor;
        }

        public int[] MoverPlayer()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("        🧭  CONTROLES DE MOVIMIENTO  ");
            Console.WriteLine("═══════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("        ↑ ");
            Console.WriteLine("        W  =  Avanzar");
            Console.WriteLine();
            Console.WriteLine("A  ─────┼─────  D  =  Derecha / Izquierda");
            Console.WriteLine();
            Console.WriteLine("        S  =  Retroceder");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("═══════════════════════════════════════");
            Console.ResetColor();
            ///////////////////////////////////////////////////////////////////////
            //logica

            bool bandera = false;

            ConsoleKeyInfo tecla;

            //obtener valor

            while (!bandera)
            {
                tecla = Console.ReadKey(true);//evitga que la tecla se muestre en la consola
                switch (tecla.Key)
                {
                    case ConsoleKey.W:
                        bandera = true;
                        posicionX--;
                        break;

                    case ConsoleKey.S:
                        bandera = true;
                        posicionX++;

                        break;

                    case ConsoleKey.A:
                        bandera = true;
                        posicionY--;

                        break;

                    case ConsoleKey.D:
                        bandera = true;
                        posicionY++;
                        break;

                    default:
                        Console.WriteLine("No correspondido, vuelve a intentar");
                        break;
                }
            }
            //revisamos que los parametros no se salgan
            RevisarParametros();
            //pasamos la referencia nuevamente
            return InvocarPlayer();
        }

        private void RevisarParametros()
        {
            if (posicionX < 0)
                posicionX = 0;


            if (posicionX >= 5)
            {
                posicionX = 4;
            }

            if (posicionY < 0)
                posicionY = 0;


            if (posicionY >= 50)
            {
                posicionY = 49;

            }
        }
    }       
} 
