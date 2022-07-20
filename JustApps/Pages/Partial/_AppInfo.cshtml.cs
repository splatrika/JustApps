using JustApps.Models;

namespace JustApps.Pages;

public class AppInfoView
{
    public AppInfoView(AppInfo app, bool allowEdit)
    {
        App = app;
        AllowEdit = allowEdit;
    }

    public AppInfo App { get; set; }
    public bool AllowEdit { get; set; }
}

