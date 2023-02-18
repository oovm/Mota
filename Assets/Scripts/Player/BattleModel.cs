using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    // decimal only 10^-28 ~ 10^28
    [Serializable]
    public struct BattleModel
    {
        public double health;
        public double attack;
        public double defense;
        public double shield;

        /// <summary>
        /// 由受击方首先攻击, 即便双方都是先攻
        /// </summary>
        public double realDamage;

        /// <summary>
        /// 每次出手追加的真实伤害
        /// </summary>
        public bool isRealDamage;

        /// <summary>
        /// 护甲穿透, 无视对方 x% 的防御
        ///
        /// 真伤 = 穿透率 >= 100%
        /// </summary>
        public double armor_penetration;

        /// <summary>
        /// 护甲抵抗, 抵抗对方 x 点穿透
        ///
        /// 无视对方 x 的防御
        /// </summary>
        public double armor_resistance;

        /// <summary>
        /// 吸血率, 回复造成伤害 x % 的血量
        ///
        /// 真伤 = 穿透率 >= 100%
        /// </summary>
        public double blood_sucking_rate;


        /// <summary>
        /// 每回合的有效伤害
        /// </summary>
        /// <param name="defender">防御者</param>
        /// <param name="attacker">攻击者</param>
        /// <returns></returns>
        public static double EffectiveDamage(BattleModel defender, BattleModel attacker)
        {
            if (defender.isSolid)
            {
                return 1;
            }

            // 抵抗 20%, 穿透 60%, 护甲 200, 攻击 400
            // 伤害 = lerp(200 * lerp(100% - (60% - 20%), 0, 100), 0)
            var defense = defender.defense * Math.Clamp(
                1 - attacker.armor_penetration + defender.armor_resistance,
                0,
                1
            );
            // damage must > 0
            return defender.realDamage + Math.Clamp(attacker.attack - defense, 0, double.PositiveInfinity);
        }


        /// <summary>
        /// 减伤率 0 ~ 100%
        ///
        /// 真伤 = 穿透率 >= 100%
        /// </summary>
        [Range(0, 100)] public float damage_reduction;

        /// <summary>
        /// 是否坚固
        /// </summary>
        public bool isSolid;

        /// <summary>
        /// return null if infinite damage received
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double LossHealth(BattleModel other)
        {
            var my_attack = EffectiveDamage(this, other);
            var ur_attack = EffectiveDamage(other, this);
            // 秒杀判定
            if (ur_attack < 0)
            {
                return 0;
            }

            if (my_attack <= 0) return double.PositiveInfinity;
            // 敌人的攻击次数
            var round = other.health / my_attack;
            return round * ur_attack;
        }
    }
}