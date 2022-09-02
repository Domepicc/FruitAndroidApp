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
    public class RecyclerAdapter : RecyclerView.Adapter
    {
        List<Fruit> mFruits;
        Context context;
        private RecyclerView mRecyclerView;


        public RecyclerAdapter(Context context, List<Fruit> fruit)
        {
            this.context = context;
            this.mRecyclerView = new RecyclerView(context);
            mFruits = fruit;

        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item_fruit, parent, false);
            RecyclerViewHolder vh = new RecyclerViewHolder(itemView);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;
            vh.Id.Text = mFruits[position].id;
            vh.Name.Text = mFruits[position].name;
            vh.Origin.Text = mFruits[position].origin;
            vh.LargestCountry.Text = mFruits[position].largestCountry;
            vh.ProdutInBillions.Text = mFruits[position].productionInBillions.ToString();

            ((RecyclerViewHolder)holder).ItemView.Click -= ItemOnClick;
            ((RecyclerViewHolder)holder).ItemView.Click += ItemOnClick;
        }

        public override int ItemCount
        {
            get { return mFruits.Count; }
        }

        public class RecyclerViewHolder : RecyclerView.ViewHolder
        {
            public TextView Id { get; private set; }
            public TextView Name { get; private set; }
            public TextView Origin { get; private set; }
            public TextView LargestCountry { get; private set; }
            public TextView ProdutInBillions { get; private set; }

            public RecyclerViewHolder(View itemView) : base(itemView)
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
            Fruit fruitClicked = this.mFruits[position];
            string fruitId = fruitClicked.id;
            Toast.MakeText(this.context, "This is fruit number " + fruitId, ToastLength.Long).Show();

            Intent intent = new Intent(this.context, typeof(DetailsFruitActivity));
            intent.PutExtra("id", fruitId);
            this.context.StartActivity(intent);
        }
    }
}