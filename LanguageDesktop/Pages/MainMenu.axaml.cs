using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;

namespace LanguageDesktop.Pages;

using static LanguageDesktop.Classes.Helper;
using LanguageDesktop.Models;

public partial class MainMenu : UserControl
{
    private void LoadCbx()
    {
        var items = Db.Genders.ToList();
        items.Insert(0, new Gender(){Name = "Все"});
        GenderCbx.Items = items;

    }
    private void LoadData()
    {
        try
        {
            if (GenderCbx.SelectedIndex == 0)
            {
                
                ClientDataGrid.Items = Db.Clients.Include(el => el.Gender).ToList();
            }

            if (GenderCbx.SelectedIndex == 1)
            {
                ClientDataGrid.Items = Db.Clients.Include(el => el.Gender).Where(el => el.Genderid == 1).ToList();
            }
            if (GenderCbx.SelectedIndex == 2)
            {
                ClientDataGrid.Items = Db.Clients.Include(el => el.Gender).Where(el => el.Genderid == 2).ToList();
            }
            
        }
        catch (Exception e)
        {
            Error();
        }
    }
    public MainMenu()
    {
        InitializeComponent();
        LoadCbx();
        GenderCbx.SelectedIndex = 0;
    }


    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        LoadData();
    }
}