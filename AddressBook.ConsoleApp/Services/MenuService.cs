
using Shared.Models;
using Shared.Interfaces;


namespace AddressBook.ConsoleApp.Services;


public class MenuService
{
    private readonly IPersonRepository _personRepository;

    public MenuService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }


    
    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("#  MAIN MENU  #");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Add a new person");
            Console.WriteLine("2. Show all persons in the list");
            Console.WriteLine("3. Show a specific person in the list");
            Console.WriteLine("4. Remove a person from the list");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("5. Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddPersonMenu();
                    break;
                case "2":
                    ShowAllPersonsMenu();
                    break;
                case "3":
                    ShowPersonByEmailMenu();
                    break;
                case "4":
                    DeletePersonInList();
                    break;
                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
            Console.ReadKey();
        }
    }


    public  void AddPersonMenu()
    {
        Person person = new Person();

        Console.Clear();
        Console.WriteLine("Enter first name: ");
        person.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter last name: ");
        person.LastName = Console.ReadLine()!;

        Console.WriteLine("Enter email address: ");
        person.Email = Console.ReadLine()!;

        Console.WriteLine("Enter phone number: ");
        person.PhoneNumber = Console.ReadLine()!;

        Console.WriteLine("Enter your home address: ");
        person.Address = Console.ReadLine()!;


        var existingPerson = _personRepository.GetPersonByEmail(person.Email);

        if (existingPerson != null)
        {
            Console.WriteLine("User already exists.");
            return;
        }

        bool added = _personRepository.AddPersonToList(person);

        if (added)
        {
            Console.WriteLine("User added successfully.");
        }
        else
        {
            Console.WriteLine("Failed to add user. The email might already exist.");
        }
        Console.WriteLine();

        if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName) ||
       string.IsNullOrEmpty(person.PhoneNumber) || string.IsNullOrEmpty(person.Email) ||
       string.IsNullOrEmpty(person.Address))
        {
            Console.WriteLine("Invalid input. All fields are required.");
            return;
        }
    }



    public  void ShowAllPersonsMenu()
    {
        var persons = _personRepository.GetPersonsFromList();

        Console.WriteLine("All Contacts:");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-15} {4,-40}", "First Name", "Last Name", "Email", "Phone Number", "Address");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");

        if (persons != null && persons.Any())
        {
            foreach (var person in persons)
            {
                if (person is Person p)
                {

                    Console.WriteLine("{0,-15} {1,-15} {2,-30} {3,-15} {4,-40}", p.FirstName, p.LastName, p.Email, p.PhoneNumber, p.Address);
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }
        else
        {
            Console.WriteLine("The list is empty.");
        }
        Console.WriteLine();
    }



    public void ShowPersonByEmailMenu()
    {
        Console.WriteLine("Enter the email of the user: ");
        var email = Console.ReadLine();

        if (!string.IsNullOrEmpty(email))
        {
            var person = _personRepository.GetPersonByEmail(email);

            if (person != null)
            {
                if (person is Person p)
                {
                    Console.WriteLine("Contact:");
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine($"Name: {p.FirstName} {p.LastName}");
                    Console.WriteLine($"Email: <{p.Email}>");
                    Console.WriteLine($"Phone Number: {p.PhoneNumber}");
                    Console.WriteLine($"Address: {p.Address}");
                    Console.WriteLine("------------------------------------------------------------");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The person you are looking for is not in the list. ");
            }
        }

    }


    public void DeletePersonInList()
    {
        Console.WriteLine("Enter the email of the user to remove: ");
        var emailToRemove = Console.ReadLine();

        if (!string.IsNullOrEmpty(emailToRemove))
        {
            bool removed = _personRepository.RemovePersonFromList(emailToRemove);

            if (removed)
            {
                Console.WriteLine("User removed successfully.");
            }
            else
            {
                Console.WriteLine("User not found or unable to remove.");
            }
        }
    }
}


