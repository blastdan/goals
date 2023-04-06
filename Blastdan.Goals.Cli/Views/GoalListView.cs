using System.Runtime.InteropServices;
using System.Net;
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
        public static IRenderable Generate(GoalSummaries model)
        {
            var renderables = new List<IRenderable>();

            foreach (var goal in model.Goals)
            {
                renderables.Add(Generate(goal));
                renderables.Add(new Rule());
            }

            renderables.Add(Generate(model.SharedWith));

            var goals = new Rows(renderables);

            return goals;
        }

        public static IRenderable Generate(IEnumerable<Employee> employees)
        {
            var panelList = new List<Panel>();

            foreach (var employee in employees)
            {
                var image = new CanvasImage(new ReadOnlySpan<byte>(employee.Image));
                image.MaxWidth = 12;
                var panel = new Panel(image);
                panel.Header($"{employee.FirstName} {employee.LastName}");

                panelList.Add(panel);
            }
            var columns = panelList.Select(p => new Layout(p.Header?.Text, p)).ToArray();
            var root = new Layout();
            root.SplitRows(
                new Layout("Title", new Text("Goals are shared with")),
                new Layout("Images")
                    .SplitColumns(columns)
            );

            return root;
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
