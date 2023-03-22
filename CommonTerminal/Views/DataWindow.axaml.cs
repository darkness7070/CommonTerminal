using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CommonTerminal.Models;
using CommonTerminal.ViewModels;
using Newtonsoft.Json;

namespace CommonTerminal.Views;

public partial class DataWindow : Window
{
    public DataWindow()
    {
        InitializeComponent();
        GetData();
    }

    private async Task GetData()
    {
        HttpClient client = new();
        var response = await client.PostAsJsonAsync("http://localhost:5175/general/applications",new AngelAPI.Request.Applications()
            {
                token = "",
                isAdmin = true
            }
        );
        var applications =
            JsonConvert.DeserializeObject<List<AngelAPI.Response.Application>>(
                await response.Content.ReadAsStringAsync());
        dataGrid.Items = applications.ToList();
        Console.WriteLine(JsonConvert.SerializeObject(applications));
    }

    private void btn_CheckApp(object? sender, RoutedEventArgs e)
    {
        var item = (AngelAPI.Response.Application)dataGrid.SelectedItem;
        if (item == null)
        {
            //TODO: Окно ошибка
            return;
        }
        AppWindow window = new(item)
        {
        };
        window.Show();
    }
}