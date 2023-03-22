using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CommonTerminal.Models;
using CommonTerminal.ViewModels;
using Newtonsoft.Json;

namespace CommonTerminal.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void btn_Login(object? sender, RoutedEventArgs e)
    {
        if(String.IsNullOrWhiteSpace(boxCode.Text)) return;
        IsEnabled = false;
        HttpClient client = new();
        try
        {
            var response = await client.GetAsync($"http://localhost:5175/general/auth?code={boxCode.Text}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var employee =
                    JsonConvert.DeserializeObject<AngelAPI.Response.Employee>(
                        await response.Content.ReadAsStringAsync());
                if (employee.IdRole != 1)
                {
                    //TODO: окно ошибки
                    IsEnabled = true;
                    return;
                }
                DataWindow window = new()
                {
                    DataContext = new MainWindowViewModel(),
                };
                window.Show();
                Close();
                return;
            }
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //TODO: окно ошибки
                IsEnabled = true;
                return;
            }
        }
        catch(Exception ex)
        {
            //TODO: окно ошибки
            IsEnabled = true;
            return;
        }
    }
}