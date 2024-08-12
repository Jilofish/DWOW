using DWOW.Models;
using DWOW.Repositories;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace DWOW.Components.Pages;

public partial class Login : IAsyncDisposable
{
    [Inject] INotif _notif { get; set; }
    [Inject] NavigationManager _navManager { get; set; }

    Variant variant { get; set; }

    List<Credential> _creds { get; set; }

    Credential model { get; set; }
    Credential _savedCred { get; set; }

    protected override void OnInitialized()
    {
        model ??= new();
        _savedCred ??= new();
        _creds ??= [];
        variant = Variant.Outlined;
        base.OnInitialized();
    }

    protected override async Task OnInitializedAsync()
    {
        _creds = await App.Db.GetAllAsync<Credential>();

        if (_creds is not null && _creds.Count > 0)
        {
            _savedCred = _creds[^1];
            model.Username = _savedCred.Username;
        }

        await base.OnInitializedAsync();
    }

    async Task OnSubmit(Credential model)
    {
        if(_creds is null || _creds.Count == 0)
        {
            // todo: Check creds if valid via SAP
            // call CheckPasswordOnSAP()
            if (!await CheckPasswordOnSAP())
            {
                // Notification error
                _notif.Error($"Wrong Username or Password", "Error");
                // Wrong password
            }

            // Saving Creds
            Credential credential = new() { 
                Username = model.Username,
                Password = model.Password
            };
            await App.Db.InsertAsync(credential);

            // Check if creds is saved
            List<Credential> creds = await App.Db.GetAllAsync<Credential>();
            if (creds is null || creds.Count == 0 || !creds.Exists(x => x.Username == model.Username && x.Password == model.Password))
            {
                // Notification error

                return;
            }
        } 
        else
        {
            // check password only on sqlite
            if (_savedCred.Password != model.Password)
            {
                // Notification error about wrong password
                _notif.Error($"Wrong Password", "Error");
                return;
            }

            // Call CheckPasswordOnSAP();
            // if it returns true do nothing and let it pass
            if (!await CheckPasswordOnSAP())
            {
                // Notificatoin error
                // Wrong password
                // if it returns false remove the saved credentials on the table and prompt password error kineme
                // if it returns false restart the login make sure that the creds table is empty.
                return;
            }
        }

        _navManager.NavigateTo("/home", true, true);
    }

    async Task<bool> CheckPasswordOnSAP()
    {
        bool valid = true;
        // TODO Logic here
        // API Client calls

        return valid;
    }

    void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
    {
        //console.Log($"InvalidSubmit: {JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true })}");
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask();
    }
}