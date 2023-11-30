using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSandboxMaui;

public partial class ImageViewContainerViewCell : ViewCell
{
    public ImageViewContainerViewCell()
    {
        InitializeComponent();
    }
    
    public void UpdateOptions(ImageViewContainerOptions options)
    {
        this.BindingContext = options;
    }
}