using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DataAccess;

namespace Elite
{
    [Activity(Label = "Login", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_login);
            //Find the SignIN button from activity_login layout
           
           Button Signin = FindViewById<Button>(Resource.Id.btnLogin);
            Signin.Click += SignInClick;


            Button SignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            SignUp.Click += SignUpClick;

        }

        public bool checkValidation() {
            bool valid = true;
            EditText txtUserName = FindViewById<EditText>(Resource.Id.editUserName);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.editPassword);
            if (txtUserName.Text == "")
            {
                txtUserName.Error = "User Name can't be blank";
                valid = false;
            }
            if (txtPassword.Text == "")
            {
                txtPassword.Error = "Password can't be blank";
                valid = false;
            }
            return valid;
        }

        //Check whether user enters the username and password correctly
        //The method will return true if the username and password are correct otherwise it will return false
        public bool CheckLogin()
        {
            bool valid = false;
            //string username = "tester";
            //string password = "123456";

            EditText txtUserName = FindViewById<EditText>(Resource.Id.editUserName);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.editPassword);
            UserService objUserService = new UserService();
           
            // if (txtUserName.Text.Equals(username) && txtPassword.Text.Equals(password))
            if (objUserService.CheckLogin(txtUserName.Text,  txtPassword.Text) != null)
            {
                valid = true;
            }

            return valid;
        }

      
        public void SignUpClick(object sender, EventArgs e) {
            Intent objMainIntent = new Intent(this, typeof(RegisterActivity));
            StartActivity(objMainIntent);
        }
        //Add Onclick Event for Signin Button
        public void SignInClick(object sender,  EventArgs e) {
            if (checkValidation())
            {
                if (CheckLogin())
                {
                    Intent objMainIntent = new Intent(this, typeof(MainActivity));
                    EditText txtUserName = FindViewById<EditText>(Resource.Id.editUserName);
                    objMainIntent.PutExtra("username",txtUserName.Text);
                    StartActivity(objMainIntent);
                }
            }
        }
    }
}