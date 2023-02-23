using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blastdan.Goals.Domain.Models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Blastdan.Goals.Cli.Views
{
    public static class GoalListView
    {
        public static IRenderable Generate(IEnumerable<Goal> model)
        {
            var goals = new Rows(model.Select(m => Generate(m)));

            return goals;
        }

        public static IRenderable Generate(Goal model)
        {
            var progress = new BreakdownChart()
                                .FullSize()
                                .AddItem("Complete", model.PercentageComplete * 100, Color.Green)
                                .AddItem("Remaining", (1 - model.PercentageComplete) * 100, Color.Grey);
            var progressPanel = new Panel(progress)
                                .Expand()
                                .Header("Progress");

            var goalDescription = new Panel(model.Description);
            goalDescription.Header = new PanelHeader(model.Title);
            goalDescription.Expand();

            var calendar = new Calendar(model.DueDate.Year, model.DueDate.Month);
            calendar.AddCalendarEvent("Due Date", model.DueDate.Year, model.DueDate.Month, model.DueDate.Day);
            calendar.HighlightStyle(Style.Parse("yellow bold"));

            var calendarPanel = new Panel(calendar)
                                .Expand()
                                .Header("Due Date");

            var layout = new Layout("Root")
                        .SplitColumns(
                            new Layout("Goal", goalDescription),
                            new Layout("Description")
                                .SplitRows(
                                    new Layout("Progress", progressPanel),
                                    new Layout("Due Date", calendarPanel)));

            return layout;
        }
    }
}
