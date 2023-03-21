using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using static LanguageDesktop.Classes.Helper;
using LanguageDesktop.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace LanguageDesktop.Pages;

public partial class Registration : UserControl
{
    public Registration()
    {
        InitializeComponent();
    }

    

    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (PasswordPbx.Text == Password2Pbx.Text)
            {
                User user = new User();
                user.Password = PasswordPbx.Text;
                user.Login = LoginTbx.Text;
                Db.Users.Add(user);
                Db.SaveChanges();
                Navigation.Content = new Auth();
            }
            else
            {
                MessageBoxManager
                    .GetMessageBoxStandardWindow("Внимание", "Пароли не совпадают", ButtonEnum.Ok, Icon.Info)
                    .ShowDialog(win);
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }
}