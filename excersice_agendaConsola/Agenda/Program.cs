using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Agenda;

    internal class Program
    {
        
        private static void Main(string[] args)
        {
            byte op = 0;
           
            //Crea el archivo si no existe
            Archivotxt.Crear();
           
            //=============================================
            //============== MENU PRINCIPAL ===============
            //=============================================

            while (op != 5)
            {
                Console.ResetColor();
                Console.WriteLine("""
                                  ===============
                                  Agenda Personal
                                  ===============
                                  Selecciona una opción
                                  1.- Ver Contactos
                                  2.-Agregar Contacto
                                  3.-Editar Contacto
                                  4.-Eliminar Contacto
                                  5.-Salir de la Agenda
                                  """);
                
                //Revisar si op es una entrada válida
                if (!(byte.TryParse(Console.ReadLine(),
                        out op))) //Out funciona para pasar una variable, si es correcto guarda el resultado en esta 
                {
                    MarcarError("Ingresa un valor válido");
                    continue;
                }
                


                switch (op)
                {
                    case 1:
                        Archivotxt.VerContactos();
                        break;
                    
                    case 2:
                        AgregarContacto(false);
                        break;
                    
                    case 3:
                        AgregarContacto(true);
                        break;
                    case 4:
                        Archivotxt.EliminarContacto();
                        break;
                    
                    case 5:
                        Console.WriteLine("Saliendo....");
                        break;
                    default:
                        MarcarError("Ninguna opción coincide");
                        break;
                }
                
                Console.WriteLine("Pulsa enter para continuar...");
                Console.ReadLine();
            }

        }

      
        
        



        private static void AgregarContacto(bool editando)
        {
            int number = 0;
            while (editando)
            {
                
                Console.WriteLine("Indica el número de listado del contacto a Editar");
                Archivotxt.VerContactos();
            
                //Parsear la variable 
                
                if (!Int32.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Algo anda mal, Ingresa un dato correcto -_-");
                    return;
                }

                break;
            }
            
            //Aquí solo se verifica que el usuario tenga datos correctos, El usuario es agregado en Archivotxt.cs
            //Crear usuario temporal
            Contacto temp = new Contacto();
            
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingresa su nombre");
                    string? nombre = Console.ReadLine();
                    temp.Nombre = nombre;
                    break;
                    
                }
                catch (ArgumentException e)
                {
                    MarcarError(e.Message);
                }
               
            }
           
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingresa su Email");
                    string? email = Console.ReadLine();
                    temp.Email = email;
                    break;
                    
                }
                catch (ArgumentException e)
                {
                    MarcarError(e.Message);
                }
               
            }
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingresa su Teléfono");
                    string? telefono = Console.ReadLine();
                    temp.Telefono = telefono;
                    break;
                    
                }
                catch (ArgumentException e)
                {
                    MarcarError(e.Message);
                }
               
            }
            while (true)
            {
                Console.WriteLine("Ingresa su Fecha de nacimiento: AAAA/MM/DD");
                
                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly fecha))
                {
                    try
                    {
                        temp.FechaNacimiento = fecha;
                        break;

                    }
                    catch (Exception e)
                    {
                        MarcarError(e.Message);
                    }
                }
                else
                {
                        MarcarError("La fecha debe estar en formato AAAA/MM/DD con datos reales");
                    
                }
            }

            if (editando) Archivotxt.EditarContacto(number, temp);
            else Archivotxt.AgregarContacto(temp);
                
            

            
        }

        

        private static void EditarContacto()
        {
            
        }

        
        
        /////////Otros metodos de ayuda
        private static void MarcarError(string msj)
        {
            ConsoleColor color = Console.ForegroundColor;
            
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msj);
            
            Console.ForegroundColor = color;
        }
    }