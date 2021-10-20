using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wc3ConstantObjects
{
    class Wc3Class
    {
        int iD;
        string name;
        string text;
        ObjectType type;

        public Wc3Class(ObjectType objectType)
        {
            ID = (int)(objectType);
            Type = objectType;
            Name = objectType.ToString();
            switch (objectType)
            {
                case ObjectType.unit:
                    Text = "Units";
                    break;
                case ObjectType.item:
                    Text = "Items";
                    break;
                case ObjectType.destructible:
                    Text = "Destructibles";
                    break;
                case ObjectType.doodad:
                    Text = "Doodads";
                    break;
                case ObjectType.ability:
                    Text = "Abilities";
                    break;
                case ObjectType.buffEffect:
                    Text = "Buffs/Effects";
                    break;
                case ObjectType.upgrade:
                    Text = "Upgrades";
                    break;
            }
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Text { get => text; set => text = value; }
        internal ObjectType Type { get => type; set => type = value; }

        public enum ObjectType
        {
            unit = 0,
            item = 1,
            destructible = 2,
            doodad = 3,
            ability = 4,
            buffEffect = 5,
            upgrade = 6,
        }


    }
}
