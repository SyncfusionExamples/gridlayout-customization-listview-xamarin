using Syncfusion.DataSource.Extensions;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        SfListView listView;
        protected override void OnAttachedTo(ContentPage bindable)
        {
        listView = bindable.FindByName<SfListView>("listView");
listView.Loaded += ListView_Loaded;
            base.OnAttachedTo(bindable);
        }

        private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            var displayItems = listView.DataSource.DisplayItems.Where(o => (o as GroupResult) != null);
            this.listView.LayoutManager = new GridLayout() { SpanCount = displayItems.Max(o => (o as GroupResult).Items.ToList<object>().Count()) };
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            listView.Loaded -= ListView_Loaded;
            base.OnDetachingFrom(bindable);
        }
    }
}
