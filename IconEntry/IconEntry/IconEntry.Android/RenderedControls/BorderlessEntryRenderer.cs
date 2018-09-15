using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IconEntry.Controls;
using IconEntry.Droid.RenderedControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(BorderLessEntry), typeof(BorderlessEntryRenderer))]
namespace IconEntry.Droid.RenderedControls
{
    class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer() : base(Android.App.Application.Context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;



            }

        }
    }
}