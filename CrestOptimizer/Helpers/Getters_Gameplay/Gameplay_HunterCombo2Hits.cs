using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_Gameplay
{
    [HarmonyPatch(typeof(Gameplay), "HunterCombo2Hits", MethodType.Getter)]
    public static class Gameplay_HunterCombo2Hits
    {
        [HarmonyPostfix]
        public static void Postfix(Gameplay __instance, ref int __result)
        {
            __result = ConfigSettings.focusHits2.Value;
        }
    }
}
