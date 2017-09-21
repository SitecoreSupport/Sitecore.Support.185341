namespace Sitecore.Support.ContentTesting.Pipelines.StopTest
{
  using Data.Items;
  using Sitecore.ContentTesting.Data;
  using Sitecore.ContentTesting.Pipelines.StopTest;
  using Sitecore.ContentTesting.Services;

  public class SetupWinnerComponents : Sitecore.ContentTesting.Pipelines.StopTest.SetupWinnerComponents
  {
    public override void Process(StopTestArgs args)
    {
      Sitecore.Diagnostics.Assert.ArgumentNotNull(args, "args");

      #region Modified code
      var winnerItem = args.CustomData["winnerItem"] as Item;
      if (args.WinnerVersion == null || winnerItem == null)
      {
        return;
      }
      if (args.WinnerVersion.ID == winnerItem.ID)
      {
        LayoutUpdater<StopTestArgs> layoutUpdater = new LayoutUpdater<StopTestArgs>(args.WinnerVersion);
        layoutUpdater.UpdateLayout(new LayoutUpdater<StopTestArgs>.UpdateLayoutMethod(this.SetupWinner), args);
      }
      else
      {
        Services.LayoutUpdater<StopTestArgs> layoutUpdater = new Services.LayoutUpdater<StopTestArgs>(args.WinnerVersion, winnerItem);
        layoutUpdater.UpdateLayout(new LayoutUpdater<StopTestArgs>.UpdateLayoutMethod(this.SetupWinner), args);
      }
      #endregion
    }
  }
}