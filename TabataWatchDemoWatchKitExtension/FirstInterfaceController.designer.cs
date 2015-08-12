// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TabataWatchDemoWatchKitExtension
{
	[Register ("FirstInterfaceController")]
	partial class FirstInterfaceController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceGroup containerGroup { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceButton workoutButton { get; set; }

		[Action ("startWorkout_Tap:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void startWorkout_Tap (WatchKit.WKInterfaceButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (containerGroup != null) {
				containerGroup.Dispose ();
				containerGroup = null;
			}
			if (workoutButton != null) {
				workoutButton.Dispose ();
				workoutButton = null;
			}
		}
	}
}
