using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSandboxMaui;

public partial class TestListView : ContentPage
{
    private List<string> items = new List<string>();
    
    public TestListView()
    {
        InitializeComponent();
        for(var i = 0; i < 10000; i++)
        {
            this.items.Add($"Item {i}");
        }
        this.TestView.ItemsSource = this.items;
    }
}