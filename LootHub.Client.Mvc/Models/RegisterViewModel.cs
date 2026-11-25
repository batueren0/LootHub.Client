using System.ComponentModel.DataAnnotations;

namespace LootHub.Client.Mvc.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage ="İsim boş olamaz.")]
    [StringLength(50 , ErrorMessage = "En fazla 50 karakter olabilir.")]
    public string FirstName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Soyisim boş olamaz.")]
    [StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir.")]
    public string LastName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Telefon numarası boş olamaz.")]
    [RegularExpression(@"^5\d{9}$", ErrorMessage = "5 ile başlayan 10 haneli numara gir (örn. 5321234567).")]
    public string PhoneNumber { get; set; } = string.Empty;


    [Required(ErrorMessage = "E-posta boş olamaz.")]
    [StringLength(256, ErrorMessage = "En fazla 256 karakter olabilir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta gir.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Şifre boş olamaz.")]
    [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalı.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;


    [Required(ErrorMessage = "Şifre tekrarı boş olamaz.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmalı.")]
    public string ConfirmPassword { get; set; } = string.Empty;

}
