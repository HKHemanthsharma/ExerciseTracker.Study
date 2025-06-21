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
        public static readonly Repository<ExerciseShift> Repo = new Repository<ExerciseShift>();
        public static void CreateShift()
        {
            ExerciseShift NewExercise=UserInputs<ExerciseShift>
            Repo.CreateEntity()
        }

        public static void DeleteShift()
        {
            throw new NotImplementedException();
        }

        public static void GetAllShifts()
        {
            
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
