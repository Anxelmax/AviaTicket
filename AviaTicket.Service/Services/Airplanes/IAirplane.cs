using AviaTicket.Model.Airplanes;

namespace AviaTicket.Service.Services.Airplanes;

public interface IAirplane
{
    Task<AirplaneViewModel> CreateAsync(AirplaneCreateModel model);
    Task<AirplaneViewModel> UpdateAsync(long id, AirplaneUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<AirplaneViewModel> GetAsync(long id);
    Task<IEnumerable<AirplaneViewModel>> GetAllAsync();
}
