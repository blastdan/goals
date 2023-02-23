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

            var goalDescription = new Panel(model.Description);
            goalDescription.Header = new PanelHeader(model.Title);

            // Create the layout
            var layout = new Layout(model.Title)
                        .SplitRows(
                            new Layout("Goal", goalDescription),
                            new Layout("Progress", progress));

            return layout;
        }
    }
}
