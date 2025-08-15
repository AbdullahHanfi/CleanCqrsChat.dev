namespace Domain.Repositories;

using Entities;
using Shared;

public interface IUserRepository {
    Task<Result<User>> GetByIdAsync(Guid id);
    Task<Result<User>> GetByEmailAsync(string email);
    
    Task<Result<User>> CreateAsync(User user, string password);
    Task UpdateAsync(User user);
    
    Task<bool> CheckPasswordAsync(User user, string password);

    Task<IEnumerable<Result<User>>> GetUsersBynameAsync(string username);
    Task<IEnumerable<Result<User>>> GetUsersAsync(List<Guid> userIds);
}