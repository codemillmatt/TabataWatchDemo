using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using WatchKit;
using System.Timers;
using TabataPCL;

namespace TabataWatchDemoWatchKitExtension
{
	partial class FirstInterfaceController : WatchKit.WKInterfaceController
	{		
		Tabata _currentTabata;
		Timer _tabataTimer;

		UIColor workColor = UIColor.FromRGB (208, 2, 27);
		UIColor restColor = UIColor.FromRGB (130, 232, 160);

		UIStringAttributes _workoutStringAttrs;
		UIStringAttributes _restStringAttrs;
		UIStringAttributes _stopStringAttrs;

		
		public FirstInterfaceController (IntPtr handle) : base (handle)
		{			
			_workoutStringAttrs = new UIStringAttributes () { 
				ForegroundColor = workColor,
				Font = UIFont.SystemFontOfSize(112f)
			};

			_restStringAttrs = new UIStringAttributes () { 
				ForegroundColor = restColor,
				Font = UIFont.SystemFontOfSize(112f)	
			};

			_stopStringAttrs = new UIStringAttributes() {
				ForegroundColor = UIColor.White,
				Font = UIFont.SystemFontOfSize(78f, UIFontWeight.Regular)
			};
					
			_tabataTimer = new Timer ();
			_tabataTimer.Interval = 1000;
			_tabataTimer.Elapsed += ElapsedEvent;
		}

		public override void WillActivate ()
		{
			base.WillActivate ();

			WKInterfaceController.OpenParentApplication(new NSDictionary(), (reply, error) => {
				_currentTabata = new Tabata(
					int.Parse(reply["restTime"].ToString()), 
					int.Parse(reply["workTime"].ToString()), 
					int.Parse(reply["sets"].ToString())
				);
			});

			workoutButton.SetTitle (new NSAttributedString ("Go!", _stopStringAttrs));
			workoutButton.SetBackgroundColor (UIColor.Clear);


		}

		partial void startWorkout_Tap (WatchKit.WKInterfaceButton sender)
		{				
			var time = new NSAttributedString (_currentTabata.CurrentTimeRemainingFormat, _workoutStringAttrs);
			workoutButton.SetTitle (time);

			containerGroup.SetBackgroundImage(string.Empty);

			_currentTabata.ChangePhase();

			_tabataTimer.Start ();
		}

		private void ElapsedEvent (object sender, ElapsedEventArgs e)
		{		
			_currentTabata.CalculateTabata ();


			if (_currentTabata.ShouldStopTabata) {
				_tabataTimer.Stop ();

				var currentImage = string.Format ("WorkRect{0}", _currentTabata.CurrentSet - 1);

				containerGroup.SetBackgroundImage (currentImage);

				_currentTabata.ChangePhase ();
				_currentTabata.ResetTabata ();

				workoutButton.SetTitle (new NSAttributedString ("Go!", _stopStringAttrs));

			} else {		
				NSAttributedString time;

				if (_currentTabata.InWorkPhase) {
					time = new NSAttributedString (_currentTabata.CurrentTimeRemainingFormat, _workoutStringAttrs);

					if (_currentTabata.ShouldChangePhase) {
						
					}

				} else {
					time = new NSAttributedString (_currentTabata.CurrentTimeRemainingFormat, _restStringAttrs);

					if (_currentTabata.ShouldChangePhase) {
						var currentImage = string.Format ("WorkRect{0}", _currentTabata.CurrentSet - 1);

						containerGroup.SetBackgroundImage (currentImage);
					}

				}
					
				workoutButton.SetTitle (time);
			}
		}

	}
}
