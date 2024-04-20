using Dapper;
using Microsoft.Data.SqlClient;
using SampleApp.Models;

namespace SampleApp.Services;

public class PersonService : IPersonService
{
    private readonly string _connectionString;

    public PersonService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Guid> CreatePerson(Person person)
    {
        const string sql =
            """
            INSERT INTO dbo.Person (FirstName, LastName, Gender)
            OUTPUT inserted.Id
            VALUES (@FirstName, @LastName, @Gender)
            """;

        await using var connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<Guid>(sql, person);
    }

    public async Task<Person?> GetPerson(Guid id)
    {
        const string sql =
            """
            SELECT *
            FROM dbo.Person
            WHERE Id=@Id
            """;

        await using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
    }

    public async Task DeletePerson(Guid id)
    {
        const string sql =
            """
            DELETE FROM dbo.Person
            WHERE Id=@Id
            """;

        await using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}
