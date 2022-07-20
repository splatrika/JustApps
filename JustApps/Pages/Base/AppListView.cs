using JustApps.Models;
using JustApps.Pages.Base.Interfaces;
using JustApps.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustApps.Pages.Base
{
    public class AppListView : PageModel, IAppListViewProvider
    {
        public IAppBrowserService Service { get; }

        [ViewData] public IEnumerable<AppListItem> Apps { get; private set; }
        [ViewData] public BrowserView BrowserModel { get; private set; }
        [ViewData] public AppListItem? SelectedApp { get; private set; }
        [ViewData] public bool IsAppSelected => SelectedApp != null;

        [BindProperty] public Review SendingReview { get; set; }

        private readonly ILogger<AppListView> _logger;
        private readonly string _pageName;


        public AppListView(ILogger<AppListView> logger, IAppBrowserService service,
            string pageName)
        {
            _logger = logger;
            Service = service;
            SendingReview = new();
            Apps = Service.GetAll();
            _pageName = pageName;
        }


        public void OnGet(int id)
        {
            Apps = Service.GetAll();
            BrowserModel = new(_pageName, Apps);
            if (id != 0)
            {
                SelectedApp = Apps.First(x => x.Info.Id == id);
            }
        }
    }
}

