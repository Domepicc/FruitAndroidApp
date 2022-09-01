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
using System.Reflection;

namespace FruitApp.Activity
{
    [Activity(Label = "Details Fruit")]
    public class DetailsFruitActivity : AppCompatActivity
    {
        private Fruit mFruit;
        bool isEditable = false;

        TextView idTextView;
        TextView nameTextView;
        TextView orginTextView;
        TextView largestCountryTextView;
        TextView productInBillionsTextView;

        int[] resources = new int[] {
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


            // set URL
            string url = Resources.GetString(Resource.String.fruit_api_url);
            UrlSingleton.Create(url);
            FindAllTextView();

        }

        protected override void OnStart()
        {
            base.OnStart();

            // checks that the id is passed
            string id;
            id = Intent.GetStringExtra("id");
            Toast.MakeText(this, "This is fruit number " + id, ToastLength.Long).Show();

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
            Fruit fruitForPost = new Fruit();

            if (isEditable)
            {
                fruitForPost = GetElementFromDetailsFruit();
                FruitAPI api = new FruitAPI();
                api.Post<Fruit>(fruitForPost, fruitForPost.id);
                Toast.MakeText(this, $"edit: {fruitForPost.name}" , ToastLength.Long).Show();
                btn.Text = "EDIT";
            }
            else
            {
                btn.Text = "SAVE";
            }

            EditEnable(!isEditable);
            isEditable = !isEditable;
        }

        private void SetElementOfDetailsFruit(Fruit mFruit)
        {
            idTextView.Text = mFruit.id;
            nameTextView.Text = mFruit.name;
            orginTextView.Text = mFruit.origin;
            largestCountryTextView.Text = mFruit.largestCountry;
            productInBillionsTextView.Text = mFruit.productionInBillions.ToString();

        }

        private void FindAllTextView()
        {
            idTextView = FindViewById<TextView>(Resource.Id.fruit_id_edittext);
            nameTextView = FindViewById<TextView>(Resource.Id.name_edittext);
            orginTextView = FindViewById<TextView>(Resource.Id.origin_edittext);
            largestCountryTextView = FindViewById<TextView>(Resource.Id.largest_country_edittext);
            productInBillionsTextView = FindViewById<TextView>(Resource.Id.product_in_billions_edittext);
        }

        private Fruit GetElementFromDetailsFruit()
        {
            Fruit fruitForPost = new Fruit();

            fruitForPost.id = idTextView.Text;
            fruitForPost.name = nameTextView.Text;
            fruitForPost.origin = orginTextView.Text;
            fruitForPost.largestCountry = largestCountryTextView.Text;
            fruitForPost.productionInBillions = decimal.Parse(productInBillionsTextView.Text);
            
            return fruitForPost;
        }

        private void EditEnable(bool isEnable)
        {
            nameTextView.Enabled = isEnable;
            orginTextView.Enabled = isEnable;
            largestCountryTextView.Enabled = isEnable;
            productInBillionsTextView.Enabled = isEnable;

        }
    }
}