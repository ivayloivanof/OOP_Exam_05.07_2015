namespace WinterIsComing.Models
{
    using Core;
    using Core.Commands;

    class NewCommandDispatcher : CommandDispatcher
    {

        public override void DispatchCommand(string[] commandArgs)
        {
            base.DispatchCommand(commandArgs);
        }

        public override void SeedCommands()
        {
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
            base.SeedCommands();
        }
    }
}
