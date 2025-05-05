using DemoLibrary.Models;

namespace DemoLibrary.DataAccess;

public class DemoDataAccess : IDataAccess
{
    private readonly List<PersonModel> people = [];

    public DemoDataAccess() =>
        people.AddRange(
            new()
            {
                Id = 1,
                FirstName = "Michael",
                LastName = "Bond"
            },
            new()
            {
                Id = 2,
                FirstName = "Shannan",
                LastName = "Bond"
            });

    public List<PersonModel> GetPeople() => people;

    public PersonModel InsertPerson(string firstName, string lastName)
    {
        var p = new PersonModel
        {
            FirstName = firstName,
            LastName = lastName,
            Id = people.Max(x => x.Id) + 1
        };

        people.Add(p);

        return p;
    }
}
