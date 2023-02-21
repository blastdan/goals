namespace Blastdan.Goals.Cli.Commands
{
    public enum GoalsExitCode
    {
        SUCCESS = 0,
        ERROR = 1,
        CANNOT_EXECUTE = 126,
        COMMAND_NOT_FOUND = 127,
        CONTROL_C = 130
    }
}
