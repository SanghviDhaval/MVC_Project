using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dynamic__Time_Table_Generator_Mvc.Models
{
    public class TimeTableRequest
    {
        [Display(Name = "Working Days")]
        [Range(1, 7, ErrorMessage = "Please enter a valid number of working days (between 1 and 7).")]
        public int WorkingDays { get; set; }

        [Display(Name = "Subjects Per Day")]
        [Range(1, 8, ErrorMessage = "Please enter a valid number of subjects per day (between 1 and 8).")]
        public int SubjectsPerDay { get; set; }

        [Display(Name = "Total Subjects")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid number of total subjects.")]
        public int TotalSubjects { get; set; }

        public List<SubjectHoursRequest> Subjects { get; set; } = new List<SubjectHoursRequest>();

        // Total hours for the week (calculated)
        [Display(Name = "Total Hours for the Week")]
        public int TotalHours { get; set; }
    }
}