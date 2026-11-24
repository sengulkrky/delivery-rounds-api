namespace DeliveryRoundsApi.Model;

public class Stop
{
    public int Id { get; set; }
    public int RoundId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string RecipientName { get; set; } = string.Empty;
    public StopStatus Status { get; set; } = StopStatus.Pending;
    public string? FailureReason { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public Round? Round { get; set; }
}
