using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LoginSystem
{

	public class OnSignUpEventArgs : EventArgs
	{

		private string mFirstName;
		private string mEmailAddres;
		private string mPassword;

		public string FirstName
		{
			get { return mFirstName; }
			set { mFirstName = value; }
		}

		public string Email
		{
			get { return mEmailAddres; }
			set { mEmailAddres = value; }
		}

		public string Password
		{
			get { return mPassword; }
			set { mPassword = value; }
		}

		public OnSignUpEventArgs(string firstName, string email, string password) : base()
		{
			FirstName = firstName;
			Email = email;
			Password = password;
		}

	}

	class dialog_SignUp : DialogFragment
	{

		private EditText mTxtFristName;
		private EditText mTxtEmail;
		private EditText mTxtPassword;
		private Button mBtnEmailSignUp;

		public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.dialog_sign_up, container, false);

			mTxtFristName = view.FindViewById<EditText> (Resource.Id.txtFirstName);
			mTxtEmail = view.FindViewById<EditText> (Resource.Id.txtEmail);
			mTxtPassword = view.FindViewById<EditText> (Resource.Id.txtPassword);
			mBtnEmailSignUp = view.FindViewById<Button> (Resource.Id.btnDialogEmail);


			mBtnEmailSignUp.Click += MBtnEmailSignUp_Click;

			return view;
		}

		void MBtnEmailSignUp_Click (object sender, EventArgs e)
		{
			//user has clicked sign up button
			mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFristName.Text, mTxtEmail.Text, mTxtPassword.Text));
			this.Dismiss ();
		}

		//override onactivitycreated
		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);//sets the title bar to invisible
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;//set the animation
		}
	}
}

