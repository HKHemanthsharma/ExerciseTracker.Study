using ExerciseTracker.UI.Interfaces;
using ExerciseTracker.UI.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    public class UserInputs<T> where T : class
    {
        internal static int? GetExerciseById(List<Exercise> Entities)
        {
            List<string> UserChoices = new();

            UserChoices = Entities.Select(x => x.name).ToList();

            var UserOption = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Please Choose an option")
                .AddChoices(UserChoices));
            return Entities.Where(x => x.name == UserOption).Select(x => x.id).FirstOrDefault();
        }
        internal static int GetShiftById(List<ExerciseShift> Entities)
        {
            List<string> UserChoices = new();
            UserChoices = Entities.Select(x => $"ShiftId={x.Id};ShiftDate={x.ExerciseDate};ShiftStartTime={x.StartTime}").ToList();
            var UserOption = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Please Choose an option")
                .AddChoices(UserChoices));
            return int.Parse(UserOption.Split(";")[0].Split("=")[1]);
        }

        internal static Exercise GetNewExercise()
        {
            string Name = AnsiConsole.Ask<string>("[yellow]Enter the [Blue]Name[/] of the Exercise you want to Add:[/]");
            return new Exercise
            {
                name = Name
            };
        }

        internal static T GetUpdatedEntity(List<T> UpdatedList)
        {
            T UpdatedEntity = Activator.CreateInstance<T>();
            var props = typeof(T).GetProperties();
            string UpdatedValue;
            foreach (var prop in props)
            {
                if (prop.Name != "id")
                {
                    var res = AnsiConsole.Confirm($"[fuchsia]Do you want to change the[yellow] {prop.Name.ToString()}[/] Property:? The Current Value is [aqua]{prop.GetValue(UpdatedList[0])}[/][/]");
                    if (res)
                    {
                        AnsiConsole.MarkupLine("[olive] Enter the Updated Value:[/]");
                        UpdatedValue = Console.ReadLine();

                    }
                    else
                    {
                        UpdatedValue = prop.GetValue(UpdatedList[0]).ToString();
                    }
                    prop.SetValue(UpdatedEntity, UpdatedValue);
                }
            }
            return UpdatedEntity;
        }
    }
}
