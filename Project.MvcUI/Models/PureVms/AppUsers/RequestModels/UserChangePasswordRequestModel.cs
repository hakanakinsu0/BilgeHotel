using System.ComponentModel.DataAnnotations;

/// <summary>
/// Kullanıcının mevcut şifresini girerek yeni bir şifre belirlemesini sağlayan modeldir.
/// Yeni şifre, belirli güvenlik kurallarına uygun olmalı ve mevcut şifreyle aynı olmamalıdır.
/// </summary>
public class UserChangePasswordRequestModel : IValidatableObject
{
    /// <summary>
    /// Kullanıcının mevcut şifresidir. Yeni şifre ile aynı olmamalıdır.
    /// </summary>
    [Required(ErrorMessage = "{0} zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mevcut Şifre")]
    public string CurrentPassword { get; set; }

    /// <summary>
    /// Kullanıcının belirleyeceği yeni şifredir.
    /// En az 6 karakter, bir büyük harf, bir küçük harf ve bir rakam içermelidir.
    /// </summary>
    [Required(ErrorMessage = "{0} zorunludur.")]
    [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
    [DataType(DataType.Password)]
    [Display(Name = "Yeni Şifre")]
    public string NewPassword { get; set; }

    /// <summary>
    /// Kullanıcının yeni şifreyi doğrulamak için tekrar girdiği alandır.
    /// Yeni şifre ile birebir aynı olmalıdır.
    /// </summary>
    [Required(ErrorMessage = "{0} zorunludur.")]
    [Compare("NewPassword", ErrorMessage = "{0} ile {1} eşleşmiyor.")]
    [DataType(DataType.Password)]
    [Display(Name = "Yeni Şifre Tekrar")]
    public string ConfirmPassword { get; set; }

    /// <summary>
    /// Ek validasyon kontrolü: Yeni şifre, mevcut şifre ile aynı olamaz.
    /// </summary>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CurrentPassword == NewPassword)
        {
            yield return new ValidationResult(
                "Yeni şifre, mevcut şifre ile aynı olmamalıdır.",
                new[] { nameof(CurrentPassword) }
            );
        }
    }
}
