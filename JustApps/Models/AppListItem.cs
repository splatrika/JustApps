namespace JustApps.Models
{
    public class AppListItem
    {
        public AppListItem(AppInfo info, Review[] reviews)
        {
            Info = info;
            Reviews = reviews;
        }

        public AppInfo Info { get; set; }
        public Review[] Reviews { get; set; }
    }
}

