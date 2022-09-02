using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using FruitApp.Adapater;
using FruitApp.Adapter;
using FruitApp.API;
using FruitApp.Domain;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Views.ViewGroup;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace FruitApp.Activity
{
    [Activity(Label = "GridLayout", MainLauncher = true)]
    public class GridLayoutActivity : AppCompatActivity
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private GridLayoutAdapter mAdapter;
        private List<Fruit> mFruits;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_grid_layout);


            // set LinearLayoutManager
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.grid_fruit_recyclerview);
            //mLayoutManager = new LinearLayoutManager(this);
            mLayoutManager = new GridLayoutManager(this.ApplicationContext, 3);
            mRecyclerView.SetLayoutManager(mLayoutManager);

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
            mAdapter = new GridLayoutAdapter(this, mFruits);
            mRecyclerView.SetAdapter(mAdapter);

        }
    }
}