using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;
using System.Collections.ObjectModel;
namespace ConnectHub.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]

    private async Task NavigateToAdd()
    {
        await Shell.Current.GoToAsync("AddPersonPage");
    }

    [RelayCommand]

    private async Task NavigateToList()
    {
        await Shell.Current.GoToAsync("PersonsListPage");
    }

    [RelayCommand]

    private async Task NavigateToShowPerson()
    {
        await Shell.Current.GoToAsync("ShowPersonPage");
    }

    [RelayCommand]

    private async Task NavigateToUpdate()
    {
        await Shell.Current.GoToAsync("UpdatePersonPage");
    }

    [RelayCommand]

    private async Task NavigateToRemove()
    {
        await Shell.Current.GoToAsync("RemovePersonPage");
    }

}
