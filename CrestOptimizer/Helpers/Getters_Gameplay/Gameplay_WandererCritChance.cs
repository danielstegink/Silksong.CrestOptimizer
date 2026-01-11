using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_Gameplay
{
    [HarmonyPatch(typeof(Gameplay), "WandererCritChance", MethodType.Getter)]
    public static class Gameplay_WandererCritChance
    {
        [HarmonyPostfix]
        public static void Postfix(Gameplay __instance, ref float __result)
        {
            __result = ConfigSettings.critChance.Value / 100;
        }
    }
}