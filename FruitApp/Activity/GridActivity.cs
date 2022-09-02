using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using FruitApp.Adapter;
using FruitApp.API;
using FruitApp.Domain;
using System.Collections.Generic;

namespace FruitApp.Activity
{
    [Activity(Label = "Grid")]
    public class GridActivity : AppCompatActivity
    {
        private FruitAdapter mAdapter;
        private List<Fruit> mFruits;
        private GridView mGridView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_grid);

            mGridView = FindViewById<GridView>(Resource.Id.gridTestView);

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
            mAdapter = new FruitAdapter(mFruits);
            mGridView.Adapter = mAdapter;

            mGridView.ItemClick += ItemOnClick;

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