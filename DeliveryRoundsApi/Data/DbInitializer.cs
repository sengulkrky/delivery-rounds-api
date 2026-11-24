using DeliveryRoundsApi.Model;

namespace DeliveryRoundsApi.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Rounds.Any())
        {
            return;
        }

        var latem = new Round
        {
            Name = "Sint-Martens-Latem ochtend",
            Date = new DateOnly(2026, 11, 24),
            DriverName = "Sengül Karakaya",
            MaxStops = 6,
            IsClosed = false
        };

        latem.Stops.Add(new Stop
        {
            Address = "Kortrijksesteenweg 12, 9830 Sint-Martens-Latem",
            RecipientName = "An Claes",
            CreatedBy = "seed"
        });
        latem.Stops.Add(new Stop
        {
            Address = "Dorp 4, 9830 Sint-Martens-Latem",
            RecipientName = "Pieter Janssens",
            Status = StopStatus.Delivered,
            DeliveredAt = new DateTime(2026, 11, 24, 8, 45, 0),
            CreatedBy = "seed"
        });
        latem.Stops.Add(new Stop
        {
            Address = "Latemstraat 27, 9830 Sint-Martens-Latem",
            RecipientName = "Marie Wouters",
            Status = StopStatus.Failed,
            FailureReason = "Niemand thuis",
            CreatedBy = "seed"
        });

        var gentCentrum = new Round
        {
            Name = "Gent centrum middag",
            Date = new DateOnly(2026, 11, 24),
            DriverName = "Jonas Peeters",
            MaxStops = 2,
            IsClosed = false
        };
        gentCentrum.Stops.Add(new Stop
        {
            Address = "Veldstraat 50, 9000 Gent",
            RecipientName = "Tom De Smet",
            CreatedBy = "seed"
        });
        gentCentrum.Stops.Add(new Stop
        {
            Address = "Korenmarkt 3, 9000 Gent",
            RecipientName = "Sara Willems",
            Status = StopStatus.Delivered,
            DeliveredAt = new DateTime(2026, 11, 24, 12, 10, 0),
            CreatedBy = "seed"
        });

        var deurle = new Round
        {
            Name = "Deurle avond",
            Date = new DateOnly(2026, 11, 23),
            DriverName = "Lotte Maes",
            MaxStops = 10,
            IsClosed = true
        };
        deurle.Stops.Add(new Stop
        {
            Address = "Pontstraat 8, 9831 Deurle",
            RecipientName = "Koen Mertens",
            Status = StopStatus.Delivered,
            DeliveredAt = new DateTime(2026, 11, 23, 18, 30, 0),
            CreatedBy = "seed"
        });
        deurle.Stops.Add(new Stop
        {
            Address = "Philippe de Denterghemlaan 15, 9831 Deurle",
            RecipientName = "Elke Jacobs",
            Status = StopStatus.Delivered,
            DeliveredAt = new DateTime(2026, 11, 23, 18, 55, 0),
            CreatedBy = "seed"
        });

        var drongen = new Round
        {
            Name = "Drongen ochtend",
            Date = new DateOnly(2026, 11, 25),
            DriverName = "Jonas Peeters",
            MaxStops = 8,
            IsClosed = false
        };

        context.Rounds.AddRange(latem, gentCentrum, deurle, drongen);
        context.SaveChanges();
    }
}
