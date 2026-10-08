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
        private static Random _random = new Random();


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


        //Agregar un objeto aletoriamente, si lo tiene, intentar nuevamente y si vuelve a salir ahora si descartarlo
        public static bool AddObject()
        {

            int numAgregar = _random.Next(0, 4);
            if (HasObject(numAgregar)) return false; 

            inventario = inventario | (Objetos)(1 << numAgregar);
            return true;
        }


        //==========================================
        //======Cosas relacionadas a estados
        //==========================================


        //Ver si personaje tiene un estado
        public static bool HasEstado(int numEstado)
        {
            return (estadosActuales & ((Estados)(1 << numEstado))) != 0;
        }

        public static void AgregarEstado(int numEstado)
        {
           estadosActuales =  estadosActuales | ((Estados)(1 << numEstado));
        }

        //Eliminar un objeto

        public static bool EliminateEstado(int numEstado)
        {
            if ((estadosActuales & (Estados)(1 << numEstado)) != 0)
            {
                estadosActuales = estadosActuales ^ (Estados)(1 << numEstado);

                return true;
            }
            return false;
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




        public static void EfectosEstados()
        {
      
            Sueno -= 23;
            Hambre -= 27;

            //Significa que no tiene el estado
            if(Sueno > 0)
            {
                EliminateEstado(2);
            }
            if(Hambre > 0)
            {
                EliminateEstado(0);
            }


            //Sueño
            if (Sueno <= 0)
            {
                AgregarEstado(2);
                Sueno = 0;
                Vida -= 7;
                UltimosLogs.Add($"Sueño te ha quitado 7 Puntos de vida");
            }
    
            //Hambre
            if (Hambre <= 0)
            {
                AgregarEstado(0);
                Hambre = 0;
                Vida -= 2;
                UltimosLogs.Add($"Hambre te ha quitado 2 Puntos de vida");
            }
  


            //HAcer uso de los efectos
            //HErido
            if (HasEstado(1))
            {
                int restar = _random.Next(1, 9);
                Vida -= restar;
                UltimosLogs.Add($"Herido te ha restado {restar} puntos de vida:");
            }

            //Enfermo
            if (HasEstado(3))
            {
                Vida -= 7;
                UltimosLogs.Add($"Enfermo te ha restado {7} punto de vida:");
            }
        }
        
    }
}
