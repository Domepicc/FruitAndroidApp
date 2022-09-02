using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using FruitApp.Adapater;
using FruitApp.Adapter;
using FruitApp.API;
using FruitApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace FruitApp.Activity
{
    [Activity(Label = "List")]
    public class ListActivity : AppCompatActivity
    {
        private Adapter.ListAdapter mAdapter;
        private List<Fruit> mFruits;
        private ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_list);

            mListView = FindViewById<ListView>(Resource.Id.listView);

            // set URL
            string url = Resources.GetString(Resource.String.fruit_api_url);
            UrlSingleton.Create(url);
        }

        protected override void OnStart()
        {
            base.OnStart();

            // FruitAPI
            FruitAPI api = new FruitAPI();
            mFruits = api.Get<Fruit>();

            // set FruitAdapter
            mAdapter = new Adapter.ListAdapter(this, mFruits);
            mListView.Adapter = mAdapter;

            mListView.ItemClick += ItemOnClick;

        }

        private void ItemOnClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int position = e.Position;
            Fruit fruitClicked = this.mFruits[position];
            string fruitId = fruitClicked.id;
            Toast.MakeText(this, "This is fruit number " + fruitId, ToastLength.Long).Show();

            Intent intent = new Intent(this, typeof(DetailsFruitActivity));
            intent.PutExtra("id", fruitId);
            this.StartActivity(intent);
        }
    }
}