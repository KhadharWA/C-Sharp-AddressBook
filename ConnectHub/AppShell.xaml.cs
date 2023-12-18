using ConnectHub.Pages;

namespace ConnectHub
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            Routing.RegisterRoute(nameof(PersonsListPage),typeof(PersonsListPage));
            Routing.RegisterRoute(nameof(AddPersonPage),typeof(AddPersonPage));
            Routing.RegisterRoute(nameof(ShowPersonPage),typeof(ShowPersonPage));
            Routing.RegisterRoute(nameof(UpdatePersonPage),typeof(UpdatePersonPage));
            Routing.RegisterRoute(nameof(RemovePersonPage),typeof(RemovePersonPage));
        }
    }
}
