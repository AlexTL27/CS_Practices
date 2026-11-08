using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PruebaAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // Aquí pondremos nuestras variables y comandos limpios

    // Algo sencillo, ingresar un valor, y lo regresará elevado al x²

    [ObservableProperty]
    private string _valorX = string.Empty;
    

    [RelayCommand]
    private void Calcular()
    {
        if(double.TryParse(ValorX,out double valorParseado))
        {
            ValorX = (valorParseado * valorParseado).ToString();
        }
    }
}