using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    class Unit : IUnit
    {
        public Unit(int x, int y, string name, int attack, int health, int defence, int energy, int range, UnitType type)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.AttackPoints = attack;
            this.HealthPoints = health;
            this.DefensePoints = defence;
            this.EnergyPoints = energy;
            this.Range = range;
            this.Type = type;
            this.Spells = new List<ISpell>();
            this.CombatHandler = new CombatHandler {Unit = this};
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; private set; }
        public int Range { get; private set; }
        public int AttackPoints { get; set; }
        public int HealthPoints { get; set; }
        public int DefensePoints { get; set; }
        public int EnergyPoints { get; set; }
        public UnitType Type { get; set;  }
        public IList<ISpell> Spells { get; set; }
        public ICombatHandler CombatHandler { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format(">{0} - {1} at ({2},{3})", this.Name, this.Type, this.X, this.Y));

            if (this.HealthPoints <= 0)
            {
                sb.Append(string.Format("(Dead)"));
            }
            else
            {
                sb.AppendLine(string.Format("-Health points = {0}", this.HealthPoints));
                sb.AppendLine(string.Format("-Attack points = {0}", this.AttackPoints));
                sb.AppendLine(string.Format("-Defense points = {0}", this.DefensePoints));
                sb.AppendLine(string.Format("-Energy points = {0}", this.EnergyPoints));
                sb.Append(string.Format("-Range = {0}", this.Range));
            }

            return sb.ToString();
        }
    }
}
