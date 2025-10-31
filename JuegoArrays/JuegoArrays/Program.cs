using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //primero creamos el mapa
            CMapa mapa = new CMapa();
            //crearemos al player, sera capas de desplazarse en un area de 5 x 50
           CPlayer jugador = new CPlayer();
            //instanciamos otras cosas
            CCoin coin = new CCoin();


            while (mapa.instanciarCosas(jugador.MoverPlayer(), coin.CambiarDeLugar()))
            {
                

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n=== GAME OVER ===");
            Console.ResetColor();

        }
    }
}
