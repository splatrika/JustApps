using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JustApps.Services;
using JustApps.Pages.Base;
using JustApps.Models;

namespace JustApps.Pages;

public class AdminModel : AppListView
{
    [BindProperty] public AppInfo UpdatedApp { get; set; }

    private IAdminService _admin;

    public AdminModel(ILogger<AppListView> logger, IAppBrowserService service,
        IAdminService admin)
        : base(logger, service, "Index")
    {
        _admin = admin;
    }

    public void OnPostCreateApp()
    {
        var app = new AppInfo()
        {
            Name = "New App",
            PhotoURL = "https://i.stack.imgur.com/jqHeq.png"
        };
        _admin.Create(app, out int appId);
        OnGet(appId);
    }


    public void OnPostUpdateApp()
    {
        _admin.Update(UpdatedApp);
        OnGet(UpdatedApp.Id);
    }
}
