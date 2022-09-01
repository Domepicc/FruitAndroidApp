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
    public class TestGridLayoutAdapter : RecyclerView.Adapter
    {
        List<Fruit> mFruits;
        Context context;
        private RecyclerView mRecyclerView;


        public TestGridLayoutAdapter(Context context, List<Fruit> fruit)
        {
            this.context = context;
            this.mRecyclerView = new RecyclerView(context);
            mFruits = fruit;

        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.text_view, parent, false);
            TestGridLayoutHolder vh = new TestGridLayoutHolder(itemView);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TestGridLayoutHolder vh = holder as TestGridLayoutHolder;
            vh.Name.Text = mFruits[position].name;


            ((TestGridLayoutHolder)holder).ItemView.Click -= ItemOnClick;
            ((TestGridLayoutHolder)holder).ItemView.Click += ItemOnClick;
        }

        public override int ItemCount
        {
            get { return mFruits.Count; }
        }

        public class TestGridLayoutHolder : RecyclerView.ViewHolder
        {
            public TextView Name { get; private set; }


            public TestGridLayoutHolder(View itemView) : base(itemView)
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