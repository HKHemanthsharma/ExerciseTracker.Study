using ExerciseTracker.UI.Models;
using ExerciseTracker.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI.Services
{
    public static class ShiftService
    {
        public static readonly Repository<ExerciseShiftDto> Repo = new Repository<ExerciseShiftDto>();
        public static readonly Repository<Exercise> ExerciseRepo = new Repository<Exercise>();
        public static List<Exercise> GetAvailableExercises()
        {
            ResponseDto<Exercise> ExercisesResponse = ExerciseRepo.GetAllEntities().GetAwaiter().GetResult();
            return ExercisesResponse.Data;
        }
            
        public static void CreateShift()
        {
            List<Exercise> AvailableExercises = GetAvailableExercises();
            ExerciseShiftDto NewExercise = UserInputs<ExerciseShift>.GetNewShift(AvailableExercises);
            ResponseDto<ExerciseShiftDto> CreateResponse=Repo.CreateEntity(NewExercise).GetAwaiter().GetResult();
            UserOutputs<ExerciseShiftDto>.ShowResponse(CreateResponse);
        }

        public static void DeleteShift()
        {
            throw new NotImplementedException();
        }

        public static void GetAllShifts()
        {          
            ResponseDto<ExerciseShiftDto> ShiftList=Repo.GetAllEntities().GetAwaiter().GetResult();
            UserOutputs<ExerciseShiftDto>.ShowResponse(ShiftList);
        }

        public static void GetSingleShift()
        {
            throw new NotImplementedException();
        }

        public static void UpdateShift()
        {
            throw new NotImplementedException();
        }
    }
}
