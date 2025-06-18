using ExerciseTracker.UI.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    public class UserInputs
    {
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
