using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI.Models
{
    public class ExerciseShiftDto
    {
        public int ExerciseId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ExerciseDate { get; set; }
        public string? Comments { get; set; }
    }
}
