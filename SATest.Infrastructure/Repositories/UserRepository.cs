using Dapper;
using Microsoft.Extensions.Configuration;
using SATest.Entities.Entities;
using SATest.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SATest.Infrastructure.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {

    }
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> Add(User entity)
        {
            var sql = @"INSERT INTO [dbo].[User] ([FirstName], [LastName], [Email], [IsMale], [Status]) VALUES (@FirstName, @LastName, @Email, @IsMale, @Status)
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var insertedId = await connection.QuerySingleAsync<int>(sql, entity);
                return insertedId;
            }
        }

        public async Task<User> Get(int id)
        {
            var sql = "SELECT [Id], [FirstName], [LastName], [Email], [IsMale], [Status] FROM [dbo].[User] WHERE [Id] = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = "SELECT [Id], [FirstName], [LastName], [Email], [IsMale], [Status] FROM [dbo].[User] ";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var results = await connection.QueryAsync<User>(sql);
                return results;
            }
        }
    }
}
