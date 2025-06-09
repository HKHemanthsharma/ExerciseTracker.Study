namespace ExerciseTracker.Study.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseShift> ExerciseShifts { get; set; }
    }
}
