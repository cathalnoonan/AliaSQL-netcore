using Microsoft.Extensions.Configuration;
using SampleApp.Models;

namespace SampleApp.Tests.Services;

public class PersonService
{
    private IConfiguration _configuration;
    private SampleApp.Services.PersonService _personService;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }

    [SetUp]
    public void SetUp()
    {
        _personService = new SampleApp.Services.PersonService(_configuration.GetConnectionString("SampleDatabase")!);
    }

    [Test]
    public async Task creates_person()
    {
        var personToCreate = new Person() { FirstName = "John", LastName = "Smith", Gender = "Male" };
        var id = await _personService.CreatePerson(personToCreate);

        var createdPerson = await _personService.GetPerson(id);

        Assert.Multiple(() =>
        {
            Assert.That(createdPerson, Is.Not.Null);
            Assert.That(createdPerson?.Id, Is.EqualTo(id));
            Assert.That(createdPerson?.FirstName, Is.EqualTo(personToCreate.FirstName));
            Assert.That(createdPerson?.LastName, Is.EqualTo(personToCreate.LastName));
            Assert.That(createdPerson?.Gender, Is.EqualTo(personToCreate.Gender));
        });
    }

    [Test]
    public async Task deletes_person()
    {
        var personToCreate = new Person() { FirstName = "John", LastName = "Smith", Gender = "Male" };
        var id = await _personService.CreatePerson(personToCreate);

        var personBeforeDelete = await _personService.GetPerson(id);
        await _personService.DeletePerson(id);
        var personAfterDelete = await _personService.GetPerson(id);

        Assert.Multiple(() =>
        {
            Assert.That(personBeforeDelete, Is.Not.Null);
            Assert.That(personAfterDelete, Is.Null);
        });
    }
}
