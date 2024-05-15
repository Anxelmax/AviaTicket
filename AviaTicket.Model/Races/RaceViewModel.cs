namespace AviaTicket.Model.Races;

public class RaceViewModel
{
    public long Id { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime DateOfFly { get; set; }
    public long AirplaneId { get; set; }
}
