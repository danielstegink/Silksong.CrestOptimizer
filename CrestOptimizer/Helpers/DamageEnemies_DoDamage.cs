using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;
using UnityEngine;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(DamageEnemies), "DoDamage", new System.Type[] { typeof(GameObject), typeof(bool) })]
    public static class DamageEnemies_DoDamage
    {
        [HarmonyPrefix]
        public static void Prefix(DamageEnemies __instance, ref GameObject target, ref bool isFirstHit)
        {
            if (HeroController.instance.IsShamanCrestEquipped() &&
                 ConfigSettings.spellNail.Value &&
                 __instance.attackType == AttackTypes.Nail)
            {
                __instance.attackType = AttackTypes.Spell;
                __instance.representingTool = new SpellTool();
                __instance.isNailAttack = false;
                __instance.DamageMultiplier = 1.4f;
            }
        }
    }
}