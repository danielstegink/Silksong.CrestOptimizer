using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_Gameplay
{
    [HarmonyPatch(typeof(Gameplay), "HunterComboDamageMult", MethodType.Getter)]
    public static class Gameplay_HunterComboDamageMult
    {
        [HarmonyPostfix]
        public static void Postfix(Gameplay __instance, ref float __result)
        {
            __result = ConfigSettings.focusDamage.Value;
        }
    }
}
