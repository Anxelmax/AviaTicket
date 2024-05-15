using AviaTicket.Domain.Commons;

namespace AviaTicket.Domain.Entities;

public class Seat : Auditable
{
    public string Name { get; set; }
    public bool IsFree { get; set; } = true;
}
