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
            Exercise NewExercise = UserInputs.GetNewExercise();
            ResponseDto<Exercise> CreatedExercise= Repo.CreateEntity(NewExercise).GetAwaiter().GetResult();

        }

        public static void DeleteShift()
        {
            throw new NotImplementedException();
        }

        public static void  GetAllShifts()
        {
            ResponseDto<Exercise> response =  Repo.GetAllEntities().GetAwaiter().GetResult();
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
