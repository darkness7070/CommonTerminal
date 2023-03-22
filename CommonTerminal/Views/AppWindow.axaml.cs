using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Schema;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommonTerminal.Models;
using Newtonsoft.Json;

namespace CommonTerminal.Views;

public partial class AppWindow : Window
{
    public AppWindow()
    {
        InitializeComponent();
    }
    public AppWindow(AngelAPI.Response.Application item)
    {
        InitializeComponent();
        GetData(item.Id);
    }

    private async Task GetData(int id)
    {
        HttpClient client = new();
        HttpResponseMessage response;
        try
        {
            response = await client.GetAsync($"http://localhost:5175/general/application?id=" + id);

        }
        catch (Exception ex)
        {
            //TODO: окно ошибка
            return;
        }
        var rawData = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<AngelAPI.Response.InfoApplication>(rawData);
        dataGrid.Items = data.Visitors.ToList();
        boxPurpose.Text = data.Application.IdPurposeNavigation.Name;
        boxSubdivision.Text = data.Application.IdSubdivisionNavigation.IdSubdivisionNavigation.Name;
        boxWorker.Text = data.Application.IdSubdivisionNavigation.IdWorkerNavigation.Fullname;
        boxValidaty.Text = data.Application.ValidatyFrom.ToString("M") +" - " + data.Application.ValidatyTo.ToString("M");
        boxName.Text += " " + data.Application.Id;
        //Console.WriteLine(JsonConvert.SerializeObject(data));
    }
}