namespace AviaTicket.Model.Races;

public class RaceUpdateModel
{
    public long Id { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime DateOfFly { get; set; }
    public long AirplaneId { get; set; }
}
