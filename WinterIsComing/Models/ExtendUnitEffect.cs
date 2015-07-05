namespace WinterIsComing.Models
{
    using System.Collections.Generic;

    using Contracts;

    class ExtendUnitEffect : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (IUnit unit in units)
            {
                unit.HealthPoints += 50;
            }
        }
    }
}
