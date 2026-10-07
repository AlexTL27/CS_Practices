using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmask
{
    internal class CBitmask
    {
        //Aquí estaran los estados

        //HIstoria: Estas en un bosque, y debes llegar a tu casa, Seran 100 pasos para llegar, en cada tirada se lanzara un dado,
        //avanzara y habra posibilidad de que pasen cosas

        //Habran dos bitmask, una de estados, y otra de objetos
        // cada vez que se avanze habra posibilidad de que algo suceda (Malo o bueno), la probabilidad aumenta por tiro  5%,10%,20%,40%, max 50%
        // Cada 3 tiros sucedera algo bueno (Encontraras objetos)

        //Si tienes algun estado malo, reducira en cada tiro el porcentaje de vida, tienes 100 puntos,

        //Si al tirar salio un objeto repetido se dejara pasar, pero si es un estado repetido, tiene que salir otro


        //Podemos guardar todo en el mismo bit array
        // Estados: 0000
        //0001 : Hambre (Aparece cada 3 tiros) reduce 2 puntos de vida por Jugada
        //0010 : Herido (Reduce 3 puntos de vida por tiro) al azar reduce 8 puntos de vida por jugada
        //0100 : Sueño (Aparece cada 5 tiros, si se descansa, el contador se reseteara)   reduce 7 puntos de vida por jugada
        //1000 : Enfermo (Probabilidad de 10% de obtenerlo si Tienes algo mal,) quita 1 punto de vida por tiro 


        // Objetos: 0000  : Salen todos al azar
        //0001 : Comida ( Cura hambre, y enfermo y restaura 5 puntos de vida)  
        //0010 : agua (Cura hambre y restaura 3 puntos de vida ) sale 
        //0100 : medicina (Cura herido y restaura 25 puntos de vida)   
        //1000 : Abrigo (Restaura dos puntos de vida y reduce en 2 los restantes de sueño)

        //Otras cosas que no dependen de guardar en un estado pero sí de que sucedan y desactiven uno
        // Carpa: Reinicia conteo de sueño y cura enfermo


        public class Player
        {

            public int vida = 100;

            public Estados estadosActuales = Estados.Ninguno;
            public Objetos inventario = Objetos.Ninguno;
        }



        [Flags]
        public enum Estados
        {
            Ninguno = 0,
            //0000
            Hambre = 1 << 0,
            Herido = 1 << 1,
            Sueno = 1 << 2,
            Enfermo = 1 << 3, //1000
        }


        [Flags]
        public enum Objetos
        {
            Ninguno = 0,

            //0000
            Comida = 1 << 0,
            Agua = 1 << 1,
            Medicina = 1 << 2,
            Abrigo = 1 << 3, //1000
        }

    }
}
