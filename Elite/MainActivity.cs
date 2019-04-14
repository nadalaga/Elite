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
using Android.Support.V4.Widget;
using Xamarin.Essentials;
using Android.Support.Design.Widget;


namespace Elite
{
    [Activity(Label = "Main", Theme = "@style/AppTheme")]
    public class MainActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


      //      Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            BottomNavigationView bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            //Button btnBack = FindViewById<Button>(Resource.Id.btnBack);
            //btnBack.Click += btnBackClick;
            LoadFragment(Resource.Id.navigation_home);

        }
        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        public bool LoadFragment(int id)
        {

            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.navigation_home:

                    fragment = new FragmentHome(Intent.GetStringExtra("username"));
                    break;
                case Resource.Id.navigation_dashboard:

                    fragment = new FragmentProfile();
                    break;
                case Resource.Id.navigation_notifications:

                    fragment = new FragmentOrders();
                    break;
            }

            if (fragment == null)
                return false;
            else
            {
                SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.HomeContent, fragment)
                .Commit();
                return true;
            }
        }


        public void btnBackClick(object sender, EventArgs e)
        {
            Intent objBackIntent = new Intent(this, typeof(LoginActivity));
            StartActivity(objBackIntent);
        }



      

     

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}