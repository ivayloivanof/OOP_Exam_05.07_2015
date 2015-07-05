namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    
    using Spells;
    using Units;
    using Contracts;
    using Core;
    using Core.Exceptions;

    class CombatHandler : ICombatHandler
    {
        private int loopSpells = 0;

        public IUnit Unit { get; set; }
        public Unit UnitPrime { get; set; }
        
        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            this.UnitPrime = (Unit)Unit;
            var c = this.UnitPrime.Type;
            if (this.UnitPrime.Type == UnitType.Mage)
            {
                return candidateTargets
                .OrderByDescending(x => x.HealthPoints)
                .ThenBy(x => x.Name);
            }
            
            if (this.UnitPrime.Type == UnitType.Warrior)
            {
                return candidateTargets
                    .OrderBy(x => x.HealthPoints)
                    .ThenBy(x => x.Name);
            }
            
            return candidateTargets;
        }

        public ISpell GenerateAttack()
        {
            if (this.loopSpells == this.UnitPrime.Spells.Count)
            {
                this.loopSpells = 0;
            }
            
            for (int i = this.loopSpells; i < this.UnitPrime.Spells.Count - 1; i++)
            {
                loopSpells++;
                this.UpdateSpells(i);
                return this.UnitPrime.Spells[i];
            } 

            loopSpells++;
            this.UpdateSpells(this.UnitPrime.Spells.Count - 1);
            return this.UnitPrime.Spells[this.UnitPrime.Spells.Count - 1];
        }

        private void UpdateSpells(int numberOfSpells)
        {
            if (this.UnitPrime.EnergyPoints >= this.UnitPrime.Spells[numberOfSpells].EnergyCost)
            {
                //for cleave 
                if (this.UnitPrime.HealthPoints <= 80 && this.UnitPrime.Spells[numberOfSpells].EnergyCost == 15)
                {
                    this.UnitPrime.Spells[numberOfSpells] = new Cleave(this.UnitPrime.AttackPoints + this.UnitPrime.HealthPoints * 2);

                    //If the warrior's health is greater than 50, it costs him energy - otherwise it doesn't.
                    if (this.UnitPrime.HealthPoints < 50)
                    {
                        return;
                    }
                }

                //for Stomp
                if (this.UnitPrime.Spells[numberOfSpells].EnergyCost == 10)
                {
                    this.UnitPrime.AttackPoints += 5;
                    //If his health is less or equal to 150
                    if (this.UnitPrime.HealthPoints <= 150)
                    {
                        //TODO
                    }
                }

                this.UnitPrime.EnergyPoints -= this.UnitPrime.Spells[numberOfSpells].EnergyCost;
            }
            else
            {
                this.loopSpells--;
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.UnitPrime.Name, this.UnitPrime.Spells[numberOfSpells]));
            }
        }
    }
}
