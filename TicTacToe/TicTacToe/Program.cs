using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        public static string[] graficosFinales = {"1","2","3", "4", "5", "6", "7", "8", "",};


        static void Main(string[] args)
        {
            bool[] p1 = new bool[9];
            bool[] p2 = new bool[9];
            bool[] casillas = new bool[9];
            
            int turno = 0;
            bool gane;

            int Num;

            int contadorEmpate = 0;

            Console.WriteLine("Bienvenido al juego de gato, participaras contra el bot, :)");

           pintarGraficos("9",8);
  

            while (true)
            {
                

                // turno de player 1
                if (turno == 0)
                {
                    Console.WriteLine("Turno de Jugador 1: \"\"X\"\"");
                    Num = (RangoCorrecto() - 1);
                    if (casillas[Num])
                    {
                        Console.WriteLine("****Esa casilla ya ha sido ocupada, selecciona otra****S");
                        Console.WriteLine("#############\n\n" + graficosFinales[0] + " | " + graficosFinales[1] + " | " + graficosFinales[2] + " | " + "\n-----------\n" + graficosFinales[3] + " | " + graficosFinales[4] + " | " + graficosFinales[5] + " | " + "\n-----------\n" + graficosFinales[6] + " | " + graficosFinales[7] + " | " + graficosFinales[8] + " | " + "\n\n#############");
                        continue;
                    }
                    else
                    {
                        pintarGraficos("X", Num);
                    }
                   
                }
                //turno de player 2
                else
                {
                    Console.WriteLine("Turno de jugador 2 \"\"O\"\"");
                    
                    Random random = new Random();
                    Num = random.Next(0,9);

                    if (casillas[Num])
                    {
                        Console.WriteLine("****Esa casilla ya ha sido ocupada, selecciona otra****");
                        Console.WriteLine("#############\n\n" + graficosFinales[0] + " | " + graficosFinales[1] + " | " + graficosFinales[2] + " | " + "\n-----------\n" + graficosFinales[3] + " | " + graficosFinales[4] + " | " + graficosFinales[5] + " | " + "\n-----------\n" + graficosFinales[6] + " | " + graficosFinales[7] + " | " + graficosFinales[8] + " | " + "\n\n#############");
                        continue;
                    }
                    else
                    {
                        pintarGraficos("O", Num);
                    }
                    
                }

                //Aseguramos que el numero dado este en 1-9
                

                if (casillas[Num] == false)
                {
                    //modificamos casillas globales
                    casillas[Num] = true;
                    Console.WriteLine("########################\nLa casilla Numero " + (Num + 1) + " a sido ocupada por el jugador " + (turno == 0 ? "1" : "2") + "\n########################");
                    if (turno == 0)
                    {  //modificamos casillas propias del player 1
                        p1 = ModificarCasillaJugador(p1,Num);
                        //Alguien gano???
                        gane = CondicionesParaGanar(p1);

                        if (gane == true)
                        {
                            Console.WriteLine("Player 1 a ganado");
                            Console.ReadLine();
                            break;
                        }    
                        turno = 1;
                        contadorEmpate++;
                    }
                    else
                    {
                        //modificamos casillas propias del player 2
                        p2 = ModificarCasillaJugador(p2,Num);
                        gane = CondicionesParaGanar(p2);
                        if (gane == true)
                        {
                            Console.WriteLine("Player 2 a ganado");
                            Console.ReadLine();
                            break;
                        }
                        turno = 0;
                        contadorEmpate++;


                    }



                }

                if (contadorEmpate >= 9)
                {
                    Console.WriteLine("#####EMPATE####");
                    Console.ReadLine();
                    break;
                }


            }


        }


        static void pintarGraficos(string letra, int casilla)
        {

            graficosFinales[casilla] = letra;

            Console.WriteLine("##########################\nELTABLERO SE HA ACTUALIZADO\n##########################");
            
            Console.WriteLine("\n" + graficosFinales[0] + " | " + graficosFinales[1]  + " | " + graficosFinales[2]  + " | " + "\n-----------\n" + graficosFinales[3]  + " | " + graficosFinales[4] + " | " + graficosFinales[5] + " | " + "\n-----------\n" + graficosFinales[6] + " | " + graficosFinales[7] + " | " + graficosFinales[8] + " | " + "\n");
        }
        static bool CondicionesParaGanar(bool[] jugador)
        {
            //Vertical ----
            if (jugador[0] && jugador[1] && jugador[2]) return true;
            if (jugador[3] && jugador[4] && jugador[5]) return true;
            if (jugador[6] && jugador[7] && jugador[8]) return true;

            //horizontal |
            if (jugador[0] && jugador[3] && jugador[6]) return true;
            if (jugador[1] && jugador[4] && jugador[7]) return true;
            if (jugador[2] && jugador[5] && jugador[8]) return true;

            //Diagonal /\
            if (jugador[0] && jugador[4] && jugador[8]) return true;
            if (jugador[6] && jugador[4] && jugador[2]) return true;


            return false;


        }
        static bool[] ModificarCasillaJugador(bool[] casillas, int NumModificar )
        {
            casillas[NumModificar] = true;
            return casillas;
        }



        static int RangoCorrecto()
        {
            int val;

            do
            {

                Console.WriteLine("####Ingresa solo valores dentro del rango 1 - 9 para seleccionar una casilla####");
                val = Int32.Parse(Console.ReadLine());

            } while (val > 9 || val < 1);


            return val;
        }
    }
}
