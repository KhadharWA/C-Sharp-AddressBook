using ConnectHub.ViewModels;

namespace ConnectHub
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; 
        }

        
    }

}
