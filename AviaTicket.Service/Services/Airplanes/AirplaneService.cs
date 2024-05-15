using AutoMapper;
using AviaTicket.DataAccess.Repositories;
using AviaTicket.Domain.Entities;
using AviaTicket.Model.Airplanes;

namespace AviaTicket.Service.Services.Airplanes;

public class AirplaneService(IRepository<Airplane> repository, IMapper mapper) : IAirplane
{
    public async Task<AirplaneViewModel> CreateAsync(AirplaneCreateModel model)
    {
        var existModel = await repository.SelectAsync(a => a.Name == model.Name);
        if (existModel is not null)
            throw new Exception("This airplane is always exists");

        var createdModel = mapper.Map<Airplane>(model);
        await repository.InsertAsync(createdModel);
        await repository.SaveChangesAsync();

        return mapper.Map<AirplaneViewModel>(createdModel);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existModel = await repository.SelectAsync(a => a.Id == id);
        if (existModel is null)
            throw new Exception("This airplane is not found");

        await repository.DeleteAsync(existModel);
        await repository.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<AirplaneViewModel>> GetAllAsync()
    {
        var models = await repository.SelectAllAsync(includes: ["Seat"]);
        var result = mapper.Map<IEnumerable<AirplaneViewModel>>(models);
        return await Task.FromResult(result);
    }

    public async Task<AirplaneViewModel> GetAsync(long id)
    {
        var existModel = await repository.SelectAsync(a => a.Id == id);
        if (existModel is null)
            throw new Exception("This airplane is not found");

        return mapper.Map<AirplaneViewModel>(existModel);
    }

    public async Task<AirplaneViewModel> UpdateAsync(long id, AirplaneUpdateModel model)
    {
        var existModel = await repository.SelectAsync(a => a.Id == id);
        if (existModel is null)
            throw new Exception("This airplane is not found");

        existModel.Name = model.Name;
        await repository.UpdateAsync(existModel);
        await repository.SaveChangesAsync();

        return mapper.Map<AirplaneViewModel>(existModel);
    }
}
