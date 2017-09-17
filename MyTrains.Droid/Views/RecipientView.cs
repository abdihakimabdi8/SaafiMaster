﻿using Android.App;
using MvvmCross.Droid.Views;

namespace MyTrains.Droid.Views
{
    [Activity(Label = "Add Recipient", NoHistory = true)]
    public class RecipientView : MvxActivity
    {
        /// <summary>
        /// Use OnViewModelSet to inflate the view's ContentView from AXML.
        /// </summary>
        protected override void OnViewModelSet()
        {
            // This uses a resource identifier generated by Android to identify the view.
            SetContentView(Resource.Layout.RecipientView);
        }
    }
}