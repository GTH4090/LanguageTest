using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static LanguageDesktop.Classes.Helper;

namespace LanguageDesktop.Pages;

public partial class Auth : UserControl
{
    
    public Auth()
    {
        
        InitializeComponent();
        
    }

    

    private void PasswordBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (PasswordTbx.IsVisible == false)
            {
                PasswordTbx.IsVisible = true;
                PasswordPbx.IsVisible = false;
            }
            else
            {
                PasswordPbx.IsVisible = true;
                PasswordTbx.IsVisible = false;
            }
        }
        catch (Exception exception)
        {
            Error();
        }
            
        
        
        
    }

    

    private void LoginBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text && el.Password == PasswordPbx.Text) != null)
            {
                Navigation.Content = new MainMenu();
            }
            else
            {
                MessageBoxManager
                    .GetMessageBoxStandardWindow("Внимание", "Неправильный логин или пароль", ButtonEnum.Ok, Icon.Info)
                    .ShowDialog(win);
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void PasswordTbx_OnKeyUp(object? sender, KeyEventArgs e)
    {
        PasswordPbx.Text = PasswordTbx.Text;
    }

    private void PasswordPbx_OnKeyUp(object? sender, KeyEventArgs e)
    {
        PasswordTbx.Text = PasswordPbx.Text;
    }

    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigation.Content = new Registration();
    }
}