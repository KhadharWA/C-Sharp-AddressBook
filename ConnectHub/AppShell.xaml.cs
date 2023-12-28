using ConnectHub.Pages;

namespace ConnectHub
{

    /// <summary>
    /// Defines the app's shell, which includes the navigation structure and routing information.
    /// </summary>
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation within the application.
            Routing.RegisterRoute(nameof(PersonsListPage),typeof(PersonsListPage));
            Routing.RegisterRoute(nameof(AddPersonPage),typeof(AddPersonPage));
            Routing.RegisterRoute(nameof(ShowPersonPage),typeof(ShowPersonPage));
            Routing.RegisterRoute(nameof(UpdatePersonPage),typeof(UpdatePersonPage));
            
        }
    }
}
