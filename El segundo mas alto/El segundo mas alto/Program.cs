using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_segundo_mas_alto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dado un listado de numeros encuentra el segundo mas alto
            int[] listado = { 12,45,675,675,675,675,675,677 };

            int mayor = listado[0]; 
            int penultimo = listado[0];

            foreach (int i in listado) 
            {
                if (i > mayor)
                {
                   
                    penultimo = mayor;
                    mayor = i;
                }
                else
                {
                    //Se encontro uno menor = mejor, que (i =! mayor &&.....), asi no se asignata otro numero igual a mayor a "mayor"
                    if((penultimo == mayor && i < penultimo) || i > penultimo) penultimo = i;
                }
            }

            if (penultimo == mayor) Console.WriteLine("No hay mayor");
            else Console.WriteLine(penultimo);
            
        }
    }
}
