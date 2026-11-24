using DeliveryRoundsApi.Model;

namespace DeliveryRoundsApi.Dtos;

public static class RoundMappings
{
    public static RoundDto ToDto(this Round round)
    {
        return new RoundDto
        {
            Id = round.Id,
            Name = round.Name,
            Date = round.Date,
            DriverName = round.DriverName,
            MaxStops = round.MaxStops,
            IsClosed = round.IsClosed
        };
    }

    public static RoundDetailDto ToDetailDto(this Round round)
    {
        return new RoundDetailDto
        {
            Id = round.Id,
            Name = round.Name,
            Date = round.Date,
            DriverName = round.DriverName,
            MaxStops = round.MaxStops,
            IsClosed = round.IsClosed,
            Stops = round.Stops.Select(s => s.ToDto()).ToList()
        };
    }

    public static Round ToEntity(this RoundInputDto dto)
    {
        return new Round
        {
            Name = dto.Name,
            Date = (DateOnly)dto.Date,
            DriverName = dto.DriverName,
            MaxStops = dto.MaxStops
        };
    }
}
