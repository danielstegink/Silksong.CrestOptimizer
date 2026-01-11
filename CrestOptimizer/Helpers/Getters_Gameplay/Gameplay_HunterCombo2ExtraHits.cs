using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_Gameplay
{
    [HarmonyPatch(typeof(Gameplay), "HunterCombo2ExtraHits", MethodType.Getter)]
    public static class Gameplay_HunterCombo2ExtraHits
    {
        [HarmonyPostfix]
        public static void Postfix(Gameplay __instance, ref int __result)
        {
            __result = ConfigSettings.focusHits2S.Value;
        }
    }
}
