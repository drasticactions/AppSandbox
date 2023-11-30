using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSandboxMaui;

public partial class ImageViewContainer : ContentView
{
    public ImageViewContainer()
    {
        InitializeComponent();
    }

    public void UpdateOptions(ImageViewContainerOptions options)
    {
        this.BindingContext = options;
    }
}

public class ImageViewContainerOptions
{
    public List<string> Urls { get; } = new();

    public string Url => Urls.FirstOrDefault();
}