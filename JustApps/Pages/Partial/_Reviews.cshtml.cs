using JustApps.Models;

namespace JustApps.Pages;

public class ReviewsView
{
    public ReviewsView(AppListItem target)
    {
        Reviews = target.Reviews;
        AppId = target.Info.Id;
    }

    public int AppId { get; }
    public Review[] Reviews { get; }
}

