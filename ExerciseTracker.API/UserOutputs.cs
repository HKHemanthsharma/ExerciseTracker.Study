using ExerciseTracker.UI.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI
{
    public static class UserOutputs<T> where T:class
    {
        public static void ShowResponse(ResponseDto<T> Response)
        {
            if(!Response.IsSuccess)
            {
                string ResponseString = $"[yellow]Response Method:{Response.ResponseMethod}\n[maroon]Reponse Message:{Response.ResponseMethod}[/][/]";
                var panel = new Panel(ResponseString);
                panel.Header = new PanelHeader("[Red]Request Failed!!![/]");
                panel.Border = BoxBorder.Rounded;
                panel.Padding = new Padding(2, 2, 2, 2);
            }
            else
            {
                string ResponseString = $"[yellow]Response Method:{Response.ResponseMethod}\n[green]Reponse Message:{Response.ResponseMethod}[/][/]";
                var panel = new Panel(ResponseString);
                panel.Header = new PanelHeader("[lime]Request Success!!![/]");
                panel.Border = BoxBorder.Rounded;
                panel.Padding = new Padding(2, 2, 2, 2);
                string Heading = Response.ResponseMethod switch
                {
                    "Get" => "Here is the Entity Details",
                    "Post" => "Details of the Entity Created",
                    "Put" => "Details of the updated Entity",
                    "Delete" => "Details of the Entity Deleted"

                };
                AnsiConsole.MarkupLine(Heading);
                Table Responsetable = new Table();
                Responsetable.Title = new TableTitle(typeof(T).Name);
                var props = typeof(T).GetProperties().ToList(); ;
                props.ForEach(x => Responsetable.AddColumn(Markup.Escape(x.Name)));
                foreach(var ResponseObject in Response.Data)
                {
                    List<string> RowData= props.Select(x => x.GetValue(ResponseObject).ToString()).ToList();
                    Responsetable.AddRow(RowData.ToArray());
                }
                Responsetable.Border = TableBorder.Double;
                AnsiConsole.Write(Responsetable);
            }
            Console.ReadLine();
        }
    }
}
