namespace Sitecore.Support.ContentTesting.Pipelines.StopTest
{
  using Sitecore.ContentTesting.Extensions;
  using Sitecore.ContentTesting.Pipelines.StopTest;

  public class CreatePageLevelWinnerVersion : Sitecore.ContentTesting.Pipelines.StopTest.CreatePageLevelWinnerVersion
  {
    public override void Process(StopTestArgs args)
    {
      //TODO: Pass into args winner ID
      Sitecore.Diagnostics.Assert.ArgumentNotNull(args, "args");
      Sitecore.Data.Items.Item latestVersionIgnoreTests = args.Configuration.ContentItem.GetLatestVersionIgnoreTests();
      Sitecore.Data.Items.Item winnerVersion = this.GetWinnerVersion(args.Configuration, args.Combination);
      Sitecore.Data.Items.Item item = latestVersionIgnoreTests.Versions.AddVersion();
      if (winnerVersion != null)
      {
        using (new Sitecore.Data.Items.EditContext(item))
        {
          Sitecore.Data.Items.TemplateFieldItem[] fields = winnerVersion.Template.Fields;
          for (int i = 0; i < fields.Length; i++)
          {
            Sitecore.Data.Items.TemplateFieldItem templateFieldItem = fields[i];
            if (!(templateFieldItem.ID == FieldIDs.LayoutField) && !(templateFieldItem.ID == FieldIDs.FinalLayoutField))
            {
              item.Fields[templateFieldItem.ID].Value = winnerVersion.Fields[templateFieldItem.ID].Value;
            }
          }
          item.Fields[this.FieldId].Value = string.Empty;
        }
      }
      args.WinnerVersion = item;
    }
  }
}