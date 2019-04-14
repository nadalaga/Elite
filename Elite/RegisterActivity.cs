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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using DataAccess;
namespace Elite
{
    [Activity(Label = "Register")]
    public class RegisterActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_registertoolbar);
            Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += btnBackClickEvent;

            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += btnRegisterClick;
           /* var editToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(editToolbar);
            SupportActionBar.Title = "Register";

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);*/

        }

        public void btnRegisterClick(object sender, EventArgs e) {
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "elite.db";
            var dbFullPath = System.IO.Path.Combine(dbFolder, fileName);
            UserService objUserService = new UserService(dbFullPath);
            User objUser = new User();
            objUser.email = "alan@athina.global";
            objUser.name = "Alan Walker";
            objUser.username = "alan";
            objUser.password = "123455";
            objUser.iduser = 1;
            objUser.phone = "0224161271";
            objUser.address = "27 Selwyn Rd";

            objUserService.user = objUser;
            objUserService.Insert();

        }
        public void btnBackClickEvent(object sender, EventArgs e) {
            Intent objLoginIntent = new Intent(this, typeof(LoginActivity));
            StartActivity(objLoginIntent);
        }
       /* public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }*/
    }

  
}