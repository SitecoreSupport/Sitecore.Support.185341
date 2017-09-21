namespace Sitecore.Support.ContentTesting.Services
{
  using Data.Items;
  using Diagnostics;

  public class LayoutUpdater <T> : Sitecore.ContentTesting.Services.LayoutUpdater<T>
  {
    private Item _Item;

    public LayoutUpdater(Item item) : base(item)
    {
      Assert.ArgumentNotNull(item, "item");
      _Item = item;
    }

    public new void UpdateLayout(UpdateLayoutMethod updateMethod, T parameters)
    {
      //TODO: Take into account winner layout
      Assert.ArgumentNotNull(updateMethod, "updateMethod");
      string baseLayout = this.GetBaseLayout();
      string str2 = updateMethod(baseLayout, parameters);
      string finalLayout = this.GetFinalLayout(str2);
      string str4 = updateMethod(finalLayout, parameters);
      ItemUtil.SetLayoutDetails(_Item, str2, str4);
    }
  }
}