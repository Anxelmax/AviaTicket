using AviaTicket.Model.Seats;

namespace AviaTicket.Service.Services.Seats;

public interface ISeat
{
    Task<SeatViewModel> CreateAsync(SeatCreateModel model);
    Task<SeatViewModel> UpdateAsync(long id, SeatUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<SeatViewModel> GetAsync(long id);
    Task<IEnumerable<SeatViewModel>> GetAllAsync();
}
