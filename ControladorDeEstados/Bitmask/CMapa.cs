using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bitmask
{
    internal class CMapa
    {

        public static string[] mapa = new string[100];
        public static int TotalDado = 0;
        public static int pasosDados = 0;

        public static void InicializarMapa()
        {
            for (int i = 0; i < mapa.Length; i++)
            {
                mapa[i] = $"[{i + 1}]";
            }
        }


        public static void PintarMapa()
        {
            Console.WriteLine("\n  \n");

            int maxColumnas = 1;

            for (int i = 0; i < mapa.Length; i++)
            {

                if (maxColumnas >= 20)
                {
                    maxColumnas = 0;
                    Console.WriteLine($"{mapa[i]}");
                    continue;

                }

                Console.Write(mapa[i]);
                maxColumnas += 1;
            }

            Console.WriteLine("\n  \n \n \n");

        }



        public static void PintarDado(bool jugando)
        {
            TotalDado = 0;

            if (!jugando)
            {
                Console.WriteLine("                                ==[0]==");
                Console.WriteLine("                                ==[0]==");
                Console.WriteLine("                                ==[0]==");
            }
            else
            {
                Console.WriteLine($"                                ==[{TirarDado()}]==");
                Console.WriteLine($"                                ==[{TirarDado()}]==");
                Console.WriteLine($"                                ==[{TirarDado()}]== = Total:  " + TotalDado);

            }
        }

        public static int TirarDado()
        {

            Random ran = new Random();
            int obtenido = ran.Next(0, 4);
            TotalDado += obtenido;
            return obtenido;
        }


        public static void AvanzarEnElMapa(int pasos)
        {
            for (int i = 0; i < pasos; i++)
            {
                mapa[pasosDados] = JugadorAvanzo();
                pasosDados++;
            }

        }

        private static string JugadorAvanzo()
        {
            //Este metodo espera que regrese  un objeto, un estado, o nada
            //Llamara a aletoriedad, y usara solo las partes que dependen de tiro , no de jugada

            Aletoriedad.EventosTiros();
            return "[x]";
        }
    }
}
