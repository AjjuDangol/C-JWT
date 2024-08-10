using System.ComponentModel.DataAnnotations;

namespace GroupAssignments.Models
{
    public class VerifyModel
    {
        [Required]
        [Display(Name = "Verification Code")]
        public string VerificationCode { get; set; }
        public string Code { get; internal set; }
    }
}
