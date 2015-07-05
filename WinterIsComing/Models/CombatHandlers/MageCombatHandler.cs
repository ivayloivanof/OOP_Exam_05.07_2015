namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Models.Spells;

    internal class MageCombatHandler : CombatHandler
    {
        private int attackCount;

        public MageCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            ////-picks 3 targets with most health points. 
            //// If there are several targets with equal health points, picks those with alphabetically first name. 
            this.ValidateTargets(candidateTargets);
            var nextTargets =
                candidateTargets.OrderByDescending(t => t.HealthPoints).ThenBy(t => t.Name).Take(3).ToList();

            ////if (nextTargets.Count < 3)
            ////{
            ////    throw new GameException("Target list should contain 3 targets");
            ////}
            return nextTargets;
        }

        public override ISpell GenerateAttack()
        {
            /////. Casts Fire Breath and Blizzard, alternating each time he successfully casts a spell 
            /////(i.e. first Fire Breath, next time Blizzard, then Fire Breath again, etc.).
            ///// Fire Breath damage: Equals the mage's attack points.
            ///// Blizzard damage: Equals the mage's attack points * 2
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