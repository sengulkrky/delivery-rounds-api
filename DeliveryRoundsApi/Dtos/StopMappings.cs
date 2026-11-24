using DeliveryRoundsApi.Model;

namespace DeliveryRoundsApi.Dtos;

public static class StopMappings
{
    public static StopDto ToDto(this Stop stop)
    {
        return new StopDto
        {
            Id = stop.Id,
            Address = stop.Address,
            RecipientName = stop.RecipientName,
            Status = stop.Status,
            FailureReason = stop.FailureReason,
            DeliveredAt = stop.DeliveredAt,
            CreatedBy = stop.CreatedBy
        };
    }

    public static Stop ToEntity(this StopInputDto dto)
    {
        return new Stop
        {
            Address = dto.Address,
            RecipientName = dto.RecipientName
        };
    }
}
