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
    public class GridLayoutAdapter : RecyclerView.Adapter
    {
        List<Fruit> mFruits;
        Context context;
        private RecyclerView mRecyclerView;


        public GridLayoutAdapter(Context context, List<Fruit> fruit)
        {
            this.context = context;
            this.mRecyclerView = new RecyclerView(context);
            mFruits = fruit;

        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.name_image_fruit, parent, false);
            GridLayoutHolder vh = new GridLayoutHolder(itemView);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            GridLayoutHolder vh = holder as GridLayoutHolder;
            vh.Name.Text = mFruits[position].name;


            ((GridLayoutHolder)holder).ItemView.Click -= ItemOnClick;
            ((GridLayoutHolder)holder).ItemView.Click += ItemOnClick;
        }

        public override int ItemCount
        {
            get { return mFruits.Count; }
        }

        public class GridLayoutHolder : RecyclerView.ViewHolder
        {
            public TextView Name { get; private set; }


            public GridLayoutHolder(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                Name = itemView.FindViewById<TextView>(Resource.Id.textViewForGrid);
     
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