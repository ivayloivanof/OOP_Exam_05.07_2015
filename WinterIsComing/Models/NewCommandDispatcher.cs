namespace WinterIsComing.Models
{
    using System;
    using Core;

    class NewCommandDispatcher : CommandDispatcher
    {
        public NewCommandDispatcher() : base()
        {
        }

        public override void DispatchCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(
                    "Command is not supported by engine");
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public override void SeedCommands()
        {
            this.commandsByName["toggle-effector"] = new ToggleEffector(this.Engine);
            base.SeedCommands();
        }
    }
}
