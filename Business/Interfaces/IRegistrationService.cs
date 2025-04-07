using Registration_Page_Task.Models;

namespace Registration_Page_Task.Business.Interfaces
{
    public interface IRegistrationService
    {
        // Get all registrations
        Task<IEnumerable<Registrations>> GetAllAsync();

        // Get a registration by ID
        Task<Registrations?> GetByIdAsync(int id);

        // Create a new registration
        Task<bool> CreateAsync(Registrations reg);

        // Update an existing registration
        Task<bool> UpdateAsync(Registrations reg);

        // Delete a registration by ID
        Task<bool> DeleteAsync(int id);
    }
}
