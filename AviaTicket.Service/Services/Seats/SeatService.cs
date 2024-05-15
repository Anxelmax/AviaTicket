using AutoMapper;
using AviaTicket.DataAccess.Repositories;
using AviaTicket.Domain.Entities;
using AviaTicket.Model.Seats;

namespace AviaTicket.Service.Services.Seats;
public class SeatService(IRepository<Seat> repository, IMapper mapper) : ISeat
{
    public async Task<SeatViewModel> CreateAsync(SeatCreateModel model)
    {
        var existModel = await repository.SelectAsync(s => s.Name == model.Name);
        if (existModel is not null) throw new Exception("This seat is always exsits");

        var createdModel = mapper.Map<Seat>(model);
        await repository.InsertAsync(createdModel);
        await repository.SaveChangesAsync();

        return mapper.Map<SeatViewModel>(createdModel);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existModel = await repository.SelectAsync(s => s.Id == id);
        if (existModel is null) throw new Exception("This seat is not found");

        await repository.DeleteAsync(existModel);
        await repository.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<SeatViewModel>> GetAllAsync()
    {
        var models = await repository.SelectAllAsync();
        return mapper.Map<IEnumerable<SeatViewModel>>(models);
    }

    public async Task<SeatViewModel> GetAsync(long id)
    {
        var existModel = await repository.SelectAsync(s => s.Id == id);
        if (existModel is null) throw new Exception("This seat is not found");

        return mapper.Map<SeatViewModel>(existModel);
    }

    public async Task<SeatViewModel> UpdateAsync(long id, SeatUpdateModel model)
    {
        var existModel = await repository.SelectAsync(s => s.Id == id);
        if (existModel is null) throw new Exception("This seat is not found");

        existModel.Name = model.Name;
        existModel.IsFree = model.IsFree;

        return mapper.Map<SeatViewModel>(existModel);
    }
}
