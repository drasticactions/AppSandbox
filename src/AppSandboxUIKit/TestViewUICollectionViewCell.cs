using AppSandboxMaui;
using Microsoft.Maui.Platform;
using UIKit;

namespace AppSandboxUIKit;

public class TestViewUICollectionViewCell : UICollectionViewCell
{
    private TestView? view;
    
    public TestViewUICollectionViewCell(IntPtr handle) : base(handle)
    {
    }
    
    public void UpdateCell(MauiContext context, string text)
    {
        if (this.view is null)
        {
            this.view = new TestView();
            var view = this.view.ToPlatform(context);
            view!.Frame = this.ContentView.Bounds;
            this.ContentView.AddSubview(view);
        }
        
        this.view.UpdateText(text);
    }
}