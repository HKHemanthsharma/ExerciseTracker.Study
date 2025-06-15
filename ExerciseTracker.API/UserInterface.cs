using ExerciseTracker.UI.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    public class UserInterface
    {
        public static void MainMenu()
        {
            bool IsAppRunning = true;
            while (IsAppRunning)
            {
                Console.Clear();
                var userOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Please select an option")
                    .AddChoices(["Manage Shifts", "Manage Exercises", "Exit"])
                    );

                switch (userOption)
                {
                    case "Manage Shifts":
                        ShiftServiceMenu();
                        break;
                    case "Manage Workers":
                        WorkerServiceMenu();
                        break;
                    case "Exit":
                        IsAppRunning = false;
                        break;
                }
            }
        }

        private static void ShiftServiceMenu()
        {
            var userOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please select an option")
                .AddChoices(["ViewAllShifts", "View a single Shift", "Delete a shift", "Create a new Shift", "Update a Shift", "Exit"])
                );

            switch (userOption)
            {
                case "ViewAllShifts":
                    ShiftService.GetAllShifts();
                    break;
                case "View a single Shift":
                    ShiftService.GetSingleShift();
                    break;
                case "Delete a shift":
                    ShiftService.DeleteShift();
                    break;
                case "Create a new Shift":
                    ShiftService.CreateShift();
                    break;
                case "Update a Shift":
                    ShiftService.UpdateShift();
                    break;
                case "Exit":
                    break;
            }
        }
    }
}
