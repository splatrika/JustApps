using System;
using JustApps.Models;

namespace JustApps.Services;

public interface IAdminService
{
    void Create(AppInfo app, out int appId);
    void Remove(int id);
    void Update(AppInfo updated);
}


