namespace WinterIsComing.Models.Units
{
    using CombatHandlers;

    class IceGiant : Unit
    {
        private const int iceGiantAttackPoints = 150;
        private const int iceGiantHealthPoints = 300;
        private const int iceGiantDefence = 60;
        private const int iceGiantEnergy = 50;
        private const int iceGiantRange = 1;

        public IceGiant(string name, int x, int y) 
            : base(x, y, name, iceGiantAttackPoints, iceGiantHealthPoints, iceGiantDefence, iceGiantEnergy, iceGiantRange, UnitType.IceGiant)
        {
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
