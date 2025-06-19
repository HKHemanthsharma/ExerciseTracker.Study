using ExerciseTracker.UI.Models;
using ExerciseTracker.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI.Services
{
    public class ExerciseService
    {
        private static readonly Repository<Exercise> Repo= new Repository<Exercise>();
        public static void  CreateShift()
        {
            Exercise NewExercise = UserInputs<Exercise>.GetNewExercise();
            ResponseDto<Exercise> CreatedExercise= Repo.CreateEntity(NewExercise).GetAwaiter().GetResult();
            UserOutputs<Exercise>.ShowResponse(CreatedExercise);
        }

        public static void DeleteShift()
        {
            throw new NotImplementedException();
        }

        public static void  GetAllShifts()
        {
            ResponseDto<Exercise> Response =  Repo.GetAllEntities().GetAwaiter().GetResult();
            UserOutputs<Exercise>.ShowResponse(Response);
        }

        public static void GetSingleShift()
        {
            List<Exercise> Exercises= Repo.GetAllEntities().GetAwaiter().GetResult().Data;
            int UserChoice=UserInputs<Exercise>.GetEntityById(Exercises);
            ResponseDto<Exercise> Response = Repo.GetEntiryById(UserChoice).GetAwaiter().GetResult();
            UserOutputs<Exercise>.ShowResponse(Response);
        }

        public static void UpdateShift()
        {
            throw new NotImplementedException();
        }
    }
}
