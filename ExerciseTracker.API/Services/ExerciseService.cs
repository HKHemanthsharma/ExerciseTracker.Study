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
        public static async Task CreateShift()
        {
            Exercise NewExercise = UserInputs.GetNewExercise();
            ResponseDto<Exercise> CreatedExercise= await Repo.CreateEntity(NewExercise);

        }

        public static void DeleteShift()
        {
            throw new NotImplementedException();
        }

        public static async Task GetAllShifts()
        {
            ResponseDto<Exercise> response=await Repo.GetAllEntities();
            UserOutputs<Exercise>.ShowResponse(response);
        }

        public static void GetSingleShift()
        {
            
        }

        public static void UpdateShift()
        {
            throw new NotImplementedException();
        }
    }
}
