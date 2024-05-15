using AviaTicket.Model.Tickets;

namespace AviaTicket.Service.Services.Tickets;

public interface ITicket
{
    Task<TicketViewModel> CreateAsync(TicketCreateModel model);
    Task<TicketViewModel> UpdateAsync(long id, TicketUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<TicketViewModel> GetAsync(long id);
    Task<IEnumerable<TicketViewModel>> GetAllAsync();
}
