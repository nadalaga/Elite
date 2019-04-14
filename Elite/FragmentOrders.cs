using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DataAccess;
namespace Elite
{
    public class FragmentOrders : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public async override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.fragment_orders, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);

            View CurrentFragment = inflater.Inflate(Resource.Layout.fragment_orders, container, false);
            var orderListView = CurrentFragment.FindViewById<Android.Widget.ListView>(Resource.Id.lstOrder);
            OrderService objOrderService = new OrderService();
            await objOrderService.Insert();
             var OrderCustomAdapter = new OrderAdapter(this, objOrderService.Get());
            orderListView.Adapter = OrderCustomAdapter;
            return CurrentFragment;
        }
    }
}