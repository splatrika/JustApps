using JustApps.Models;

namespace JustApps.Pages;

public class BrowserView
{
    public BrowserView(string targetPage, IEnumerable<AppListItem> items)
    {
        TargetPage = targetPage;
        Items = items;
    }

    public string TargetPage { get; set; }
    public IEnumerable<AppListItem> Items { get; set; }
}

