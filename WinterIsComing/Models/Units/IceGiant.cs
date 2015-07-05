namespace WinterIsComing.Models.Units
{
    using Spells;

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
            base.Spells.Add(new Stomp(iceGiantAttackPoints));
        }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
