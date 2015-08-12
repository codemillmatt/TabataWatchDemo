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

namespace TabataWatchDemo
{
	[Register ("SettingsDetailTableViewController")]
	partial class SettingsDetailTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField restTime { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton saveButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField setsText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField workTime { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (restTime != null) {
				restTime.Dispose ();
				restTime = null;
			}
			if (saveButton != null) {
				saveButton.Dispose ();
				saveButton = null;
			}
			if (setsText != null) {
				setsText.Dispose ();
				setsText = null;
			}
			if (workTime != null) {
				workTime.Dispose ();
				workTime = null;
			}
		}
	}
}
