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
using FruitApp.Domain;
using AndroidX.RecyclerView.Widget;
using static AndroidX.RecyclerView.Widget.RecyclerView;
using FruitApp.Activity;

namespace FruitApp.Adapater
{
    public class FruitAdapter : RecyclerView.Adapter
    {
        List<Fruit> mFruit;
        Context context;
        private RecyclerView mRecyclerView;


        public FruitAdapter(Context context, List<Fruit> fruit)
        {
            this.context = context;
            this.mRecyclerView = new RecyclerView(context);
            mFruit = fruit;

        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item_fruit, parent, false);
            FruitViewHolder vh = new FruitViewHolder(itemView);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            FruitViewHolder vh = holder as FruitViewHolder;
            vh.Id.Text = mFruit[position].id;
            vh.Name.Text = mFruit[position].name;
            vh.Origin.Text = mFruit[position].origin;
            vh.LargestCountry.Text = mFruit[position].largestCountry;
            vh.ProdutInBillions.Text = mFruit[position].productionInBillions.ToString();

            ((FruitViewHolder)holder).ItemView.Click -= ItemOnClick;
            ((FruitViewHolder)holder).ItemView.Click += ItemOnClick;
        }

        public override int ItemCount
        {
            get { return mFruit.Count; }
        }

        public class FruitViewHolder : RecyclerView.ViewHolder
        {
            public TextView Id { get; private set; }
            public TextView Name { get; private set; }
            public TextView Origin { get; private set; }
            public TextView LargestCountry { get; private set; }
            public TextView ProdutInBillions { get; private set; }

            public FruitViewHolder(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                Id = itemView.FindViewById<TextView>(Resource.Id.fruit_id_text);
                Name = itemView.FindViewById<TextView>(Resource.Id.name_text);
                Origin = itemView.FindViewById<TextView>(Resource.Id.origin_text);
                LargestCountry = itemView.FindViewById<TextView>(Resource.Id.largest_country_text);
                ProdutInBillions = itemView.FindViewById<TextView>(Resource.Id.product_in_billions_text);
            }
        }

        private void ItemOnClick(object sender, EventArgs e)
        {
            int position = this.mRecyclerView.GetChildAdapterPosition((View)sender);
            Fruit fruitClicked = this.mFruit[position];
            string fruitId = fruitClicked.id;
            Toast.MakeText(this.context, "This is fruit number " + fruitId, ToastLength.Long).Show();

            Intent intent = new Intent(this.context, typeof(DetailsFruitActivity));
            intent.PutExtra("id", fruitId);
            this.context.StartActivity(intent);
        }
    }
}