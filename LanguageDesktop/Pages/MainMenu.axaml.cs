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
    private void LoadData()
    {
        try
        {
            ClientDataGrid.Items = Db.Clients.Include(el => el.Gender).ToList();
        }
        catch (Exception e)
        {
            Error();
        }
    }
    public MainMenu()
    {
        InitializeComponent();
        LoadData();
    }

    
}