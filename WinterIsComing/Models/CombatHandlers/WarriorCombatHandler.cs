namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Spells;

    internal class WarriorCombatHandler : CombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            this.ValidateTargets(candidateTargets);
            var nextTarget = candidateTargets
                                .OrderBy(t => t.HealthPoints)
                                .ThenBy(t => t.Name)
                                .FirstOrDefault();

            if (nextTarget == null)
            {
                return new List<IUnit>();
            }

            return new List<IUnit> { nextTarget };
        }

        public override ISpell GenerateAttack()
        {
            var damage = this.Unit.AttackPoints;

            if (this.Unit.HealthPoints <= 80)
            {
                damage += 2 * this.Unit.HealthPoints;
            }

            var spell = new Cleave(damage);
            this.ValidateEnergyPoints(this.Unit, spell);

            if (this.Unit.HealthPoints > 50)
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
            }

            return spell;
        }
    }
}