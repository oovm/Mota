#nullable enable
using UnityEngine;

namespace Player
{
    public class CareerModel
    {
        public CareerEffect[] levels = { };
        public CareerEffect[] levelsAccumulation = { };


        public void Load()
        {
            Refresh();
        }

        public void Refresh()
        {
            levelsAccumulation = new CareerEffect[levels.Length];
            for (var i = 0; i < levels.Length; i++)
            {
                levelsAccumulation[i] = levels[i];
                if (i > 0)
                {
                    levelsAccumulation[i] += levelsAccumulation[i - 1];
                }
            }
        }

        [ContextMenu("AddLevel")]
        public static void AddLevel()
        {
            var nth1 = new CareerEffect
            {
                name = "炼气",
                health = 100,
                attack = 10,
                defense = 10,
            };

            var nth2 = new CareerEffect
            {
                name = "筑基",
                health = 100,
                attack = 40,
                defense = 40,
            };
            var model = new CareerModel {levels = new[] {nth1, nth2}};
            model.Refresh();
            Debug.Log(model.levelsAccumulation);
        }
    }


    public struct CareerEffect
    {
        public string name;
        public string description;
        public Texture2D? icon;

        public double health;
        public double attack;
        public double defense;

        public static CareerEffect operator +(CareerEffect a, CareerEffect b)
        {
            return new CareerEffect
            {
                name = b.name + b.name,
                description = b.description,
                icon = b.icon,

                health = a.health + b.health,
                attack = a.attack + b.attack,
                defense = a.defense + b.defense,
            };
        }
    }
}