using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dynamic__Time_Table_Generator_Mvc.Models;

namespace Dynamic__Time_Table_Generator_Mvc.Controllers
{
    public class TimeTableController : Controller
    {
        
        public ActionResult Index()
        {
            var model = new TimeTableRequest
            {
                TotalHours = 0, 
                Subjects = new List<SubjectHoursRequest>() 
            };
            return View(model);
        }

     
        [HttpPost]
        public ActionResult CreateTimeTable(TimeTableRequest model)
        {
            if (ModelState.IsValid)
            {
                 model.Subjects = new List<SubjectHoursRequest>();
                for (int i = 0; i < model.TotalSubjects; i++)
                {
                    model.Subjects.Add(new SubjectHoursRequest { SubjectName = $"Subject {i + 1}" });
                }

                 model.TotalHours = model.WorkingDays * model.SubjectsPerDay;

                return View("SubjectHours", model); 
            }

            return View("Index", model);
        }

      
        [HttpPost]
        public ActionResult GenerateTimetable(TimeTableRequest model)
        {
            var totalEnteredHours = model.Subjects.Sum(s => s.Hours);
            var expectedTotalHours = model.WorkingDays * model.SubjectsPerDay;

            if (totalEnteredHours != expectedTotalHours)
            {
                ModelState.AddModelError("", "The total hours for all subjects must equal the total hours for the week.");
                return View("SubjectHours", model);
            }

            
            var timetable = GenerateTimetableGrid(model);

            return View("TimeTableGenerated", timetable);   
        }

        private List<List<string>> GenerateTimetableGrid(TimeTableRequest model)
        {
            var timetable = new List<List<string>>();
            var timetableGrid = new string[model.SubjectsPerDay, model.WorkingDays];

            foreach (var subject in model.Subjects)
            {
                int hoursRemaining = subject.Hours;
                for (int day = 0; day < model.WorkingDays; day++)
                {
                    for (int period = 0; period < model.SubjectsPerDay; period++)
                    {
                        if (hoursRemaining > 0 && timetableGrid[period, day] == null)
                        {
                            timetableGrid[period, day] = subject.SubjectName;
                            hoursRemaining--;
                        }
                    }
                }
            }

            for (int i = 0; i < model.SubjectsPerDay; i++)
            {
                var row = new List<string>();
                for (int j = 0; j < model.WorkingDays; j++)
                {
                    row.Add(timetableGrid[i, j] ?? "");
                }
                timetable.Add(row);
            }

            return timetable;
        }
    }

}
