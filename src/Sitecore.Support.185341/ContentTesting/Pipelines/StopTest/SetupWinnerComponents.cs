namespace Sitecore.Support.ContentTesting.Pipelines.StopTest
{
  using Sitecore.ContentTesting.Data;
  using Sitecore.ContentTesting.Pipelines.StopTest;
  using Sitecore.ContentTesting.Services;

  public class SetupWinnerComponents : Sitecore.ContentTesting.Pipelines.StopTest.SetupWinnerComponents
  {
    public override void Process(StopTestArgs args)
    {
      //TODO: Fix issue here 
      Sitecore.Diagnostics.Assert.ArgumentNotNull(args, "args");
      if (args.WinnerVersion == null)
      {
        return;
      }
      LayoutUpdater<StopTestArgs> layoutUpdater = new LayoutUpdater<StopTestArgs>(args.WinnerVersion);
      layoutUpdater.UpdateLayout(new LayoutUpdater<StopTestArgs>.UpdateLayoutMethod(this.SetupWinner), args);
    }
  }
}