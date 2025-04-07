using Registration_Page_Task.Business.Interfaces;
using Registration_Page_Task.DataAccess.Interfaces;
using Registration_Page_Task.Models;
using System.Security.Cryptography;
using System.Text;

namespace Registration_Page_Task.Business.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IRegistrationRepository _repo;
    // Constructor injection of repository
    public RegistrationService(IRegistrationRepository repo) => _repo = repo;

    // Get all registrations
    public async Task<IEnumerable<Registrations>> GetAllAsync() => await _repo.GetAllAsync();

    // Get registration by ID
    public async Task<Registrations?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

    // Create a new registration with hashed password
    public async Task<bool> CreateAsync(Registrations reg)
    {
        reg.Password = HashPassword(reg.Password);
        return await _repo.CreateAsync(reg);
    }

    // Update an existing registration with hashed password
    public async Task<bool> UpdateAsync(Registrations reg)
    {
        reg.Password = HashPassword(reg.Password);
        return await _repo.UpdateAsync(reg);
    }

    // Delete a registration by ID
    public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);

    // Hash password using SHA256
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}