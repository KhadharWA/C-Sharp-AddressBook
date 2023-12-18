

using ConnectHub.ViewModels;

namespace ConnectHub.Pages;

public partial class AddPersonPage : ContentPage
{
	public AddPersonPage(AddViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}