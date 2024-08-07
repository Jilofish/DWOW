using DWOW.Components.Dialogs;
using DWOW.Models;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace DWOW.Components.Pages;

public partial class Rewards
{
    private string _searchTerm { get; set; }
    private List<Reward> _filteredRewards { get; set; }
    private List<Reward> _allRewards { get; set; }
    private string _selectedCategory { get; set; }

    private void ApplySearch(string value)
    {
        _filteredRewards = _allRewards
            .Where(r => string.IsNullOrEmpty(_searchTerm) || r.Name.Contains(_searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    protected override void OnInitialized()
    {
        //_filteredRewards ??= new List<Reward>();
        //_allRewards ??= new List<Reward>();
        _filteredRewards ??= [];
        _allRewards ??= [];
        base.OnInitialized();
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _allRewards = await App.Db.GetAllAsync<Reward>();
            _filteredRewards = _allRewards;
            ApplySearch("");
            StateHasChanged();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task OpenSideDialog()
    {
        await DialogService.OpenSideAsync<FilterDialog>(
            "Filter",
            new Dictionary<string, object>()
            {
                { "SelectedCategory", _selectedCategory },
                { "ApplyCategory", ApplyCategory }
            },
            new SideDialogOptions
            {
                CloseDialogOnOverlayClick = true,
                Position = DialogPosition.Top,
                ShowMask = true
            }
        );
    }

    async Task ApplyCategory(string category)
    {
        ApplySearch(_searchTerm);
        _selectedCategory = string.IsNullOrEmpty(category) || category == "All" ? "All" : category;
        _filteredRewards = _filteredRewards.Where(x => _selectedCategory == "All" ? true : x.Category == _selectedCategory).ToList();
        StateHasChanged();
    }

    void ClaimReward(Reward reward)
    {
        // Logic to claim the reward, such as updating the quantity and notifying the user
    }

}