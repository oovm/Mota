using System;

namespace Player
{
    /// <summary>
    /// 单次攻击造成的伤害
    /// </summary>
    public struct DamageModel
    {
        /// <summary>
        /// 造成的伤害
        /// </summary>
        public double attack;

        /// <summary>
        /// 抵御对方 x 点攻击
        /// </summary>
        public double defense;

        /// <summary>
        /// 无视对方 x% 的护甲, 最多无视 100%
        /// </summary>
        public double penetration;

        /// <summary>
        /// 无视对方 x 点穿透 
        /// </summary>
        public double resistance;

        /// <summary>
        /// 取消对方抵抗
        /// </summary>
        public bool true_damage;

        /// <summary>
        /// 单词攻击造成的有效伤害, 必须是正的
        /// </summary>
        /// <param name="defender">防御者</param>
        /// <param name="attacker">攻击者</param>
        /// <returns></returns>
        public static double EffectiveDamage(DamageModel defender, DamageModel attacker)
        {
            return Math.Max(attacker.attack - EffectiveDefense(defender, attacker), 0);
        }

        public static double EffectiveDefense(DamageModel defender, DamageModel attacker)
        {
            var resistance = attacker.true_damage ? 0 : defender.resistance;
            return defender.defense * Math.Clamp(1 - attacker.penetration + resistance, 0, 1);
        }
    }
}