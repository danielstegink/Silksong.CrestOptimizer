using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_Gameplay
{
    [HarmonyPatch(typeof(Gameplay), "HunterCombo2DamageMult", MethodType.Getter)]
    public static class Gameplay_HunterCombo2DamageMult
    {
        [HarmonyPostfix]
        public static void Postfix(Gameplay __instance, ref float __result)
        {
            __result = ConfigSettings.focusDamage2.Value;
        }
    }
}
