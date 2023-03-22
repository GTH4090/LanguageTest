using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
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
            List<Client> clients = Db.Clients.Include(el => el.Gender).ToList();
            

            if (GenderCbx.SelectedIndex == 1)
            {
                clients = clients.Where(el => el.Genderid == 1).ToList();
            }
            if (GenderCbx.SelectedIndex == 2)
            {
                clients = clients.Where(el => el.Genderid == 2).ToList();
            }

            if (SearchTbx.Text != null && SearchTbx.Text.Length > 2)
            {
                clients = clients.Where(el =>
                    el.Firstname.Contains(SearchTbx.Text) || el.Lastname.Contains(SearchTbx.Text) ||
                    el.Surname.Contains(SearchTbx.Text) || el.Phonenum.Contains(SearchTbx.Text) ||
                    el.Email.Contains(SearchTbx.Text)).ToList();
            }

            if (FromDp.SelectedDate != null && ToDp.SelectedDate != null)
            {
                clients = clients.Where(el => el.Birthdate >= DateOnly.FromDateTime(FromDp.SelectedDate.Value) && el.Birthdate <= DateOnly.FromDateTime(ToDp.SelectedDate.Value))
                    .ToList();
            }



            ClientDataGrid.Items = clients;
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

    private void SearchTbx_OnKeyUp(object? sender, KeyEventArgs e)
    {
        LoadData();
    }

    private void FromDp_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        LoadData();
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigation.Content = new ClientEdit(-1);
    }

    private void EditBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (ClientDataGrid.SelectedItem != null)
        {
            var item = ClientDataGrid.SelectedItem as Client;
            Navigation.Content = new ClientEdit(item.Id);
        }
        
    }

    private async void DelBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (ClientDataGrid.SelectedItem != null)
            {
                if (await MessageBoxManager
                        .GetMessageBoxStandardWindow("Точно?", "Вы уверены?", ButtonEnum.YesNo, Icon.Question)
                        .ShowDialog(win) == ButtonResult.Yes)
                {
                    var item = ClientDataGrid.SelectedItem as Client;
                    Db.Clients.Remove(item); 
                    Db.SaveChanges(); 
                    LoadData();
                }
                
                
                
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }
}