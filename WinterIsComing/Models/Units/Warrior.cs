namespace WinterIsComing.Models.Units
{
    using CombatHandlers;
    class Warrior : Unit
    {
        private const int warriorAttackPoints = 120;
        private const int warriorHealthPoints = 180;
        private const int warriorDefence = 70;
        private const int warriorEnergy = 60;
        private const int warriorRange = 1;

        public Warrior(string name, int x, int y) 
            : base(x, y, name, warriorAttackPoints, warriorHealthPoints, warriorDefence, warriorEnergy, warriorRange, UnitType.Warrior)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
