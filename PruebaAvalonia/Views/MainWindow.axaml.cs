using Avalonia.Controls;
using PruebaAvalonia.ViewModels;

namespace PruebaAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}