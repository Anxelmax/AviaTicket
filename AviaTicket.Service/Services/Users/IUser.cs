using AviaTicket.Model.Users;

namespace AviaTicket.Service.Services.Users;

public interface IUser
{
    Task<UserViewModel> CreateAsync(UserCreateModel model);
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<UserViewModel> GetAsync(long id);
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}
