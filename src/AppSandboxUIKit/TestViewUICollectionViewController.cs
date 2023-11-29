using CoreGraphics;
using Foundation;
using UIKit;

namespace AppSandboxUIKit;

public class TestViewUICollectionViewController : UIViewController, IUICollectionViewDataSource, IUICollectionViewDelegate
{
    private UICollectionView collectionView;
    private List<string> items = new List<string>();
    private MauiContext context;
    
    public TestViewUICollectionViewController(MauiContext context)
    {
        this.context = context;
        for(var i = 0; i < 10000; i++)
        {
            this.items.Add($"Item {i}");
        }
    }
    
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Create a UICollectionViewFlowLayout
        var flowLayout = new UICollectionViewFlowLayout
        {
            ScrollDirection = UICollectionViewScrollDirection.Vertical,
            MinimumInteritemSpacing = 0,
            MinimumLineSpacing = 0,
            ItemSize = new CGSize(View.Bounds.Width, 50),
        };

        // Create a UICollectionView with the specified layout
        collectionView = new UICollectionView(View.Bounds, flowLayout);
        collectionView.RegisterClassForCell(typeof(TestViewUICollectionViewCell), "CustomCell1");
        collectionView.DataSource = this;
        collectionView.Delegate = this;

        // Add the UICollectionView to the view controller's view
        View.AddSubview(collectionView);
    }

    public override void ViewWillAppear(bool animated)
    {
        base.ViewWillAppear(animated);

        // Update the frame of the UICollectionView to fill the view
        collectionView.Frame = View.Bounds;
    }

    public IntPtr GetItemsCount(UICollectionView collectionView, IntPtr section)
    {
        return this.items.Count();
    }

    public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
    {
        var cell = collectionView.DequeueReusableCell("CustomCell1", indexPath) as TestViewUICollectionViewCell;
        cell!.UpdateCell(this.context, this.items[indexPath.Row]);
        return cell;
    }
}