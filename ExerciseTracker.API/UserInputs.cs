using ExerciseTracker.UI.Interfaces;
using ExerciseTracker.UI.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    public class UserInputs<T> where T:class,IShift,IExercise
    {
        internal static int GetEntityById(List<T>? Entities)
        {
            List<string> UserChoices = new();
            if(typeof(T).Name=="Exercise")
            {
                UserChoices = Entities.Select(x => x.name).ToList();
            }
            else
            {
                UserChoices = Entities.Select(x => $"ShiftId={x.Id};ShiftDate={x.ExerciseDate};ShiftStartTime={x.StartTime}").ToList();
            }
            var UserOption = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Please Choose an option")
                .AddChoices(UserChoices));
           if(typeof(T).Name=="Exercise")
            {
                return Entities.Where(x => x.name == UserOption).Select(x=>x.Id).FirstOrDefault();
            }
            else
            {
                return int.Parse(UserOption.Split(";")[0].Split("=")[1]);
            }
        }

        internal static Exercise GetNewExercise()
        {
            string Name=AnsiConsole.Ask<string>("[yellow]Enter the [Blue]Name[/] of the Exercise you want to Add:[/]");
            return new Exercise
            {
                name = Name
            };
        }
    }
}
