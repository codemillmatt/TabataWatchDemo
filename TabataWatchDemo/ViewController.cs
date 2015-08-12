using System;
using System.Timers;

using UIKit;
using TabataPCL;

namespace TabataWatchDemo
{
	public partial class ViewController : UIViewController
	{
		Tabata _currentTabata;
		Timer _tabataTimer;

		UIColor workColor = UIColor.FromRGB (208, 2, 27);
		UIColor restColor = UIColor.FromRGB (130, 232, 160);

		public ViewController (IntPtr handle) : base (handle)
		{			
			_tabataTimer = new Timer ();
			_tabataTimer.Interval = 1000;
			_tabataTimer.Elapsed += ElapsedEvent;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			_currentTabata = AppDelegate.CurrentTabata;
			_currentTabata.ResetTabata ();
			timeLeftLabel.Text = _currentTabata.WorkTime.ToString ();
		}
			
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ResetThumbs ();

			var backColor = View.BackgroundColor;

			// Perform any additional setup after loading the view, typically from a nib.
			startStopButton.TouchUpInside += (sender, e) => {	
				startStopButton.Hidden = true;
				if (_currentTabata.ShouldStopTabata) {
					ResetThumbs();
					_currentTabata.ResetTabata ();
					timeLeftLabel.Text = _currentTabata.CurrentTimeRemainingFormat;
					statusLabel.Text = "Work";
					View.BackgroundColor = workColor;
				}

				if (_currentTabata.IsRunning) {
					_currentTabata.ChangePhase ();
					_tabataTimer.Stop ();
				} else {
					View.BackgroundColor = workColor;
					_currentTabata.ChangePhase ();
					_tabataTimer.Start ();
				}
			};

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void ElapsedEvent (object sender, ElapsedEventArgs e)
		{		
			_currentTabata.CalculateTabata ();

			if (_currentTabata.ShouldStopTabata) {
				_tabataTimer.Stop ();

				InvokeOnMainThread (() => {
					ColorThumb(_currentTabata.CurrentSet);
					View.BackgroundColor = UIColor.Orange;
					timeLeftLabel.Text = "0";
					statusLabel.Text = "Done!";
					startStopButton.Hidden = false;
				});
			} else {

				InvokeOnMainThread (() => {
					if (_currentTabata.InWorkPhase) {
						View.BackgroundColor = workColor;
						statusLabel.Text = "Work";
					} else {
						View.BackgroundColor = restColor;
						statusLabel.Text = "Rest";
						ColorThumb(_currentTabata.CurrentSet);
					}

					timeLeftLabel.Text = _currentTabata.CurrentTimeRemainingFormat;
				});
			}
		}

		private void ResetThumbs() {
			var thumbImage = UIImage.FromBundle ("Thumb");
			thumb1.Image = thumbImage;
			thumb2.Image = thumbImage;
			thumb3.Image = thumbImage;
			thumb4.Image = thumbImage;
			thumb5.Image = thumbImage;
			thumb6.Image = thumbImage;
			thumb7.Image = thumbImage;
			thumb8.Image = thumbImage;
			thumb9.Image = thumbImage;
		}

		private void ColorThumb(int currentSet) {
			InvokeOnMainThread (() => {
				var thumbImage = UIImage.FromBundle ("RedThumb");
				switch (currentSet) {
				case 1:
					thumb1.Image = thumbImage;
					break;
				case 2:
					thumb2.Image = thumbImage;
					break;
				case 3:
					thumb3.Image = thumbImage;
					break;
				case 4:
					thumb4.Image = thumbImage;
					break;
				case 5:
					thumb5.Image = thumbImage;
					break;
				case 6:
					thumb6.Image = thumbImage;
					break;
				case 7:
					thumb7.Image = thumbImage;
					break;
				case 8:
					thumb8.Image = thumbImage;
					break;
				case 9: 
					thumb9.Image = thumbImage;
					break;
				}
			});
		}
			
	}
}

