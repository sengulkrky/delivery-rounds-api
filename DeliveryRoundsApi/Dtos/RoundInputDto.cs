using System.ComponentModel.DataAnnotations;

namespace DeliveryRoundsApi.Dtos;

public class RoundInputDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date is required.")]
    public DateOnly? Date { get; set; }

    [Required(ErrorMessage = "Driver name is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Driver name must be between 1 and 100 characters.")]
    public string DriverName { get; set; } = string.Empty;

    [Range(1, 50, ErrorMessage = "Max stops must be between 1 and 50.")]
    public int MaxStops { get; set; }
}
