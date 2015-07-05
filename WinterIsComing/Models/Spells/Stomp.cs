namespace WinterIsComing.Models.Spells
{
    class Stomp : Spell
    {
        protected const int costsStompEnergy = 10;

        public Stomp(int damage) 
            : base(damage, costsStompEnergy)
        {
        }

        public override string ToString()
        {
            return "Stomp";
        }
    }
}
