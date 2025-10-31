using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(IsAnagram("amor", "romssa"));
        }

        public static bool IsAnagram(string pa1, string pa2)
        {
            //verificamos si una es mayor o menor
            if (pa1.Length > pa2.Length || pa2.Length > pa1.Length || pa1 == pa2) { 
                return false;
            }

            bool coincidencia = false;
            byte index = 0;

            //Revisar todas las letras de la primer palabra palabra con cada letra de la segunda

            for (int a = 0; a < pa2.Length; a++) 
            {
                char i = pa2[a];
                index = 0;
                foreach (char j in pa1)
                {
                    if (i != j)
                    {
                        coincidencia = false;
                        index++;

                    }
                    else
                    {
                        coincidencia = true;

                        pa1 = pa1.Remove(index,1);
                        pa2 = pa2.Remove(a,1);

                        Console.WriteLine(pa1);
                        index++;
                        a = 0;
                        break;

                    }
                }
            }
            if (!coincidencia) return false;
            return true;

        }
    }
}
