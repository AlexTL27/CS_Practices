using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MoverFigurasInteractivo.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    [ObservableProperty] private double _coordenadaX;
    [ObservableProperty] private double _coordenadaY;
    
    public void MapearCoordenadas(double Xmetodo, double Ymetodo)
    {
        CoordenadaX = Xmetodo;
        CoordenadaY = Ymetodo;
        
    }
    
}
