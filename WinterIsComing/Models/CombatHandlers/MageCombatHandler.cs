namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Spells;

    internal class MageCombatHandler : CombatHandler
    {
        private int attackCount;

        public MageCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            this.ValidateTargets(candidateTargets);
            var nextTargets = candidateTargets
                                .OrderByDescending(t => t.HealthPoints)
                                .ThenBy(t => t.Name)
                                .Take(3)
                                .ToList();

            return nextTargets;
        }

        public override ISpell GenerateAttack()
        {
            ISpell spell;
            if (this.attackCount % 2 == 0)
            {
                spell = new FireBreath(this.Unit.AttackPoints);
            }
            else
            {
                spell = new Blizzard(this.Unit.AttackPoints * 2);
            }

            this.ValidateEnergyPoints(this.Unit, spell);
            this.attackCount++;
            this.Unit.EnergyPoints -= spell.EnergyCost;
            return spell;
        }
    }
}