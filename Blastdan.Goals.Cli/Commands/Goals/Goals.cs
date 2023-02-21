using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console.Cli;

namespace Blastdan.Goals.Cli.Commands.Goals
{
    public class Goals : AsyncCommand
    {
        public Goals()
        {

        }

        public override Task<int> ExecuteAsync(CommandContext context) => throw new NotImplementedException();
    }
}
