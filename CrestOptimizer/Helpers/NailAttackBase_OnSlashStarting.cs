using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;
using UnityEngine;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(NailAttackBase), "OnSlashStarting")]
    public static class NailAttackBase_OnSlashStarting
    {
        [HarmonyPostfix]
        public static void Postfix(NailAttackBase __instance)
        {
            if (Gameplay.WarriorCrest.IsEquipped && 
                __instance.name.Equals("UpSlash"))
            {
                Vector3 baseValue = __instance.transform.localScale;
                Vector3 multiplier = ConfigSettings.biggerUpSlash.Value;
                __instance.transform.localScale = new Vector3(baseValue.x * multiplier.y, baseValue.y * multiplier.x, baseValue.z);
            }
        }
    }
}