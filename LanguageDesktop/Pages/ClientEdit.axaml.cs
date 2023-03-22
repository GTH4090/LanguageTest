using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using static LanguageDesktop.Classes.Helper;
using LanguageDesktop.Models;

namespace LanguageDesktop.Pages;

public partial class ClientEdit : UserControl

{
    private void LoadCbx()
    {
        try
        {
            GenderCbx.Items = Db.Genders.ToList();
        }
        catch (Exception e)
        {
            Error();
        }
    }
    int _id = 0;
    public ClientEdit(int id)
    {
        _id = id;
        InitializeComponent();
        LoadCbx();

        try
        {
            if (id == -1)
            {
                ClientSp.DataContext = new Client();
                GenderCbx.SelectedIndex = 0;
            
                BirthDp.SelectedDate = DateTime.Now;
            }
            else
            {
                ClientSp.DataContext = Db.Clients.FirstOrDefault(el => el.Id == id);
                
            }
        }
        catch (Exception e)
        {
            Error();
        }
        
    }

    public ClientEdit()
    {
        
    }

    

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (_id == -1)
            {
                (ClientSp.DataContext as Client).Regdate = DateOnly.FromDateTime(DateTime.Now);
                Db.Clients.Add(ClientSp.DataContext as Client);
            }

            Db.SaveChanges();
            Navigation.Content = new MainMenu();
        }
        catch (Exception exception)
        {
            Error();
        }
        
    }

    private void CancelBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigation.Content = new MainMenu();
    }
}