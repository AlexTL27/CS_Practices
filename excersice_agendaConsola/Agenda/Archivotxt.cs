using System.Text;
using System.Text.RegularExpressions;

namespace Agenda;

public static class Archivotxt
{
    //Clase estática con metodos para trabjar con el txt de manera más fácil 
    static string ruta = Path.Combine(Directory.GetCurrentDirectory(), "Agenda.txt");

    
    
    public static void  Crear()
    {
        //Revisa si no existe el archivo y lo crea
        if (!File.Exists(ruta))
        {
            Console.WriteLine("Creando archivo");
            File.Create(ruta).Close();
            string[] bienvenida =
            [
                "================================", 
                "======== Agenda Personal =======",
                "================================"
            ];
            File.WriteAllLines(ruta,bienvenida);
        }

    }
    
    
    
    public static void VerContactos()
    {
        var con = 1;
        //Este método regresará los contactos que se tienen en el txt
        using (StreamWriter sw = new StreamWriter(ruta, true))
        {
            string[] archivo = File.ReadAllLines(ruta);

            foreach (string line in archivo)
            {
                if (!line.Contains("Nombre"))
                    continue;

                Console.WriteLine($"{con}.- {line.Substring(11)} ");
                con++;
            }
                
        }
    }

    public static void AgregarContacto(Contacto temp)
    {
        //Ahora agregamos al usuario en el txt
        using (StreamWriter sw  = new StreamWriter(ruta, true))
        {
            int primera = 0;
            foreach (var user in temp.GetDatos())
            {
                string line = primera == 0
                    ? $"{TotalContactos()}.-{user.Nombre}: {user.Valor}"
                    : $"{user.Nombre}: {user.Valor}";
                     
                    
                primera++;
                sw.WriteLine(line);   
            }
            sw.WriteLine("=======");
                
        }
    }


    public static void EliminarContacto()
    {
            Console.WriteLine("Indica el número de listado del contacto a eliminar");
            VerContactos();
            
            //Parsear la variable 
            int number;
            if (!Int32.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Algo anda mal, Ingresa un dato correcto -_-");
                return;
            }
            

        
            using (StreamReader sr = new StreamReader(ruta, true))
            {
                List<string> nuevoArchivo = new List<string>();
                
                int con = 1;
                int nom = 1;
                var aumentar = 0;
                string? line;

                int bandera = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //Omitir primeras tres líneas
                    if (bandera <= 2 )
                    { 
                        nuevoArchivo.Add(line);
                        bandera ++;
                        continue;
                    }

                   
                    if (con == number)
                    {
                        Console.WriteLine($"Usuario Encontrado, Eliminando");
                    
                        for(int b = 0; b <= 3; b++ )
                        {
                            sr.ReadLine();
                        }

                        con++;
                    }
                    else
                    {
                        //Agregamos líneas normalmente para crear el nuevo archivo
                        if (line.Contains(".-Nombre:"))
                        {
                            int index = line.IndexOf(".-Nombre:");

                            
                            //El anterior metodo devuelve -1 si no encuentra el índice
                            if(index > -1) line = $"{nom}{line.Substring(index)}";
                        }
                        nuevoArchivo.Add(line);
                        
                        aumentar++;
                        if (aumentar == 5)
                        {
                            aumentar = 0;
                            con++;
                            nom++;
                        }
                    }
                    
                    
                }
                
                //Ahora sobreescribir el archivo
                using (StreamWriter sw  = new StreamWriter(ruta, false))
                {
                    foreach (var linea in nuevoArchivo)
                    {
                        sw.WriteLine(linea);
                    }
                }
            }
    }

    public static void EditarContacto(int number, Contacto temp)
    {
        
            using (StreamReader sr = new StreamReader(ruta, true))
            {
                List<string> nuevoArchivo = new List<string>();
                
                int con = 1;
              
                var aumentar = 0;
                string? line;

                int bandera = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //Omitir primeras tres líneas
                    if (bandera <= 2 )
                    { 
                        nuevoArchivo.Add(line);
                        bandera ++;
                        continue;
                    }

                   
                    if (con == number)
                    {
                        Console.WriteLine($"Usuario Encontrado, Editando");
                    
                        //Elimina al usuario
                        for(int b = 0; b <= 3; b++ )
                        {
                            sr.ReadLine();
                        }
                        
                        
                        //AHora lo agrega
                        string nombre = $"{con}.- Nombre: {temp.Nombre}";
                        string email =  $"Email: {temp.Email}";
                        string telefono =  $"Telefono: {temp.Telefono}";
                        string nacimiento = $"Fecha de nacimiento: {temp.FechaNacimiento}";
                        
                        nuevoArchivo.Add(nombre);
                        nuevoArchivo.Add(email);
                        nuevoArchivo.Add(telefono);
                        nuevoArchivo.Add(nacimiento);
                        nuevoArchivo.Add("=======");

                        con++;
                    }
                    else
                    {
                        
                        nuevoArchivo.Add(line);
                        
                        aumentar++;
                        if (aumentar == 5)
                        {
                            aumentar = 0;
                            con++;
                        }
                    }
                    
                    
                }
                
                //Ahora sobreescribir el archivo
                using (StreamWriter sw  = new StreamWriter(ruta, false))
                {
                    foreach (var linea in nuevoArchivo)
                    {
                        sw.WriteLine(linea);
                    }
                }
            }
        
    }
    
    
    private static int TotalContactos()
    {
        
        //Empieza a contar desde 0
        return File.ReadAllLines(ruta).Count(line => line.Contains("Nombre")) + 1;
    }
}