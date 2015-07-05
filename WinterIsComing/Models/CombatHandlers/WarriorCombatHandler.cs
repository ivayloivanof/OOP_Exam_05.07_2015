namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Models.Spells;

    internal class WarriorCombatHandler : CombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            ////- picks the first target in range with least health points and casts Cleave. 
            ////  If there are several targets with equal health points, the one with alphabetically first name is picked.
            this.ValidateTargets(candidateTargets);
            var nextTarget = candidateTargets.OrderBy(t => t.HealthPoints).ThenBy(t => t.Name).FirstOrDefault();
            if (nextTarget == null)
            {
                return new List<IUnit>();
            }

            return new List<IUnit> { nextTarget };
        }

        public override ISpell GenerateAttack()
        {
            /////Cleave damage: Equals the warrior's attack points. 
            /////If the warrior's health is equal or below 80, his health * 2 is added to the damage.
            //// If the warrior's health is greater than 50, it costs him energy - otherwise it doesn't.
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