using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using DataAccess;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Elite
{
    class OrderAdapter : BaseAdapter<Order>
    {

        Activity context;
        List<Order> orders;
        public OrderAdapter(Android.App.Activity context, List<Order> orders)
        {
            this.context = context;
            this.orders = orders;
        }

        public OrderAdapter(FragmentOrders fragmentOrders, Task<List<Order>> task)
        {
        }

        public override Order this[int position]
        {
            get
            {
                return orders[position];
            }
        }


        public override long GetItemId(int position)
        {
            return position;
        }




        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //var view = convertView;
            var view = context.LayoutInflater.Inflate(Resource.Layout.order_row, parent, false);
            var photo = view.FindViewById<ImageView>(Resource.Id.imgOrder);
            var txtName = view.FindViewById<TextView>(Resource.Id.txtName);
            var txtEmail = view.FindViewById<TextView>(Resource.Id.txtDescription);
            Stream stream = context.Assets.Open(orders[position].image);
            Drawable drawable = Drawable.CreateFromStream(stream, null);
            photo.SetImageDrawable(drawable);
            txtName.Text = orders[position].name;
            txtEmail.Text = orders[position].description;
            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return 0;
            }
        }

    }

    class OrderAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}