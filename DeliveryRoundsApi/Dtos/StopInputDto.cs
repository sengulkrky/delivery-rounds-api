using System.ComponentModel.DataAnnotations;

namespace DeliveryRoundsApi.Dtos;

public class StopInputDto
{
    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be between 1 and 200 characters.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Recipient name is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Recipient name must be between 1 and 100 characters.")]
    public string RecipientName { get; set; } = string.Empty;
}
