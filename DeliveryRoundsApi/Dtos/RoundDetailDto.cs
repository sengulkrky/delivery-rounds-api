namespace DeliveryRoundsApi.Dtos;

public class RoundDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public int MaxStops { get; set; }
    public bool IsClosed { get; set; }

    public List<StopDto> Stops { get; set; } = [];
}
