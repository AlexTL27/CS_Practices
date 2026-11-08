using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using MoverFigurasInteractivo.ViewModels;

namespace MoverFigurasInteractivo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
       InitializeComponent();
       DataContext = new MainViewModel();
    }

    private void Canvas_PointerMoved(object? sender, PointerEventArgs e)
    {
        if (DataContext is MainViewModel mainViewModel)
        {
            var posicion = e.GetPosition(CanvasPrincipal);
            var x = Math.Round(posicion.X, 2);
            var y = Math.Round(posicion.Y, 2);
            
            mainViewModel.MapearCoordenadas(x, y);
            CoordenadasText.Text = $"X: {x}, Y: {y}";
            
        }
    
    }

    private void CanvasPrincipal_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        CoordenadasText.Foreground = Brushes.Brown;
    }

    private void CanvasPrincipal_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        CoordenadasText.Foreground = Brushes.White;
        
    }
}