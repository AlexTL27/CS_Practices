using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoArrays
{
    internal class CCoin
    {
        private int posicionX;
        private int posicionY;
        private Random random = new Random();


        public int[] CambiarDeLugar()
        {
            posicionX = random.Next(0, 5);
            posicionY = random.Next(0, 50);

            int[] valor = { posicionX, posicionY };
            return valor;
        }
    }
}
