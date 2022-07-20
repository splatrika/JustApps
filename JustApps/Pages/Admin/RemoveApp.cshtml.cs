using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustApps.Models;
using JustApps.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustApps.Pages.Admin;

public class RemoveAppModel : PageModel
{
    [ViewData] public AppInfo? RemovingApp { get; set; }
    [BindProperty] public int RemovingAppId { get; set; }

    private IAdminService _admin;
    private IAppBrowserService _browser;

    public RemoveAppModel(IAdminService admin, IAppBrowserService browser)
    {
        _admin = admin;
        _browser = browser;
    }

    public void OnGet(int id)
    {
        RemovingApp = _browser.GetAll().First(x => x.Info.Id == id).Info;
        RemovingAppId = id;
    }


    public IActionResult OnPost()
    {
        RemovingApp = _browser.GetAll().First(x => x.Info.Id == RemovingAppId).Info;
        _admin.Remove(RemovingApp.Id);
        return RedirectToPage("./Index");
    }
}
