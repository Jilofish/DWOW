using DWOW.Repositories;
using Microsoft.AspNetCore.Components;

namespace DWOW.Components.Pages;

public partial class Home
{
    [Inject] INotif _notif { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            _notif.Warning($"Logged in successfully at {DateTime.Now}", "Logged in");
        }
            base.OnAfterRender(firstRender);
    }

}