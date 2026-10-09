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
        
        
        var partes = DividirEcuacion(ecuacionCompleta);

        foreach (var a in  partes)
        {
            Console.WriteLine(a);
        }
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