using JustApps.Services;
using JustApps.Pages.Base;

namespace JustApps.Pages;


public class IndexModel : AppListView
{
    public IndexModel(ILogger<AppListView> logger, IAppBrowserService service) : base(logger, service, "Index")
    {
    }

    public void OnPostComment()
    {
        var appId = SendingReview.AppId;
        if (ModelState.IsValid)
        {
            Service.SendReview(SendingReview);
            SendingReview = new();
        }
        OnGet(appId);
    }
}
