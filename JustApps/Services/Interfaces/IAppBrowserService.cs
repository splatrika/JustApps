using System;
using JustApps.Models;

namespace JustApps.Services;

public interface IAppBrowserService
{
    IEnumerable<AppListItem> GetAll();
    void SendReview(Review item);
}

