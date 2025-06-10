namespace ExerciseTracker.Study.Models.DTO
{
    public class ExerciseShiftDto
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string? Comments { get; set; }
    }
}
