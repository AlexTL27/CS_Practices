using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bitmask.CBitmask;

namespace Bitmask
{
    static class Personaje
    {
        public static int Vida { get; set; } = 100;
        public static int Sueno { get; set; } = 100;
        public static int Hambre { get; set; } = 100;

        public static int Suerte = 0;



        public static List<string> UltimosLogs = new List<string>();

        //Estados
        public static Estados estadosActuales = Estados.Ninguno;
        public static Objetos inventario = Objetos.Ninguno;



        //Devuelve si el inventario tiene algun item
        public static bool HasObject(int numInventario)
        {
            return (inventario & ((Objetos)(1 << numInventario))) != 0;
        }


        //Eliminar un objeto

        public static void EliminateObject(int numInventario)
        {
            if ((inventario & (Objetos)(1 << numInventario)) != 0)
            {
                inventario = inventario ^ (Objetos)(1 << numInventario);
            }

        }

        //Ver si personaje tiene un estado
        public static bool HasEstado(int numEstado)
        {
            return (estadosActuales & ((Estados)(1 << numEstado))) != 0;
        }

        public static void AgregarEstado(int numEstado)
        {
           estadosActuales =  estadosActuales | ((Estados)(1 << numEstado));
        }


        //Listar Estados
        public static string ListarEstados()
        {
            List<string> estados = ["| Hambre | ","| Herido |","| Sueño | ", "| Enfermo | ",];
          
            for (int i = 0; i <= 3; i++) 
            {

                if( (estadosActuales & (Estados)(1 << i)) == 0)
                {
                    //Significa que no lo tiene
                    estados[i] = "";
                }
                
            }

            //Regresar un string con todos los estados
            return ($"{estados[0]}{estados[1]}{estados[2]}{estados[3]}");
        }



        
    }
}
