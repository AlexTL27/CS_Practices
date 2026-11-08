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
    Point centroElipse2 = new Point(570, 470);
    Point ultimaPosicion;
    private int _figuraSeleccionada = 0;

    //Puntos para el triangulo
    Point pA = new Point(100, 60);
    Point pB = new Point(300, 60);
    Point pC = new Point(200, 200);


    private double radio = 40;

    private bool puedeMover = false;
    private bool _mousePulsado = false;
    public LienzoPersonalizado()
    {
        PointerPressed += CanvasPrincipal_OnPointerPressed;  
        PointerMoved += Canvas_PointerMoved;
        PointerReleased += Canvas_PointerReleased;
    }
    
    /// <summary>
    /// Renderiza nuevamente todo
    /// </summary>
    /// <param name="context"></param>
    
    public override void Render(DrawingContext context)
    {
        base.Render(context);
        
        //Para que detecte el movimiento del mouse
        context.DrawRectangle(Brushes.Transparent, null, new Rect(0, 0, Bounds.Width, Bounds.Height));

        var pen = new Pen(Brushes.CornflowerBlue, 3);


        //Pintar Triangulo
        context.DrawLine(pen, pA, pB);
        context.DrawLine(pen, pB, pC);
        context.DrawLine(pen, pC, pA);




        context.DrawEllipse(Brushes.Aquamarine, pen, centroElipse,radio,radio);
        context.DrawEllipse(Brushes.Aquamarine, pen, centroElipse2, radio, radio);

      
    }


    /// <summary>
    /// Se ejecuta cada vez que el mouse se mueve
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_PointerMoved(object? sender, PointerEventArgs e)
    {
        Point mouseCoordenadas = e.GetPosition(this);
     
    
            if (_mousePulsado && _figuraSeleccionada!= 0)
            {
                //Obtener la diferencia de coordenadas del mouse
                var deltaX = mouseCoordenadas.X - ultimaPosicion.X;
                var deltaY = mouseCoordenadas.Y - ultimaPosicion.Y;
                var delta = new Point(deltaX, deltaY);



                //if item 2 es igual a 1, es la primer elipse
                if (_figuraSeleccionada == 1)
                {
                    //Obtener la diferencia de coordenadas del mouse

                    centroElipse += delta;

                }

                if (_figuraSeleccionada == 2)
                {
                    centroElipse2 += delta;

                }

                if (_figuraSeleccionada == 3)
                {
      
                    pA +=  delta;
                    pB += delta;
                    pC += delta;


                }
                ultimaPosicion = mouseCoordenadas;

                InvalidateVisual();
            }
  
        

    }



    /// <summary>
    /// Se ejecuta al presionar el mouse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CanvasPrincipal_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        Point mouseCoordenadas = e.GetPosition(this);

        if (EstaDentro(mouseCoordenadas))
        {
            ultimaPosicion = mouseCoordenadas;

            _mousePulsado = true;

        }
    }


    private void Canvas_PointerReleased(object? sender, PointerEventArgs e)
    {
        _mousePulsado = false;
        _figuraSeleccionada = 0;
    }


    /// <summary>
    /// Regresa true si el mouse esta dentro de alguna figura figura
    /// </summary>
    /// <param name="mouseCoordenadas"></param>
    /// <returns></returns>
    private bool EstaDentro(Point  mouseCoordenadas)
    {
     
        double eValor = Math.Pow((mouseCoordenadas.X - centroElipse.X),2)
                        / Math.Pow(radio,2)  +
                        Math.Pow((mouseCoordenadas.Y - centroElipse.Y),2) / Math.Pow(radio,2);
        

        if (eValor <= 1)
        {
            _figuraSeleccionada = 1;
            return (true);
        }


        eValor = Math.Pow((mouseCoordenadas.X - centroElipse2.X), 2)
                      / Math.Pow(radio, 2) +
                      Math.Pow((mouseCoordenadas.Y - centroElipse2.Y), 2) / Math.Pow(radio, 2);

        if (eValor <= 1)
        {
            _figuraSeleccionada = 2;

            return (true);
        }


        //Calcular Triangulo

        var D1 = ((mouseCoordenadas.X - pB.X) * (pA.Y - pB.Y)) - ((mouseCoordenadas.Y - pB.Y) * (pA.X -  pB.X));
        var D2 = ((mouseCoordenadas.X - pC.X) * (pB.Y - pC.Y)) - ((mouseCoordenadas.Y - pC.Y) * (pB.X - pC.X));
        var D3 = ((mouseCoordenadas.X - pA.X) * (pC.Y - pA.Y)) - ((mouseCoordenadas.Y - pA.Y) * (pC.X - pA.X));

        if ((D1 >= 0 && D2 >= 0 && D3 >= 0) || (D1 < 0 && D2 < 0 && D3 < 0))
        {
            _figuraSeleccionada = 3;

            return (true);
        }



        return (false);
    }

}