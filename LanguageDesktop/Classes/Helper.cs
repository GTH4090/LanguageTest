using Avalonia.Controls;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace LanguageDesktop.Classes;
using LanguageDesktop.Models;

public class Helper
{
    public static LanguageContext Db = new LanguageContext();

    public static Window win = null;
    
    public static ContentControl Navigation = null;

    public static void Error(string err = "Ошибка подключения к БД")
    {
        MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", err, ButtonEnum.Ok, Icon.Error).ShowDialog(win);
    }
}