using JustApps.Models;
using JustApps.Services;
using Microsoft.AspNetCore.Mvc;

namespace JustApps.Pages.Base.Interfaces
{
    public interface IAppListViewProvider
    {
        IAppBrowserService Service { get; }

        [ViewData] IEnumerable<AppListItem> Apps { get; }
        [ViewData] BrowserView BrowserModel { get; }
        [ViewData] AppListItem? SelectedApp { get; }
        [ViewData] bool IsAppSelected => SelectedApp != null;

        [BindProperty] public Review SendingReview { get; set; }
    }
}

