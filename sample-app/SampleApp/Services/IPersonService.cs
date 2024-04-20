using SampleApp.Models;

namespace SampleApp.Services;

public interface IPersonService
{
    /// <summary>
    /// Creates a person and returns the identifier.
    /// </summary>
    /// <param name="person">Person</param>
    /// <returns>Identifier</returns>
    Task<Guid> CreatePerson(Person person);

    /// <summary>
    /// Retrieves a person by identifier.
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Person (or null if not found)</returns>
    Task<Person?> GetPerson(Guid id);

    /// <summary>
    /// Deletes a person by identifier.
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns></returns>
    Task DeletePerson(Guid id);
}
