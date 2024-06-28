using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Book.ViewModels
{
    public class HomeYaratishViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "iltimos Titleni kiriting!")]
        [StringLength(50, ErrorMessage = "Title uzunligi 50ta harfdan oshib ketdi")]
        public string Title { get; set; }

        [Required(ErrorMessage = "iltimos Authorni kiriting!")]
        public string Author { get; set; }

        [Required(ErrorMessage = "iltimos Chop etilgan yilini kiriting!")]
        [CurrentYear]
        public int PublishedYear { get; set; }

        [Required(ErrorMessage = "iltimos Rasmni kiriting!")]
        public IFormFile Photo { get; set; }
    }

    // cheklov
    public class CurrentYearAttribute : ValidationAttribute
    {
        public CurrentYearAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;
                if (year >= 1000 && year <= currentYear)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Yil 1000 va {currentYear} orasida bo'lishi kerak");
                }
            }
            return new ValidationResult("Xayo yil");
        }
    }
}
