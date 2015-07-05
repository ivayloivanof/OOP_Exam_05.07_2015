namespace WinterIsComing.Models.Spells
{
    class FireBreath : Spell
    {
        protected const int costsFireBrathEnergy = 30;

        public FireBreath(int damage) 
            : base(damage, costsFireBrathEnergy)
        {
        }

        public override string ToString()
        {
            return "FireBreath";
        }
    }
}
