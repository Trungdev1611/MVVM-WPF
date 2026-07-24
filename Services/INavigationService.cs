using Reserveroom.viewModels;

namespace Reserveroom.Services;

/// <summary>
/// Navigation service — quyết định ViewModel nào đang hiển thị.
/// </summary>
public interface INavigationService
{
    ViewModelBase? CurrentViewModel { get; }

    event Action? CurrentViewModelChanged;

    void NavigateTo(ViewModelBase viewModel);
}
