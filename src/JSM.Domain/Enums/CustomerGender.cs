using System.ComponentModel.DataAnnotations;

namespace JSM.Domain.Enums
{
    public enum CustomerGender
    {
        [Display(Name = "Male")]
        M = 1,

        [Display(Name = "Female")]
        F = 2
    }
}
