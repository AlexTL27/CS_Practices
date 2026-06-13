using System.Collections;
using System.Text.RegularExpressions;

namespace Agenda;

public class Contacto
{
    //Propiedades
    private string _nombre;
    public string Nombre 
    {
        get { return _nombre; }
        set
        {
            DatoVacio(value, "Nombre");
            
            _nombre = value.Trim();
        }
    }

    //Email
    private string _email;
    public string Email 
    {
        get { return _email; }
        set
        {
            DatoVacio(value, "Email");
            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email inválido");
            
            _email = value.Trim();
        }
        
    }
    
    private string _telefono;
    public string Telefono 
    {
        get { return _telefono; }
        set
        {
            DatoVacio(value, "Telefono");
            if (value.Length > 20)
                throw new ArgumentException("telefono muy largo");
            
            
            if (!value.All(r => char.IsDigit(r) ))
                throw new ArgumentException("telefono inválido");

            
            _telefono = value.Trim();
        }
        
    }
    
    private DateOnly? _fechaNacimiento;
    public DateOnly? FechaNacimiento 
    {
        get { return _fechaNacimiento; }
        set
        {
            DatoVacio(value, "Fecha de nacimiento");
            _fechaNacimiento = value;
        }
        
    }


    private void DatoVacio(Object? value, string msj)
    {
        
        //Solo asegura que el dato no este vacio
        if (value == null)
            throw new ArgumentException($"El {msj} es requerido");
        
        
        if (value is string str && string.IsNullOrWhiteSpace(str))
            throw new ArgumentException($"El {msj} es requerido");
    }
   
    /////////Añadiendo IEnumerable////////////
    public IEnumerable<(string Nombre,object? Valor)> GetDatos()
    {
        yield return ("Nombre",_nombre);
        yield return ("Email",_email);
        yield return ("Teléfono", _telefono);
        yield return ("Fecha de nacimiento", _fechaNacimiento);
    } 
}