using AutoMapper;
using AviaTicket.DataAccess.Repositories;
using AviaTicket.Domain.Entities;
using AviaTicket.Model.Tickets;

namespace AviaTicket.Service.Services.Tickets;

public class TicketService(IRepository<Ticket> repository, IMapper mapper) : ITicket
{
    public async Task<TicketViewModel> CreateAsync(TicketCreateModel model)
    {
        var existSeat = await repository.SelectAsync(s => s.SeatId == model.SeatId);
        if (existSeat is not null)
            throw new Exception("This seat is not free");

        var existUser = await repository.SelectAsync(s => s.UserId == model.UserId);
        if (existUser is not null)
            throw new Exception("This user is always bought ticket for this race");

        var createdModel = mapper.Map<Ticket>(model);
        await repository.InsertAsync(createdModel);
        await repository.SaveChangesAsync();

        return mapper.Map<TicketViewModel>(createdModel);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existModel = await repository.SelectAsync(t => t.Id == id);
        if (existModel is null) throw new Exception("This ticket is not found");
        await repository.DeleteAsync(existModel);
        await repository.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TicketViewModel>> GetAllAsync()
    {
        var models = await repository.SelectAllAsync(includes: ["Seat", "SoldByUser", "User"]);
        return mapper.Map<IEnumerable<TicketViewModel>>(models);
    }

    public async Task<TicketViewModel> GetAsync(long id)
    {
        var existModel = await repository.SelectAsync(t => t.Id == id);
        if (existModel is null) throw new Exception("This ticket is not found");
        return mapper.Map<TicketViewModel>(existModel);
    }

    public async Task<TicketViewModel> UpdateAsync(long id, TicketUpdateModel model)
    {
        var existModel = await repository.SelectAsync(t => t.Id == id);
        if (existModel is null) throw new Exception("This ticket is not found");
        existModel.SeatId = model.SeatId;
        existModel.UserId = model.UserId;
        await repository.UpdateAsync(existModel);
        await repository.SaveChangesAsync();
        return mapper.Map<TicketViewModel>(existModel);
    }
}
