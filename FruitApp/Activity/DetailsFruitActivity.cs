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
using FruitApp.Domain;
using FruitApp.API;
using Android.Content.Res;


namespace FruitApp.Activity
{
    [Activity(Label = "Details Fruit")]
    public class DetailsFruitActivity : AppCompatActivity
    {
        private Fruit mFruit;
        bool isEditable = false;
        int[] resources = new int[] {
                Resource.Id.fruit_id_edittext,
                Resource.Id.name_edittext,
                Resource.Id.origin_edittext,
                Resource.Id.largest_country_edittext,
                Resource.Id.product_in_billions_edittext
            };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_details_fruit);

            // Create your application here
        }

        protected override void OnStart()
        {
            base.OnStart();

            // checks that the id is passed
            string id;
            id = Intent.GetStringExtra("Id");
                Toast.MakeText(this, "This is fruit number " + id, ToastLength.Long).Show();

            // set URL
            string url = Resources.GetString(Resource.String.fruit_api_url);
            UrlSingleton.Create(url);

            // FruitAPI
            FruitAPI api = new FruitAPI();
            mFruit = api.Get<Fruit>(id);

            EditEnable(false);
            SetElementOfDetailsFruit(mFruit);


            Button btn = FindViewById<Button>(Resource.Id.button);
            btn.Text = "EDIT";
            btn.Click += OnClic;


        }

        private void OnClic (object sender, EventArgs eventArgs)
        {
            Button btn = FindViewById<Button>(Resource.Id.button);
            if (isEditable)
            {
                GetElementFromDetailsFruit();
                Toast.MakeText(this, "ok", ToastLength.Long).Show();
                btn.Text = "EDIT";
                EditEnable(!isEditable);
                isEditable = !isEditable;

            }
            else
            {
                btn.Text = "SAVE";
                EditEnable(!isEditable);
                isEditable = !isEditable;

            }

        }

        private void SetElementOfDetailsFruit(Fruit mFruit)
        {
            FindViewById<TextView>(Resource.Id.fruit_id_edittext).Text = mFruit.Id;
            FindViewById<TextView>(Resource.Id.name_edittext).Text = mFruit.Name;
            FindViewById<TextView>(Resource.Id.origin_edittext).Text = mFruit.Origin;
            FindViewById<TextView>(Resource.Id.largest_country_edittext).Text = mFruit.LargestCountry;
            FindViewById<TextView>(Resource.Id.product_in_billions_edittext).Text = mFruit.ProductionInBillions.ToString();

        }

        private void GetElementFromDetailsFruit()
        {
            mFruit.Id = FindViewById<TextView>(Resource.Id.name_edittext).Text;
            mFruit.Name = FindViewById<TextView>(Resource.Id.name_edittext).Text;
            mFruit.Origin = FindViewById<TextView>(Resource.Id.origin_edittext).Text;
            mFruit.LargestCountry = FindViewById<TextView>(Resource.Id.largest_country_edittext).Text;
            mFruit.ProductionInBillions = decimal.Parse(FindViewById<TextView>(Resource.Id.product_in_billions_edittext).Text);
        }

        private void EditEnable(bool b)
        {
            TextView[] textViews = new TextView[resources.Length];
            for (int i = 0; i < resources.Length; i++)
            {
                textViews[i] = FindViewById<TextView>(resources[i]);
                textViews[i].Enabled = b;
            }
        }
    }
}