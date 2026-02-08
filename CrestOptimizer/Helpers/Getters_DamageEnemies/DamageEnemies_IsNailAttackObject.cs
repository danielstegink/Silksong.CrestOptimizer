using CrestOptimizer.Settings;
using HarmonyLib;
using UnityEngine;

namespace CrestOptimizer.Helpers.Getters_DamageEnemies
{
    [HarmonyPatch(typeof(DamageEnemies), "IsNailAttackObject")]
    public static class DamageEnemies_IsNailAttackObject
    {
        [HarmonyPostfix]
        public static void Postfix(DamageEnemies __instance, ref GameObject gameObject, ref bool __result)
        {
            if (HeroController.instance.IsShamanCrestEquipped() &&
                 ConfigSettings.spellNail.Value)
            {
                __result = false;
            }
        }
    }
}