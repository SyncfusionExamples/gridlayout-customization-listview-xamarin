# How to display different column in each row of ListView in Xamarin.Forms


You can define each row with different number of column count in SfListView by customizing the SpanCount property of LayoutManager in Xamarin.Forms.

**XAML**
``` xml
<ContentPage xmlns:listView="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms">
    <ContentPage.Content>
           <listView:SfListView x:Name="listView" 
                             GroupHeaderSize="0"
                             ItemSize="50" 
                             ItemsSource="{Binding contactsinfo}" >
                    <listView:SfListView.DataSource>
                        <dataSource:DataSource>
                            <dataSource:DataSource.GroupDescriptors>
                                <dataSource:GroupDescriptor PropertyName="CountryName"/>
                            </dataSource:DataSource.GroupDescriptors>
                        </dataSource:DataSource>
                    </listView:SfListView.DataSource>
                </listView:SfListView>       
    </ContentPage.Content>
</ContentPage>
```
**C#**

The SpanCount value calculated based on the maximum grouped items count from the GroupResult.

``` c#
listView.Loaded += ListView_Loaded;
 
private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
{
    var displayItems = listView.DataSource.DisplayItems.Where(o => (o as GroupResult) != null);
    this.listView.LayoutManager = new GridLayout() { SpanCount = displayItems.Max(o => (o as GroupResult).Items.ToList<object>().Count()) };
}
```
**Output**

![GridLayout](https://github.com/SyncfusionExamples/gridlayout-customization-listview-xamarin/blob/master/ScreenShots/GridLayout.png)
