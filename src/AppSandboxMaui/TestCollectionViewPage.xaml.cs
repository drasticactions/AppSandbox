using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSandboxMaui;

public partial class TestCollectionViewPage : ContentPage
{
    private List<string> items = new List<string>();
    
    public TestCollectionViewPage()
    {
        InitializeComponent();
        for(var i = 0; i < 10000; i++)
        {
            this.items.Add($"Item {i}");
        }
        this.TestCollection.ItemsSource = this.items;
    }
}