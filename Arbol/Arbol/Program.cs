using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int numeroTotal;
            int numeroSeguimiento = 0;
            int bucle = 0;
            int seguimiento = 0;
            string asterisco = "*";
            string imprimir = "";

            Console.WriteLine("Escribe que tan grande quieres que imprima el pino");
           
            numeroTotal = Int32.Parse(Console.ReadLine());

            do
            {
                bucle++;

                do
                {
                    imprimir = imprimir + asterisco;
                    seguimiento++;
                    Console.WriteLine(imprimir);
                   
                } while (seguimiento < bucle);

               
                numeroSeguimiento++;
                
            } while (numeroSeguimiento < numeroTotal);



            
            Console.ReadLine();
        }
    }
}
