using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Blastdan.Goals.Cli.Views
{
    public static class WhoAmIView
    {
        public static IRenderable Generate(Employee model)
        {
            var table = new Table();
            table.Border(TableBorder.Ascii);

            table.AddColumn("Employee Number");
            table.Columns[0].Centered();
            table.AddColumn("First Name");
            table.Columns[1].LeftAligned();
            table.AddColumn("Last Name");
            table.Columns[2].LeftAligned();

            table.AddRow($"[blue]{model.EmployeeId}[/]", model.FirstName, model.LastName);

            return table;
        }
    }
}
