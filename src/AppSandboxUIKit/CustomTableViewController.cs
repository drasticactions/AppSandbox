using Foundation;
using UIKit;

namespace AppSandboxUIKit;

public class CustomTableViewController : UITableViewController
{
    public CustomTableViewController()
    {
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Register custom cell classes
        TableView.RegisterClassForCellReuse(typeof(CustomTableViewCell1), "Cell1");
        TableView.RegisterClassForCellReuse(typeof(CustomTableViewCell2), "Cell2");
        TableView.RowHeight = UITableView.AutomaticDimension;
        TableView.EstimatedRowHeight = 100f;
        TableView.Source = new CustomTableViewSource();
    }

    // Custom table view source class
    private class CustomTableViewSource : UITableViewSource
    {
        private int number;
        
        public CustomTableViewSource()
        {
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
            // Determine which cell to return based on the index path
            if (indexPath.Row % 2 == 0)
            {
                var cell = tableView.DequeueReusableCell("Cell1", indexPath) as CustomTableViewCell1;
                // Configure cell1 with data
                cell.TitleLabel.Text = "Cell 1";
                cell.DescriptionLabel.Text = "This is a custom cell with variable height.";

                return cell;
            }
            else
            {
                var cell = tableView.DequeueReusableCell("Cell2", indexPath) as CustomTableViewCell2;
                // Configure cell2 with data
                cell.TitleLabel.Text = "Cell 2";
                cell.DescriptionLabel.Text = "Another custom cell with a different height.";

                return cell;
            }
        }

        // public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        // {
        //     var cell = this.GetCell(tableView, indexPath);
        //     
        //     // Determine the height of the cell based on the index path
        //     if (indexPath.Row % 2 == 0)
        //     {
        //         return 100f; // Set the height for cell1
        //     }
        //     else
        //     {
        //         return 150f; // Set the height for cell2
        //     }
        // }
    }
}

// Custom cell classes
public class CustomTableViewCell1 : UITableViewCell
{
    public UILabel TitleLabel { get; set; }
    public UILabel DescriptionLabel { get; set; }

    public CustomTableViewCell1(IntPtr handle) : base(handle)
    {
        SelectionStyle = UITableViewCellSelectionStyle.None;
        ContentView.BackgroundColor = UIColor.White;

        TitleLabel = new UILabel()
        {
            Font = UIFont.BoldSystemFontOfSize(50f),
            TextColor = UIColor.Black,
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        DescriptionLabel = new UILabel()
        {
            Font = UIFont.SystemFontOfSize(14f),
            TextColor = UIColor.Gray,
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        ContentView.AddSubviews(TitleLabel, DescriptionLabel);

        // Add constraints for TitleLabel and DescriptionLabel
        NSLayoutConstraint.ActivateConstraints(new[]
        {
            TitleLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, 10f),
            TitleLabel.LeftAnchor.ConstraintEqualTo(ContentView.LeftAnchor, 10f),
            TitleLabel.RightAnchor.ConstraintEqualTo(ContentView.RightAnchor, -10f),

            DescriptionLabel.TopAnchor.ConstraintEqualTo(TitleLabel.BottomAnchor, 5f),
            DescriptionLabel.LeftAnchor.ConstraintEqualTo(ContentView.LeftAnchor, 10f),
            DescriptionLabel.RightAnchor.ConstraintEqualTo(ContentView.RightAnchor, -10f),
            DescriptionLabel.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor, -10f),
        });
    }
    
    // public CustomTableViewCell1(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
    // {
    //     
    // }
}

public class CustomTableViewCell2 : UITableViewCell
{
    public UILabel TitleLabel { get; set; }
    public UILabel DescriptionLabel { get; set; }

    public CustomTableViewCell2(IntPtr handle) : base(handle)
    {
        SelectionStyle = UITableViewCellSelectionStyle.None;
        ContentView.BackgroundColor = UIColor.White;

        TitleLabel = new UILabel()
        {
            Font = UIFont.BoldSystemFontOfSize(18f),
            TextColor = UIColor.Black,
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        DescriptionLabel = new UILabel()
        {
            Font = UIFont.SystemFontOfSize(14f),
            TextColor = UIColor.Gray,
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        ContentView.AddSubviews(TitleLabel, DescriptionLabel);

        // Add constraints for TitleLabel and DescriptionLabel
        NSLayoutConstraint.ActivateConstraints(new[]
        {
            TitleLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, 10f),
            TitleLabel.LeftAnchor.ConstraintEqualTo(ContentView.LeftAnchor, 10f),
            TitleLabel.RightAnchor.ConstraintEqualTo(ContentView.RightAnchor, -10f),

            DescriptionLabel.TopAnchor.ConstraintEqualTo(TitleLabel.BottomAnchor, 5f),
            DescriptionLabel.LeftAnchor.ConstraintEqualTo(ContentView.LeftAnchor, 10f),
            DescriptionLabel.RightAnchor.ConstraintEqualTo(ContentView.RightAnchor, -10f),
            DescriptionLabel.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor, -10f),
        });
    }

    // public CustomTableViewCell2(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
    // {
    //     
    // }
}