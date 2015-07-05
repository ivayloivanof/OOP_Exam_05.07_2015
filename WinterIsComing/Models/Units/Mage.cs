namespace WinterIsComing.Models.Units
{
    using Spells;

    class Mage : Unit
    {
        private const int mageAttackPoints = 80;
        private const int mageHealthPoints = 80;
        private const int mageDefence = 40;
        private const int mageEnergy = 120;
        private const int mageRange = 2;

        public Mage(string name, int x, int y)
            : base(x, y, name, mageAttackPoints, mageHealthPoints, mageDefence, mageEnergy, mageRange, UnitType.Mage)
        {
            base.Spells.Add(new FireBreath(mageAttackPoints));
            base.Spells.Add(new Blizzard(mageAttackPoints*2));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
