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
        public DamageModel physical;
        public double shield;

        /// <summary>
        /// 先攻
        /// 
        /// 由受击方首先攻击, 即便双方都是先攻
        /// </summary>
        public bool isAssault;

        /// <summary>
        /// 坚固, 优先级最高
        ///
        /// 管你什么花里胡哨的毒伤点燃吸血真伤, 统统一点伤害
        /// </summary>
        public bool isSolid;

        /// <summary>
        /// 每次出手追加的真实伤害
        ///
        /// 比如中毒, 点燃, 每次出手都会触发一次
        ///
        /// 可以是负的, 表示治疗, 同样每次出手都会触发一次
        /// </summary>
        public double attack_modifier;

        /// <summary>
        /// 每回合攻击次数
        /// </summary>
        public byte attack_times;

        /// <summary>
        /// 吸血率, 回复造成伤害 x % 的血量, 可以大于 100%
        /// </summary>
        public double blood_sucking_rate;

        /// <summary>
        /// 反伤率, 反击造成伤害 x % 的伤害, 可以大于 100%
        /// </summary>
        public double retaliation_rate;


        /// <summary>
        /// 每回合的血量变化
        /// </summary>
        /// <param name="defender">防御者</param>
        /// <param name="attacker">攻击者</param>
        /// <returns>(防御者血量变化, 攻击者血量变化)</returns>
        public static (double, double) EffectiveDelta(BattleModel defender, BattleModel attacker)
        {
            double defender_delta = 0;
            double attacker_delta = 0;

            if (defender.isSolid)
            {
                defender_delta = 1;
            }
            else
            {
                var damage = -DamageModel.EffectiveDamage(defender.physical, attacker.physical);
                var blood_sucking = damage * attacker.blood_sucking_rate;
            }

            attacker_delta *= attacker.attack_times;
            return (defender_delta, attacker_delta);
        }

        /// <summary>
        /// return null if infinite damage received
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double LossHealth(BattleModel other)
        {
            var my_action = EffectiveDelta(other, this);
            var ur_action = EffectiveDelta(this, other);
            var my_delta = my_action.Item1 + my_action.Item2;
            var ur_delta = my_action.Item1 + ur_action.Item2;
            // 回血比伤血快, 不可战胜
            if (ur_delta >= 0)
            {
                return double.PositiveInfinity;
            }

            var lossHealth = 0.0;
            var otherHealth = other.health;
            if (other.isAssault)
            {
                // ur_action first
                // get the round of finish
                lossHealth += ur_action.Item1;
                otherHealth += ur_action.Item2;
            }

            var round = Math.Floor(otherHealth / ur_delta);
            lossHealth += round * my_delta;
            return lossHealth;
        }
    }
}