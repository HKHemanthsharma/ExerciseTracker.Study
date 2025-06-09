namespace ExerciseTracker.Study.Models
{
    public class ExerciseShift
    {
        public int ShiftId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Comments { get; set; }
        public Exercise Exercise { get; set; }
    }
}
