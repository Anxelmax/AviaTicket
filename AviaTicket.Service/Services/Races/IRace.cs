using AviaTicket.Model.Races;

namespace AviaTicket.Service.Services.Races;

public interface IRace
{
    Task<RaceViewModel> CreateAsync(RaceCreateModel model);
    Task<RaceViewModel> UpdateAsync(long id, RaceCreateModel model);
    Task<bool> DeleteAsync(long id);
    Task<RaceViewModel> GetAsync(long id);
    Task<IEnumerable<RaceViewModel>> GetAllAsync();
}
