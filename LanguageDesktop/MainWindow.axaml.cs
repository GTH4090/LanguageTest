using Avalonia.Controls;
using Avalonia.Interactivity;
using static LanguageDesktop.Classes.Helper;

namespace LanguageDesktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Navigation = this.FindControl<ContentControl>("MainFrame");
        Navigation.Content = new Pages.Auth();
        win = this;
    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}