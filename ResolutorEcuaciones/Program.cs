namespace ResolutorEcuaciones;

class Program
{
    private static string ecuacionCompleta;
    private const string signos = "+-/*=";
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingresa la ecuación, la x sera tomada como una variable") ;
        ecuacionCompleta = Console.ReadLine();

        if (String.IsNullOrEmpty(ecuacionCompleta.Trim())) return;
        
        

        //Ecuacion dividida por partes
        var partes = DividirEcuacion(ecuacionCompleta);
        partes = SumarConstantes(partes.ToArray());
        partes = CambiarLados(partes);
        partes = SumarConstantes(partes.ToArray());
        ResolverEcuacion(partes);

      
    }



    //resolver ecuacion
    private static void ResolverEcuacion(List<string> parteslista)
    {
        foreach (var parte in parteslista)
        {


            //Primero vemos si a la izquierda tenemos tipo 3x => *3x
            if (int.TryParse(parte.Substring(0,parte.Length - 1) , out int num))
                {
                    // Si entra aquí, significa que sí era un número válido, 

                    if (! (byte.TryParse(parte[parte.Length - 1].ToString(), out _)) && !(signos.Contains(parte[parte.Length - 1])))
                    {
                    // Si entra aquí, significa que viene variable


                        Console.WriteLine($"{parte[parte.Length - 1]} =  {float.Parse(parteslista[^1]) / num}");
                        
                    }

                }

            

        }
  

    }




    //Pasar de lado las cosas
    private static List<string> CambiarLados(List<string> parteslista)
    {
        bool intercambiarSigno = true;
        LinkedList<string> partes = new LinkedList<string>(parteslista);

        // Empezamos desde el primer nodo
        LinkedListNode<string> nodoActual = partes.First;

        int con = 0;
        while (con < partes.Count)
        {
            //Guardar el siguiente nodo
            LinkedListNode<string> siguienteNodo = nodoActual.Next;


            //al actual le haremos:
            if (int.TryParse(nodoActual.Value, out var val))
            {
                partes.Remove(nodoActual);
                partes.AddLast(IntercambiarSignos(nodoActual.Value,intercambiarSigno));
            
            }
            if (nodoActual.Value == "=") intercambiarSigno = false;

            // Avanzamos al siguiente nodo que guardamos antes
            nodoActual = siguienteNodo;
    
            con++;
        }


        return partes.ToList<string>();

    }

    private static string IntercambiarSignos(string num, bool intercambiar)
    {
        if (!intercambiar) return num;
        string nuevonum = "";

        foreach (var n in num) 
        {
            char a = n;

            if (signos.Contains(n))
            {
                if (n == '+') a = '-';
                if (n == '-') a = '+';
                if (n == '/') a = '*';
                if (n == '*') a = '/';
            }
           
            nuevonum += a;
            
           
        }

        return nuevonum;


    }


    private static List<string> SumarConstantes(string[] partes)
    {
        List<string> result = new List<string>();
        int con = 0;

        foreach (string texto in partes)
        {
            if (int.TryParse(texto, out var val))
            {
                con += val;
            }
            else
            {
                //Significa que trae variable

                //revisamos si es el =, de serlo agregamos lo que tenemos hasta ahora,y ponemos un signo de =, y continua el proceso con lo que este a la derecha del signo
                if (texto == "=")
                {
                    if(con != 0) result.Add(ReasignarSigno(con));
                    result.Add("=");
                    con = 0;
                    continue;

                }
                result.Add(texto);
            }
        }
        if (con != 0) result.Add(ReasignarSigno(con));
        return result;
    }

    private static string ReasignarSigno(int valor)
    {
        if (valor >= 0) { return $"+{valor}"; }
        else { return $"{valor}"; }
    }



    private static List<string> DividirEcuacion(string ecuacion)
    {
        List<string> ecuacionPartes = new List<string>();
        string parte = "";
  
        foreach (char c in ecuacion)
        {
               if(signos.Contains(c))
               {
                   //rompe este bucle, guarda el signo, y lo agrega para la siguiente
                   if(parte != "") ecuacionPartes.Add(parte);
                   
                   if (c == '=')
                   {
                       ecuacionPartes.Add("=");
                       parte = "";
                       continue;
                   }
                   
                   //ya hicimos todo, y guardamos el ultimo signo
                   parte = c.ToString();
                   continue;
               }

               parte += c;
        }
        ecuacionPartes.Add(parte);
        return ecuacionPartes;
    }
}