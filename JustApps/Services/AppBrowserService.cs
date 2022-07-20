using System;
using JustApps.Models;
using JustApps.Data;

namespace JustApps.Services
{
    public class AppBrowserService : IAppBrowserService
    {
        private IServiceScopeFactory _scopeFactory;


        public AppBrowserService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public IEnumerable<AppListItem> GetAll()
        {
            using (var scope = _scopeFactory.CreateAsyncScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var result = new AppListItem[db.AppsInfo.Count()];
                var i = 0;

                var apps = db.AppsInfo.OrderBy(x => x.Id).ToList();

                foreach (var appInfo in apps)
                {
                    var reviews = new List<Review>();

                    foreach (var review in db.Reviews)
                    {
                        if (review.AppId == appInfo.Id)
                        {
                            reviews.Add(review);
                        }
                    }
                    result[i] = new(appInfo, reviews.ToArray());
                    i++;
                }
                return result;
            }
        }


        public void SendReview(Review item)
        {
            using (var scope = _scopeFactory.CreateAsyncScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var i = db.AppsInfo.Count();
                //var appInfo = db.AppsInfo.First(x => x.Id == item.AppId);
                var appInfo = db.AppsInfo.FirstOrDefault(x => x.Id == item.AppId);
                if (appInfo == null)
                {
                    throw new NullReferenceException($"There isn't app with id {item.AppId}");
                }
                db.Reviews.Add(item);
                db.SaveChanges();
            }
        }
    }
}



