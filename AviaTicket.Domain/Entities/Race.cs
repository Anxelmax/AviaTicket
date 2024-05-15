using AviaTicket.Domain.Commons;

namespace AviaTicket.Domain.Entities;

public class Race : Auditable
{
    public string From { get; set; }
    public string To { get; set; }
    public DateTime DateOfFly { get; set; }
    public long AirplaneId { get; set; }
    public Airplane Airplane { get; set; }
}
