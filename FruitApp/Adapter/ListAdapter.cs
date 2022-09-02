using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FruitApp.Activity;
using FruitApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AndroidX.RecyclerView.Widget.RecyclerView;
using static FruitApp.Adapater.RecyclerAdapter;

namespace FruitApp.Adapter
{
    internal class ListAdapter : BaseAdapter
    {
        private Context context;
        private List<Fruit> mFruits;
        private ListView mListView;

        public ListAdapter(Context context, List<Fruit> fruits)
        {
            this.context = context;
            this.mListView = new ListView(context);
            this.mFruits = fruits;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return long.Parse(mFruits[position].id);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ListViewHolder holder = null;


                
            var inflater = LayoutInflater.From(parent.Context);
            //replace with your item and your holder items
            //comment back in
            view = inflater.Inflate(Resource.Layout.item_fruit, parent, false);
            holder = new ListViewHolder(view);
            

            holder.Id.Text = mFruits[position].id;
            holder.Name.Text = mFruits[position].name;
            holder.Origin.Text = mFruits[position].origin;
            holder.LargestCountry.Text = mFruits[position].largestCountry;
            holder.ProdutInBillions.Text = mFruits[position].productionInBillions.ToString();




            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return mFruits.Count;
            }
        }
    }

    internal class ListViewHolder
    {
            public TextView Id { get; private set; }
            public TextView Name { get; private set; }
            public TextView Origin { get; private set; }
            public TextView LargestCountry { get; private set; }
            public TextView ProdutInBillions { get; private set; }


            public ListViewHolder(View itemView)
            {
                // Locate and cache view references:
                Id = itemView.FindViewById<TextView>(Resource.Id.fruit_id_text);
                Name = itemView.FindViewById<TextView>(Resource.Id.name_text);
                Origin = itemView.FindViewById<TextView>(Resource.Id.origin_text);
                LargestCountry = itemView.FindViewById<TextView>(Resource.Id.largest_country_text);
                ProdutInBillions = itemView.FindViewById<TextView>(Resource.Id.product_in_billions_text);
            }

    }


}