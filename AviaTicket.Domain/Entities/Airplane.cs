using AviaTicket.Domain.Commons;

namespace AviaTicket.Domain.Entities;

public class Airplane : Auditable
{
    public string Name { get; set; }
    public IList<Seat> Seat { get; set; }
}
