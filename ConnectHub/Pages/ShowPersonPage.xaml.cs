using ConnectHub.ViewModels;

namespace ConnectHub.Pages;

public partial class ShowPersonPage : ContentPage
{
	public ShowPersonPage(ShowViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}