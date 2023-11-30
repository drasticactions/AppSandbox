using AppSandboxMaui;
using Drastic.PureLayout;
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace AppSandboxUIKit;

public class ImageTableViewController : UITableViewController
{
    private MauiContext context;
    
    public ImageTableViewController(MauiContext context)
    {
        this.context = context;
    }
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Register custom cell classes
        TableView.RegisterClassForCellReuse(typeof(ImageViewCell1), "Cell1");
        TableView.RowHeight = UITableView.AutomaticDimension;
        TableView.EstimatedRowHeight = 200f;
        TableView.Source = new ImageTableViewDataSource(this.context);
    }
}

public class ImageTableViewDataSource : UITableViewSource
{
    private int number;
    private Random random = new();
    private MauiContext context;
    
    public ImageTableViewDataSource(MauiContext context)
    {
        this.context = context;
        this.number = 50;
    }
        
    public override nint NumberOfSections(UITableView tableView)
    {
        // Return the number of sections in your table view
        return 1;
    }

    public override nint RowsInSection(UITableView tableview, nint section)
    {
        // Return the number of rows in your section
        return number; // You can adjust this based on your data
    }
        
    public override void WillDisplay (UITableView tableView, UITableViewCell cell, NSIndexPath     indexPath)
    {

        if (indexPath.Row == this.number - 1) {
            number += 50;
            tableView.ReloadData();
        }
    }

    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
        var cell = tableView.DequeueReusableCell("Cell1", indexPath) as ImageViewCell1;
        if (!cell.IsInitialized)
        {
            var options = new ImageViewContainerOptions();
            var imageNum = this.random.Next(1, 4);
            for (var i = 0; i < imageNum; i++)
            {
                options.Urls.Add($"https://picsum.photos/seed/{this.random.Next(1, 1000)}/200/200");
            }
            cell!.SetupCell(this.context, options);
        }
        return cell;
    }

    // public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
    // {
    //     return 200f;
    // }
}

public class ImageViewCell1 : UITableViewCell
{
    private ImageViewContainer? view;
    
    public ImageViewCell1(IntPtr handle) : base(handle)
    {
    }

    public bool IsInitialized => this.view is not null;

    public void SetupCell(MauiContext context, ImageViewContainerOptions options)
    {
        if (this.view is null)
        {
            this.view = new ImageViewContainer();
            var uiview = this.view.ToPlatform(context);
            ContentView.AddSubview(uiview);
            this.TranslatesAutoresizingMaskIntoConstraints = false;
            uiview.TranslatesAutoresizingMaskIntoConstraints = false;
            uiview.AutoPinEdgesToSuperviewEdges();
        }
        
        this.view.UpdateOptions(options);
    }
}