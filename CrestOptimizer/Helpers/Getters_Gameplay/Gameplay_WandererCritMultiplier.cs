using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_Gameplay
{
    [HarmonyPatch(typeof(Gameplay), "WandererCritMultiplier", MethodType.Getter)]
    public static class Gameplay_WandererCritMultiplier
    {
        [HarmonyPostfix]
        public static void Postfix(Gameplay __instance, ref float __result)
        {
            __result = ConfigSettings.critDamage.Value;
        }
    }
}