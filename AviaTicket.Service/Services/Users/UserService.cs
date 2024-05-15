using AutoMapper;
using AviaTicket.DataAccess.Repositories;
using AviaTicket.Domain.Entities;
using AviaTicket.Model.Users;

namespace AviaTicket.Service.Services.Users;

public class UserService(IRepository<User> repository, IMapper mapper) : IUser
{
    public async Task<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var existModel = await repository.SelectAsync(u => u.Login == model.Login);
        if (existModel is not null) throw new Exception("This user with login is always exists");

        var createdModel = mapper.Map<User>(model);
        await repository.InsertAsync(createdModel);
        await repository.SaveChangesAsync();

        return mapper.Map<UserViewModel>(createdModel);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existModel = await repository.SelectAsync(u => u.Id == id);
        if (existModel is null) throw new Exception("This user is not found");

        await repository.DeleteAsync(existModel);
        await repository.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var models = await repository.SelectAllAsync(includes: ["Role"]);
        return mapper.Map<IEnumerable<UserViewModel>>(models);
    }

    public async Task<UserViewModel> GetAsync(long id)
    {
        var existModel = await repository.SelectAsync(u => u.Id == id);
        if (existModel is null) throw new Exception("This user is not found");

        return mapper.Map<UserViewModel>(existModel);
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model)
    {
        var existModel = await repository.SelectAsync(u => u.Id == id);
        if (existModel is null) throw new Exception("This user is not found");

        existModel.Login = model.Login;
        existModel.Password = model.Password;
        existModel.UpdatedAt = DateTime.UtcNow;
        await repository.UpdateAsync(existModel);
        await repository.SaveChangesAsync();
        return mapper.Map<UserViewModel>(existModel);
    }
}
