using DeliveryRoundsApi.Model;

namespace DeliveryRoundsApi.Dtos;

public class StopDto
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string RecipientName { get; set; } = string.Empty;
    public StopStatus Status { get; set; }
    public string? FailureReason { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}
