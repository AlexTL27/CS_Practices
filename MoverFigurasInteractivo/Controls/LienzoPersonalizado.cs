using System;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;
using Avalonia.Input;

namespace MoverFigurasInteractivo.Controls;

public class LienzoPersonalizado : Control
{
    //Definir algunos valores
    Point centroElipse = new Point(510, 370);
    private double radio = 40; 
    public LienzoPersonalizado()
    {
        PointerPressed += CanvasPrincipal_OnPointerPressed;  
        PointerMoved += Canvas_PointerMoved;
}
    public override void Render(DrawingContext context)
    {
        base.Render(context);
        
        //Para que detecte el movimiento del mouse
        context.DrawRectangle(Brushes.Transparent, null, new Rect(0, 0, Bounds.Width, Bounds.Height));

        var pen = new Pen(Brushes.CornflowerBlue, 3);

        // Coordenadas de inicio y fin (equivalente a tu g.DrawLine de WinForms)
        Point inicio = new Point(50, 50);
        Point fin = new Point(250, 150);

        // Trazar la línea en el lienzo
        context.DrawLine(pen, inicio, fin);
        
      
        
        context.DrawEllipse(Brushes.Aquamarine, pen, centroElipse,radio,radio);
    }

    private void CanvasPrincipal_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
      
        
    }

    private void Canvas_PointerMoved(object? sender, PointerEventArgs e)
    {
        Point mouseCoordenadas = e.GetPosition(this);
        if (EstaDentro(mouseCoordenadas))
        {
            centroElipse = mouseCoordenadas;
            InvalidateVisual();
        }
        
    }


    private bool EstaDentro(Point  mouseCoordenadas)
    {
        double eValor = Math.Pow((mouseCoordenadas.X - centroElipse.X),2)
                        / Math.Pow(radio,2)  +
                        Math.Pow((mouseCoordenadas.Y - centroElipse.Y),2) / Math.Pow(radio,2);

        if (eValor <= 1)
        {
            return true;
        }
        return false;
    }

}