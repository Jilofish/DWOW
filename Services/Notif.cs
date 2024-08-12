using DWOW.Repositories;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace DWOW.Services;

public class Notif : INotif
{
    NotificationService _notifService { get; set; }

    public Notif(NotificationService notifService)
    {
        _notifService = notifService;
    }

    public void Error(string message, string? title)
    {
        _notifService.Notify(new NotificationMessage
        {
            Style = "width: 90%; border-radius: 20px; position: fixed; top: 5px; left: 50%; transform: translateX(-50%); color: white;",
            Severity = NotificationSeverity.Error,
            Summary = $"{(string.IsNullOrEmpty(title) ? "Error" : title)}",
            Detail = $"{message}",
            Duration = 5000,
            CloseOnClick = true,
        });
    }

    public void Info(string message, string? title)
    {
        _notifService.Notify(new NotificationMessage
        {
            Style = "width: 90%; border-radius: 20px; position: fixed; top: 5px; left: 50%; transform: translateX(-50%); color: white;",
            Severity = NotificationSeverity.Info,
            Summary = $"{(string.IsNullOrEmpty(title) ? "Info" : title)}",
            Detail = $"{message}",
            Duration = 5000,
            CloseOnClick = true,
        });
    }

    public void Success(string message, string? title)
    {
        _notifService.Notify(new NotificationMessage
        {
            Style = "width: 90%; border-radius: 20px; position: fixed; top: 5px; left: 50%; transform: translateX(-50%); color: white;",
            Severity = NotificationSeverity.Success,
            Summary = $"{(string.IsNullOrEmpty(title) ? "Success" : title)}",
            Detail = $"{message}",
            Duration = 5000,
            CloseOnClick = true,
        });
    }

    public void Warning(string message, string? title)
    {
        _notifService.Notify(new NotificationMessage
        {
            Style = "width: 90%; border-radius: 20px; position: fixed; top: 5px; left: 50%; transform: translateX(-50%); color: white;",
            Severity = NotificationSeverity.Warning,
            Summary = $"{(string.IsNullOrEmpty(title) ? "Warning" : title)}",
            Detail = $"{message}",
            Duration = 5000,
            CloseOnClick = true,
        });
    }
}
