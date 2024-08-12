namespace DWOW.Repositories;

public interface INotif
{
    public void Success(string message, string? title);
    public void Info(string message, string? title);
    public void Warning(string message, string? title);
    public void Error(string message, string? title);
}
