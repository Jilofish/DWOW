using Microsoft.AspNetCore.Components;
using Radzen;

namespace DWOW.Components.Dialogs;

public partial class FilterDialog : IAsyncDisposable
{
    [Parameter] public string SelectedCategory { get; set; }
    [Parameter] public Func<string, Task> ApplyCategory { get; set; }

    [Inject] DialogService Ds { get; set; }

    string _selectedCategory { get; set; }
    List<string> CategoryOptions { get; set; }

    protected override void OnInitialized()
    {
        CategoryOptions ??= ["All", "Food", "Drinks"];
        base.OnInitialized();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if(firstRender)
        {
            _selectedCategory = SelectedCategory;
            StateHasChanged();
        }
        base.OnAfterRender(firstRender);
    }

    void ApplyFilters()
    {
        ApplyCategory?.Invoke(_selectedCategory);
        Ds.CloseSide(true);
    }

    public ValueTask DisposeAsync()
    {
        ApplyCategory?.Invoke(_selectedCategory);
        return new ValueTask();
    }
}