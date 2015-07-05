namespace WinterIsComing.Models
{
    using System.Linq;

    using Core;
    using Core.Commands;
    using Core.Exceptions;
    using Contracts;

    class ToggleEffector : AbstractCommand
    {
        public ToggleEffector(IEngine engine) : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var liveUnits = this.Engine.Units
                .Where(u => u.HealthPoints > 0);

            throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy));
        }
    }
}
