namespace WinterIsComing.Models
{
    using Core;

    class NewCommandDispatcher : CommandDispatcher
    {

        public override void DispatchCommand(string[] commandArgs)
        {
            base.DispatchCommand(commandArgs);
        }

        public override void SeedCommands()
        {
            this.commandsByName["toggle-effector"] = new ToggleEffector(this.Engine);
            base.SeedCommands();
        }
    }
}
