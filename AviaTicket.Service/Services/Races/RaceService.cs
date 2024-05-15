using AutoMapper;
using AviaTicket.DataAccess.Repositories;
using AviaTicket.Domain.Entities;
using AviaTicket.Model.Races;

namespace AviaTicket.Service.Services.Races;

public class RaceService(IRepository<Race> repository, IMapper mapper) : IRace
{
    public async Task<RaceViewModel> CreateAsync(RaceCreateModel model)
    {
        var createdModel = mapper.Map<Race>(model);
        await repository.InsertAsync(createdModel);
        await repository.SaveChangesAsync();

        return mapper.Map<RaceViewModel>(createdModel);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existModel = await repository.SelectAsync(r => r.Id == id);
        if (existModel is null)
            throw new Exception("This race is not found");

        await repository.DeleteAsync(existModel);
        await repository.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<RaceViewModel>> GetAllAsync()
    {
        var models = await repository.SelectAllAsync(includes: ["Airplane"]);
        return mapper.Map<IEnumerable<RaceViewModel>>(models);
    }

    public async Task<RaceViewModel> GetAsync(long id)
    {
        var existModel = await repository.SelectAsync(r => r.Id == id);
        if (existModel is null)
            throw new Exception("This race is not found");

        return mapper.Map<RaceViewModel>(existModel);
    }

    public async Task<RaceViewModel> UpdateAsync(long id, RaceCreateModel model)
    {
        var existModel = await repository.SelectAsync(r => r.Id == id);
        if (existModel is null)
            throw new Exception("This race is not found");

        existModel.From = model.From;
        existModel.To = model.To;
        existModel.DateOfFly = model.DateOfFly;
        existModel.AirplaneId = model.AirplaneId;
        await repository.UpdateAsync(existModel);
        await repository.SaveChangesAsync();

        return mapper.Map<RaceViewModel>(existModel);
    }
}
