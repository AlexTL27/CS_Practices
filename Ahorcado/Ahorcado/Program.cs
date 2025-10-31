using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valorArray;
            int vidas = 3;
            string letra;
      
            
            Console.WriteLine("''''''''''''''''''''''''''''''\nBienvenido al ahorcado\n''''''''''''''''''''''''''''''\n" +
                "Este es un juego para dos Players, el primero escribira la palabra y el segundo la adivinara\n''''''''''''''''''''''''''''''\n" +
                "Comenzemos: Di el numero de letras que contiene tu palabra.\n''''''''''''''''''''''''''''''");
           


            valorArray =  Int32.Parse(Console.ReadLine()); 
            string[] palabra = new string[valorArray]; // palabra oculta
            string[] adivino = new string[valorArray];// aqui se guerdan las letras que adivino el jugador
            bool correcto = false;
            bool terminado = false;
            for (int i = 0; i < adivino.Length; i++)
            {
                adivino[i] = "-";
            }


            Console.WriteLine("''''''''''''''''''''''''''''''\nBien,Ahora escribe las letras en orden. PDTA: Que el otro jugador no vea XD\n''''''''''''''''''''''''''''''\n");

            for (int a = 0; a < palabra.Length; a++)
            {
                Console.WriteLine("Letra "+ (a+1) + ":"); palabra[a] = Console.ReadLine();
            }

            Console.WriteLine("\nAhora es turno del Siguiente jugador, Pulsa enter antes de darle el mando del juego");
            Console.ReadLine();

            for(int a = 0;a <= 20; a++)
            {
                Console.WriteLine("''''''''''''''''''''''''''''''\n\n''''''''''''''''''''''''''''''\n");
            }

            Console.WriteLine("''''''''''''''''''''''''''''''\nEs tu turno de jugar, tienes 3 vidas, teclea letras y adivina la palabra\n''''''''''''''''''''''''''''''" +
                "\nsi te equivocas, perderas una vida, tienes 3.\n''''''''''''''''''''''''''''''\nComenzemos:\n");


            while(vidas > 0)
            {
                Console.WriteLine("''''''''''''''''''''''''''''''\nEscribe una letra\n''''''''''''''''''''''''''''''");
                letra = Console.ReadLine();
                correcto = false;

                for(int a = 0; a < palabra.Length; a++)
                {
                    if(letra  == palabra[a])
                    {
                        adivino[a] = letra;
                        Console.WriteLine("''''''''''''''''''''''''''''''\nLa letra  esta dentro de la palabra\n''''''''''''''''''''''''''''''\n");
                        correcto = true;
                        for(int b = 0; b < adivino.Length; b++)
                        {
                           Console.WriteLine("La partida va asi: "+adivino[b]);
                        }
                    }
                    else
                    {
                        if(((a + 1) == palabra.Length) && !correcto )
                        {
                            vidas--;
                            Console.WriteLine("Error, Vidas:" + vidas);
                            
                        }
                   
                    }
                }
                for(int a = 0; a < adivino.Length; a++)
                {
                    if (adivino[a] == palabra[a])
                    {
                        terminado = true;
                    }
                    else
                    {
                        terminado = false;
                        break;
                    }
                }
               if( terminado )
                {
                    int vidasrestantes = vidas;
                    vidas = 0;
                }
            }


            if(terminado)
            {
                Console.WriteLine("'''''''''''''''''''''''''''''\nFelicidades Has adivinado la palabra\n'''''''''''''''''''''''''''''\nHa ganado el jugador '2'"); ;
            }
            else
            {
                Console.WriteLine("'''''''''''''''''''''''''''''\nPerdiste UnU\n'''''''''''''''''''''''''''''\nHa ganado el jugador '1'");
            }

            Console.WriteLine("FIN");
          


            Console.ReadLine();
        }
    }
}
