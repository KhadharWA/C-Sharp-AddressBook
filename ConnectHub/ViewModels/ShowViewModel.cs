

using Shared.Interfaces;

namespace ConnectHub.ViewModels;

public partial class ShowViewModel
{
    private readonly IPersonRepository _personRepository;

    public ShowViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    
  
}
