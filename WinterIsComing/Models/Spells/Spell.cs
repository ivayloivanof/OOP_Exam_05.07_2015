namespace WinterIsComing.Models.Spells
{
    using Contracts;

    class Spell : ISpell
    {
        public Spell(int damage, int energyCost)
        {
            this.Damage = damage;
            this.EnergyCost = energyCost;
        }

        public int Damage { get; private set; }
        public int EnergyCost { get; private set; }
    }
}
