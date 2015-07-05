namespace WinterIsComing.Models.Spells
{
    class Blizzard : Spell
    {
        private const int costsBlizzardEnergy = 40;

        public Blizzard(int damage) 
            : base(damage, costsBlizzardEnergy)
        {
        }

        public override string ToString()
        {
            return "Blizzard";
        }
    }
}
