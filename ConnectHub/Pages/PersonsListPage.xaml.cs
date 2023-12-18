
using ConnectHub.ViewModels;

namespace ConnectHub.Pages;

public partial class PersonsListPage : ContentPage
{
	public PersonsListPage(PersonListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}