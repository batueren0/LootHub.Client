using System.ComponentModel.DataAnnotations;

namespace LootHub.Client.Mvc.Models;

public class AddressFormViewModel
{
    [Required(ErrorMessage = "Başlık boş olamaz.")]
    [StringLength(50, ErrorMessage = "50 karakterden fazla olamaz.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Detay boş olamaz.")]
    [StringLength(128, ErrorMessage = "128 karakterden fazla olamaz.")]
    public string Details { get; set; } = string.Empty;

    [Required(ErrorMessage = "Şehir boş olamaz.")]
    [StringLength(50, ErrorMessage = "50 karakterden fazla olamaz.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ülke boş olamaz.")]
    [StringLength(50, ErrorMessage = "50 karakterden fazla olamaz.")]
    public string Country { get; set; } = "Türkiye";
}
