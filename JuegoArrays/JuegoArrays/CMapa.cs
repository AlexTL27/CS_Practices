using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoArrays
{
    internal class CMapa
    {
        private int[,] mapa;
        private bool bandera = true;

        private int puntuacion = 0;
        private int movimientosRestantes = 100;
        public CMapa()
        {
            mapa = new int[5, 50];
            
        }

        public void imprimirMapa()
        {
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    //pintar al player de rojo y al coin de amarillo
                    if (mapa[i,j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(mapa[i, j] + " ");
                        Console.ResetColor();
                        continue;
                    }
                    if (mapa[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(mapa[i, j] + " ");
                        Console.ResetColor();
                        continue;

                    }
                    else
                    {
                        Console.Write(mapa[i, j] + " ");

                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Puntuación: {puntuacion}   Movimientos Restantes: {movimientosRestantes}");
            Console.ResetColor();
        }

        int[] posViejaCoin = {0,0};
        //busca la posicion de player, recibe X and Y
        public bool instanciarCosas(int[] posicion, int[] posCoin)
        {
            //Limpiamos mapa y consola
            LimpiarMapa();
            Console.Clear();

            //posicion player
            movimientosRestantes--;
            if (movimientosRestantes <= 0)
                return false;
            
            mapa[posicion[0], posicion[1]] = 1;

            //posicion coin, no se movera hasta que player la toque
            if ((posicion[0] == posViejaCoin[0] && posicion[1] == posViejaCoin[1]) || bandera)
            {
                bandera = false;
                posViejaCoin = posCoin;
                mapa[posCoin[0], posCoin[1]] = 2;
                puntuacion++;
            }
            else
            {
                mapa[posViejaCoin[0], posViejaCoin[1]] = 2;

            }


            //imprimir mapa 
            imprimirMapa();
            return true;
        }

        private void LimpiarMapa()
        {
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {

                    mapa[i, j] = 0;
                }
                
            }

      
        }

    }

}
