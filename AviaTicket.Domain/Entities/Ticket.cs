using AviaTicket.Domain.Commons;

namespace AviaTicket.Domain.Entities;

public class Ticket : Auditable
{
    public long SeatId { get; set; }
    public Seat Seat { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public int Price { get; set; }
}
