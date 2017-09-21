namespace Sitecore.Support.ContentTesting.Services
{
  using Data.Items;

  public class LayoutUpdater <T> : Sitecore.ContentTesting.Services.LayoutUpdater<T>
  {
    public LayoutUpdater(Item item) : base(item)
    {
    }

    public new void UpdateLayout(UpdateLayoutMethod updateMethod, T parameters)
    {
      //TODO: Take into account winner layout
      base.UpdateLayout(updateMethod, parameters);
    }
  }
}