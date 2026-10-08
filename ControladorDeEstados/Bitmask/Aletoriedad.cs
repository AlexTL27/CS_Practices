using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bitmask
{
    internal class Aletoriedad
    {
        //Esta clase sera la encargada de regresar objetos o estados, manejara la aletoriedad durante el juego
        private static Random _random = new Random();


        //Podemos guardar todo en el mismo bit array
        // Estados: 0000
        //0001 : Hambre (Aparece cada 3 tiros) reduce 2 puntos de vida por Jugada
        //0010 : Herido (Reduce 3 puntos de vida por tiro) al azar, reduce 8 puntos de vida por jugada
        //0100 : Sueño (Aparece cada 5 tiros, si se descansa, el contador se reseteara)   reduce 7 puntos de vida por jugada
        //1000 : Enfermo (Probabilidad de 10% de obtenerlo si Tienes algo mal,) quita 1 punto de vida por tiro 


        // Objetos: 0000  : Salen todos al azar
        //0001 : Comida ( Cura hambre, y enfermo y restaura 5 puntos de vida)  
        //0010 : agua (Cura hambre y restaura 3 puntos de vida ) sale 
        //0100 : medicina (Cura herido y restaura 25 puntos de vida)   
        //1000 : Abrigo (Restaura dos puntos de vida y reduce en 2 los restantes de sueño)

        //Otras cosas que no dependen de guardar en un estado pero sí de que sucedan y desactiven uno
        // Carpa: Reinicia conteo de sueño y cura enfermo

        public static void EventosTiros()
        {
   
           
            int numero = _random.Next(0, 101); // Genera entre 0 y 100
            int numeroUser = _random.Next(0, 101); // Genera entre 0 y 100


            //44           //87  //20    // 77   //97
            if (numero == numeroUser || (numero > (numeroUser - (Personaje.Suerte / 2)) && numero < (numeroUser + (Personaje.Suerte / 2)))) 
            {
                if (Personaje.AddObject())
                {
                    Personaje.Suerte = 0;
                    Personaje.UltimosLogs.Add("Se encontró un objeto");
                }

                return;

            }
            
            //sino paso nada bueno, probabilidad de herida


           
            if (numero <= 10)
            {
                //Significa que ya tiene el estado
                if (Personaje.HasEstado(1)) return;

                Personaje.AgregarEstado(1);
                Personaje.UltimosLogs.Add("Oh no, una rama te a cortado un poco el brazo, TE infectaste con Herido");
                return;

                //sino se lo ponemos
            }
       

            Personaje.Suerte += 3;

        }

        public static void EventosJugada()
        {
            int numero = _random.Next(0, 101);

            //HAcer que se efectuen los estados
            Personaje.EfectosEstados();



            //Posibilidad de que salga carpa
            if(numero < 9)
            {
                Personaje.UltimosLogs.Add("Encontraste una carpa donde descansar, Sueño se ha restablecido y ya no estas enfermo");
                Personaje.Sueno = 100;
                Personaje.EliminateEstado(2);
                Personaje.EliminateEstado(3);
            }


            if(Personaje.HasEstado(0) || Personaje.HasEstado(1) || Personaje.HasEstado(2))
            {
                if (Personaje.HasEstado(3)) return;

                if(numero > 50 && numero < 55)
                {
                    Personaje.AgregarEstado(3);
                    Personaje.UltimosLogs.Add("Los efectos en tu cuerpo te empiezan a hacer daño, ahora estas enfermo");
                }
            }


        }
    }
}
