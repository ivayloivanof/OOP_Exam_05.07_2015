namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using System.Collections.Generic;

    using Core;
    using Contracts;
    using Core.Exceptions;

    internal abstract class CombatHandler : ICombatHandler
    {
        protected CombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();

        public void ValidateTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (candidateTargets == null)
            {
                throw new ArgumentNullException("targets", "Target list can not be null");
            }
        }

        public void ValidateEnergyPoints(IUnit unit, ISpell spell)
        {
            if (unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(
                    string.Format(GlobalMessages.NotEnoughEnergy, unit.Name, spell.GetType().Name));
            }
        }
    }
}