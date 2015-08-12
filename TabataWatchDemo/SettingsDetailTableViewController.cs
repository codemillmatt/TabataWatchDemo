using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TabataWatchDemo
{
	partial class SettingsDetailTableViewController : UITableViewController
	{
		public SettingsDetailTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			restTime.Text = AppDelegate.CurrentTabata.RestTime.ToString ();
			workTime.Text = AppDelegate.CurrentTabata.WorkTime.ToString ();
			setsText.Text = AppDelegate.CurrentTabata.NumberOfSets.ToString ();

			saveButton.TouchUpInside += (sender, e) => {
				AppDelegate.CurrentTabata.RestTime = int.Parse(restTime.Text);
				AppDelegate.CurrentTabata.WorkTime = int.Parse(workTime.Text);
				AppDelegate.CurrentTabata.NumberOfSets = int.Parse(setsText.Text);

				DismissModalViewController(true);
			};
		}
	}
}
