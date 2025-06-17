using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI.Models
{
    public class ExerciseShift
    {
            public int Id { get; set; }
            public int ExerciseId { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public DateTime ExerciseDate { get; set; }
            public int Duration { get; set; }
            public string? Comments { get; set; }
            public Exercise Exercise { get; set; }
        
    }
}
