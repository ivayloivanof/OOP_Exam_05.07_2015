namespace WinterIsComing.Models.Spells
{
    class Cleave : Spell
    {
        private const int costsCleaveEnergy = 15;

        public Cleave(int damage) 
            : base(damage, costsCleaveEnergy)
        {
        }

        public override string ToString()
        {
            return "Cleave";
        }
    }
}
