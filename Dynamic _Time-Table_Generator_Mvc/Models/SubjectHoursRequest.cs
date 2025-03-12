using System.ComponentModel.DataAnnotations;

namespace Dynamic__Time_Table_Generator_Mvc.Models
{
    public class SubjectHoursRequest
    {
        [Required(ErrorMessage = "Subject Name is required.")]
        [StringLength(100, ErrorMessage = "Subject Name cannot exceed 100 characters.")]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "Hours are required.")]
        [Range(1, 10, ErrorMessage = "Hours should be between 1 and 10.")]
        [Display(Name = "Hours per Subject")]
        public int Hours { get; set; }
    }
}