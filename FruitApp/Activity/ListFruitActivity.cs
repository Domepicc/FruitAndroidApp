using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.AppCompat.App;


namespace FruitApp.Activity
{

    [Activity(Label = "List Fruit", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class ListFruitActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_list_fruit);

            // Create your application here
        }
    }


}