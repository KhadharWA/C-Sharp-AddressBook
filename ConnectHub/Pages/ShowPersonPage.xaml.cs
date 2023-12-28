using ConnectHub.ViewModels;

namespace ConnectHub.Pages;

public partial class ShowPersonPage : ContentPage
{
	public ShowPersonPage(ShowViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


    /// <summary>
    /// Called when the page appears on the screen. Overridden to perform additional initialization tasks.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
    }


    /// <summary>
    /// Clear the person details in the ViewModel when the page is no longer visible.
    /// </summary>
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        
        if (BindingContext is ShowViewModel viewModel)
        {
            viewModel.ClearPersonDetails();
        }
    }
}