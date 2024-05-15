namespace AviaTicket.Model.Tickets;

public class TicketCreateModel
{
    public long SeatId { get; set; }
    public long SoldBy { get; set; }
    public long UserId { get; set; }
    public long RaceId { get; set; }
    public decimal Price { get; set; }
}
