

namespace Shared.Interfaces;


/// <summary>
/// Defines the contract for a person with basic contact details.
/// </summary>
public interface IPerson
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }
}
