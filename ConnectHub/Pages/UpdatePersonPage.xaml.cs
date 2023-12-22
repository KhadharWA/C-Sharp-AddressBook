using ConnectHub.ViewModels;

namespace ConnectHub.Pages;

public partial class UpdatePersonPage : ContentPage
{
	public UpdatePersonPage(UpdateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}