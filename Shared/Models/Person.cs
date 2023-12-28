
using Shared.Interfaces;

namespace Shared.Models;


/// <summary>
/// Represents a person with basic contact details.
/// </summary>
public class Person : IPerson
{
    /// <summary>
    /// Gets or sets the first name of the person.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the person.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email address of the person.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets the phone number of the person.
    /// </summary>
    public string PhoneNumber { get; set; } = null!;


    /// <summary>
    /// Gets or sets the physical address of the person.
    /// </summary>
    public string Address { get; set; } = null!;
}
