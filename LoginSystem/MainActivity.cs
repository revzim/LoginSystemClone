using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace LoginSystem
{
	[Activity (Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		
		private Button mBtnSignUp;
		private ProgressBar mProgressBar;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//reference to button
			mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
			mProgressBar = FindViewById<ProgressBar> (Resource.Id.progressBar1);
			mBtnSignUp.Click += MBtnSignUp_Click;
		
		}

		void MBtnSignUp_Click (object sender, EventArgs e)
		{
			//Pull up the dialog
			FragmentTransaction transaction = FragmentManager.BeginTransaction();

			dialog_SignUp signUpDialog = new dialog_SignUp();

			signUpDialog.Show (transaction, "dialog fragment");

			//signupdialog

			signUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;
		}

		void SignUpDialog_mOnSignUpComplete (object sender, OnSignUpEventArgs e)
		{
			mProgressBar.Visibility = ViewStates.Visible;
			Thread thread = new Thread (ActLikeRequest);
			thread.Start ();
			/*string userPassword = e.Password;
			string userEmail = e.Email;
			string userFirstName = e.FirstName;*/
		}

		private void ActLikeRequest()
		{
			
			Thread.Sleep (3000);

			//run on ui thread
			RunOnUiThread(() => {mProgressBar.Visibility = ViewStates.Invisible; } );
		}
	}
}


