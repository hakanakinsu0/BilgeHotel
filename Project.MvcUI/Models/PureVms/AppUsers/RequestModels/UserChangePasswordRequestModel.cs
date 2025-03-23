using System.ComponentModel.DataAnnotations;

public class UserChangePasswordRequestModel : IValidatableObject
{
    [Required(ErrorMessage = "{0} zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mevcut Şifre")]
    public string CurrentPassword { get; set; }

    [Required(ErrorMessage = "{0} zorunludur.")]
    [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
    [DataType(DataType.Password)]
    [Display(Name = "Yeni Şifre")]
    public string NewPassword { get; set; }

    [Required(ErrorMessage = "{0} zorunludur.")]
    [Compare("NewPassword", ErrorMessage = "{0} ile {1} eşleşmiyor.")]
    [DataType(DataType.Password)]
    [Display(Name = "Yeni Şifre Tekrar")]
    public string ConfirmPassword { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Yeni şifrenin mevcut şifre ile aynı olmamasını kontrol ediyoruz.
        if (CurrentPassword == NewPassword)
        {
            yield return new ValidationResult("Yeni şifre, mevcut şifre ile aynı olmamalıdır.",new[] { nameof(CurrentPassword) });
        }
    }
}

