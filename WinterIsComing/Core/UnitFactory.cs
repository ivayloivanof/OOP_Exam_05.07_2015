﻿namespace WinterIsComing.Core
{
    using System;
    using Contracts;
    using Models;
    using Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case UnitType.Mage:
                    return new Mage(name, x, y);
                case UnitType.IceGiant:
                    return new IceGiant(name, x, y);
                case UnitType.Warrior:
                    return new Warrior(name, x, y);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
