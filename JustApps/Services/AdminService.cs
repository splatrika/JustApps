using System;
using JustApps.Models;
using JustApps.Data;

namespace JustApps.Services;

public class AdminService : IAdminService
{
    private IServiceScopeFactory _scopeFactory;

    public AdminService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void Create(AppInfo app, out int id)
    {
        using (var scope = _scopeFactory.CreateAsyncScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var created = db.AppsInfo.Add(app);
            db.SaveChanges();
            id = db.AppsInfo.OrderBy(x => x.Id).Last().Id;
        }
    }

    public void Remove(int id)
    {
        using (var scope = _scopeFactory.CreateAsyncScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.AppsInfo.Remove(db.AppsInfo.First(x => x.Id == id));
            db.SaveChanges();
            var reviews = db.Reviews.Where(x => x.AppId == id);
            db.Reviews.RemoveRange(reviews);
            db.SaveChanges();
        }
    }

    public void Update(AppInfo updated)
    {
        using (var scope = _scopeFactory.CreateAsyncScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.AppsInfo.Update(updated);
            db.SaveChanges();
        }
    }
}

