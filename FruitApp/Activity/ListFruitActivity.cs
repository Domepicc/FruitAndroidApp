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
using FruitApp.API;
using FruitApp.Domain;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using static Android.Telephony.CarrierConfigManager;
using AndroidX.RecyclerView.Widget;
using static AndroidX.RecyclerView.Widget.RecyclerView;
using FruitApp.Adapater;
using Android.Text;
using Java.Lang;

namespace FruitApp.Activity
{

    [Activity(Label = "List Fruit", MainLauncher = true )]
    public class ListFruitActivity : AppCompatActivity
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private FruitAdapter mAdapter;
        private List<Fruit> mFruits;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            mFruits = new List<Fruit>();

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_recycler_view_fruit);

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

            // set LinearLayoutManager
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.list_fruit_recyclerview);
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // set FruitAdapter
            mAdapter = new FruitAdapter(this, mFruits);
            mRecyclerView.SetAdapter(mAdapter);


        }




    }


}