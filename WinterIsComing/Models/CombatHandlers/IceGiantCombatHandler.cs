namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Spells;

    internal class IceGiantCombatHandler : CombatHandler
    {
        public IceGiantCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            this.ValidateTargets(candidateTargets);
            var nextTargets = candidateTargets
                                .ToList();

            if (this.Unit.HealthPoints <= 150)
            {
                nextTargets = new List<IUnit> { candidateTargets.FirstOrDefault() };
            }

            return nextTargets;
        }

        public override ISpell GenerateAttack()
        {
            var spell = new Stomp(this.Unit.AttackPoints);
            this.Unit.AttackPoints += 5;
            this.ValidateEnergyPoints(this.Unit, spell);
            this.Unit.EnergyPoints -= spell.EnergyCost;

            return spell;
        }
    }
}