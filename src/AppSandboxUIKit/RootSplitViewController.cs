using AppSandboxMaui;
using Microsoft.Maui.Platform;
using UIKit;

namespace AppSandboxUIKit;

public class RootSplitViewController : UISplitViewController
    {
        private SidebarViewController sidebar;
        private BasicViewController testViewController;
        private UIViewController testListViewController;
        private UIViewController testCollectionViewController;
        private UINavigationController navController;
        private MauiContext context;
        public RootSplitViewController(MauiContext context)
            : base(UISplitViewControllerStyle.DoubleColumn)
        {
            this.context = context;
            var items = new List<SidebarListItem>();
            items.Add(new SidebarListItem() { Name = "Home" });
            items.Add(new SidebarListItem() { Name = "Maui List View" });
            items.Add(new SidebarListItem() { Name = "Maui Collection View" });
            this.sidebar = new SidebarViewController(items);
            this.testViewController = new BasicViewController();
            this.testListViewController = new TestListView().ToUIViewController(this.context);
            this.testCollectionViewController = new TestCollectionViewPage().ToUIViewController(this.context);
            this.navController = new UINavigationController(this.testCollectionViewController);
            this.sidebar.OnItemSelected += this.Sidebar_OnItemSelected;
            this.PreferredDisplayMode = UISplitViewControllerDisplayMode.OneBesideSecondary;
            this.SetViewController(this.sidebar, UISplitViewControllerColumn.Primary);
            this.SetViewController(this.navController, UISplitViewControllerColumn.Secondary);

#if !TVOS
            this.PrimaryBackgroundStyle = UISplitViewControllerBackgroundStyle.Sidebar;
#endif
        }

        private void Sidebar_OnItemSelected(object? sender, SidebarSelectionEventArgs e)
        {
            this.navController.ViewControllers = null;
            GC.Collect();
            switch (e.Item.Name)
            {
                case "Home":
                    this.navController.ViewControllers = new UIViewController[1] { this.testViewController };
                    this.navController.PopToRootViewController(false);
                    break;
                case "Maui List View":
                    this.navController.ViewControllers = new UIViewController[1] { this.testListViewController };
                    this.navController.PopToRootViewController(false);
                    break;
                case "Maui Collection View":
                    this.navController.ViewControllers = new UIViewController[1] { this.testCollectionViewController };
                    this.navController.PopToRootViewController(false);
                    break;
            }

#if IOS
            this.ShowColumn(UISplitViewControllerColumn.Secondary);
#endif
        }
    }
    
public class BasicViewController : UIViewController
{
    public BasicViewController()
    {
        this.View!.AddSubview(new UILabel(View!.Frame)
        {
#if !TVOS
            BackgroundColor = UIColor.SystemBackground,
#endif
            TextAlignment = UITextAlignment.Center,
            Text = "Hello, Apple!",
            AutoresizingMask = UIViewAutoresizing.All,
        });
    }
}