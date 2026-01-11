using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_Gameplay
{
    [HarmonyPatch(typeof(Gameplay), "HunterComboHits", MethodType.Getter)]
    public static class Gameplay_HunterComboHits
    {
        [HarmonyPostfix]
        public static void Postfix(Gameplay __instance, ref int __result)
        {
            __result = ConfigSettings.focusHits.Value;
        }
    }
}
