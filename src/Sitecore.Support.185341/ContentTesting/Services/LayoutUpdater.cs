namespace Sitecore.Support.ContentTesting.Services
{
  using Data.Items;
  using Diagnostics;

  public class LayoutUpdater<T> : Sitecore.ContentTesting.Services.LayoutUpdater<T>
  {
    #region AddedCode
    private Item _ItemToUpdate;

    public LayoutUpdater(Item itemToUpdate, Item layoutSourceItem) : base(layoutSourceItem)
    {
      Assert.ArgumentNotNull(itemToUpdate, "itemToUpdate");
      _ItemToUpdate = itemToUpdate;
    }
    #endregion

    public new void UpdateLayout(UpdateLayoutMethod updateMethod, T parameters)
    {
      Assert.ArgumentNotNull(updateMethod, "updateMethod");
      string baseLayout = this.GetBaseLayout();
      string str2 = updateMethod(baseLayout, parameters);
      string finalLayout = this.GetFinalLayout(str2);
      string str4 = updateMethod(finalLayout, parameters);
      #region Modified code
      ItemUtil.SetLayoutDetails(_ItemToUpdate, str2, str4);
      #endregion
    }
  }
}