using Npgsql;
using Registration_Page_Task.Business.Interfaces;
using Registration_Page_Task.DataAccess.Interfaces;
using Registration_Page_Task.Models;

namespace Registration_Page_Task.DataAccess.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IConfiguration _config;

        // Injecting configuration to access connection string
        public RegistrationRepository(IConfiguration config) => _config = config;

        // Create a PostgreSQL connection
        private NpgsqlConnection CreateConnection() =>
            new(_config.GetConnectionString("DefaultConnection"));

        // Get all users using stored procedure
        public async Task<IEnumerable<Registrations>> GetAllAsync()
        {
            var result = new List<Registrations>();
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT * FROM get_all_users()", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new Registrations
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Password = reader.GetString(4),
                    CreatedAt = reader.GetDateTime(5)
                });
            }
            return result;
        }

        // Get user by ID using stored procedure
        public async Task<Registrations?> GetByIdAsync(int id)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT * FROM user_by_id(@_id)", conn);
            cmd.Parameters.AddWithValue("_id", id);
            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Registrations
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Password = reader.GetString(4),
                    CreatedAt = reader.GetDateTime(5)
                };
            }
            return null;
        }

        // Create new user using stored procedure
        public async Task<bool> CreateAsync(Registrations reg)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT create_user(@_fullname, @_email, @_phone, @_password)", conn);
            cmd.Parameters.AddWithValue("_fullname", reg.FullName);
            cmd.Parameters.AddWithValue("_email", reg.Email);
            cmd.Parameters.AddWithValue("_phone", reg.Phone);
            cmd.Parameters.AddWithValue("_password", reg.Password);

            var result = await cmd.ExecuteScalarAsync();
            return result is bool success && success;
        }

        // Update user using stored procedure
        public async Task<bool> UpdateAsync(Registrations reg)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT update_user(@_id, @_fullname, @_email, @_phone, @_password)", conn);
            cmd.Parameters.AddWithValue("_id", reg.Id);
            cmd.Parameters.AddWithValue("_fullname", reg.FullName);
            cmd.Parameters.AddWithValue("_email", reg.Email);
            cmd.Parameters.AddWithValue("_phone", reg.Phone);
            cmd.Parameters.AddWithValue("_password", reg.Password);

            var result = await cmd.ExecuteScalarAsync();
            Console.WriteLine($"🔍 Update Result: {result} ({result?.GetType().Name})");

            return result is bool success && success;
        }

        // Delete user using stored procedure
        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = CreateConnection();
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT delete_user(@_id)", conn);
            cmd.Parameters.AddWithValue("_id", id);

            var result = await cmd.ExecuteScalarAsync();
            return result is bool success && success;
        }
    }
}
